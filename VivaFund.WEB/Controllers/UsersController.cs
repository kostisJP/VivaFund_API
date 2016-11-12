using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using VivaFund.DomainModels;
using VivaFund.WEB.Models;

namespace VivaFund.WEB.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();

            var response = client.GetAsync("http://localhost:51041/api/user/all").Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.Content != null)
            {
                var contact = JsonConvert.DeserializeObject<List<User>>(rep);
                if (response.IsSuccessStatusCode)
                {
                    return View(contact.ToList());
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var client = new HttpClient();

            var response = client.GetAsync("http://localhost:51041/api/user/all").Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.Content != null)
            {
                var contact = JsonConvert.DeserializeObject<User>(rep);
                if (response.IsSuccessStatusCode)
                {
                    return View(contact);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // GET: Users/Create
        public ActionResult Create()
        {

            User user = new User();

            return View(user);
        }


        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,Token,FirstName,LastName,Email,Password,InsertedDate,UpdatedDate,IsActive")] User user)
        {
            var client = new HttpClient();

            var response = client.PostAsync("http://localhost:51041/api/user/save", new StringContent(new JavaScriptSerializer().Serialize(user), Encoding.UTF8, "application/json")).Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Users");
            }
            else
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            var client = new HttpClient();

            var response = client.GetAsync("http://localhost:51041/api/user/" + id).Result;
            User contact = JsonConvert.DeserializeObject<User>(response.ToString());
            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,Token,FirstName,LastName,Email,Password,InsertedDate,UpdatedDate,IsActive")] User user)
        {
            var client = new HttpClient();

            var response = client.PostAsync("http://localhost:51041/api/user/save", new StringContent(new JavaScriptSerializer().Serialize(user), Encoding.UTF8, "application/json")).Result;
            User contact = JsonConvert.DeserializeObject<User>(response.ToString());
            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //User user = await db.Users.FindAsync(id);
            //if (user == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //User user = await db.Users.FindAsync(id);
            //db.Users.Remove(user);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
