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
using VivaFund.ServicesInterfaces;
using VivaFund.Services;

namespace VivaFund.WEB.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: Projects
        public ActionResult Index()
        {
            var projects = _projectService.GetAllProjects();

            if (projects != null)
                return View(projects);

            return RedirectToAction("Error", "Home");

        }

        // GET: Projects/Details/5
        public ActionResult Details(int id)
        {
            var project = _projectService.GetProjectById(id);

            if (project != null)
                return View(project);

            return RedirectToAction("Error", "Home");
        }

        // GET: Projects/Create
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
        public ActionResult Create(Project project)
        {
            _projectService.SetProject(project);

            return View(project);

            //var client = new HttpClient();

            //var response = client.PostAsync("http://localhost:51041/api/project/save", new StringContent(new JavaScriptSerializer().Serialize(project), Encoding.UTF8, "application/json")).Result;
            //var rep = await response.Content.ReadAsStringAsync();
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index", "Projects");
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Projects");
            //}
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int id)
        {
            var project = _projectService.GetProjectById(id);

            if (project == null)
                RedirectToAction("Error", "Home");

            return View(project);           
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            _projectService.SetProject(project);

            return View();
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
