using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using VivaFund.DomainModels;
using VivaFund.WEB.Models;

namespace VivaFund.WEB.Controllers
{
    public class ProjectCategoriesController : Controller
    {

        // GET: ProjectCategories
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();

            var response = client.GetAsync("http://localhost:51041/api/category/all").Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.Content != null)
            {
                var contact = JsonConvert.DeserializeObject<List<ProjectCategory>>(rep);
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

        // GET: ProjectCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var client = new HttpClient();

            var response = client.GetAsync("http://localhost:51041/api/category/all").Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.Content != null)
            {
                var contact = JsonConvert.DeserializeObject<ProjectCategory>(rep);
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

        // GET: ProjectCategories/Create
        public ActionResult Create()
        {
            ProjectCategory item = new ProjectCategory();
            return View(item);
        }

        // POST: ProjectCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProjectCategoryId,Token,CategoryName,InsertedDate,UpdatedDate,IsActive")] ProjectCategory projectCategory)
        {
            var client = new HttpClient();

            var response = client.PostAsync("http://localhost:51041/api/category/save", new StringContent(new JavaScriptSerializer().Serialize(projectCategory), Encoding.UTF8, "application/json")).Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProjectCategories");
            }
            else
            {
                return RedirectToAction("Index", "ProjectCategories");
            }
            //if (ModelState.IsValid)
            //{
            //    db.ProjectCategories.Add(projectCategory);
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}

            //return View(projectCategory);
        }

        // GET: ProjectCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var client = new HttpClient();

            var response = client.GetAsync("http://localhost:51041/api/category/" + id).Result;
            var contact = JsonConvert.DeserializeObject<ProjectCategory>(response.ToString());
            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        // POST: ProjectCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProjectCategoryId,Token,CategoryName,InsertedDate,UpdatedDate,IsActive")] ProjectCategory projectCategory)
        {
            var client = new HttpClient();

            var response = client.PostAsync("http://localhost:51041/api/category/save", new StringContent(new JavaScriptSerializer().Serialize(projectCategory), Encoding.UTF8, "application/json")).Result;
            var contact = JsonConvert.DeserializeObject<ProjectCategory>(response.ToString());
            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            else
            {
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    db.Entry(projectCategory).State = EntityState.Modified;
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //return View(projectCategory);
        }

        // GET: ProjectCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ProjectCategory projectCategory = await db.ProjectCategories.FindAsync(id);
            //if (projectCategory == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(projectCategory);
            return View();
        }

        // POST: ProjectCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //ProjectCategory projectCategory = await db.ProjectCategories.FindAsync(id);
            //db.ProjectCategories.Remove(projectCategory);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
