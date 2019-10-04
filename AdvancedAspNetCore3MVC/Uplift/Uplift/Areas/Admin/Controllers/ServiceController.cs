using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;
using Uplift.Models.ViewModels;

namespace Uplift.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public ServiceVM ServVM { get; set; }

        public ServiceController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            this._unitOfWork = unitOfWork;
            this._hostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id) 
        {
            ServVM = new ServiceVM() 
            {
                Service = new Service(),
                CategoryList = _unitOfWork.Category.GetCategoryListForDropDown(),
                FrequencyList = _unitOfWork.Frequency.GetFrequencyListForDropDown()
            };

            if (id != null)
            {
                ServVM.Service = _unitOfWork.Service.Get(id.GetValueOrDefault());
            }

            return View(ServVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert() 
        {
            if (!ModelState.IsValid)
            {
                ServVM.CategoryList = _unitOfWork.Category.GetCategoryListForDropDown();
                ServVM.FrequencyList = _unitOfWork.Frequency.GetFrequencyListForDropDown();
                return View(ServVM);
            }

            string webRootpath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (ServVM.Service.Id == 0)
            {
                //New Service
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootpath, @"images\services");
                var extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(uploads,fileName + extension),FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                ServVM.Service.ImageUrl = @"\images\services\" + fileName + extension;
                _unitOfWork.Service.Add(ServVM.Service);
            }
            else
            {
                //edit service
                var serviceFromDb = _unitOfWork.Service.Get(ServVM.Service.Id);
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootpath, @"images\services");
                    var extension_new = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootpath, serviceFromDb.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension_new), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    ServVM.Service.ImageUrl = @"\images\services\" + fileName + extension_new;
                }
                else
                {
                    ServVM.Service.ImageUrl = serviceFromDb.ImageUrl;
                }

                _unitOfWork.Service.Update(ServVM.Service);
            }

            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));

        }

        #region API CALLS

        public IActionResult GetAll() 
        {
            return Json(new { data = _unitOfWork.Service.GetAll(includeProperties: "Category,Frequency") });
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            var serviceFromDb = _unitOfWork.Service.Get(id);
            string webRootpath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootpath, serviceFromDb.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            if (serviceFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting. " });
            }

            _unitOfWork.Service.Remove(serviceFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted Successfully. " });
        }

        #endregion

    }
}