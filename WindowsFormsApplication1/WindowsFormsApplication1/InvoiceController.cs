using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Controller
{
    public class InvoiceController
    {
        IInvoiceView _view;
        List<InvoiceModel> Invoices = new List<InvoiceModel>();
        List<LogModel> Logs = new List<LogModel>();

        public InvoiceController(IInvoiceView view)
        {
            _view = view;
            _view.SetController(this);
        }

        public void SearchBySubscriberNo(string subscriberno)
        {
            _view.InvoiceHeader();
            long totalinvoiceamount = 0;
            foreach (var p in Invoices)
            {
                if (p.SubscriberNo == subscriberno)
                {
                    totalinvoiceamount = p.InvoiceAmount + totalinvoiceamount;
                    _view.AddInvoicesToGrid(p);

                }
            }
            _view.ShowInformation(totalinvoiceamount);
        }

        public void ShowAllInvoices()
        {
            _view.InvoiceHeader();

            foreach (var p in Invoices)
            {
                _view.AddInvoicesToGrid(p);
            }

        }


        public void ReadData()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                string file = openFileDialog1.FileName;
                String fileExtension = System.IO.Path.GetExtension(file).ToLower();
                if (fileExtension != ".txt")
                {
                    MessageBox.Show("The file not .txt");
                }
                else
                try
                {
                    int lineNumber = 0;
                    using (StreamReader sr = new StreamReader(file))
                    {

                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            bool IsCrash = false;
                            lineNumber++;


                            var InvoiceData = new InvoiceModel();

                            try
                            {
                                InvoiceData.SubscriberNo = line.Substring(2, 9);
                            }
                            catch (Exception e)
                            {
                                AddLog(e, lineNumber, "SubscriberNo");
                                IsCrash = true;
                            }
                            try
                            {
                                InvoiceData.InvoiceAmount = Convert.ToInt64(Math.Floor(Convert.ToDouble(line.Substring(19, 15))));
                            }
                            catch (Exception e)
                            {
                                AddLog(e, lineNumber, "InvoiceAmount");
                                IsCrash = true;
                            }
                            try
                            {
                                InvoiceData.InvoiceDate = line.Substring(34, 10);
                            }
                            catch (Exception e)
                            {
                                AddLog(e, lineNumber, "InvoiceDate");
                                IsCrash = true;
                            }
                            try
                            {
                                InvoiceData.InvoicePeriod = line.Substring(47, 4);
                            }
                            catch (Exception e)
                            {
                                AddLog(e, lineNumber, "InvoicePeriod");
                                IsCrash = true;
                            }
                            try
                            {
                                InvoiceData.InvoiceNo = line.Substring(51, 10);
                            }
                            catch (Exception e)
                            {
                                AddLog(e, lineNumber, "Invoice No");
                                IsCrash = true;

                            }
                            if (IsCrash == false)
                            {
                                Invoices.Add(InvoiceData);
                            }
                        }
                        sr.Close();
                    }
                }
                catch (IOException ex)
                {
                    Console.Write(ex.ToString());
                }
                if (Logs.Count > 0)
                {
                    ShowLogs();
                }

                _view.ShowInformation(Invoices.Count.ToString());
            }
        }
        #region [ Log Helper ]
        public void ShowLogs()
        {
            _view.LogHeader();
            foreach (var p in Logs)
            {

                _view.AddLogsToGrid(p);
            }
        }
        public void AddLog(Exception ex, int line, string field)
        {
            var Exceptionlog = new LogModel()
            {
                RecordLine = line,
                Exception = ex.Message,
                ExceptionField = field
            };
            Logs.Add(Exceptionlog);
        }
    }

    #endregion


}
