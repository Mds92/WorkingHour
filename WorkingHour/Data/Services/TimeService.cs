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
                xElement = new XElement(Constants.TimeNodeName,
                    new XAttribute(nameof(TimeModel.Id), Guid.NewGuid().ToString()),
                    new XAttribute(nameof(TimeModel.ProjectId), timeModel.ProjectId),
                    new XAttribute(nameof(TimeModel.StartDateTime), timeModel.StartDateTime.ToStandardString()),
                    new XAttribute(nameof(TimeModel.StopDateTime), timeModel.StopDateTime.ToStandardString()),
                    new XAttribute(nameof(TimeModel.Duration), timeModel.Duration.ToStandardString()),
                    new XAttribute(nameof(TimeModel.RegisterDateTime), DateTime.Now.ToStandardString()));
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
