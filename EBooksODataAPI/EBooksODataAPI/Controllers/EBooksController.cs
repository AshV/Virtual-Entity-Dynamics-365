using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;

using Microsoft.Data.OData;

using EBooksODataAPI.DB;

namespace EBooksODataAPI.Controllers
{
    public class EBooksController : ODataController
    {
        public IHttpActionResult Get()
        {
            return Ok(EBookDB.Instance.EBooks.AsQueryable());
        }
    }
}
