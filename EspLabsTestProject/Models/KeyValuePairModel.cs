using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EspLabsTestProject.Models
{
    public class KeyValuePairModel
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public string KeyValuePair {
            get
            {
                return $"{Key} {"="} {Value}";
            }
           
        }
    }
}
