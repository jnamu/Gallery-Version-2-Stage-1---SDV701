using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GalleryVersion2
{
    public partial class InputBox : Form
    {
        private string _Answer;

        public string Answer
        {
            get { return _Answer; }
            set { _Answer = value; }
        }

        public InputBox(string question)
        {
            InitializeComponent();
            lblQuestion.Text = question;
            lblError.Text = "";
            txtAnswer.Focus();
            ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _Answer = txtAnswer.Text;
            DialogResult = DialogResult.OK;
            //if (txtAnswer.Text.Length > 0 && txtAnswer.Text.Length < 2)
            //{
            //    _Answer = txtAnswer.Text;
            //    DialogResult = DialogResult.OK;
            //    this.Close();
            //}
            //else
            //{
            //    lblError.Text = "Please enter one character into the text box.";
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string getAnswer()
        {
            return _Answer;
        }
    }
}