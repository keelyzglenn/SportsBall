﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsBall.Models;

namespace SportsBall.Controllers
{
    public class DivisionsController : Controller
    {
        private SportsBallContext db = new SportsBallContext();
        public IActionResult Index()
        {
            return View(db.Divisions.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisDivision = db.Divisions.Include(divisions => divisions.Teams).FirstOrDefault(divisions =>
            divisions.DivisionId == id);
            return View(thisDivision);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Division division)
        {
            db.Divisions.Add(division);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisDivision = db.Divisions.FirstOrDefault(divisions => divisions.DivisionId == id);
            return View(thisDivision);
        }

        [HttpPost]
        public IActionResult Edit(Division division)
        {
            db.Entry(division).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisDivision = db.Divisions.FirstOrDefault(divisions => divisions.DivisionId == id);
            return View(thisDivision);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisDivision = db.Divisions.FirstOrDefault(divisions => divisions.DivisionId == id);
            db.Divisions.Remove(thisDivision);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}