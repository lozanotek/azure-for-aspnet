using System.Web.Optimization;

namespace Orwell.CDN
{
    public class BootstrapBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Add @Styles.Render("~/Content/bootstrap/base") in the <head/> of your _Layout.cshtml view
            // For Bootstrap theme add @Styles.Render("~/Content/bootstrap/theme") in the <head/> of your _Layout.cshtml view
            // Add @Scripts.Render("~/bundles/bootstrap") after jQuery in your _Layout.cshtml view
            // When <compilation debug="true" />, MVC4 will render the full readable version. When set to <compilation debug="false" />, the minified version will be rendered automatically
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/scripts/bootstrap*"));
            bundles.Add(new StyleBundle("~/css/bootstrap/base-style").Include("~/css/bootstrap/bootstrap.css").Include("~/css/bootstrap/bootstrap-multiselect.css"));

        }
    }
}