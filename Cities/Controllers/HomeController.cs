﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cities.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Cities);

        public ViewResult Edit()
        {
            ViewBag.Countries = new SelectList(repository.Cities
                .Select(c => c.Country).Distinct());
            return View("Create", repository.Cities.First());
        }

        public ViewResult Create()
        {
            ViewBag.Countries = new SelectList(repository.Cities
                .Select(c => c.Country).Distinct());
            return View();
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            repository.AddCity(city);
            return RedirectToAction("Index");
        }
    }
}
