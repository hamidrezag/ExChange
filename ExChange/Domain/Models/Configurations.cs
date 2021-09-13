using Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Configurations:BaseModel
    {
        public Config Type { get; set; }
        public string Value { get; set; }
        public string ExtraJson { get; set; }
    }
}
