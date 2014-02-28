using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.SimpleAnalytics.Models;
using Orchard.ContentManagement.Handlers;

namespace Lombiq.SimpleAnalytics.Handlers
{
    public class AnalyticsSettingsPartHandler : ContentHandler
    {
        public AnalyticsSettingsPartHandler()
        {
            Filters.Add(new ActivatingFilter<AnalyticsSettingsPart>("Site"));
        }
    }
}