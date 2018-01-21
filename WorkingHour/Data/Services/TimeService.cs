using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using WorkingHour.Assets;
using WorkingHour.Data.Models;

namespace WorkingHour.Data.Services
{
    public class TimeService : BaseService
    {
        public static void Save(TimeModel timeModel)
        {
            var project = ProjectService.SelectById(timeModel.ProjectId.ToString());
            if (project == null)
                throw new Exception("Project is not exist");
            var xDocument = GetDataBaseXDocumentInstance;
            var xElement = GetElement(timeModel.Id.ToString()) ?? GetElement(timeModel.StartDateTime.ToStandardString(), timeModel.StopDateTime.ToStandardString());
            if (xElement == null)
            {
                xElement = new XElement(Constants.TimeNodeName,
                    new XAttribute(nameof(TimeModel.Id), Guid.NewGuid().ToString()),
                    new XAttribute(nameof(TimeModel.ProjectId), timeModel.ProjectId),
                    new XAttribute(nameof(TimeModel.StartDateTime), timeModel.StartDateTime.ToStandardString()),
                    new XAttribute(nameof(TimeModel.StopDateTime), timeModel.StopDateTime.ToStandardString()),
                    new XAttribute(nameof(TimeModel.Duration), timeModel.Duration.ToStandardString()),
                    new XAttribute(nameof(TimeModel.RegisterDateTime), DateTime.Now.ToStandardString()),
                    new XAttribute(nameof(TimeModel.Description), timeModel.Description));
                xDocument.Descendants(Constants.TimesNodeName).First().Add(xElement);
            }
            else
            {
                xElement.SetAttributeValue(nameof(TimeModel.StartDateTime), timeModel.StartDateTime.ToStandardString());
                xElement.SetAttributeValue(nameof(TimeModel.StopDateTime), timeModel.StopDateTime.ToStandardString());
                xElement.SetAttributeValue(nameof(TimeModel.Duration), timeModel.Duration.ToStandardString());

            }
            SaveChanges();
            ProjectService.CalculateTotalDuration(project.Id.ToString());
        }

        public static List<TimeModel> SelectAllByProjectId(string projectId)
        {
            var elements = GetDataBaseXDocumentInstance
                .Descendants(Constants.TimeNodeName)
                .Where(q => q.HasAttributes &&
                                     q.Attribute(nameof(TimeModel.ProjectId)) != null &&
                                     q.Attribute(nameof(TimeModel.ProjectId)).Value.Equals(projectId, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
            var times = new List<TimeModel>();
            foreach (var xElement in elements)
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
            return times;
        }

        private static XElement GetElement(string id)
        {
            return GetDataBaseXDocumentInstance
                .Descendants(Constants.TimeNodeName)
                .FirstOrDefault(q => q.HasAttributes && 
                    q.Attribute(nameof(TimeModel.Id)) != null && 
                    q.Attribute(nameof(TimeModel.Id)).Value.Equals(id, StringComparison.InvariantCultureIgnoreCase));
        }
        private static XElement GetElement(string startDateTime, string stopDateTime)
        {
            return GetDataBaseXDocumentInstance
                .Descendants(Constants.TimeNodeName)
                .FirstOrDefault(q => q.HasAttributes && 
                    q.Attribute(nameof(TimeModel.StartDateTime)) != null && q.Attribute(nameof(TimeModel.StartDateTime)).Value.Equals(startDateTime, StringComparison.InvariantCultureIgnoreCase) &&
                    q.Attribute(nameof(TimeModel.StopDateTime)) != null && q.Attribute(nameof(TimeModel.StopDateTime)).Value.Equals(stopDateTime, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
