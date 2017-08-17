using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    public class InvoiceModel

    {
        public IList<InvoiceModel> Invoices { get; set; }
        public string SubscriberNo { get; set; }

        public long InvoiceAmount { get; set; }

        public string InvoiceDate { get; set; }

        public string InvoicePeriod { get; set; }

        public string InvoiceNo { get; set; }


    }
}