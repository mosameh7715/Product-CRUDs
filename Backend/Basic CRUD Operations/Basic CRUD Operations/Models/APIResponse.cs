using System.Net;

namespace Basic_CRUD_Operations.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public dynamic Result { get; set; }
    }
}
