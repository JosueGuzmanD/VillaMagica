using System.Net;

namespace MagicVilla.Models
{
    public class APIResponse
    {
        public HttpStatusCode statusCode { get; set; }
        public bool IsOk { get; set; } = true;
        public List<string> ErrorMessages { get; set; }

        public object Result { get; set; }

    }
}
