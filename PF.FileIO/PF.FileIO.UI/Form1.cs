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

            // Displays a SaveFileDialog so the user can save the text

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text File|*.txt";
            saveFileDialog1.Title = "Save an Text File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves via a FileStream created by the OpenFile method.
                FileStream fs = (FileStream)saveFileDialog1.OpenFile();
                // NOTE that the FilterIndex property is one-based.
                (saveFileDialog1.FilterIndex)
                {
                    this.menuSaveAs.Text.Save(fs,

         );
                    fs.Close();


                    StreamReader streamReader;
                    while (!streamReader.EndOfStream)
                    {

                    }

                }


            }
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
            
  