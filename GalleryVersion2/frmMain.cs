using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GalleryVersion2
{
    sealed public partial class frmMain : Form
    {
        private frmMain()
        {
            InitializeComponent();
        }

        private static readonly frmMain _Instance = new frmMain();
        public delegate void Notify(string prGalleryName);
        public event Notify GalleryNameChanged;

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        } 

        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Gallery - " + prGalleryName;
        }


        private clsArtistList _ArtistList;
        //private clsArtistList _ArtistList = new clsArtistList();
        //private const string fileName = "gallery.xml";

        public void updateDisplay()
        {
            string[] lcDisplayList = new string[_ArtistList.Count];

            lstArtists.DataSource = null;
            _ArtistList.Keys.CopyTo(lcDisplayList, 0);
            lstArtists.DataSource = lcDisplayList;
            lblValue.Text = Convert.ToString(_ArtistList.GetTotalValue());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmArtist.Run(new clsArtist(_ArtistList));
                ////_ArtistList.NewArtist();
                //NewArtist();
                //updateDisplay();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "Error adding new artist");
            }
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                try
                {
                    //EditArtist(lcKey);
                    //updateDisplay();
                    frmArtist.Run(_ArtistList[lcKey]);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "This should never occur");
                }
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            try
            {
                _ArtistList.Save();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.GetBaseException().Message);
            }
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                lstArtists.ClearSelected();
                _ArtistList.Remove(lcKey);
                updateDisplay();
            }
        }

        //private void save()
        //{
        //    try
        //    {
        //        System.IO.FileStream lcFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
        //        System.Runtime.Serialization.Formatters.Soap.SoapFormatter lcFormatter =
        //            new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

        //        lcFormatter.Serialize(lcFileStream, theArtistList);
        //        lcFileStream.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "File Save Error");
        //    }
        //}

        //private void retrieve()
        //{
        //    try
        //    {
        //        System.IO.FileStream lcFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
        //        System.Runtime.Serialization.Formatters.Soap.SoapFormatter lcFormatter =
        //            new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

        //        theArtistList = (clsArtistList)lcFormatter.Deserialize(lcFileStream);
        //        updateDisplay();
        //        lcFileStream.Close();
        //    }

        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "File Retrieve Error");
        //    }
        //}

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                _ArtistList = clsArtistList.Retrieve();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.GetBaseException().Message);
            }
            updateDisplay();
            GalleryNameChanged += new Notify(updateTitle);
            GalleryNameChanged(_ArtistList.GalleryName); // event raising!
        }

        private void btnChangeGalleryName_Click(object sender, EventArgs e)
        {
            string lcReply = new InputBox(clsArtistList.FACTORY_PROMPT).Answer;
            if (!string.IsNullOrEmpty(lcReply))
            {
                _ArtistList.GalleryName = lcReply;
                GalleryNameChanged(_ArtistList.GalleryName);
                updateDisplay();
            }
        }

        //public void EditArtist(string lcIndex)
        //{
        //    if (lcIndex != null)
        //    {
        //        clsArtist lcArtist = (clsArtist)_ArtistList[lcIndex];
        //        //lcArtist.EditDetails();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Sorry no artist by this name");
        //    }
        //}

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
    }
}