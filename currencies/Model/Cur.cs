using System;
using Newtonsoft.Json;

namespace currencies.Model
{
    public class Cur
    {
        public string code { get; set; }
        public string numeric { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public int decimals { get; set; }
        public string symbol { get; set; }
    }
}
