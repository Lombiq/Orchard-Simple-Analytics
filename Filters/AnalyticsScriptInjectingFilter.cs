using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Settings;
using Orchard.UI.Admin;
using Orchard.UI.Resources;
using Orchard.ContentManagement;
using Lombiq.SimpleAnalytics.Models;

namespace Lombiq.SimpleAnalytics.Filters
{
    public class AnalyticsScriptInjectingFilter : FilterProvider, IResultFilter
    {
        private readonly ISiteService _siteService;
        private readonly IResourceManager _resourceManager;


        public AnalyticsScriptInjectingFilter(
            ISiteService siteService,
            IResourceManager resourceManager)
        {
            _siteService = siteService;
            _resourceManager = resourceManager;
        }
        
		
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            // Should only run on a full view rendering result only.
            if (!(filterContext.Result is ViewResult)) return;

            var settings = _siteService.GetSiteSettings().As<AnalyticsSettingsPart>();

            if (!settings.IncludeOnAdmin && AdminFilter.IsApplied(filterContext.RequestContext)) return;

            if (string.IsNullOrEmpty(settings.AnalyticsScript)) return;

            // In case you haven't seen javascript in an MVC result filter today.
            _resourceManager.RegisterHeadScript("<script type=\"text/javascript\">" + settings.AnalyticsScript + "</script>");
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}