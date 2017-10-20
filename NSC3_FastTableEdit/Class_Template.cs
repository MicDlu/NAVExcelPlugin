using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSC3_FastTableEdit
{
    public class Class_Template
    {
        private string name;
        private int tableNo;
        private List<string> fields = new List<string>();
        public static Class_Template currentTemplate;

        public Class_Template(string name, int tableNo)
        {
            this.Name = name;
            this.TableNo = tableNo;
        }

        public Class_Template(string name, int tableNo, List<string> fields)
        {
            this.Name = name;
            this.TableNo = tableNo;
            this.Fields = fields;
        }

        public string Name { get => name; set => name = value; }
        public int TableNo { get => tableNo; set => tableNo = value; }
        public List<string> Fields { get => fields; set => fields = value; }

       
    }
}
