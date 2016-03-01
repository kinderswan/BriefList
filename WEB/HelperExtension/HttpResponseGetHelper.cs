using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Security.Principal;
using Newtonsoft.Json;

namespace WEB.HelperExtension
{
    public class HttpResponseGetHelper<T>
    {
        private readonly bool _isAuthenticated;
        private readonly HttpResponseMessage _response;
        private Func<Task<T>> _func;

        public HttpResponseGetHelper(bool isAuthenticated, HttpRequestMessage request)
        {
            _isAuthenticated = isAuthenticated;
            _response = request.CreateResponse();
        }

        public void Method(Func<Task<T>> task)
        {
            _func = task;
        }

        public async Task<HttpResponseMessage> Result()
        {
            if (_isAuthenticated)
            {
                _response.StatusCode = HttpStatusCode.OK;
                try
                {
                    _response.Content = new StringContent(JsonConvert.SerializeObject(await _func()));
                }
                catch (Exception)
                {
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    return _response;
                }
                _response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return _response;
            }
            _response.StatusCode = HttpStatusCode.Unauthorized;
            return _response;
        }

    }
}
