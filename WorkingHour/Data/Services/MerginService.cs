using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using WorkingHour.Assets;
using WorkingHour.Data.Models;

namespace WorkingHour.Data.Services
{
    public class MerginService
    {
        private readonly string _dataBaseFilePath;
        public MerginService(string dataBaseFilePath)
        {
            _dataBaseFilePath = dataBaseFilePath;
        }

        private XDocument _xDocument;
        private XDocument GetDataBaseXDocumentInstance
        {
            get
            {
                if (_xDocument != null) return _xDocument;
                _xDocument = XDocument.Load(_dataBaseFilePath);
                return _xDocument;
            }
        }

        public List<ProjectModel> SelectAllProjects()
        {
            var xdocument = GetDataBaseXDocumentInstance;
            var projectNodes = xdocument.Descendants(Constants.ProjectNodeName)
                .Where(q => q.HasAttributes &&
                    q.Attribute(nameof(ProjectModel.Id)) != null &&
                    q.Attribute(nameof(ProjectModel.Title)) != null &&
                    q.Attribute(nameof(ProjectModel.InitialDuration)) != null &&
                    q.Attribute(nameof(ProjectModel.TotalDuration)) != null &&
                    q.Attribute(nameof(ProjectModel.RegisterDateTime)) != null).ToList();

            var projects = new List<ProjectModel>();
            foreach (var projectNode in projectNodes)
            {
                int.TryParse(projectNode.Attribute(nameof(ProjectModel.Id))?.Value, out var projectId);
                var title = projectNode.Attribute(nameof(ProjectModel.Title))?.Value;
                var initialDuration = projectNode.Attribute(nameof(ProjectModel.InitialDuration))?.Value.StandardTimeSpanParse() ?? new TimeSpan(0, 0, 0, 0);
                var totalDuration = projectNode.Attribute(nameof(ProjectModel.TotalDuration))?.Value.StandardTimeSpanParse() ?? new TimeSpan(0, 0, 0, 0);
                DateTime.TryParse(projectNode.Attribute(nameof(ProjectModel.RegisterDateTime))?.Value, out var registerDateTime);

                var project = new ProjectModel
                {
                    Id = projectId,
                    Title = title ?? "",
                    InitialDuration = initialDuration,
                    TotalDuration = totalDuration,
                    RegisterDateTime = registerDateTime
                };

                var timeNodes = GetDataBaseXDocumentInstance
                    .Descendants(Constants.TimeNodeName)
                    .Where(q => q.HasAttributes &&
                                q.Attribute(nameof(TimeModel.ProjectId)) != null &&
                                q.Attribute(nameof(TimeModel.ProjectId)).Value.Equals(projectId.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    .ToList();
                var times = new List<TimeModel>();
                foreach (var xElement in timeNodes)
                {
                    times.Add(new TimeModel
                    {
                        Id = Guid.Parse(xElement.Attribute(nameof(TimeModel.Id)).Value),
                        ProjectId = int.Parse(xElement.Attribute(nameof(TimeModel.ProjectId)).Value),
                        Description = xElement.Attribute(nameof(TimeModel.Description)).Value,
                        StartDateTime = DateTime.Parse(xElement.Attribute(nameof(TimeModel.StartDateTime)).Value),
                        StopDateTime = DateTime.Parse(xElement.Attribute(nameof(TimeModel.StopDateTime)).Value),
                        Duration = xElement.Attribute(nameof(TimeModel.Duration)).Value.StandardTimeSpanParse(),
                        RegisterDateTime = DateTime.Parse(xElement.Attribute(nameof(TimeModel.RegisterDateTime)).Value)
                    });
                }

                project.Times = times.OrderBy(q => q.RegisterDateTime).ToList();

                projects.Add(project);
            }



            return projects.OrderByDescending(q => q.RegisterDateTime).ToList();
        }
        public int GetTheSameProjectsCount(List<ProjectModel> projectsOfCurrentDataBase)
        {
            var projectsOfExternalDataBase = SelectAllProjects();
            var theSameProjects =
                        (from p1 in projectsOfExternalDataBase
                         from p2 in projectsOfCurrentDataBase
                         where p1.Title.Equals(p2.Title, StringComparison.InvariantCultureIgnoreCase)
                         select p1).ToList();
            return theSameProjects.Count;
        }
        public List<ProjectModel> GetTheSameProjects(List<ProjectModel> projectsOfCurrentDataBase)
        {
            var projectsOfExternalDataBase = SelectAllProjects();
            var theSameProjects =
                        (from p1 in projectsOfExternalDataBase
                         from p2 in projectsOfCurrentDataBase
                         where p1.Title.Equals(p2.Title, StringComparison.InvariantCultureIgnoreCase)
                         select p1).ToList();
            return theSameProjects;
        }
    }
}
