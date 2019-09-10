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
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File|*.txt";
            saveFileDialog.InitialDirectory = @"c:\Users\public";
            saveFileDialog.Title = "Save an Text File";
            saveFileDialog.ShowDialog();
            StreamWriter streamWriter;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                streamWriter = File.CreateText(saveFileDialog.FileName);
                streamWriter.WriteLine(txtInfo.Text);

                streamWriter.Close();
                streamWriter = null;
            }

        }
        private void menuSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File|*.txt";
                saveFileDialog.InitialDirectory = @"c:\Users\public";
                saveFileDialog.Title = "Save an Text File";
                saveFileDialog.ShowDialog();
                StreamWriter streamWriter;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    streamWriter = File.CreateText(saveFileDialog.FileName);
                    streamWriter.WriteLine(txtInfo.Text);

                    streamWriter.Close();
                    streamWriter = null;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void menuNew_Click(object sender, EventArgs e)
        {
            if (txtInfo.Text != string.Empty)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File|*.txt";
                saveFileDialog.InitialDirectory = @"c:\Users\public";
                saveFileDialog.Title = "Save an Text File";
                saveFileDialog.ShowDialog();
                StreamWriter streamWriter;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    streamWriter = File.CreateText(saveFileDialog.FileName);
                    streamWriter.WriteLine(txtInfo.Text);

                    streamWriter.Close();
                    streamWriter = null;
                }

            }

            txtInfo.Text = "";
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                StreamReader streamReader;
                lblStatus.Text = string.Empty;

                openFileDialog.Title = " Please pick a file to open.";
                openFileDialog.InitialDirectory = @"c:\\Users\public";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    streamReader = File.OpenText(openFileDialog.FileName);
                    txtInfo.Text = streamReader.ReadToEnd();
                    streamReader.Close();
                    streamReader = null;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ShowError(Exception exception)
        {
            lblStatus.Text = exception.Message;
            lblStatus.ForeColor = Color.Red;
        }

      
    }
}
            
  