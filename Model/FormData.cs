using System.Collections.Generic;

namespace PavluqueOrderGenerator.Model
{
    public class FormData
    {
        public List<string> Skus { get; set; }
        public List<string> Types { get; set; }
        public List<string> Sizes { get; set; }
        public List<int> Quantities { get; set; }
    }
}