// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using NUnit.Tests1;
using Newtonsoft.Json;
using FluentAssertions;

namespace Tests
{

    public class Tests : BaseTest
    {


        [Test]
        public void GetallCustomersTest()
        {

            //    string response = getAllCustomers();
        }


        //my try
        [Test]
        public void GetSingleCustomersTest()
        {
            Customer cust = new Customer();
            cust.company_name = "jisqa";
            cust.country = "AU";
            cust.currency = "aud";
            cust.default_language = "en";
            cust.phone = "11062021";
            cust.website = "www.test";
            cust.vat_number = "2021201";


            string jsonBody = JsonConvert.SerializeObject(cust);

            string responseData = custApi.CreateCustomer(jsonBody);

            CustomerResponse resp = JsonConvert.DeserializeObject<CustomerResponse>(responseData);
            int id = resp.data.id;
            string website = resp.data.website;
            string response = custApi.getSingleCustomer(id);
            
            //validation pending

            TestContext.WriteLine(website);
            Assert.AreEqual("www.test", website);
            
                }
        
        [Test]
        public void CreateCustomerTest()
        {
            Customer cust = new Customer();
            cust.company_name = "jisqa";
            cust.country = "AU";
            cust.currency = "aud";
            cust.default_language = "en";
            cust.phone = "11062021";
            cust.website = "www.test";
            cust.vat_number = "2021201";


            string jsonBody = JsonConvert.SerializeObject(cust);

            string responseData = custApi.CreateCustomer(jsonBody);
            CustomerResponse actualCustomer = JsonConvert.DeserializeObject<CustomerResponse>(responseData);
            //assertion
           // Assert.AreEqual(cust.company_name, actualCustomer.data.company_name);
          // responseData.

        }


        [Test]

        public void DeleteCustomer_Test()
        {

            Customer cust = new Customer();
            cust.company_name = "jisqa";
            cust.country = "AU";
            cust.currency = "aud";
            cust.default_language = "en";
            cust.phone = "11062021";
            cust.website = "www.test";
            cust.vat_number = "2021201";


            string jsonBody = JsonConvert.SerializeObject(cust);
            CustomerAPI custApi = new CustomerAPI();
            string responseData = custApi.CreateCustomer(jsonBody);
            CustomerResponse res = JsonConvert.DeserializeObject<CustomerResponse>(responseData);
            int id = res.data.id;
            custApi.deleteCustomer(id);
            //validation pending

        }

        [Test]
        public void putcustomer_Test()

        {
            //string updateBody = "{\"company_name\": \"jjoylearning\", \"vat_number\": \"string\", \"phone\": \"10101010\", \"website\": \"postmantutorial\",\"currency\": \"string\",\"country\": \"AU\",\"default_language\": \"en\"}";
            Customer cust = new Customer();
            cust.company_name = "jPUT";
            cust.country = "AU";
            cust.currency = "aud";
            cust.default_language = "en";
            cust.phone = "11062021";
            cust.website = "www.test";
            cust.vat_number = "2021201";

           
            string originalBody = JsonConvert.SerializeObject(cust);
            CustomerAPI custApi = new CustomerAPI();
            string responseData = custApi.CreateCustomer(originalBody);
            CustomerResponse resp= JsonConvert.DeserializeObject<CustomerResponse>(responseData);

            //Changing content for put 
            cust.phone = "14142021";
            cust.company_name = "jjPutTest";
            string modifiedBody = JsonConvert.SerializeObject(cust);
            int id = resp.data.id;

            string putResponseData = custApi.putCustomer(id, modifiedBody);

            CustomerResponse putRes = JsonConvert.DeserializeObject<CustomerResponse>(putResponseData);
           

            //Assertion is pending .. do it your self..
            Assert.Multiple(() =>
            {
                Assert.AreEqual(putRes.data.phone, cust.phone);
                Assert.AreEqual(putRes.data.company_name, cust.company_name);
            });

        }



    }
}