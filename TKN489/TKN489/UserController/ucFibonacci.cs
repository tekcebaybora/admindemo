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
    public partial class ucFibonacci : UserControl
    {
        private static ucFibonacci _instance;
        TKN489Controller _controller = new TKN489Controller();
        public static ucFibonacci Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucFibonacci();
                return _instance;
            }
        }

        public ucFibonacci()
        {
            InitializeComponent();
        }


        private void btnGetIndex_Click(object sender, EventArgs e)
        {


            if (_controller.CheckDigitPositive(txtIndex.Text))
            {
                txtResult.Text = Fibonacci(Int32.Parse(txtIndex.Text)).ToString();
            }
            else
                MessageBox.Show("Index must be positive Integer");
            

    }

        private int Fibonacci(int number)
        {
            if (number == 0)
                return 0;
            else if (number == 1)
                return 1;
            else
            {
                return Fibonacci(number - 2) + Fibonacci(number - 1);
            }
        }

    }
}
