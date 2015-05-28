using System;
using System.Collections.Generic;
//using System.Windows.Forms;

namespace GalleryVersion2
{
    [Serializable()] 
    public class clsArtistList : SortedList<string, clsArtist>
    {
        private const string _fileName = "galleryVersion2.xml";
        private string _GalleryName;
        public static readonly string FACTORY_PROMPT = "Enter Gallery's new name";

        public string GalleryName
        {
            get { return _GalleryName; }
            set { _GalleryName = value; }
        }

        //public void EditArtist(string prKey)
        //{
        //    clsArtist lcArtist;
        //    //lcArtist = (clsArtist)this[prKey];
        //    lcArtist = this[prKey];
        //    if (lcArtist != null)
        //        lcArtist.EditDetails();
        //    else
        //        MessageBox.Show("Sorry no artist by this name");
        //}
       
        //public void NewArtist()
        //{
        //    clsArtist lcArtist = new clsArtist(this);
        //    try
        //    {
        //        if (lcArtist.Name != "")
        //        {
        //            Add(lcArtist.Name, lcArtist);
        //            MessageBox.Show("Artist added!");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Duplicate Key!");
        //    }
        //}
        
        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsArtist lcArtist in Values)
            {
                lcTotal += lcArtist.TotalValue;
            }
            return lcTotal;
        }

        public void Save()
        {
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_fileName, System.IO.FileMode.Create);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                lcFormatter.Serialize(lcFileStream, this);
                lcFileStream.Close();
            }
            catch (Exception Ex)
            {
                //MessageBox.Show(e.Message, "File Save Error");
                throw new Exception("File Save Error");
            }
        }

        public static clsArtistList Retrieve()
        {
            clsArtistList lcArtistList;
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_fileName, System.IO.FileMode.Open);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                lcArtistList = (clsArtistList)lcFormatter.Deserialize(lcFileStream);
                //updateDisplay();
                lcFileStream.Close();
            }

            catch (Exception Ex)
            {
                //MessageBox.Show(e.Message, "File Retrieve Error");
                throw new Exception("File Retrieve Error");
                lcArtistList = new clsArtistList();
            }
            return lcArtistList;
        }
    }
}
