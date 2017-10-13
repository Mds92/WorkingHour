using System;
using System.Collections.Generic;
using System.Linq;
using WorkingHour.Data.Models;

namespace WorkingHour.Data.Services
{
    public class ProjectService : BaseService
    {
        public List<ProjectModel> SellectAll()
        {
            var xdocument = GetDataBaseXDocumentInstance;
            var projectNodes = xdocument.Descendants("Project").Where(q => q.HasAttributes && q.Attribute("Id") != null && q.Attribute("Title") != null && q.Attribute("TotalDuration") != null).ToList();
            return projectNodes.Select(q => new ProjectModel
            {
                Id = int.Parse(q.Attribute("Id").Value),
                Title = q.Attribute("Title").Value,
                TotalDuration = TimeSpan.Parse(q.Attribute("TotalDuration").Value)
            }).ToList();
        }
    }
}
