using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class HttpResponseHelper
    {
        internal class MResult
        {
            public string Message { get; set; }
            public object Result { get; set; }
        }

        internal static ObjectResult Create(HttpStatusCode status, string message = "", object result = null)
        {

            if (result == null)
            {
                result = new { };
            }

            var mResult = new MResult { Message = message, Result = result };

            return new ObjectResult(mResult)
            {
                StatusCode = (int)status
            };

        }
    }
}
