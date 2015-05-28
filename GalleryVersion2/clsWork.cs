using System;

namespace GalleryVersion2
{
    [Serializable()] 
    public abstract class clsWork
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private DateTime _Date = DateTime.Now;
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        private decimal _Value;
        public decimal Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public clsWork()
        {
            EditDetails();
        }

        public abstract void EditDetails();

        //public void NewWork(clsWork lcWork)
        //{
        //    frmArtist.NewWork();
        //}

        public static readonly string FACTORY_PROMPT = "Enter P for Painting, S for Sculpture and H for Photograph";

        //public static clsWork NewWork()
        //{
        //    char lcReply;
        //    InputBox inputBox = new InputBox("Enter P for Painting, S for Sculpture and H for Photograph");
        //    //inputBox.ShowDialog();
        //    //if (inputBox.getAction() == true)
        //    if (inputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        lcReply = Convert.ToChar(inputBox.getAnswer());

        //        switch (char.ToUpper(lcReply))
        //        {
        //            case 'P': return new clsPainting();
        //            case 'S': return new clsSculpture();
        //            case 'H': return new clsPhotograph();
        //            default: return null;
        //        }
        //    }
        //    else
        //    {
        //        inputBox.Close();
        //        return null;
        //    }
        //}

        public static clsWork NewWork(char prChoice)
        {
            switch (char.ToUpper(prChoice))
            {
                case 'P': return new clsPainting();
                case 'S': return new clsSculpture();
                case 'H': return new clsPhotograph();
                default: return null;
            }
        }

        public override string ToString()
        {
            return _Name + "\t" + _Date.ToShortDateString();  
        }
        
        //public string GetName()
        //{
        //    return _Name;
        //}

        //public DateTime GetDate()
        //{
        //    return _Date;
        //}

        //public decimal GetValue()
        //{
        //    return _Value;
        //}
    }
}
