using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Group
    {
        public int groupNumber { get; set; }
        public int identifierInGroup { get; set; }
        public string prop1 { get; set; }
        public string prop2 { get; set; }
        public string prop3 { get; set; }

        public Group() { }

        public Group(int groupNumber, int identifierInGroup, string prop1, string prop2, string prop3)
        {
            this.groupNumber = groupNumber;
            this.identifierInGroup = identifierInGroup;
            this.prop1 = prop1;
            this.prop2 = prop2;
            this.prop3 = prop3;
        }

    }
}