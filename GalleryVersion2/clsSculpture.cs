using System;
//using System.Windows.Forms;

namespace GalleryVersion2
{
    [Serializable()] 
    public class clsSculpture : clsWork
    {
        public delegate void LoadSculptureFormDelegate(clsSculpture prSculpture);
        public static LoadSculptureFormDelegate LoadSculptureForm;

        private float _Weight;
        public float Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        private string _Material;
        public string Material
        {
            get { return _Material; }
            set { _Material = value; }
        }

        //[NonSerialized()]
        //private frmSculpture _SculptureDialog;

        //public override void EditDetails()
        //{
        //    if (sculptureDialog == null)
        //    {
        //        sculptureDialog = new frmSculpture();
        //    }
        //    sculptureDialog.SetDetails(_Name, _Date, _Value, _Weight, _Material);
        //    if(sculptureDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        sculptureDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Weight, ref _Material);
        //    }

        //}

        public override void EditDetails()
        {
            LoadSculptureForm(this);
            //if (_SculptureDialog == null)
            //    _SculptureDialog = frmSculpture.Instance;
            //_SculptureDialog.SetDetails(this);
        }
    }
}