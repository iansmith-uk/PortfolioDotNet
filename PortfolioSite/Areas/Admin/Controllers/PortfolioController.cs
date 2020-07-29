using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PortfolioSite.Data;
using PortfolioSite.Models;

namespace PortfolioSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext _db;


        public PortfolioController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: PortfolioController
        public async Task<ActionResult> IndexAsync()
        {
            var userId = _db._httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var all = await _db.PortfolioModels.Where(m => m.uID == userId).ToListAsync();
            

            return View(all);
        }

        // GET: PortfolioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PortfolioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortfolioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PortfolioModel model)
        {
            model.uID = _db._httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                
                var file = Request.Form.Files.First();

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                model.image = ms.ToArray();

                ms.Close();
                ms.Dispose();

                _db.PortfolioModels.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
            
        }

        // GET: PortfolioController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var current = await _db.PortfolioModels.FindAsync(id);
            return View(current);
        }

        // POST: PortfolioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, PortfolioModel model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count() > 0)
                {
                    var file = Request.Form.Files.First();

                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    model.image = ms.ToArray();

                    ms.Close();
                    ms.Dispose();
                }
                else
                {
                    var current = await _db.PortfolioModels.FindAsync(id);
                    model.image = current.image;
                }
                _db.Update(model);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View();


        }

        // GET: PortfolioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PortfolioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
