using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [Serializable]
    public class Customer
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string ContactNumber { set; get; }
        public DateTime BirthDate { set; get; }


    }
}
