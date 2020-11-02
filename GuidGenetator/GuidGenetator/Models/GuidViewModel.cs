using System.Collections.Generic;

namespace GuidGenetator.Models
{
    public class GuidViewModel
    {
        public int GuidQuantity { get; set; }
        public bool IsBetweenBraces { get; set; }
        public bool IsUppercase { get; set; }
        public List<string> GuidList { get; set; }
    }
}