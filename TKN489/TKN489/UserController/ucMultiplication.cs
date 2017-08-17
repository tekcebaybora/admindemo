using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TKN489.Controller;

namespace TKN489.UserController
{
    public partial class ucMultiplication : UserControl
    {
        private static ucMultiplication _instance;
        TKN489Controller _controller = new TKN489Controller();

        public static ucMultiplication Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucMultiplication();
                return _instance;
            }
        }

        public ucMultiplication()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

            if (_controller.CheckDigitPositive(txtX.Text))
            {
                int Number = Int32.Parse(txtX.Text);

                if(Number<=15)
                MultiplicationGrid(Number);
                else
                MessageBox.Show("Number must be between 1 to 15");
            }
            else
                MessageBox.Show("Number must be positive Integer");

        }

        private void MultiplicationGrid(int x)
        {

            listView.Clear();
            ListViewItem item;
            for (int i = 1; i <= x; i++)
            {
                listView.Columns.Add(i.ToString());
                item = new ListViewItem();
                for (int j = 1; j <= x; j++)
                {
                    if (j == 1)
                    {
                        item.Text = (i * j).ToString();
                    }
                    else
                    {
                        item.SubItems.Add((i * j).ToString());
                    }


                }
                listView.Items.Add(item);
            }
        }
    }
}
