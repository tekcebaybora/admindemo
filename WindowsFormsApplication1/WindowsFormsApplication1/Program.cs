using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Controller;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InvoiceView view = new InvoiceView();
            view.Visible = false;
            InvoiceController controller = new InvoiceController(view);
            Application.EnableVisualStyles();
            view.ShowDialog();
          
          

        }
    }
}
