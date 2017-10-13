using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using WorkingHour.Data.Models;

namespace WorkingHour.Data.Services
{
    public class ProjectService : BaseService
    {
        public List<ProjectModel> SelectAll()
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

        public void Save(ProjectModel projectModel)
        {
            var xElement = SelectById(projectModel.Id.ToString());

            var xDocument = GetDataBaseXDocumentInstance;
            if (xElement == null)
            {
                xElement = new XElement("Project",
                    new XAttribute("Id", projectModel.Id),
                    new XAttribute("Title", projectModel.Title),
                    new XAttribute("TotalDuration", projectModel.TotalDuration.ToString()),
                    new XAttribute("RegisterDateTime", DateTime.Now));
                xDocument.Descendants("Projects").First().Add(xElement);
            }
            else
            {
                xElement.SetAttributeValue("Title", projectModel.Title);
                xElement.SetAttributeValue("TotalDuration", projectModel.TotalDuration.ToString());
            }
            SaveChanges();
        }

        private XElement SelectById(string id)
        {
            return GetDataBaseXDocumentInstance
                .Descendants("Project")
                .FirstOrDefault(q => q.HasAttributes && q.Attribute("Id") != null && q.Attribute("Id").Value
                                .Equals(id, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
