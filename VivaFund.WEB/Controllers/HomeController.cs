using System;
using System.Security.Claims;
using System.Web.Mvc;

namespace VivaFund.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                {
                    Claim oType =
                        ClaimsPrincipal.Current.FindFirst(
                            "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider");
                    if (oType != null)
                    {
                        ViewBag.Title = oType.Value;
                        ViewBag.Name =
                            ClaimsPrincipal.Current.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")
                                .Value;

                        // The object ID claim will only be emitted for work or school accounts at this time.
                        Claim oid =
                            ClaimsPrincipal.Current.FindFirst(
                                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                        ViewBag.Subject = oid == null ? string.Empty : oid.Value;
                    }
                }
                {
                    Claim oType = ClaimsPrincipal.Current.FindFirst("urn:facebook:name");
                    if (oType != null)
                    {
                        ViewBag.Title = "Facebook Identity";
                        // The 'preferred_username' claim can be used for showing the user's primary way of identifying themselves http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name
                        ViewBag.Username =
                            ClaimsPrincipal.Current.FindFirst(
                                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;

                        // The subject or nameidentifier claim can be used to uniquely identify the user
                        ViewBag.Subject =
                            ClaimsPrincipal.Current.FindFirst(
                                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                        ViewBag.Message = "Your application description page.";
                    }
                }
                {
                    Claim oType = ClaimsPrincipal.Current.FindFirst("preferred_username");
                    if (oType != null)
                    {
                        ViewBag.Title = "Microsoft Identity";
                        // The 'preferred_username' claim can be used for showing the user's primary way of identifying themselves
                        ViewBag.Username = ClaimsPrincipal.Current.FindFirst("name").Value;

                        // The subject or nameidentifier claim can be used to uniquely identify the user
                        ViewBag.Subject = ClaimsPrincipal.Current.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                        ViewBag.Message = "Your application description page.";
                    }
                }
                ViewBag.Title = "Viva Fund";
            }
            catch (Exception)
            {
                //Ignored
            }
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            try
            {
                {
                    Claim oType =
                        ClaimsPrincipal.Current.FindFirst(
                            "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider");
                    if (oType != null)
                    {
                        ViewBag.Title = oType.Value;
                        ViewBag.Name =
                            ClaimsPrincipal.Current.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")
                                .Value;

                        // The object ID claim will only be emitted for work or school accounts at this time.
                        Claim oid =
                            ClaimsPrincipal.Current.FindFirst(
                                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                        ViewBag.Subject = oid == null ? string.Empty : oid.Value;
                    }
                }
                {
                    Claim oType = ClaimsPrincipal.Current.FindFirst("urn:facebook:name");
                    if (oType != null)
                    {
                        ViewBag.Title = "Facebook Identity";
                        // The 'preferred_username' claim can be used for showing the user's primary way of identifying themselves http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name
                        ViewBag.Username =
                            ClaimsPrincipal.Current.FindFirst(
                                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;

                        // The subject or nameidentifier claim can be used to uniquely identify the user
                        ViewBag.Subject =
                            ClaimsPrincipal.Current.FindFirst(
                                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                        ViewBag.Message = "Your application description page.";
                    }
                }
                {
                    Claim oType = ClaimsPrincipal.Current.FindFirst("preferred_username");
                    if (oType != null)
                    {
                        ViewBag.Title = "Microsoft Identity";
                        // The 'preferred_username' claim can be used for showing the user's primary way of identifying themselves
                        ViewBag.Username = ClaimsPrincipal.Current.FindFirst("name").Value;

                        // The subject or nameidentifier claim can be used to uniquely identify the user
                        ViewBag.Subject = ClaimsPrincipal.Current.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
                        ViewBag.Message = "Your application description page.";
                    }
                }
            }
            catch (Exception)
            {
                //Ignored
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}