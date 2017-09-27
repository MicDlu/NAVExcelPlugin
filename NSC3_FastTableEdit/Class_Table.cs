using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSC3_FastTableEdit
{
    static public class Class_Table
    {
        static public string tableNo;
        static public string tableName;
        static public List<Class_Column> tableColumns;
    }

    public class Class_Column
    {
        public string TableNo;
        public string No;
        public string TableName;
        public string FieldName;
        public string Type;
        public string Len;
        public string Class;
        public string Enabled;
        public string FieldCaption;
        public string OptionString;
    }
}
