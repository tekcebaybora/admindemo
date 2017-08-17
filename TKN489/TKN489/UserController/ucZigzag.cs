using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TKN489.UserController
{
    public partial class ucZigzag : UserControl
    {
        private static ucZigzag _instance;

        public static ucZigzag Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucZigzag();
                return _instance;
            }
        }
        public ucZigzag()
        {
            InitializeComponent();
        }

        private void btnZigZag_Click(object sender, EventArgs e)
        {
            string[] array201 = new string[201];
            for (int i = 0; i <= 200; i++)
            {
                if (i == 0)
                {
                    array201[i] = i.ToString();
                }
                else if (i % 3 == 0)
                {
                    array201[i] = "zig";
                    if (i % 5 == 0 && i < 100)
                    {
                        array201[i] = "zigzag";
                    }
                    else if (i % 5 == 0 && i > 100)
                    {
                        array201[i] = "zagzig";
                    }
                }
                else if (i % 5 == 0)
                {
                    array201[i] = "zag";

                }

                else
                    array201[i] = i.ToString();
            }

            for (int i = 0; i <= 200; i++)
            {
                ListViewItem item = new ListViewItem(array201[i].ToString());
                listZigZag.Items.Add(item.Text);
            }
        }

        private void listZigZag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
