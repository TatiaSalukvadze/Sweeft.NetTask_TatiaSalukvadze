using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    internal class Country
    {
        public CountryName? name { get; set; }
        public string? region { get; set; }
        public string? subregion { get; set; }
        public double[]? latlng { get; set; }
        public double? area { get; set; }
        public long? population { get; set; }
    }

    internal class CountryName
    {
        public string? common { get; set; }
    }

