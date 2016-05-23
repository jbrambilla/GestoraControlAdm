using System.Web;
using System.Web.Optimization;

namespace EGestora.GestoraControlAdm.UI.Site
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/sb-admin-2.js",
                        "~/Scripts/metisMenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquerymask").Include(
                        "~/Scripts/jquery.mask.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/sb-admin-2.css",
                      "~/Content/metisMenu.css",
                      "~/Content/font-awesome/css/font-awesome.css"));

            ///////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////BUNDLE DO NOVO LAYOUT////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////

            bundles.Add(new StyleBundle("~/Content/principal").IncludeDirectory("~/Content/smartadmin/css", "*.min.css"));

            bundles.Add(new ScriptBundle("~/scripts/smartadmin").Include(
                "~/Scripts/smartadmin/app.config.js",
                "~/Scripts/smartadmin/plugin/jquery-touch/jquery.ui.touch-punch.min.js",
                "~/Scripts/smartadmin/bootstrap/bootstrap.min.js",
                "~/Scripts/smartadmin/notification/SmartNotification.min.js",
                "~/Scripts/smartadmin/smartwidgets/jarvis.widget.min.js",
                "~/Scripts/smartadmin/plugin/jquery-validate/jquery.validate.min.js",
                "~/Scripts/smartadmin/plugin/masked-input/jquery.maskedinput.min.js",
                "~/Scripts/smartadmin/plugin/select2/select2.min.js",
                "~/Scripts/smartadmin/plugin/bootstrap-slider/bootstrap-slider.min.js",
                "~/Scripts/smartadmin/plugin/bootstrap-progressbar/bootstrap-progressbar.min.js",
                "~/Scripts/smartadmin/plugin/msie-fix/jquery.mb.browser.min.js",
                "~/Scripts/smartadmin/plugin/fastclick/fastclick.min.js",
                "~/Scripts/smartadmin/app.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/full-calendar").Include(
                "~/Scripts/smartadmin/plugin/moment/moment.min.js",
                "~/Scripts/smartadmin/plugin/fullcalendar/jquery.fullcalendar.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/charts").Include(
                "~/Scripts/smartadmin/plugin/easy-pie-chart/jquery.easy-pie-chart.min.js",
                "~/Scripts/smartadmin/plugin/sparkline/jquery.sparkline.min.js",
                "~/Scripts/smartadmin/plugin/morris/morris.min.js",
                "~/Scripts/smartadmin/plugin/morris/raphael.min.js",
                "~/Scripts/smartadmin/plugin/flot/jquery.flot.cust.min.js",
                "~/Scripts/smartadmin/plugin/flot/jquery.flot.resize.min.js",
                "~/Scripts/smartadmin/plugin/flot/jquery.flot.time.min.js",
                "~/Scripts/smartadmin/plugin/flot/jquery.flot.fillbetween.min.js",
                "~/Scripts/smartadmin/plugin/flot/jquery.flot.orderBar.min.js",
                "~/Scripts/smartadmin/plugin/flot/jquery.flot.pie.min.js",
                "~/Scripts/smartadmin/plugin/flot/jquery.flot.tooltip.min.js",
                "~/Scripts/smartadmin/plugin/dygraphs/dygraph-combined.min.js",
                "~/Scripts/smartadmin/plugin/chartjs/chart.min.js",
                "~/Scripts/smartadmin/plugin/highChartCore/highcharts-custom.min.js",
                "~/Scripts/smartadmin/plugin/highchartTable/jquery.highchartTable.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/datatables").Include(
                "~/Scripts/smartadmin/plugin/datatables/jquery.dataTables.min.js",
                "~/Scripts/smartadmin/plugin/datatables/dataTables.colVis.min.js",
                "~/Scripts/smartadmin/plugin/datatables/dataTables.tableTools.min.js",
                "~/Scripts/smartadmin/plugin/datatables/dataTables.bootstrap.min.js",
                "~/Scripts/smartadmin/plugin/datatable-responsive/datatables.responsive.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/jq-grid").Include(
                "~/Scripts/smartadmin/plugin/jqgrid/jquery.jqGrid.min.js",
                "~/Scripts/smartadmin/plugin/jqgrid/grid.locale-en.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/forms").Include(
                "~/Scripts/smartadmin/plugin/jquery-form/jquery-form.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/smart-chat").Include(
                "~/Scripts/smartadmin/smart-chat-ui/smart.chat.ui.min.js",
                "~/Scripts/smartadmin/smart-chat-ui/smart.chat.manager.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/vector-map").Include(
                "~/Scripts/smartadmin/plugin/vectormap/jquery-jvectormap-1.2.2.min.js",
                "~/Scripts/smartadmin/plugin/vectormap/jquery-jvectormap-world-mill-en.js"
                ));

            BundleTable.EnableOptimizations = true;


        }
    }
}
