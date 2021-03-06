﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouseUdemy.Data;
using GraniteHouseUdemy.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraniteHouseUdemy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            return View(_db.ProductTypes.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        //with every post request, an antiforgery token is added and passed along with the request, 
        //once it reaches the server it checks to see if the token is valid or not, if it is valid then it knows that the request has not been altered in any way (e.g. hacking)
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Add(productTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = await _db.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //with every post request, an antiforgery token is added and passed along with the request, 
        //once it reaches the server it checks to see if the token is valid or not, if it is valid then it knows that the request has not been altered in any way (e.g. hacking)
        public async Task<IActionResult> Edit(int id, ProductTypes productTypes)
        {
            if (id!= productTypes.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(productTypes); //Entity framework here handles all the mapping, normally we should fetch the database ebtry and update it
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = await _db.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = await _db.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //with every post request, an antiforgery token is added and passed along with the request, 
        //once it reaches the server it checks to see if the token is valid or not, if it is valid then it knows that the request has not been altered in any way (e.g. hacking)
        public async Task<IActionResult> Delete(int id)
        {
            var productType = await _db.ProductTypes.FindAsync(id);
            _db.ProductTypes.Remove(productType);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}