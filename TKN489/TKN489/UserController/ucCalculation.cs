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
    public partial class ucCalculation : UserControl 
    {
        private static ucCalculation _instance;
        TKN489Controller _controller = new TKN489Controller();
        public static ucCalculation Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucCalculation();
                return _instance;
            }
        }

        public ucCalculation()
        {
            InitializeComponent();
        }

        private void txtX_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtY_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtZ_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtT_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            int z = 0;
            bool AllDigit = true;
            
            if (_controller.CheckDigit(txtX.Text))
            {
                 x = Int32.Parse(txtX.Text);
                
            }
            else
            {
                AllDigit = false;
                MessageBox.Show("X must be Integer");
            }
            if (_controller.CheckDigit(txtY.Text))
            {
                 y = Int32.Parse(txtY.Text);
            }
            else
            {
                AllDigit = false;
                MessageBox.Show("Y must be Integer");
            }
            if (_controller.CheckDigit(txtZ.Text))
            {
                 z = Int32.Parse(txtZ.Text);
            }
            else
            {
                AllDigit = false;
                MessageBox.Show("Z must be Integer");
            }
            if (AllDigit)
            {
                int t = (x + y) * z;
                txtT.Text = t.ToString();
            }
            else
                txtT.Text = "Calculation Error";
            
        }

        public void SetController(TKN489Controller controller)
        {
            throw new NotImplementedException();
        }

        public void SetUserController(Panel panel)
        {
            throw new NotImplementedException();
        }


    }
}
