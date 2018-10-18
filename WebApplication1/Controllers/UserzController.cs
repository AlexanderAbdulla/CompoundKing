using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserzController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserzController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //public async Task<IActionResult> Index()
        public IActionResult Index()
        {
            

            Dictionary<string, List<string>> userPairs = new Dictionary<string, List<string>>();
           
            foreach(var item in _context.ApplicationUser.ToList())
            {
                if (item.UserName == "A")
                {
                    ViewBag.masterKey = item.Id;
                } 
                List<string> list = new List<string>();
                list.Add(item.UserName);
                list.Add(item.Email);
                userPairs.Add(item.Id, list);
            }

           
            return View(userPairs);
            
        }

        // GET: ApplicationRoles/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(string key)
        {
            var uid = _context.Users.Find(key).Id;
            var username = _context.Users.Find(key).UserName;
           // List<string> rolesToAdd = new List<string>();
            List<string> rolesToDelete = new List<string>();


            
            foreach (var role in _context.Roles)
            {
                if (_context.UserRoles.Find(uid, role.Id) == null)
                {
                    Debug.WriteLine("we can add " + role.Name);

                    

                }
                else
                {
                    Debug.WriteLine("we can not add " + role.Name);
                    rolesToDelete.Add(role.Name);

                }
            }

            //await _userManager.AddToRoleAsync(_context.Users.Find(uid), "HAR");

            ViewBag.uid = uid;
            ViewBag.username = username;
            //ViewBag.rolesToAdd = rolesToAdd;
            ViewBag.rolesToDelete = rolesToDelete;
            //Viewbag array 


            return View();
        }

        // POST: ApplicationRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Delete(string UserID, string Role)
        {


           // Debug.WriteLine("username is + " + UserID);
            //Debug.WriteLine("role is + " + Role);

            if (_context.Users.Find(UserID) != null)
            {
              //  Debug.WriteLine("Adding" + Role + " to " + _context.Users.Find(UserID).UserName);
            }

            await _userManager.RemoveFromRoleAsync(_context.Users.Find(UserID), Role);

            //await _userManager.RemoveFromRoleAsync(_context.Users.Find(UserID), Role);
            //return View(applicationRole);

            await _context.SaveChangesAsync();
            return View("~/Views/Userz/Deleted.cshtml");
        }




        // GET: ApplicationRoles/Create
        [HttpGet]
        public async Task<IActionResult> Create(string key)
        {
            var uid = _context.Users.Find(key).Id;
            var username = _context.Users.Find(key).UserName;
            List<string> rolesToAdd = new List<string>();
            List<string> rolesAlreadyAdded = new List<string>();


            //public async Task<IActionResult> DeleteConfirmed(string id)

            foreach (var role in _context.Roles)
            {
                if(_context.UserRoles.Find(uid, role.Id) == null)
                {
                    rolesToAdd.Add(role.Name);
                    Debug.WriteLine("we can add " + role.Name);

                       // await _userManager.AddToRoleAsync(_context.Users.Find(uid), role.Name);
                    
                       // Debug.WriteLine("We couldnt add " + role.Name);
                    
                   
                } else
                {
                    Debug.WriteLine("we can not add " + role.Name);
                    rolesAlreadyAdded.Add(role.Name);

                }
            }

            //await _userManager.AddToRoleAsync(_context.Users.Find(uid), "HAR");
            
            ViewBag.uid = uid;
            ViewBag.username = username;
            ViewBag.rolesToAdd = rolesToAdd;
            ViewBag.rolesAlreadyAdded = rolesAlreadyAdded;
            //Viewbag array 
           

            return View();
        }

        // POST: ApplicationRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(string UserID, string Role)
        {

            
            Debug.WriteLine("username is + " + UserID);
            Debug.WriteLine("role is + " + Role);

            if (_context.Users.Find(UserID) !=null)
            {
                Debug.WriteLine("Adding" + Role + " to " + _context.Users.Find(UserID).UserName);
            }

            await _userManager.AddToRoleAsync(_context.Users.Find(UserID), Role);

            //await _userManager.RemoveFromRoleAsync(_context.Users.Find(UserID), Role);
            //return View(applicationRole);

            await _context.SaveChangesAsync();
            return View("~/Views/Userz/Created.cshtml");
        }

    }


}