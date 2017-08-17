using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TKN489.UserController;
using TKN489.Controller;

namespace TKN489
{
    public partial class TKN489View : Form, ITKN489View
    {
        TKN489Controller controller;
       

        public TKN489View()
        {
            InitializeComponent();
        }
        public void SetController(TKN489Controller cont)
        {
            controller = cont;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void btnReadSort_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(ucReadsort.Instance))
            {
                panel1.Controls.Add(ucReadsort.Instance);
                ucReadsort.Instance.Dock = DockStyle.Fill;
                ucReadsort.Instance.BringToFront();

            }
            else
                ucReadsort.Instance.BringToFront();
        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(ucMultiplication.Instance))
            {
                panel1.Controls.Add(ucMultiplication.Instance);
                ucMultiplication.Instance.Dock = DockStyle.Fill;
                ucMultiplication.Instance.BringToFront();

            }
            else
                ucMultiplication.Instance.BringToFront();
        }

        private void btnCalculation_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(ucCalculation.Instance))
            {
                panel1.Controls.Add(ucCalculation.Instance);
                ucCalculation.Instance.Dock = DockStyle.Fill;
                ucCalculation.Instance.BringToFront();

            }
            else
                ucCalculation.Instance.BringToFront();
        }

        private void btnZigZag_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(ucZigzag.Instance))
            {
                panel1.Controls.Add(ucZigzag.Instance);
                ucZigzag.Instance.Dock = DockStyle.Fill;
                ucZigzag.Instance.BringToFront();

            }
            else
                ucZigzag.Instance.BringToFront();
        }

        private void btnFibonacci_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(ucFibonacci.Instance))
            {
                panel1.Controls.Add(ucFibonacci.Instance);
                ucFibonacci.Instance.Dock = DockStyle.Fill;
                ucFibonacci.Instance.BringToFront();

            }
            else
                ucFibonacci.Instance.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
