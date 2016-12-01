using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Facebook;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using VivaFund.DomainModels;
using VivaFund.WEB.Models;
using VivaFund.ServicesInterfaces;
using VivaFund.Services;
using VivaFund.ViewModels;
using AutoMapper;

namespace VivaFund.WEB.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMemberService _memberService;
        private readonly IDonationService _donationService;

        public ProjectsController(IProjectService projectService, 
            IMemberService memberService, 
            IDonationService donationService)
        {
            _projectService = projectService;
            _memberService = memberService;
            _donationService = donationService;
        }

        // GET: Projects
        public ActionResult Index()
        {
            var projects = _projectService.GetAllProjects();

            if (projects != null)
                return View(projects);

            return RedirectToAction("Error", "Home");

        }

        //public ActionResult Details()
        //{
        //    return RedirectToAction("Error", "Home");
        //}

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            var project = _projectService.GetProjectById(id??0);

            var donations = _donationService.GetDonationByProjectId(id??0);

            //var projectVM = new ProjectViewModel();

            //projectVM = Mapper.Map<ProjectViewModel>(project);
            //projectVM = Mapper.Map<ProjectViewModel>(donations);

            if (project != null)
                return View(project);

            return RedirectToAction("Error", "Home");
        }

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public string GetUserId()
        {
            var userEmail = "";
            var identity = ClaimsPrincipal.Current.FindFirst("urn:facebook:name");
            if (identity != null)
            {
                var accessToken = ClaimsPrincipal.Current.FindFirst("FacebookAccessToken").Value;
                var fb = new FacebookClient(accessToken);
                var myInfo = fb.Get<FBUser>("/me?fields=email,first_name,last_name,gender");
                userEmail = myInfo.email;

            }

            Claim msftType = ClaimsPrincipal.Current.FindFirst("preferred_username");
            if (msftType != null)
            {
                var accessToken = ClaimsPrincipal.Current.FindFirst("nonce").Value;
                userEmail = ClaimsPrincipal.Current.FindFirst("preferred_username").Value;
            }
            Claim AspNetType = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider");
            if (AspNetType != null && AspNetType.Value == "ASP.NET Identity")
            {
                var user_ = UserManager.FindById(ClaimsPrincipal.Current.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
                return user_?.Id ?? null;
                //var accessToken = ClaimsPrincipal.Current.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                //userEmail = ClaimsPrincipal.Current.FindFirst("preferred_username").Value;
            }
            var user = UserManager.FindByEmail(userEmail);
            return user?.Id ?? null;
            //ASP.NET Identity
        }

        // GET: Projects/Create
        [Authorize]
        public async Task<ActionResult> Create()
        {
            var client = new HttpClient();
            var item = new Project { Member = _memberService.GetMemberById(GetUserId()) };
            item.MemberId = item.Member.MemberId;

            //members.Select(x =>
            //new SelectListItem
            //{
            //    Text = x.MemberId.ToString(),
            //    Value = x.AspNetUserId.ToString()
            //});

            var response2 = client.GetAsync("http://localhost:51041/api/category/all").Result;
            var rep2 = await response2.Content.ReadAsStringAsync();
            if (response2.Content != null)
            {
                var projects = JsonConvert.DeserializeObject<List<ProjectCategory>>(rep2);
                if (response2.IsSuccessStatusCode)
                {
                    var ins = new List<SelectListItem>();
                    ins.Add(new SelectListItem { Text = "Select ...", Value = "Select", Selected = true });
                    ins.AddRange(projects.Select(
                            x =>
                                new SelectListItem
                                {
                                    Text = x.CategoryName,
                                    Value = x.ProjectCategoryId.ToString(),
                                    Selected = false
                                }));

                    ViewBag.ProjectCategoryId = ins;

                }
                return View(item);
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
            project.Member = _memberService.GetMemberById(GetUserId());
            project.MemberId = _memberService.GetMemberById(GetUserId()).MemberId;

            _projectService.SetProject(project);


            return RedirectToAction("Index", "Projects");

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
