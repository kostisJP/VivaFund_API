﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.Interfaces
{
    public interface IProjectRepository
    {

        void UndoChanges();
       
        IEnumerable<Project> GetAllProjects();
        IEnumerable<Project> GetProjectsByCategory(int categoryId);
        IEnumerable<Project> GetProjectsByMember(int memberId);
        IEnumerable<ProjectMedia> GetProjectMediaByProjectId(int projectId);
        Project GetProjectById(int id);
        void InsertOrUpdateProject(Project project);
        
    }
}
