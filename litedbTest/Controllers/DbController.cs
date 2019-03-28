using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using litedbTest.Models;
using LiteDB;

namespace litedbTest.Controllers
{
    public class DbController : Controller
    {
        // GET: Db
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string saveCustomer(customersViewModel customer)
        {
            using (var db = new LiteDatabase(Server.MapPath("~/App_data/MyData.db")))
            {
                // Get a collection (or create, if doesn't exist)
                var collection = db.GetCollection<customersViewModel>("customers");
                var results = collection.Find(x => x.firstName.StartsWith(customer.firstName));
                collection.Insert(customer);

                results = collection.Find(x => x.firstName.StartsWith(customer.firstName));
                return "User Saved";

            
            }
        }

        //public void updateCustomer(customers customerData)
        //{
        //    using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
        //    {
        //        // Get a collection (or create, if doesn't exist)
        //        var collection = db.GetCollection<customers>("customers");

        //        var results = collection.Find(x => x.firstName.StartsWith(customerData.firstName));
                


        //    }

        //        // Update a document inside a collection
        //        customer.Name = "Joana Doe";

        //        col.Update(customer);

        //        // Index document using document Name property
        //        col.EnsureIndex(x => x.Name);

        //        // Use LINQ to query documents
        //        var results = col.Find(x => x.Name.StartsWith("Jo"));

        //        // Let's create an index in phone numbers (using expression). It's a multikey index
                

        //        // and now we can query phones
        //        var r = col.FindOne(x => x.Phones.Contains("8888-5555"));
        //    }

        //}
    }
}