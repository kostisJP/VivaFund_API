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
    public class ProjectsController : Controller
    {

        // GET: Projects
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();

            var response = client.GetAsync("http://localhost:51041/api/project/all").Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.Content != null)
            {
                var contact = JsonConvert.DeserializeObject<List<Project>>(rep);
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

        // GET: Projects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var client = new HttpClient();

            var response = client.GetAsync("http://localhost:51041/api/project/" + id).Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.Content != null)
            {
                var contact = JsonConvert.DeserializeObject<Project>(rep);
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

        // GET: Projects/Create
        [Authorize]
        public async Task<ActionResult> Create()
        {
            var client = new HttpClient();
            Project item = new Project();
            var response = client.GetAsync("http://localhost:51041/api/member/all").Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.Content != null)
            {
                var members = JsonConvert.DeserializeObject<List<Member>>(rep);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.MemberId = new SelectList(members, "MemberId", "AspNetUserId");
                    var response2 = client.GetAsync("http://localhost:51041/api/category/all").Result;
                    var rep2 = await response2.Content.ReadAsStringAsync();
                    if (response2.Content != null)
                    {
                        var projects = JsonConvert.DeserializeObject<List<ProjectCategory>>(rep2);
                        if (response.IsSuccessStatusCode)
                        {
                            ViewBag.ProjectCategoryId = new SelectList(projects, "ProjectCategoryId", "CategoryName");
                        }
                        return View(item);
                    }

                    return View(item);
                }
                else
                {
                    return View(item);
                }
            }
            return View(item);
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProjectId,MemberId,ProjectCategoryId,TitleEn,TitleEl,SubtitleEn,SubtitleEl,BodyEn,BodyEl,Goal,Views,Completed,InsertedDate,UpdatedDate,IsActive")] Project project)
        {
            var client = new HttpClient();

            var response = client.PostAsync("http://localhost:51041/api/project/save", new StringContent(new JavaScriptSerializer().Serialize(project), Encoding.UTF8, "application/json")).Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Projects");
            }
            else
            {
                return RedirectToAction("Index", "Projects");
            }
            //if (ModelState.IsValid)
            //{
            //    db.Projects.Add(project);
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.MemberId = new SelectList(db.Members, "MemberId", "FirstName", project.MemberId);
            //ViewBag.ProjectCategoryId = new SelectList(db.ProjectCategories, "ProjectCategoryId", "CategoryName", project.ProjectCategoryId);
            //return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var client = new HttpClient();

            var response = client.GetAsync("http://localhost:51041/api/project/" + id).Result;
            var contact = JsonConvert.DeserializeObject<Project>(response.ToString());
            if (response.IsSuccessStatusCode)
            {
                return View(contact);
            }
            else
            {
                return View(contact);
            }
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProjectId,MemberId,ProjectCategoryId,TitleEn,TitleEl,SubtitleEn,SubtitleEl,BodyEn,BodyEl,Goal,Views,Completed,InsertedDate,UpdatedDate,IsActive")] Project project)
        {
            var client = new HttpClient();

            var response = client.PostAsync("http://localhost:51041/api/project/save", new StringContent(new JavaScriptSerializer().Serialize(project), Encoding.UTF8, "application/json")).Result;
            var contact = JsonConvert.DeserializeObject<Project>(response.ToString());
            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        // GET: Projects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Project project = await db.Projects.FindAsync(id);
            //if (project == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(project);
            return RedirectToAction("Index");
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //Project project = await db.Projects.FindAsync(id);
            //db.Projects.Remove(project);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
