using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Controller;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1
{
    public interface IInvoiceView
    {
        void InvoiceHeader();

        void LogHeader();

      

        void AddInvoicesToGrid(InvoiceModel invoice);

        void AddLogsToGrid(LogModel invoice);

        void SetController(InvoiceController controller);

        void ShowInformation(string Info);

        void ShowInformation(long Info);



    }
}
