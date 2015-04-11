﻿using System.Web.Optimization;

namespace WebAPI2Angular
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/vendor/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/vendor/bootstrap.js",
                      "~/Scripts/vendor/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.css",
                      "~/Content/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/angular").Include(
                      "~/Scripts/vendor/angular.min.js",
                      "~/Scripts/vendor/angular-ui-router.min.js",
                      "~/Scripts/vendor/angular-animate.min.js",
                      "~/Scripts/vendor/angular-resource.min.js",
                      "~/Scripts/vendor/loading-bar.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/app/configs").IncludeDirectory(
                      "~/Scripts/app/configs/",
                      "*.js",
                      true));

            bundles.Add(new ScriptBundle("~/bundles/app/services").IncludeDirectory(
                      "~/Scripts/app/services/",
                      "*.js",
                      true));
            bundles.Add(new ScriptBundle("~/bundles/app/controllers").IncludeDirectory(
                      "~/Scripts/app/controllers/",
                      "*.js",
                      true));

            bundles.Add(new ScriptBundle("~/bundles/app/filters").IncludeDirectory(
                      "~/Scripts/app/filters/",
                      "*.js",
                      true));

            bundles.Add(new ScriptBundle("~/bundles/app/directives").IncludeDirectory(
                      "~/Scripts/app/directives/",
                      "*.js",
                      true));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
