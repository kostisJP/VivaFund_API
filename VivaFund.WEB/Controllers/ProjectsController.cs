﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using VivaFund.DomainModels;
using VivaFund.ServicesInterfaces;
using VivaFund.ViewModels;
using AutoMapper;
using RestSharp;
using RestSharp.Authenticators;
using System.Reflection;

namespace VivaFund.WEB.Controllers
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MultipleButtonAttribute : ActionNameSelectorAttribute
    {
        public string Name { get; set; }
        public string Argument { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var isValidName = false;
            var keyValue = string.Format("{0}:{1}", Name, Argument);
            var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

            if (value != null)
            {
                controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
                isValidName = true;
            }

            return isValidName;
        }
    }
    public class ProjectsController : VivaBaseController
    {
        private readonly IProjectService _projectService;
        private readonly IMemberService _memberService;
        private readonly IDonationService _donationService;
        private readonly IRewardService _rewardService;

        public ProjectsController(IProjectService projectService,
            IMemberService memberService,
            IDonationService donationService,
            IRewardService rewardService)
        {
            _projectService = projectService;
            _memberService = memberService;
            _donationService = donationService;
            _rewardService = rewardService;
        }

        // GET: Projects
        public ActionResult Index()
        {
            var projects = _projectService.GetAllProjects();

            var projectsVM = Mapper.Map<IEnumerable<ProjectViewModel>>(projects);

            if (projects != null)
                return View(projectsVM);

            return RedirectToAction("Error", "Home");

        }

        // GET: Projects/Category/5
        public ActionResult Category(int id)
        {
            var projects = _projectService.GetAllProjectsByCategory(id);

            if (projects != null)
                return View("Index", projects);

            return RedirectToAction("Error", "Home");

        }

        //public ActionResult Details()
        //{
        //    return RedirectToAction("Error", "Home");
        //}

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            var project = _projectService.GetProjectById(id ?? 0);

            var donations = _donationService.GetAllDonationsByProjectId(id ?? 0).ToList();
            var projectMedia = _projectService.GetProjectMediaByProjectId(id ?? 0).ToList();
            var comments = _projectService.GetCommentsByProjectId(id ?? 0).ToList();
            var rewards = _rewardService.GetAllRewardsByProjectId(id ?? 0).ToList();

            var projectVM = new ProjectViewModel();
            if (GetUserId() != null)
            {
                ViewBag.Flag = true;
                ViewBag.MemberId = _memberService.GetMemberById(GetUserId()).MemberId;
            }
            else
            {
                ViewBag.Flag = false;
            }
            projectVM = Mapper.Map<ProjectViewModel>(project);

            if (donations != null)
            {
                var don = Mapper.Map<IEnumerable<DonationViewModel>>(donations);
                projectVM.Donations = don;
            }
            if (projectMedia != null)
            {
                var pm = Mapper.Map<IEnumerable<ProjectMediaViewModel>>(projectMedia);
                projectVM.ProjectMedia = pm;
            }
            if (comments != null)
            {
                var comm = Mapper.Map<IEnumerable<CommentViewModel>>(comments);
                projectVM.Comments = comm;
            }
            if (rewards != null)
            {
                var rwd = Mapper.Map<IEnumerable<RewardViewModel>>(rewards);
                projectVM.Rewards = rwd;
            }

            if (project != null)
                return View(projectVM);

            return RedirectToAction("Error", "Home");
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
        [MultipleButton(Name = "action", Argument = "Create")]
        public ActionResult Create(Project project)
        {
            project.Member = _memberService.GetMemberById(GetUserId());
            project.MemberId = _memberService.GetMemberById(GetUserId()).MemberId;

            _projectService.SetProject(project);


            return RedirectToAction("Index", "Projects");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "Add")]
        public async Task<ActionResult> Add(Project project)
        {
            var client = new HttpClient();
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
            }
            var rew = new VivaFund.DomainModels.Reward();
            rew.ProjectID = project.ProjectId;
            rew.Project = project;
            rew.Title = "";
            rew.RewardDescription = "";
            project.Rewards.Add(rew);
            return View("../Projects/Create", project);
        }

        // GET: Projects/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var project = _projectService.GetProjectById(id);

            if (project != null)
            {
                if (project.Member.AspNetUserId == GetUserId())
                {
                    return View(project);
                }
            }

            return RedirectToAction("Error", "Home");
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


        private const string merchantId = "e8189548-ee71-4a8f-a18f-8297aed6adfc";

        private const string apiKey = "XAs}{V";
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Checkout(Project project)
        {

            var cl = new RestClient("https://demo.vivapayments.com/api/")
            {

                Authenticator = new HttpBasicAuthenticator(merchantId, apiKey)

            };

            var request = new RestRequest("transactions", Method.POST)
            {

                RequestFormat = DataFormat.Json

            };


            request.AddParameter("PaymentToken", Request.Form["vivaWalletToken"]);



            var response = await cl.ExecuteTaskAsync<TransactionResult>(request);



            if (response.Data != null)
            {

                Response.Write(response.Data.ErrorCode + "--" + response.Data.ErrorText);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                }
                Donation don = new Donation()
                {
                    ProjectId = project.ProjectId,
                    DonatedAmount = Convert.ToInt32(response.Data.Amount),
                    Member = _memberService.GetMemberById(GetUserId()),
                    MemberId = _memberService.GetMemberById(GetUserId()).MemberId,
                    IsActive = true,
                    Reward = null
                };
                _donationService.SetDonation(don);
                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
            }
            else
            {
                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
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
