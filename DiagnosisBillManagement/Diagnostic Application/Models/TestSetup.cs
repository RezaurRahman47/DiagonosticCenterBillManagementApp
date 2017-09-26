using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagnostic_Application.Models {
    public class TestSetup {

        public int Id { get; set; }
        public string TestName { get; set; }
        public decimal Fee { get; set; }
        public int TestTypeId { get; set; }
        public int Count { get; set; }
    }
}