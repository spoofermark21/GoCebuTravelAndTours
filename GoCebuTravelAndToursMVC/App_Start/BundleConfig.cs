﻿using System.Web;
using System.Web.Optimization;

namespace GoCebuTravelAndToursMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/fontawesome-rating.js",
                        "~/Scripts/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            /*bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap-flatly.css",
                    "~/Content/site.css"));*/

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.min.css",
                    "~/Content/bootflat.min.css",
                    "~/Content/site.css",
                    "~/Content/bootflat.site.min.css",
                    "~/Content/font-awesome.min.css"
                    ));

            BundleTable.EnableOptimizations = true;

        }
    }
}
