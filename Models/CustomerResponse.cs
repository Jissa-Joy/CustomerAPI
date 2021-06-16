using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    class CustomerResponse
    {
        public bool success { get; set; }
        public Customer data { get; set; }
        public string message { get; set; }

    }
}
