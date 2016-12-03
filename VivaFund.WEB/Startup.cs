using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Web.Mvc;
using Microsoft.Owin;
using Owin;
using VivaFund.WEB;
using System.Linq.Expressions;
using System;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using Facebook;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(Startup))]
namespace VivaFund.WEB
{

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            System.Web.Helpers.AntiForgeryConfig.UniqueClaimTypeIdentifier = System.Security.Claims.ClaimTypes.NameIdentifier;


        }
    }
    public static class HtmlButtonExtension
    {

        public static MvcHtmlString Button(this HtmlHelper helper,
                                           string innerHtml,
                                           object htmlAttributes)
        {
            return Button(helper, innerHtml, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)
            );
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string innerHtml,
            IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("button");
            builder.InnerHtml = innerHtml;
            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString Button(this HtmlHelper helper, object innerHtml, object htmlAttributes)
        {
            return helper.Button(innerHtml, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString ButtonFor<TModel, TField>(this HtmlHelper<TModel> html,
                                                            Expression<Func<TModel, TField>> property,
                                                            object innerHtml,
                                                            object htmlAttributes)
        {
            // lazily based on TextAreaFor

            var attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var name = ExpressionHelper.GetExpressionText(property);
            var metadata = ModelMetadata.FromLambdaExpression(property, html.ViewData);

            string fullName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            ModelState modelState;
            if (html.ViewData.ModelState.TryGetValue(fullName, out modelState) && modelState.Errors.Count > 0)
            {
                if (!attrs.ContainsKey("class")) attrs["class"] = string.Empty;
                attrs["class"] += " " + HtmlHelper.ValidationInputCssClassName;
                attrs["class"] = attrs["class"].ToString().Trim();
            }
            var validation = html.GetUnobtrusiveValidationAttributes(name, metadata);
            if (null != validation) foreach (var v in validation) attrs.Add(v.Key, v.Value);

            string value;
            if (modelState != null && modelState.Value != null)
            {
                value = modelState.Value.AttemptedValue;
            }
            else if (metadata.Model != null)
            {
                value = metadata.Model.ToString();
            }
            else
            {
                value = String.Empty;
            }

            attrs["name"] = name;
            attrs["Value"] = value;
            return html.Button(innerHtml, attrs);
        }
    }
    public class TransactionResult

    {

        public int ErrorCode { get; set; }

        public string ErrorText { get; set; }

        public decimal Amount { get; set; }

        public Guid TransactionId { get; set; }

    }

    public class VivaBaseController : Controller
    {
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
                var myInfo = fb.Get<Controllers.FBUser>("/me?fields=email,first_name,last_name,gender");
                userEmail = myInfo.email;

            }

            System.Security.Claims.Claim msftType = ClaimsPrincipal.Current.FindFirst("preferred_username");
            if (msftType != null)
            {
                var accessToken = ClaimsPrincipal.Current.FindFirst("nonce").Value;
                userEmail = ClaimsPrincipal.Current.FindFirst("preferred_username").Value;
            }
            System.Security.Claims.Claim AspNetType = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider");
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
    }
}
