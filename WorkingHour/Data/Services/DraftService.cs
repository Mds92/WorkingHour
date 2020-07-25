using System;
using System.Linq;
using WorkingHour.Assets;
using WorkingHour.Data.Models;

namespace WorkingHour.Data.Services
{
    public class DraftService : BaseService
    {
        private static readonly string DraftStartDateTimeAttributeName = $"Draft{nameof(DraftModel.StartDateTime)}";
        private static readonly string DraftStopDateTimeAttributeName = $"Draft{nameof(DraftModel.StopDateTime)}";
        private static readonly string DraftDurationAttributeName = $"Draft{nameof(DraftModel.Duration)}";

        public static DraftModel GetDraftModel()
        {
            var xDocument = GetDataBaseXDocumentInstance;
            var rootNode = xDocument.Descendants(Constants.RootNodeName)
                .FirstOrDefault(q => q.HasAttributes &&
                    q.Attribute(DraftStartDateTimeAttributeName) != null &&
                    q.Attribute(DraftStopDateTimeAttributeName) != null &&
                    q.Attribute(DraftDurationAttributeName) != null);
            if (rootNode == null) return null;
            var duration = rootNode.Attribute(DraftDurationAttributeName)?.Value.StandardTimeSpanParse() ?? TimeSpan.MinValue;
            DateTime.TryParse(rootNode.Attribute(DraftStartDateTimeAttributeName)?.Value, out var startDateTime);
            DateTime.TryParse(rootNode.Attribute(DraftStopDateTimeAttributeName)?.Value, out var stopDateTime);
            return new DraftModel
            {
                StartDateTime = startDateTime,
                StopDateTime = stopDateTime,
                Duration = duration
            };
        }

        public static void Save(DraftModel model)
        {
            var xElement = GetRootElement();
            if (model.StartDateTime != DateTime.MinValue)
                xElement.SetAttributeValue(DraftStartDateTimeAttributeName, model.StartDateTime.ToStandardString());
            if (model.StopDateTime != DateTime.MinValue)
                xElement.SetAttributeValue(DraftStopDateTimeAttributeName, model.StopDateTime.ToStandardString());
            if (model.Duration != TimeSpan.MinValue)
                xElement.SetAttributeValue(DraftDurationAttributeName, model.Duration.ToStandardString());
            SaveChanges();
        }

        public static void Clear()
        {
            var xElement = GetRootElement();
            xElement.SetAttributeValue(DraftStartDateTimeAttributeName, "");
            xElement.SetAttributeValue(DraftStopDateTimeAttributeName, "");
            xElement.SetAttributeValue(DraftDurationAttributeName, "");
            SaveChanges();
        }
    }
}
