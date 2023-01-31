using System.Net;

namespace Gestran.Middlewares
{
    public class CustomResponse
    {
        public object Data { get; set; }
        public string Status { get; set; } = "Sucesso";
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool HasError => Errors.Count > 0;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
