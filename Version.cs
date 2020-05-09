using System;
using System.Collections.Generic;
using System.Text;

namespace VersionManager
{
    public class Version
    {
        public String Id { get; set; }
        public String Value { get; set; }
        public String Date { get; set; }
        public List<String> Items { get; set; }
    }
}
