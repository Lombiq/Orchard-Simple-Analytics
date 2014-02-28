using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace Lombiq.SimpleAnalytics.Models
{
    public class AnalyticsSettingsPart : ContentPart
    {
        public string AnalyticsScript
        {
            get { return this.Retrieve(x => x.AnalyticsScript); }
            set { this.Store(x => x.AnalyticsScript, value); }
        }

        public bool IncludeOnAdmin
        {
            get { return this.Retrieve(x => x.IncludeOnAdmin); }
            set { this.Store(x => x.IncludeOnAdmin, value); }
        }
    }
}