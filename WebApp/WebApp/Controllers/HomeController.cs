﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            string nombre = "Andrés";
            ViewBag.Nom = nombre;
            return RedirectToAction("Index");
        }

    }
}