using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private Models.CarShopDBEntities db = new Models.CarShopDBEntities();

        public ActionResult Index()
        {
            var items = db.Cars;            
            return View(items);
        }

        public ActionResult CarPage(int item_id)
        {
            var items = db.Cars.FirstOrDefault(x => x.id == item_id);
            if (items == null)
            {
                return Content("<h1>Can't find page</h1>");
            }
            return View(items);
        }
        [ChildActionOnly]
        public ActionResult Nav()
        {
            var Items = db.Cars;
            string result = "";
            foreach (var item in Items)
            {
                result += "<li><a href= '/Home/CarPage/?item_id= "+ item.id +"' title = '" + item.NameOfCar + "'>" + item.NameOfCar + "<a/></li>";
            }
            return Content(result);
        }
        [HttpGet]
        public ActionResult Form(int item_id = 0)
        {
            ViewBag.Item = item_id;
            return PartialView();
        }
        [ChildActionOnly]
        public string FormOptions(int item_id)
        {
            var Items = db.Cars;
            string str = "";
            foreach (var item in Items)
            {

                if (item_id == item.id)
                {
                    str += "< option value = " + item.id + " selected>"+ item.NameOfCar+"</ option >";
                }
                else
                {
                    str += "< option value = " + item.id + ">" + item.NameOfCar + "</ option >";
                }
            }
            return str;
        }
        [HttpPost]
        public string Form(string name, string tel, int car)
        {
            Order order = new Order
            {
                UserName = name,
                UserPhone = tel,
                CarID = car,
                Status = "Created"
            };
            db.Orders.Add(order);
            db.SaveChanges();
            return "Your application for ordering" + db.Cars.FirstOrDefault(x => x.id == car).NameOfCar + " was shedule";
        }

    }
}