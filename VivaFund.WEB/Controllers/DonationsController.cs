using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using VivaFund.DomainModels;
using VivaFund.WEB.Models;

namespace VivaFund.WEB.Controllers
{
    public class DonationsController : Controller
    {
        // GET: Donations
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var client = new HttpClient();

            var response = client.GetAsync("http://localhost:51041/api/donation/all").Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.Content != null)
            {
                var contact = JsonConvert.DeserializeObject<List<Donation>>(rep);
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

        // GET: Donations/Details/5
        public async System.Threading.Tasks.Task<ActionResult> Details(int? id)
        {
            var client = new HttpClient();

            var response = client.GetAsync("http://localhost:51041/api/donation/all").Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.Content != null)
            {
                var contact = JsonConvert.DeserializeObject<Donation>(rep);
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

        // GET: Donations/Create
        public async System.Threading.Tasks.Task<ActionResult> Create()
        {
            var client = new HttpClient();
            Donation item = new Donation();
            ViewBag.MemberId = new SelectList(new List<Member>(), "MemberId", "FirstName");
            ViewBag.ProjectId = new SelectList(new List<Project>(), "ProjectId", "TitleEn");
            ViewBag.RewardID = new SelectList(new List<Reward>(), "RewardID", "Title");
            var response = client.GetAsync("http://localhost:51041/api/member/all").Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.Content != null)
            {
                var members = JsonConvert.DeserializeObject<List<Member>>(rep);
                if (response.IsSuccessStatusCode && members.Count > 0)
                {
                    ViewBag.MemberId = new SelectList(members, "MemberId", "FirstName");
                    var response2 = client.GetAsync("http://localhost:51041/api/project/all").Result;
                    var rep2 = await response2.Content.ReadAsStringAsync();
                    if (response2.Content != null)
                    {
                        var projects = JsonConvert.DeserializeObject<List<Project>>(rep2);
                        if (response2.IsSuccessStatusCode && projects.Count > 0)
                        {
                            ViewBag.ProjectId = new SelectList(projects, "ProjectId", "TitleEn");
                            var response3 = client.GetAsync("http://localhost:51041/api/reward/project/"+projects.First().ProjectId).Result;
                            var rep3 = await response3.Content.ReadAsStringAsync();
                            if (response3.Content != null)
                            {
                                var rewards = JsonConvert.DeserializeObject<List<Reward>>(rep3);
                                if (response3.IsSuccessStatusCode && rewards.Count > 0)
                                {
                                    ViewBag.RewardID = new SelectList(rewards, "RewardID", "Title");

                                }
                                return View(item);
                            }
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

        // POST: Donations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Create([Bind(Include = "DonationId,MemberId,ProjectId,DonatedAmount,RewardId,InsertedDate,UpdatedDate,IsActive")] Donation donation)
        {
            var client = new HttpClient();

            var response = client.PostAsync("http://localhost:51041/api/donation/save", new StringContent(new JavaScriptSerializer().Serialize(donation), Encoding.UTF8, "application/json")).Result;
            var rep = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Donations");
            }
            else
            {
                return RedirectToAction("Index", "Donations");
            }
        }

    }
}
