﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.ServicesInterfaces
{
    public interface IProjectService
    {

        #region PROJECTCATEGORY
        IEnumerable<ProjectCategory> GetAllCategories();
        ProjectCategory GetProjectCategoryById(int id);
        ProjectCategory SetCategory(ProjectCategory projectCategory);
        #endregion PROJECTCATEGORY

        #region PROJECT
        IEnumerable<Project> Recommended(int memberId);
        IEnumerable<Project> GetAllProjects();
        IEnumerable<Project> GetAllProjectsByCategory(int categoryId);
        IEnumerable<ProjectMedia> GetProjectMediaByProjectId(int projectId);
        IEnumerable<Comment> GetCommentsByProjectId(int projectId);
        Project GetProjectById(int id);
        void SetProject(Project project);
        IEnumerable<Project> GetProjectsByMember(int id);
        #endregion PROJECT

    }
}
