using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    class CustomerOptions
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VatNumber { get; set; }
        public DateTime CreatedFrom{ get; set; }
        public DateTime CreatedTo { get; set; }
        public int CustomerId { get; set; }

    }
}
