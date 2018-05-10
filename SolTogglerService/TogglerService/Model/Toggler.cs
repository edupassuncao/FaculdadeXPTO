using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TogglerService.Model
{
    public class Toggler
    {
        public int Id { get; set; }
        public string  NameButton { get; set; }
        public string Restricted { get; set; }
        public string Allowed { get; set; }
        public bool IsOn { get; set; }
    }
}
