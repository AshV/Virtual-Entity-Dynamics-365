using System;
using Microsoft.OData.Edm;
using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using EBooksODataAPI.Models;

namespace EBooksODataAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("odata", null, GetEdmModel());
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            config.EnsureInitialized();
        }
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "EBooksODataAPI";
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<EBook>("EBooks");

            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
}
