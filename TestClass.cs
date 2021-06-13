// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System;

namespace Tests
{

    public class Tests
    {

        string auth = "{\"email\": \"user7@sector36.com\", \"password\":\"user@007\"}";
        string baseURL = "http://api.qaauto.co.nz/api";
        string version = "v1";


        [Test]
        public void Auth()
        {
            var client = new RestClient($"{baseURL}/{version}/auth/login");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //setting up header
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGkucWFhdXRvLmNvLm56XC9hcGlcL3YxXC9hdXRoXC9sb2dpbiIsImlhdCI6MTYyMzExMDczMSwiZXhwIjoxNjIzMTE0MzMxLCJuYmYiOjE2MjMxMTA3MzEsImp0aSI6IldrMHkzQ1d4TDVra3dCNU8iLCJzdWIiOjQ0LCJwcnYiOiIyM2JkNWM4OTQ5ZjYwMGFkYjM5ZTcwMWM0MDA4NzJkYjdhNTk3NmY3In0.Y_9JXN5VgjTgDNCbpAr21Rr05Indapcxx6Le_0VM6U0");
            //body
            request.AddParameter("application/json", auth, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}