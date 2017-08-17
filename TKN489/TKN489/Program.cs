using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TKN489.Controller;

namespace TKN489
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TKN489());

            TKN489View view = new TKN489View();
            view.Visible = false;
            TKN489Controller controller = new TKN489Controller(view);
            Application.EnableVisualStyles();
            view.ShowDialog();

        }
    }
}
