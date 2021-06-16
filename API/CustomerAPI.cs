
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
   public class CustomerAPI : BaseAPI
    {
        //this is create customer method 
        public string CreateCustomer(string body)
        {
            string url = $"{baseURL}/{version}/customers";
            var client = new RestClient(url);

            var request = new RestRequest(Method.POST);
            //setting up header
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {token}");
            //body
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
        public string getSingleCustomer(int id)
        {
            string url = $"{baseURL}/{version}/customers/{id}";
            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);
            //setting up header
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {token}");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
        public string getAllCustomers()
        {
            string url = $"{baseURL}/{version}/customers";
            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);
            //setting up header
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {token}");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string deleteCustomer(int id)
        {
            string url = $"{baseURL}/{version}/customers/{id}";
            var client = new RestClient(url);

            var request = new RestRequest(Method.DELETE);
            //setting up header
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {token}");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response.Content;
        }
        public string putCustomer(int id,string body)
        {
            string url = $"{baseURL}/{version}/customers/{id}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            //setting up header
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {token}");
            
            //body
            request.AddParameter("application/json",body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response.Content;
            
        }
    }
}
