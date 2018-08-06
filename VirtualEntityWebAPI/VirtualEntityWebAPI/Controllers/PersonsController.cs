using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using VirtualEntityWebAPI.Models;
using Microsoft.Data.OData;
using VirtualEntityWebAPI.DataSource;

namespace VirtualEntityWebAPI.Controllers
{
    [EnableQuery]
    public class PersonsController : ODataController
    {
        public IHttpActionResult Get()
        {
            return Ok(SampleDataSource.Instance.Persons.AsQueryable());
        }
    }
}