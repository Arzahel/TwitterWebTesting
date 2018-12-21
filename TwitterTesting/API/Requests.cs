using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using TwitterTesting;

namespace PetTesting_API
{
    class Requests
    {
        private RestClient _client;
        private RestRequest _request;
        private IRestResponse _response;
        private static Uri BaseUrl = new Uri("http://petstore.swagger.io");

        public Requests()
        {
            _client.BaseUrl = BaseUrl;
        }

        public bool CheckUserCreation()
        {
            _response = CreateUser();
            
            if (_response.StatusCode == System.Net.HttpStatusCode.OK) return true;
            else return false;

            var initialJson = JsonConvert.DeserializeObject(@"C:\Users\Habito\Documents\NewUserData.json");
            if (initialJson.Equals(JsonConvert.DeserializeObject(_response.Content)));
        }

        public IRestResponse CreateUser()
        {
            _request = new RestRequest();
            _request.Method = Method.POST;
            _request.AddFile("body", @"C:\Users\Habito\Documents\NewUserData.json");
            _request.Resource = ResoursesEnum.user.ToString();

            return _client.Execute(_request);
        }

        public IRestResponse UpdateUser(string username)
        {
            _request = new RestRequest();
            _request.Method = Method.PUT;
            _request.AddFile("body", @"C:\Users\Habito\Documents\NewUserData.json");
            _request.Resource = ResoursesEnum.user.ToString() + "\\" + username;

            return _client.Execute(_request);
        }

        public IRestResponse DeleteUser(string username)
        {
            _request = new RestRequest();
            _request.Method = Method.DELETE;
            _request.AddFile("body", @"C:\Users\Habito\Documents\NewUserData.json");
            _request.Resource = ResoursesEnum.user.ToString() + "\\" + username;

            return _client.Execute(_request);
        }

        public IRestResponse GetUser(string username)
        {
            _request = new RestRequest();
            _request.Method = Method.GET;
            _request.AddFile("body", @"C:\Users\Habito\Documents\NewUserData.json");
            _request.Resource = ResoursesEnum.user.ToString() + "\\" + username;

            return _client.Execute(_request);
        }

        private void SaveToLog()
        {
            var requestToLog = new
            {
                resource = _request.Resource,
                parameters = _request.Parameters.Select(parameter => new
                {
                    name = parameter.Name,
                    value = parameter.Value,
                    type = parameter.Type.ToString()
                }),
                method = _request.Method.ToString(),
                // This will generate the actual Uri used in the request
                uri = _client.BuildUri(_request),
            };

            var responseToLog = new
            {
                statusCode = _response.StatusCode,
                content = _response.Content,
                headers = _response.Headers,
                // The Uri that actually responded (could be different from the requestUri if a redirection occurred)
                responseUri = _response.ResponseUri,
                errorMessage = _response.ErrorMessage,
            };

            Log log = new Log();
            log.Info(string.Format("Request completed in {0} ms, Request: {1}, Response: {2}",
                10,
                JsonConvert.SerializeObject(requestToLog),
                JsonConvert.SerializeObject(responseToLog)));
        }
    }
}
