using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Controller;

namespace WindowsFormsApplication1
{
    public partial class InvoiceView : Form, IInvoiceView
    {
        InvoiceController controller;

        public InvoiceView()
        {
            InitializeComponent();
        }

        public void SetController(InvoiceController cont)
        {
            controller = cont;
        }
        private void button1_Click(object sender, EventArgs e)
        {
         
            controller.ReadData();
        }

  


        private void SearchInvoices_Click(object sender, EventArgs e)
        {
            
            controller.SearchBySubscriberNo(txtInvoiceNumber.Text);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region [Grid Helper ]
        public void AddInvoicesToGrid(InvoiceModel invoice)
        {
   
            ListViewItem parent;
            parent = listView.Items.Add(invoice.SubscriberNo);
            parent.SubItems.Add(invoice.InvoiceAmount.ToString());
            parent.SubItems.Add(invoice.InvoiceDate);
            parent.SubItems.Add(invoice.InvoicePeriod);
            parent.SubItems.Add(invoice.SubscriberNo);
        }
        public void AddLogsToGrid(LogModel log)
        {

          
            ListViewItem parent;
            parent = listView.Items.Add(log.RecordLine.ToString());
            parent.SubItems.Add(log.ExceptionField);
            parent.SubItems.Add(log.Exception);
        }

        public void InvoiceHeader()
        {

            listView.Columns.Clear();
            listView.Columns.Add("Abone Numarası", 150, HorizontalAlignment.Left);
            listView.Columns.Add("Borç Yükleme Tutarı", 150, HorizontalAlignment.Left);
            listView.Columns.Add("Son ödeme tarihi", 100, HorizontalAlignment.Left);
            listView.Columns.Add("Dönem Yıl", 150, HorizontalAlignment.Left);
            listView.Columns.Add("Fatura No", 150, HorizontalAlignment.Left);
            listView.Items.Clear();

     
        }

        public void LogHeader()
        {

            listView.Columns.Clear();
            listView.Columns.Add("Hatalı Kayıt Sırası", 150, HorizontalAlignment.Left);
            listView.Columns.Add("Hata Alanı", 150, HorizontalAlignment.Left);
            listView.Columns.Add("Hata Sebebi", 150, HorizontalAlignment.Left);
            listView.Items.Clear();


        }


        public void ShowInformation(string Info)
        {
            textboxInfo.Text = "Toplam " + Info + " Kayıt Aktarıldı";
        }

        public void ShowInformation(long amount)
        {
            textboxInfo.Text = "Toplam Borç Miktarı : " + amount;
        }
        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            controller.ShowAllInvoices();
        }
    }
}
