using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TKN489.UserController
{
    public partial class ucReadsort : UserControl
    {
        private static ucReadsort _instance;
        private List<double> list = new List<double>();
        private List<string> StringNumbers = new List<string>();
        ListViewItem item;
        public static ucReadsort Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucReadsort();
                return _instance;
            }
        }
        public ucReadsort()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                string file = openFileDialog1.FileName;
                String fileExtension = System.IO.Path.GetExtension(file).ToLower();
                if (fileExtension != ".txt")
                {
                    MessageBox.Show("The file type is not txt");
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

                                lineNumber++;
                                List<string> splitStrings = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
                                StringNumbers.AddRange(splitStrings);

                            }

                            sr.Close();
                        }
                     
                      
                    }
                    catch (IOException ex)
                    {
                        Console.Write(ex.ToString());
                    }
         
            
                listBox1.DataSource = StringNumbers;
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            list = StringNumbers.Select(x => double.Parse(x)).OrderByDescending(x => x).ToList();
            listBox1.DataSource = list;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
