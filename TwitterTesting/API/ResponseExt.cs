using PetTesting_API;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterTesting.API
{
    public static class ResponseExt
    {

        static public IRestResponse CreateUser(this IRestRequest request, RestClient client)
        {
            request = new RestRequest();
            request.Method = Method.POST;
            request.AddFile("body", @"C:\Users\Habito\Documents\NewUserData.json");
            request.Resource = ResoursesEnum.user.ToString();

            return client.Execute(request);
        }

        public static IRestResponse UpdateUser(this IRestRequest request, RestClient client, string username)
        {
            request = new RestRequest();
            request.Method = Method.PUT;
            request.AddFile("body", @"C:\Users\Habito\Documents\NewUserData.json");
            request.Resource = ResoursesEnum.user.ToString() + "\\" + username;

            return client.Execute(request);
        }

        public static IRestResponse DeleteUser(this IRestRequest request, RestClient client, string username)
        {
            request = new RestRequest();
            request.Method = Method.DELETE;
            request.AddFile("body", @"C:\Users\Habito\Documents\NewUserData.json");
            request.Resource = ResoursesEnum.user.ToString() + "\\" + username;

            return client.Execute(request);
        }

        public static IRestResponse GetUser(this IRestRequest request, RestClient client, string username)
        {
            request = new RestRequest();
            request.Method = Method.GET;
            request.AddFile("body", @"C:\Users\Habito\Documents\NewUserData.json");
            request.Resource = ResoursesEnum.user.ToString() + "\\" + username;

            return client.Execute(request);
        }
    }
}
