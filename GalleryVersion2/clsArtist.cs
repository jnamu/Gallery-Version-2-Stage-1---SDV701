using System;

namespace GalleryVersion2
{
    [Serializable()] 
    public class clsArtist
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _speciality;
        public string Speciality
        {
            get { return _speciality; }
            set { _speciality = value; }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        //private decimal _TotalValue;
        public decimal TotalValue
        {
            get { return _WorksList.GetTotalValue(); }
            //get { return _TotalValue; }
            //set { _TotalValue = value; }
        }

        private clsWorksList _WorksList;
        public clsWorksList WorksList
        {
            get { return _WorksList; }
            //set { _WorksList = value; }
        }

        private clsArtistList _ArtistList;
        public clsArtistList ArtistList
        {
            get { return _ArtistList; }
            //set { _ArtistList = value; }
        }
        
        //private static frmArtist artistDialog = new frmArtist();
        //private byte _sortOrder;

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            //EditDetails();
        }
        
        //public void EditDetails()
        //{
        //    artistDialog.SetDetails(_name, _speciality, _phone, _WorksList, _ArtistList);
        //    //artistDialog.SetDetails(_name, _speciality, _phone, _sortOrder, _WorksList, _ArtistList);
        //    if (artistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        artistDialog.GetDetails(ref _name, ref _speciality, ref _phone);
        //        //artistDialog.GetDetails(ref _name, ref _speciality, ref _phone, ref _sortOrder);
        //        _TotalValue = _WorksList.GetTotalValue();
        //    }
        //}

        //public void EditDetails()
        //{
        //    artistDialog.SetDetails(this);
        //    if (artistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        _TotalValue = _WorksList.GetTotalValue();
        //    }
        //}

        public bool IsDuplicate(string prArtistName)
        {
            return _ArtistList.ContainsKey(prArtistName);
        }

        //public string GetKey()
        //{
        //    return _name;
        //}

        //public decimal GetWorksValue()
        //{
        //    return _TotalValue;
        //}

        public void NewArtist()
        {
            if (!string.IsNullOrEmpty(Name))
                _ArtistList.Add(Name, this);
            else
                throw new Exception("No artist name entered");
        }

        //public void NewArtist()
        //{
        //    clsArtist lcArtist = new clsArtist(_ArtistList);
        //    try
        //    {
        //        if (lcArtist.Name != "")
        //        {
        //            _ArtistList.Add(lcArtist.Name, lcArtist);
        //            MessageBox.Show("Artist Added!");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Duplicate Key!");
        //    }
        //}
    }
}
