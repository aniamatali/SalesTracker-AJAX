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

    public class SalesAssociateController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public SalesAssociateController (UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.SalesAssociates.Where(x => x.User.Id == currentUser.Id));
        }

		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
        public async Task<IActionResult> Create(SalesAssociate salesassociate)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            salesassociate.User = currentUser;
            _db.SalesAssociates.Add(salesassociate);
            _db.SaveChanges();
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
