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

        static class Globals
        {
            public static string filename0;
            public static int counter = 0;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File|*.txt";
            saveFileDialog.InitialDirectory = @"c:\Users\public";
            saveFileDialog.Title = "Save an Text File";
            StreamWriter streamWriter;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                streamWriter = File.CreateText(saveFileDialog.FileName);
                streamWriter.WriteLine(txtInfo.Text);

                streamWriter.Close();
                streamWriter = null;

                lblStatus.Text = "File Saved...";
                lblStatus.ForeColor = Color.Blue;

                Globals.filename0 = saveFileDialog.FileName;
                Globals.counter++;
                
            }

        }
        private void menuSave_Click(object sender, EventArgs e)
        {
            if (Globals.counter == 0) { 
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File|*.txt";
                saveFileDialog.InitialDirectory = @"c:\Users\public";
                saveFileDialog.Title = "Save an Text File";
              
                StreamWriter streamWriter;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    streamWriter = File.CreateText(saveFileDialog.FileName);
                    streamWriter.WriteLine(txtInfo.Text);

                    streamWriter.Close();
                    streamWriter = null;


                        lblStatus.Text = "File Saved...";
                        lblStatus.ForeColor = Color.Blue;

                        Globals.filename0 = saveFileDialog.FileName;
                        Globals.counter++;
                    }


            }
            catch (Exception)
            {

                throw;
            }
            }
            else
            {
                
                StreamWriter streamWriter;
                streamWriter = File.AppendText(Globals.filename0);
                streamWriter.WriteLine(txtInfo.Text);
                streamWriter.Close();
                streamWriter = null;

                lblStatus.Text = "File Saved...";
                lblStatus.ForeColor = Color.Blue;
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
        
                StreamWriter streamWriter;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    streamWriter = File.CreateText(saveFileDialog.FileName);
                    streamWriter.WriteLine(txtInfo.Text);

                    streamWriter.Close();
                    streamWriter = null;
                }

            }

            txtInfo.Clear();
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

                    lblStatus.Text = "Opened: " + openFileDialog.FileName;
                    lblStatus.ForeColor = Color.Blue;
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
            
  