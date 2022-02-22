using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpD
{
    public class HttpClientStream
    {
        private readonly HttpClient _httpClient;

        private HttpMethod _method;

        public HttpClient HttpClient => _httpClient;
        public HttpMethod Method => _method;

        public HttpClientStream(HttpMethod method, string url="http://127.0.0.1:8000")
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.BaseAddress = new Uri(url);
            _method = method;
        }

        public StreamReader SendMessage(string message="")
        {
            HttpRequestMessage request = new HttpRequestMessage(_method, _httpClient.BaseAddress);
            //var content = new FormUrlEncodedContent();
            StreamReader reader = new StreamReader(request.Content.ReadAsStream());
            return reader;
        }

        public string ResponseFromStream(StreamReader stream)
        {
            string res = stream.ReadToEnd();
            stream.Close();
            return res;
        }
    }
}