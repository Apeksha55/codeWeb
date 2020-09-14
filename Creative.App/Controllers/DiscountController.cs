using Newtonsoft.Json;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

using Creative.Web.Service;
using DiscountVM = Creative.Web.ViewModel.DiscountVM;

namespace Creative.Web.Controllers
{
    public class DiscountController : Controller
    {
        // GET: Discount
        public List<DiscountVM> getAllProducts()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Products/getAllProducts");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<DiscountVM>>(response.Content.ReadAsStringAsync().Result);

        }

        public ActionResult GetProduct(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Products/getProduct?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            DiscountVM data = JsonConvert.DeserializeObject<DiscountVM>(response.Content.ReadAsStringAsync().Result);

            ViewBag.Title = "All Discounts";
            return View(data);
        }
        public List<DiscountVM> getAll()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Discounts/getAllDiscounts");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<DiscountVM>>(response.Content.ReadAsStringAsync().Result);

        }
        // GET: Discount  
        public ActionResult GetAllDiscounts()
        {
            try
            {

                List<DiscountVM> data = getAll();
                ViewBag.Title = "All Discounts";

                return View(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditDiscount(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Discounts/getDiscount?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            DiscountVM data = JsonConvert.DeserializeObject<DiscountVM>(response.Content.ReadAsStringAsync().Result);

            ViewBag.Title = "All Discounts";
            return View(data);
        }
        [HttpPost]
        public ActionResult EditDiscount(DiscountVM Discount)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpContent c = new StringContent(JsonConvert.SerializeObject(Discount), Encoding.UTF8, "application/json");

            HttpResponseMessage response = serviceObj.PutResponse("api/Discounts/updateDiscount", c);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllDiscounts");
        }
        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Discounts/getDiscount?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            DiscountVM data = JsonConvert.DeserializeObject<DiscountVM>(response.Content.ReadAsStringAsync().Result);
            ViewBag.Title = "All Discounts";
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DiscountVM Discount)
        {
            ServiceRepository serviceObj = new ServiceRepository();

            HttpContent c = new StringContent(JsonConvert.SerializeObject(Discount), Encoding.UTF8, "application/json");
            HttpResponseMessage response = serviceObj.PostResponse("api/Discounts/addDiscount", c);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllDiscounts");
        }
        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Discounts/deleteDiscount?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllDiscounts");
        }
    }
}
