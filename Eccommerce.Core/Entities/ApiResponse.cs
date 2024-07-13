using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Core.Entities
{
    public class ApiResponse
    {
        public HttpStatusCode StatuseCode { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessages { get; set; }
        public object Result { get; set; }

    }
}
