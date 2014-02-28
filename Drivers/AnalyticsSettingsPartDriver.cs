using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.SimpleAnalytics.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace Lombiq.SimpleAnalytics.Drivers
{
    public class AnalyticsSettingsPartDriver : ContentPartDriver<AnalyticsSettingsPart>
    {
        protected override DriverResult Editor(AnalyticsSettingsPart part, dynamic shapeHelper)
        {
            return Editor(part, null, shapeHelper);

        }

        protected override DriverResult Editor(AnalyticsSettingsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            return ContentShape("Parts_AnalyticsSettings_SiteSettings_Edit",
                () =>
                {
                    if (updater != null)
                    {
                        updater.TryUpdateModel(part, Prefix, null, null);
                    }

                    return shapeHelper.EditorTemplate(
                        TemplateName: "Parts.AnalyticsSettings.SiteSettings",
                        Model: part,
                        Prefix: Prefix);
                });
        }
    }
}