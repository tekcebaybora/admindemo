using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    public class LogModel

    {
        public IList<LogModel> Logs { get; set; }
        public int RecordLine { get; set; }
        public string Exception { get; set; }

        public string ExceptionField { get; set; }

        


    }
}