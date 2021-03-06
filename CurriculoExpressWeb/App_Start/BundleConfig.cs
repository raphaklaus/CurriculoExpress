﻿using System.Web;
using System.Web.Optimization;

namespace CurriculoExpressWeb
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.maskedinput.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
            "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/myjs").Include(
            "~/Scripts/Base.js",
            "~/Scripts/cidades-estados-v0.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/base").Include(
                "~/Content/css/animate.css",
                "~/Content/css/bootstrap-theme.css",
                "~/Content/css/bootstrap-theme.min.css",
                "~/Content/css/bootstrap.css",
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/font-awesome.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/General.css"));

            bundles.Add(new StyleBundle("~/Content/login").Include(
                "~/Content/css/Login.css"));


            bundles.Add(new StyleBundle("~/Content/site").Include(
                "~/Content/css/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}