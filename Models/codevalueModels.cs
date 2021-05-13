using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestTestMVC.Models
{
    public class CodeValue
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Value { get; set; }
    }

    public class CodeValueData
    {
        public int Code { get; set; }
        public string Value { get; set; }
        //

    }

    public class CVData
    {
        public Dictionary<string, string> Data {get; set;}
    }
}
