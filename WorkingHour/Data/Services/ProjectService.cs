using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using WorkingHour.Assets;
using WorkingHour.Data.Models;

namespace WorkingHour.Data.Services
{
    public class ProjectService : BaseService
    {
        public static List<ProjectModel> SelectAll()
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
                int.TryParse(projectNode.Attribute(nameof(ProjectModel.Id))?.Value, out int id);
                var title = projectNode.Attribute(nameof(ProjectModel.Title))?.Value;
                var initialDuration = projectNode.Attribute(nameof(ProjectModel.InitialDuration))?.Value.StandardTimeSpanParse() ?? new TimeSpan(0, 0, 0, 0);
                var totalDuration = projectNode.Attribute(nameof(ProjectModel.TotalDuration))?.Value.StandardTimeSpanParse() ?? new TimeSpan(0, 0, 0, 0);
                DateTime.TryParse(projectNode.Attribute(nameof(ProjectModel.RegisterDateTime))?.Value, out var registerDateTime);

                projects.Add(new ProjectModel
                {
                    Id = id,
                    Title = title ?? "",
                    InitialDuration = initialDuration,
                    TotalDuration = totalDuration,
                    RegisterDateTime = registerDateTime
                });
            }

            return projects;
        }
        public static ProjectModel SelectById(string projectId)
        {
            var xelement = GetElement(projectId);
            if (xelement == null) return null;
            return new ProjectModel
            {
                Id = int.Parse(xelement.Attribute(nameof(ProjectModel.Id)).Value),
                Title = xelement.Attribute(nameof(ProjectModel.Title)).Value,
                InitialDuration = xelement.Attribute(nameof(ProjectModel.InitialDuration)).Value.StandardTimeSpanParse(),
                TotalDuration = xelement.Attribute(nameof(ProjectModel.TotalDuration)).Value.StandardTimeSpanParse(),
                RegisterDateTime = DateTime.Parse(xelement.Attribute(nameof(ProjectModel.RegisterDateTime)).Value)
            };
        }
        public static void CalculateTotalDuration(string projectId)
        {
            var xelement = GetElement(projectId);
            if (xelement == null) return;
            var totalTimeSpan = xelement.Attribute(nameof(ProjectModel.InitialDuration))?.Value.StandardTimeSpanParse() ?? new TimeSpan(0, 0, 0, 0);
            var xdocument = GetDataBaseXDocumentInstance;
            var allProjectsTimes = xdocument.Descendants(Constants.TimeNodeName)
                .Where(q => q.HasAttributes &&
                    q.Attribute(nameof(TimeModel.Duration)) != null &&
                    q.Attribute(nameof(TimeModel.ProjectId)) != null &&
                    q.Attribute(nameof(TimeModel.ProjectId)).Value.Equals(projectId.ToString(), StringComparison.InvariantCultureIgnoreCase));
            foreach (var timeElement in allProjectsTimes)
            {
                var duration = timeElement.Attribute(nameof(TimeModel.Duration))?.Value.StandardTimeSpanParse() ?? new TimeSpan(0, 0, 0, 0);
                totalTimeSpan = totalTimeSpan.Add(duration);
            }
            xelement.SetAttributeValue(nameof(ProjectModel.TotalDuration), totalTimeSpan.ToStandardString());
            SaveChanges();
        }
        public static void Save(ProjectModel projectModel)
        {
            var xDocument = GetDataBaseXDocumentInstance;
            var xElement = GetElement(projectModel.Id.ToString());
            if (xElement == null)
            {
                xElement = new XElement(Constants.ProjectNodeName,
                                new XAttribute(nameof(ProjectModel.Id), projectModel.Id),
                                new XAttribute(nameof(ProjectModel.Title), projectModel.Title),
                                new XAttribute(nameof(ProjectModel.InitialDuration), projectModel.InitialDuration.ToStandardString()),
                                new XAttribute(nameof(ProjectModel.TotalDuration), "00:00:00"),
                                new XAttribute(nameof(ProjectModel.RegisterDateTime), DateTime.Now.ToStandardString()));
                xDocument.Descendants(Constants.ProjectsNodeName).First().Add(xElement);
            }
            else
            {
                xElement.SetAttributeValue(nameof(ProjectModel.Title), projectModel.Title);
                xElement.SetAttributeValue(nameof(ProjectModel.InitialDuration), projectModel.InitialDuration.ToStandardString());
            }

            // 
            SaveChanges();
            CalculateTotalDuration(projectModel.Id.ToString());
            BackupService.GetBackup();
        }
        private static XElement GetElement(string projectId)
        {
            return GetDataBaseXDocumentInstance
                .Descendants(Constants.ProjectNodeName)
                .FirstOrDefault(q => q.HasAttributes &&
                    q.Attribute(nameof(ProjectModel.Id)) != null &&
                    q.Attribute(nameof(ProjectModel.Id)).Value.Equals(projectId, StringComparison.InvariantCultureIgnoreCase));
        }
        public static void Delete(int id)
        {
            var idString = id.ToString();
            var projectElement = GetElement(idString);
            if(projectElement == null)
                throw new Exception($"Project with {id} Id is not exist in DataBase");
            projectElement.RemoveAll();
            var times = GetDataBaseXDocumentInstance.Descendants(Constants.TimeNodeName)
                .Where(q => q.HasAttributes && q.Attribute(nameof(TimeModel.ProjectId)) != null &&
                            q.Attribute(nameof(TimeModel.ProjectId)).Value.Equals(idString));
            times.Remove();
            projectElement.Remove();
            SaveChanges();
        }
    }
}
