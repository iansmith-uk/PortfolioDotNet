using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioSite.Data;
using PortfolioSite.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace PortfolioSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: AdminController
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = _db._httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            InfoModel infoModel = new InfoModel();
            infoModel.Location = "Test Location";
            infoModel.Name = "Test Name";
            infoModel.Email = "user@email.com";
            infoModel.uID = userId;

            InfoModel dbModel = await _db.InfoModels.FirstOrDefaultAsync(m => m.uID == userId);

            if(dbModel != null)
            {
                infoModel = dbModel;
            }

            return View(infoModel);
        }

        // POST: AdminController/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Index(InfoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = _db._httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    InfoModel dbModel = await _db.InfoModels.FindAsync(model.Id);


                
                    
                

                    if (dbModel == null)
                    {
                        //create new
                        _db.InfoModels.Add(model);
                    }
                    else
                    {
                        var FromDb = await _db.InfoModels.FindAsync(model.Id);
                        FromDb.Name = model.Name;
                        FromDb.Email = model.Email;
                        FromDb.uID = userId;
                        FromDb.Location = model.Location;
                    }

                    await _db.SaveChangesAsync();
                    
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
