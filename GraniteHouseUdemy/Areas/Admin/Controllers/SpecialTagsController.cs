using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouseUdemy.Data;
using GraniteHouseUdemy.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraniteHouseUdemy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SpecialTagsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            return View(_db.SpecialTags.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //with every post request, an antiforgery token is added and passed along with the request, 
        //once it reaches the server it checks to see if the token is valid or not, if it is valid then it knows that the request has not been altered in any way (e.g. hacking)
        public async Task<IActionResult> Create(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                _db.Add(specialTags);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTag = await _db.SpecialTags.FindAsync(id);
            if (specialTag == null)
            {
                return NotFound();
            }

            return View(specialTag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //with every post request, an antiforgery token is added and passed along with the request, 
        //once it reaches the server it checks to see if the token is valid or not, if it is valid then it knows that the request has not been altered in any way (e.g. hacking)
        public async Task<IActionResult> Edit(int id, SpecialTags specialTags)
        {
            if (id != specialTags.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(specialTags); //Entity framework here handles all the mapping, normally we should fetch the database ebtry and update it
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTag = await _db.SpecialTags.FindAsync(id);
            if (specialTag == null)
            {
                return NotFound();
            }

            return View(specialTag);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var specialTag = await _db.SpecialTags.FindAsync(id);
            if (specialTag == null)
            {
                return NotFound();
            }

            return View(specialTag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //with every post request, an antiforgery token is added and passed along with the request, 
        //once it reaches the server it checks to see if the token is valid or not, if it is valid then it knows that the request has not been altered in any way (e.g. hacking)
        public async Task<IActionResult> Delete(int id)
        {
            var specialTag = await _db.SpecialTags.FindAsync(id);
            _db.SpecialTags.Remove(specialTag);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}