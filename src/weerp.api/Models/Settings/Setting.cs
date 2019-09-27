using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weerp.api.Models.Settings
{
    public class Setting
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string StringValue { get; set; }

        public int? IntegerValue { get; set; }

        public double? DoubleValue { get; set; }

        public DateTime? DateValue { get; set; }
    }
}
