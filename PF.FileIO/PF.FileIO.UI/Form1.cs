using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PF.FileIO.UI
{
    public partial class frmFileIO : Form
    {
        public frmFileIO()
        {
            InitializeComponent();
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new stream writer variable
                StreamWriter streamWriter;
                // Associate the streamwriter with a file.
                streamWriter = File.AppendText("c:\\Users\\Public\\MyFile.txt");
                //write the data to the file.
                streamWriter.WriteLine(txtInfo.Text);
                //Close and cleanup
                streamWriter.Close();
                streamWriter = null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void ShowError (Exception exception)
        {
            lblStatus.Text = exception.Message;
            lblStatus.ForeColor = Color.Red;
        }
    }
}
