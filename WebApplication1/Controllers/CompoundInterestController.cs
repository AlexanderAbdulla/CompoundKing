using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CompoundInterestController : Controller
    {

        // GET: CompoundInterest
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(double interestRate, double principal, double timesPerYear, double years)
        {
            CoumpoundInterest ci = new CoumpoundInterest(interestRate, principal, timesPerYear, years);
            double compoundInterest = ci.CalculateCompoundnInterest();
            ViewBag.compoundInterest = compoundInterest;
            return View();
        }

        [HttpPost]
        public ActionResult Results(double interestRate, double principal, double timesPerYear, double years)
        {
            CoumpoundInterest ci = new CoumpoundInterest(interestRate, principal, timesPerYear, years);
            double compoundInterest = ci.CalculateCompoundnInterest();
            ViewBag.compoundInterest = compoundInterest;
            
            return View();
        }


    }
}