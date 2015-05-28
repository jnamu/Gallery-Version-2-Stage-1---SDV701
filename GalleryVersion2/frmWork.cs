using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GalleryVersion2
{
    public partial class frmWork : Form
    {
        protected clsWork _Work;

        public frmWork()
        {
            InitializeComponent();
        }

        //public void SetDetails(string prName, DateTime prDate, decimal prValue)
        //{
        //    txtName.Text = prName;
        //    txtCreation.Text = prDate.ToShortDateString();
        //    txtValue.Text = Convert.ToString(prValue);
        //}

        public void SetDetails(clsWork prWork)
        {
            _Work = prWork;
            updateForm();
            ShowDialog();
        }

        //public void GetDetails(ref string prName, ref DateTime prDate, ref decimal prValue)
        //{
        //    prName = txtName.Text;
        //    prDate = Convert.ToDateTime(txtCreation.Text);
        //    prValue = Convert.ToDecimal(txtValue.Text);
        //}

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (isValid() == true)
            if (isValid())
            {
                //DialogResult = DialogResult.OK;
                pushData();
                Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        public virtual bool isValid()
        {
            return true;
        }

        protected virtual void updateForm()
        {
            txtName.Text = _Work.Name;
            txtCreation.Text = _Work.Date.ToShortDateString();
            txtValue.Text = _Work.Value.ToString();
        }

        protected virtual void pushData()
        {
            _Work.Name = txtName.Text;
            _Work.Date = DateTime.Parse(txtCreation.Text);
            _Work.Value = decimal.Parse(txtValue.Text);
        }
    
    }
}