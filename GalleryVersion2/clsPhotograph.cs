using System;
//using System.Windows.Forms;

namespace GalleryVersion2
{
    [Serializable()]
    public class clsPhotograph : clsWork
    {
        public delegate void LoadPhotographFormDelegate(clsPhotograph prPhotograph);
        public static LoadPhotographFormDelegate LoadPhotographForm;

        private float _Width;
        public float Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        private float _Height;
        public float Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        private string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        //[NonSerialized()]
        //private frmPhotograph _PhotoDialog;

        //public override void EditDetails()
        //{
        //    if (photoDialog == null)
        //    {
        //        photoDialog = new frmPhotograph();
        //    }
        //    photoDialog.SetDetails(_Name, _Date, _Value, _Width, _Height, _Type);
        //    if(photoDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        photoDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Width, ref _Height, ref _Type);
        //    }
        //}

        public override void EditDetails()
        {
            LoadPhotographForm(this);
            //if (_PhotoDialog == null)
            //    _PhotoDialog = frmPhotograph.Instance;
            //_PhotoDialog.SetDetails(this);
        }
        
    }
}
