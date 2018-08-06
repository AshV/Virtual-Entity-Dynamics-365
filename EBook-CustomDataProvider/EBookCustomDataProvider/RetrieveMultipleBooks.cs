using EBookCustomDataProvider.Database;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Extensions;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookCustomDataProvider
{
    public class RetrieveMultipleBooks : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracer = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);
            EBooksDB.Instance.Initialize();

            try
            {
                QueryExpression query = context.InputParameterOrDefault<QueryExpression>("Query");

                var visitor = new SearchVisitor();
                query.Accept(visitor);

                EntityCollection results = new EntityCollection();

                results.Entities.AddRange(EBooksDB.Instance.Ebooks.Entities);
                context.OutputParameters["BusinessEntityCollection"] = results;
            }
            catch (Exception e)
            {
                throw new InvalidPluginExecutionException(e.Message);
            }
        }
    }
}