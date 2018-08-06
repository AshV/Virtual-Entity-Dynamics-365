using Microsoft.Data.Edm;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Batch;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using VirtualEntityWebAPI.Models;


namespace VirtualEntityWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
         //   config.Routes.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            config.EnsureInitialized();
        }
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "Sample";
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<Person>("Persons");
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
}
