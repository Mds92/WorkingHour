using System;
using System.Linq;
using System.Xml.Linq;
using WorkingHour.Assets;
using WorkingHour.Data.Models;

namespace WorkingHour.Data.Services
{
    public class DraftService : BaseService
    {
        private static readonly string DraftStartDateTimeAttributeName = $"Draft{nameof(DraftModel.StartDateTime)}";
        private static readonly string DraftDurationAttributeName = $"Draft{nameof(DraftModel.Duration)}";

        public static DraftModel GetDraftModel()
        {
            var xdocument = GetDataBaseXDocumentInstance;
            var rootNode = xdocument.Descendants(Constants.RootNodeName)
                .FirstOrDefault(q => q.HasAttributes &&
                    q.Attribute(DraftStartDateTimeAttributeName) != null &&
                    q.Attribute(DraftDurationAttributeName) != null);
            if (rootNode == null) return null;
            var duration = rootNode.Attribute(DraftDurationAttributeName)?.Value.StandardTimeSpanParse() ?? TimeSpan.MinValue;
            DateTime.TryParse(rootNode.Attribute(DraftStartDateTimeAttributeName)?.Value, out DateTime startDateTime);
            return new DraftModel
            {
                StartDateTime = startDateTime,
                Duration = duration
            };
        }

        public static void Save(DraftModel model)
        {
            var xdocument = GetDataBaseXDocumentInstance;
            var xElement = GetRootElement();
            if (model.StartDateTime != DateTime.MinValue)
                xElement.SetAttributeValue(DraftStartDateTimeAttributeName, model.StartDateTime.ToStandardString());
            if (model.Duration != TimeSpan.MinValue)
                xElement.SetAttributeValue(DraftDurationAttributeName, model.Duration.ToStandardString());
            SaveChanges();
        }

        public static void Clear()
        {
            var xdocument = GetDataBaseXDocumentInstance;
            var xElement = GetRootElement();
            xElement.SetAttributeValue(DraftStartDateTimeAttributeName, "");
            xElement.SetAttributeValue(DraftDurationAttributeName, "");
            SaveChanges();
        }

        private static XElement GetRootElement()
        {
            return GetDataBaseXDocumentInstance.Descendants(Constants.RootNodeName).First();
        }
    }
}
