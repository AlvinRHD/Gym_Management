﻿using Microsoft.AspNetCore.Mvc;

namespace Gym_Management.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}