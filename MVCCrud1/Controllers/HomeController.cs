using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrud1.Controllers
{
    public class HomeController : Controller
    {
        MVCCRUDDBContext _context = new MVCCRUDDBContext();
        public ActionResult Index()
        {
            var listofData = _context.StudentInformations.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentInformation model)
        {
            _context.StudentInformations.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Succesfully";
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            var data = _context.StudentInformations.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(StudentInformation Model)
        {
            var data = _context.StudentInformations.Where(x => x.StudentId == Model.StudentId).FirstOrDefault();
            if (data != null)
            {
                data.StudentCity = Model.StudentCity;
                data.StudentName = Model.StudentName;
                data.StudentFees = Model.StudentFees;
                _context.SaveChanges();

            }
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.StudentInformations.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var data = _context.StudentInformations.Where(x => x.StudentId == id).FirstOrDefault();
            _context.StudentInformations.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record delete Successfully";
            return RedirectToAction("index");
        }


    }
}