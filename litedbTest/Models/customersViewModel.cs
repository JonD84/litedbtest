using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace litedbTest.Models
{
    public class customersViewModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public bool isActive { get; set; }
    }
}