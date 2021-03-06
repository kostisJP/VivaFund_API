// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace VivaFund.WEB.DependencyResolution {
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using Interfaces;
    using ServicesInterfaces;
    using Services;
    using Repository;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Web;
    using System.Data.Entity;
    using Microsoft.Owin.Security;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            //For<IExample>().Use<Example>();
            For<IProjectRepository>().Use<ProjectRepository>();
            For<IDonationRepository>().Use<DonationRepository>();
            For<IFilterRepository>().Use<FilterRepository>();
            For<IMemberRepository>().Use<MemberRepository>();
            For<IProjectCategoryRepository>().Use<ProjectCategoryRepository>();
            For<IRewardRepository>().Use<RewardRepository>();


            For<IProjectService>().Use<ProjectService>();
            For<IDonationService>().Use<DonationService>();
            For<IFilterService>().Use<FilterService>();
            For<IMemberService>().Use<MemberService>();
            For<IRewardService>().Use<RewardService>();

            For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>();
            For<DbContext>().Use(new Models.ApplicationDbContext());
            For<IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);
        }

        #endregion
    }
}