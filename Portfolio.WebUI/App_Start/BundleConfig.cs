using System.Web;
using System.Web.Optimization;

namespace Portfolio.WebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Scripts
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                        "~/Content/Common/jquery/query-{version}.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Bundles/jqueryval").Include(
                        "~/Content/Common/jquery/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/Scripts/jqueryui").Include(
                        "~/Content/Common/jquery/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                      "~/Content/Common/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/masonry").Include(
                      "~/Content/Website/Scripts/masonry/masonry.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Website/main").Include(
                      "~/Content/Website/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/Scripts/swipedetect").Include(
                      "~/Content/Website/Scripts/swipedetect.js"));

            bundles.Add(new ScriptBundle("~/Scripts/masonry").Include(
                      "~/Content/Website/Scripts/masonry/masonry.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Dashboard/main").Include(
                      "~/Content/Dashboard/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/Scripts/dropbox").Include(
                      "~/Content/Dashboard/Scripts/dropbox/dropbox.js"));

            bundles.Add(new ScriptBundle("~/Scripts/tinymce").Include(
                      "~/Content/Dashboard/Scripts/tinymce/tinymce.min.js"));

            //Styles
            bundles.Add(new StyleBundle("~/Styles/Website/css").Include(
                      "~/Content/Website/Styles/style.css"));

            bundles.Add(new StyleBundle("~/Styles/Dashboard/css").Include(
                      "~/Content/Common/bootstrap/css/bootstrap.css",
                      "~/Content/Dashboard/Styles/style.css"));

            bundles.Add(new StyleBundle("~/Styles/font-awesome").Include(
                      "~/Content/Common/font-awesome-4.4.0/css/font-awesome.css"));
        }
    }
}
