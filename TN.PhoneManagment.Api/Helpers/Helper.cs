using TN.PhoneManagment.Contact.Enum;

namespace TN.PhoneManagment.Api.Helpers
{
    public sealed class Helper
    {
        public static readonly Dictionary<Status, string> _statusNameDictionary = new Dictionary<Status, string>()
        {
            {Status.Submitted, "Submitted"},
            {Status.InTransit, "In Transit"},
            {Status.Delivered, "Delevered"}
        };
    }
}
