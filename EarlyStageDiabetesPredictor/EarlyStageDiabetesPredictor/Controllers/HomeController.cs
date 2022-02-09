using EarlyStageDiabetesPredictor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EarlyStageDiabetesPredictor.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        
        public ActionResult Test()
        {
           
            ViewBag.Title = "Test for diabetes";
            ModelState.Clear();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Test(Person person)
        {
            if(ModelState.IsValid)
            {
                Person result = AzureModel.CheckForDiabetes(person);
                DiabetesResults.getDiabetesResultsInstance().Results.Add(result);
                return RedirectToAction("Results");
            }
            
            ViewBag.Title = "Test for diabetes";
            return View();
        }
        
        public ActionResult Delete(int i) 
        {
            DiabetesResults.getDiabetesResultsInstance().Results.RemoveAt(i);
            return RedirectToAction("Results");
        }

        public ActionResult Result()
        {
            return PartialView("Result",DiabetesResults.getDiabetesResultsInstance().Results.Last());
        }
        public ActionResult Results()
        {
            
            ViewBag.Title = "Diabetes results";
            return View(DiabetesResults.getDiabetesResultsInstance().Results);
        }
    }
}
