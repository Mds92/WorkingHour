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
            var projectNodes = xdocument.Descendants("Project")
                .Where(q => q.HasAttributes &&
                    q.Attribute("Id") != null &&
                    q.Attribute("Title") != null &&
                    q.Attribute("TotalDuration") != null &&
                    q.Attribute("RegisterDateTime") != null).ToList();
            return projectNodes.Select(q => new ProjectModel
            {
                Id = int.Parse(q.Attribute("Id").Value),
                Title = q.Attribute("Title").Value,
                TotalDuration = TimeSpan.Parse(q.Attribute("TotalDuration").Value),
                RegisterDateTime = DateTime.Parse(q.Attribute("RegisterDateTime").Value)
            }).ToList();
        }

        public static ProjectModel SelectById(string projectId)
        {
            var xelement = GetElement(projectId);
            if (xelement == null) return null;
            return new ProjectModel
            {
                Id = int.Parse(xelement.Attribute("Id").Value),
                Title = xelement.Attribute("Title").Value,
                TotalDuration = TimeSpan.Parse(xelement.Attribute("TotalDuration").Value),
                RegisterDateTime = DateTime.Parse(xelement.Attribute("RegisterDateTime").Value)
            };
        }

        public static void CalculateTotalDuration(string projectId)
        {
            var xelement = GetElement(projectId);
            if (xelement == null) return;
            var xdocument = GetDataBaseXDocumentInstance;
            var allProjectsTimes = xdocument.Descendants("Time")
                .Where(q => q.HasAttributes && 
                    q.Attribute("Duration") != null && 
                    q.Attribute("ProjectId") != null && 
                    q.Attribute("ProjectId").Value.Equals(projectId.ToString(), StringComparison.InvariantCultureIgnoreCase));
            var totalTimeSpan = new TimeSpan(0, 0, 0, 0);
            foreach (var timeElement in allProjectsTimes)
            {
                var duration = timeElement.Attribute("Duration").Value;
                if (string.IsNullOrWhiteSpace(duration)) continue;
                TimeSpan.TryParse(duration, out TimeSpan timeSpan);
                if (timeSpan <= TimeSpan.MinValue) continue;
                totalTimeSpan = totalTimeSpan.Add(timeSpan);
            }
            xelement.SetAttributeValue("TotalDuration", totalTimeSpan.ToStandardString());
            SaveChanges();
        }

        public static void Save(ProjectModel projectModel)
        {
            var xDocument = GetDataBaseXDocumentInstance;
            var xElement = GetElement(projectModel.Id.ToString());
            if (xElement == null)
            {
                xElement = new XElement("Project",
                                new XAttribute("Id", projectModel.Id),
                                new XAttribute("Title", projectModel.Title),
                                new XAttribute("TotalDuration", projectModel.TotalDuration.ToStandardString()),
                                new XAttribute("RegisterDateTime", DateTime.Now.ToStandardString()));
                xDocument.Descendants("Projects").First().Add(xElement);
            }
            else
            {
                xElement.SetAttributeValue("Title", projectModel.Title);
                xElement.SetAttributeValue("TotalDuration", projectModel.TotalDuration.ToStandardString());
            }
            SaveChanges();
            CalculateTotalDuration(projectModel.Id.ToString());
        }

        private static XElement GetElement(string projectId)
        {
            return GetDataBaseXDocumentInstance
                .Descendants("Project")
                .FirstOrDefault(q => q.HasAttributes && q.Attribute("Id") != null && q.Attribute("Id").Value
                                .Equals(projectId, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
