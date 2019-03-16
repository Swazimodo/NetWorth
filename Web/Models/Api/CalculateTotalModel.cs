using System.Collections.Generic;

namespace NetWorth.Web.Models.Api
{
    public class CalculateTotalModel
    {
        public CalculateTotalModel()
        {
            Roster = new List<RosterItem>();
            TargetCurrencyAbbrv = string.Empty;
        }

        public List<RosterItem> Roster { get; set; }
        public string TargetCurrencyAbbrv { get; set; }
    }
}
