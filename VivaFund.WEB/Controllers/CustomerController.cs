using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using VivaFund.DomainModels;

namespace VivaFund.WEB.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController()
        {
            //_db = new VivaDbContext(ConfigurationManager.ConnectionStrings["VivaDbContext"].ConnectionString);
        }
        // GET: Customer
        public ActionResult Index()
        {
            var client = new HttpClient();
            var user = new User() { FirstName = "abc", LastName = "efg", UserId = 100 };

            var response = client.PostAsync("api/users", new StringContent(new JavaScriptSerializer().Serialize(user), Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                return View(response.Content);
            }
            return View(response);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var client = new HttpClient();
            var user = new User() { FirstName = "abc", LastName = "efg", UserId = 100};

            var response = client.PostAsync("api/users/" + id, new StringContent(new JavaScriptSerializer().Serialize(user), Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                return View(response.Content);
            }
            else
            {
                return View();
            }

        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
