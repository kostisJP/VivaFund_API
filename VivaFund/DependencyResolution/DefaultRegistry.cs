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

namespace VivaFund.DependencyResolution {
    using Interfaces;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using Repository;
    using ServicesInterfaces;
    using Services;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
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
        }

        #endregion
    }
}