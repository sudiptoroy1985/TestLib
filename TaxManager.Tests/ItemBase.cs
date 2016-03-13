using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TaxManager.Tests
{
    public class ItemBase
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsExemptOffAllTaxes { get; set; }

    }
    


}
