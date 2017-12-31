using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidifi.Models;
using System.Data.Entity;

namespace Vidifi.Controllers
{
    public class CustomersController : Controller
    {
        //a dbcontext is required to acccess the database
        private ApplicationDbContext _context;
        //the dbcontext needs to be initialied in the constructor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //since dbcontext is a disposable object, you need to dispose of it using the method below
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ViewResult Index()
        {
            //the Customers property is a dbSet definied in the dbcontext, allows us to get all records in the DB.
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //entity does not query the database at this point, the query is performed when you iterate over the object within the view.
            //This is called deffered execution 
            //if needed, you can query the object immediately but calling the .ToList() method on the object.
            //by default Entity framework only loads the Object and not the related objects, to solve this problem you have to load the Customer
            //and it's related objects together with the Include() method. 
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return View();

            return View(customer);
        }
      
    }
}