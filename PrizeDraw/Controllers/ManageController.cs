using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrizeDraw.DataLayer;
using PrizeDraw.DataLayer.Model;
using PrizeDraw.DataLayer.Providers;
using PrizeDraw.DataLayer.DataAccess;
using PrizeDraw.Models;

namespace PrizeDraw.Views.Manage
{
    public class ManageController : Controller
    { 
        [Authorize(Roles="Admin")]
        //GET: Manage
        public IActionResult Index()
        {
            return View();
        }
    }
}