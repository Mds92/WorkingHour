﻿using System;
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
                TimeSpan.TryParse(projectNode.Attribute(nameof(ProjectModel.InitialDuration))?.Value, out TimeSpan initialDuration);
                TimeSpan.TryParse(projectNode.Attribute(nameof(ProjectModel.TotalDuration))?.Value, out TimeSpan totalDuration);
                DateTime.TryParse(projectNode.Attribute(nameof(ProjectModel.RegisterDateTime))?.Value, out DateTime registerDateTime);

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
            TimeSpan.TryParse(xelement.Attribute(nameof(ProjectModel.InitialDuration))?.Value, out TimeSpan totalTimeSpan);
            var xdocument = GetDataBaseXDocumentInstance;
            var allProjectsTimes = xdocument.Descendants(Constants.TimeNodeName)
                .Where(q => q.HasAttributes && 
                    q.Attribute(nameof(TimeModel.Duration)) != null && 
                    q.Attribute(nameof(TimeModel.ProjectId)) != null && 
                    q.Attribute(nameof(TimeModel.ProjectId)).Value.Equals(projectId.ToString(), StringComparison.InvariantCultureIgnoreCase));
            foreach (var timeElement in allProjectsTimes)
            {
                TimeSpan.TryParse(timeElement.Attribute(nameof(TimeModel.Duration))?.Value, out TimeSpan duration);
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
        }

        private static XElement GetElement(string projectId)
        {
            return GetDataBaseXDocumentInstance
                .Descendants(Constants.ProjectNodeName)
                .FirstOrDefault(q => q.HasAttributes && 
                    q.Attribute(nameof(ProjectModel.Id)) != null && 
                    q.Attribute(nameof(ProjectModel.Id)).Value.Equals(projectId, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
