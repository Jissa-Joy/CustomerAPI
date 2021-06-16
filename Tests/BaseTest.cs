// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Tests1;

namespace Tests
{
    public class BaseTest
    {
        public CustomerAPI custApi;
        public readonly static string email = "user7@sector36.com";
        public readonly static string password = "user@007";
        public string token = "";


        [OneTimeSetUp]
        public void setUp()
        {
            custApi = new CustomerAPI();
            User user = new User(email, password);
            //convert to json
            string auth = JsonConvert.SerializeObject(user);
            token = BaseAPI.AuthToken(auth);
        }
    }
}