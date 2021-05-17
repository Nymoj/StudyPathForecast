using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using StudyPathForecast.Database;

namespace StudyPathForecast
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Connections.Initiate();
            ID3.CSID3Algorithm csid3 = new ID3.CSID3Algorithm();
            ID3.CSID3Algorithm.Root = csid3.ID3(ID3.CSModel.GetData(), ID3.CSModel.PredictiveProperties, "root");
        }

        void Application_End(object sender, EventArgs e)
        {
            Connections.Destroy();
        }
    }
}