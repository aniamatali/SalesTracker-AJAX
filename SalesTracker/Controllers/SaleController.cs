using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SalesTracker.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SalesTracker.Controllers
{
    [Authorize]
	public class SaleController : Controller
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;

		public SaleController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
		{
			_userManager = userManager;
			_db = db;
		}


		public IActionResult Index()
		{
			return View(_db.Sales.Include(x => x.SalesAssociate).ToList());
		}


		
		public IActionResult Create()
		{
            ViewBag.SaleId = new SelectList(_db.SalesAssociates, "SalesAssociateId", "Name");
			return View();
		}

        [HttpPost]
		public IActionResult Create(Sale item)
		{
			_db.SaveChanges();   // Updated
									 // Removed db.SaveChanges() call
			return RedirectToAction("Index");
		}

		public IActionResult Details(int id)
		{
			var thisSalesAssociate = _db.SalesAssociates
								 .Include(x => x.Sales)
								 .FirstOrDefault(items => items.SalesAssociateId == id);
			return View(thisSalesAssociate);
		}

	}
}
