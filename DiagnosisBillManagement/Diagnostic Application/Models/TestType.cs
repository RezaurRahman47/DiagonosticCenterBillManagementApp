using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagnostic_Application.Models {
    [Serializable]
    public class TestType {
        public int Id { get; set; }
        public string TestTypeName { get; set; }
    }
}