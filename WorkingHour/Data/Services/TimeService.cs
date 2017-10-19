using System;
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
                xElement = new XElement("Time",
                    new XAttribute("Id", Guid.NewGuid().ToString()),
                    new XAttribute("ProjectId", timeModel.ProjectId),
                    new XAttribute("StartDateTime", timeModel.StartDateTime.ToStandardString()),
                    new XAttribute("StopDateTime", timeModel.StopDateTime.ToStandardString()),
                    new XAttribute("Duration", timeModel.Duration.ToStandardString()),
                    new XAttribute("RegisterDateTime", DateTime.Now.ToStandardString()));
                xDocument.Descendants("Times").First().Add(xElement);
            }
            else
            {
                xElement.SetAttributeValue("StartDateTime", timeModel.StartDateTime.ToStandardString());
                xElement.SetAttributeValue("StopDateTime", timeModel.StopDateTime.ToStandardString());
                xElement.SetAttributeValue("Duration", timeModel.Duration.ToStandardString());

            }
            SaveChanges();
            ProjectService.CalculateTotalDuration(project.Id.ToString());
        }

        private static XElement GetElement(string id)
        {
            return GetDataBaseXDocumentInstance
                .Descendants("Time")
                .FirstOrDefault(q => q.HasAttributes && q.Attribute("Id") != null && q.Attribute("Id").Value
                                .Equals(id, StringComparison.InvariantCultureIgnoreCase));
        }
        private static XElement GetElement(string startDateTime, string stopDateTime)
        {
            return GetDataBaseXDocumentInstance
                .Descendants("Time")
                .FirstOrDefault(q => q.HasAttributes && 
                    q.Attribute("StartDateTime") != null && q.Attribute("StartDateTime").Value.Equals(startDateTime, StringComparison.InvariantCultureIgnoreCase) &&
                    q.Attribute("StartDateTime") != null && q.Attribute("StopDateTime").Value.Equals(stopDateTime, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
