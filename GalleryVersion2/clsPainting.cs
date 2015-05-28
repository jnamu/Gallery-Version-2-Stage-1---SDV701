using System;
//using System.Windows.Forms;

namespace GalleryVersion2
{
    [Serializable()] 
    public class clsPainting : clsWork
    {
        public delegate void LoadPaintingFormDelegate(clsPainting prPainting);
        public static LoadPaintingFormDelegate LoadPaintingForm;

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
        //private frmPainting _PaintDialog;

        //public override void EditDetails()
        //{
        //    if (paintDialog == null)
        //    {
        //        paintDialog = new frmPainting();
        //    }
        //    paintDialog.SetDetails(_Name, _Date, _Value, _Width, _Height, _Type);
        //    if(paintDialog.ShowDialog() == DialogResult.OK)
        //    {
        //       paintDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Width, ref _Height, ref _Type);
        //    }
        //}

        public override void EditDetails()
        {
            LoadPaintingForm(this);
            //if (_PaintDialog == null)
            //    _PaintDialog = frmPainting.Instance;
            //_PaintDialog.SetDetails(this);
        }
    }
}
