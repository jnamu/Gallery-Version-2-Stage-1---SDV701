using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GalleryVersion2
{
    sealed public partial class frmSculpture : GalleryVersion2.frmWork
    {     
        private frmSculpture()
        {
            InitializeComponent();
        }

        public static readonly frmSculpture Instance = new frmSculpture();

        public static void Run(clsSculpture prSculpture)
        {
            Instance.SetDetails(prSculpture);
        }

        //public virtual void SetDetails(string prName, DateTime prDate, decimal prValue,
        //                       float prWeight, string prMaterial)
        //{
        //    base.SetDetails(prName, prDate, prValue);
        //    txtWeight.Text = Convert.ToString(prWeight);
        //    txtMaterial.Text = prMaterial;
        //}

        //public virtual void GetDetails(ref string prName, ref DateTime prDate, ref decimal prValue,
        //                               ref float prWeight, ref string prMaterial)
        //{
        //    base.GetDetails(ref prName, ref prDate, ref prValue);
        //    prWeight = Convert.ToSingle(txtWeight.Text);
        //    prMaterial = txtMaterial.Text;
        //}

        protected override void updateForm()
        {
            base.updateForm();
            clsSculpture lcWork = (clsSculpture)_Work;
            txtWeight.Text = lcWork.Weight.ToString();
            txtMaterial.Text = lcWork.Material;
        }

        protected override void pushData()
        {
            base.pushData();
            clsSculpture lcWork = (clsSculpture)_Work;
            lcWork.Weight = Single.Parse(txtWeight.Text);
            lcWork.Material = txtMaterial.Text;
        }

    }
}

