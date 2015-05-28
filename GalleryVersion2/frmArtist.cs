using System;
//using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GalleryVersion2
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        //private clsArtistList _ArtistList;
        private clsWorksList _WorksList;
        private byte _sortOrder; // 0 = Name, 1 = Date
        private clsArtist _Artist;
        private static Dictionary<clsArtist, frmArtist> _ArtistFormList = new Dictionary<clsArtist,frmArtist>();

        public static void Run(clsArtist prArtist)
        {
            frmArtist lcArtistForm;
            if (!_ArtistFormList.TryGetValue(prArtist, out lcArtistForm))
            {
                lcArtistForm = new frmArtist();
                _ArtistFormList.Add(prArtist, lcArtistForm);
                lcArtistForm.SetDetails(prArtist);
            }
            else
            {
                lcArtistForm.Show();
                lcArtistForm.Activate();
            }
        }

        private void updateDisplay()
        {
            //txtName.Enabled = txtName.Text == "";
            if (_sortOrder == 0)
            {
                _WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _WorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
            frmMain.Instance.updateDisplay();
        }

        //public void SetDetails(string prName, string prSpeciality, string prPhone,
        //                       clsWorksList prWorksList, clsArtistList prArtistList)
        ////public void SetDetails(string prName, string prSpeciality, string prPhone, byte prSortOrder,
        //                       //clsWorksList prWorksList, clsArtistList prArtistList)
        //{
        //    txtName.Text = prName;
        //    txtSpeciality.Text = prSpeciality;
        //    txtPhone.Text = prPhone;
        //    _ArtistList = prArtistList;
        //    _WorksList = prWorksList;
        //    _sortOrder = _WorksList.SortOrder;
        //    //_sortOrder = prSortOrder;
        //    updateDisplay();
        //}

        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            txtName.Enabled = string.IsNullOrEmpty(_Artist.Name);
            updateForm();
            updateDisplay();
            Show();
            //ShowDialog(); // re-shows the form
        }

        //public void GetDetails(ref string prName, ref string prSpeciality, ref string prPhone)
        ////public void GetDetails(ref string prName, ref string prSpeciality, ref string prPhone, ref byte prSortOrder)
        //{
        //    prName = txtName.Text;
        //    prSpeciality = txtSpeciality.Text;
        //    prPhone = txtPhone.Text;
        //    //prSortOrder = _sortOrder;
        //    _WorksList.SortOrder = _sortOrder;
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //_WorksList.DeleteWork(lstWorks.SelectedIndex);
            DeleteWork(lstWorks.SelectedIndex);
            updateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //_WorksList.AddWork();
            ////NewWork();
            //updateDisplay();
            string lcReply = new InputBox(clsWork.FACTORY_PROMPT).Answer;
            if (!string.IsNullOrEmpty(lcReply))
            {
                _WorksList.AddWork(lcReply[0]);
                updateDisplay();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
            {
                try
                {
                    pushData();
                    if (txtName.Enabled)
                    {
                        _Artist.NewArtist();
                        MessageBox.Show("Artist added!", "Success");
                        frmMain.Instance.updateDisplay();
                        txtName.Enabled = false;
                    }
                    //DialogResult = DialogResult.OK;
                    Hide();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        //public virtual Boolean isValid()
        //{
        //    if (txtName.Enabled && txtName.Text != "")
        //        if (_ArtistList.Contains(txtName.Text))
        //        {
        //            MessageBox.Show("Artist with that name already exists!");
        //            return false;
        //        }
        //        else
        //            return true;
        //    else
        //        return true;
        //}

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
                EditWork(lstWorks.SelectedIndex);
                updateDisplay();
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _sortOrder = Convert.ToByte(rbByDate.Checked);
            updateDisplay();
        }

        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
            //_ArtistList = _Artist.ArtistList;
            _WorksList = _Artist.WorksList;
            _sortOrder = _Artist.WorksList.SortOrder;
            updateDisplay();
            frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
            updateTitle(_Artist.ArtistList.GalleryName);
        }


        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
            _Artist.WorksList.SortOrder = _sortOrder;
        }

        public void DeleteWork(int lcIndex)
        {
            if (lcIndex >= 0 && lcIndex < _WorksList.Count)
            {
                if (MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {
                    _WorksList.RemoveAt(lcIndex);
                }
            }
        }

        public void EditWork(int lcIndex)
        {
            if (lcIndex >= 0 && lcIndex < _WorksList.Count)
            {
                clsWork lcWork = (clsWork)_WorksList[lcIndex];
                lcWork.EditDetails();
            }
            else
            {
                MessageBox.Show("Sorry no work selected #" + Convert.ToString(lcIndex));
            }
        }

        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Artist Details - " + prGalleryName;
        }

        //public static clsWork NewWork(clsWork lcWork)
        //{
        //    char lcReply;
        //    InputBox inputBox = new InputBox("Enter P for Painting, S for Sculpture and H for Photograph");
        //    if (inputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        lcReply = Convert.ToChar(inputBox.getAnswer());

        //        switch (char.ToUpper(lcReply))
        //        {
        //            //case 'P': return new clsPainting();
        //            //case 'S': return new clsSculpture();
        //            //case 'H': return new clsPhotograph();
        //            case 'P': return new clsPainting();
        //            case 'S': return new clsSculpture();
        //            case 'H': return new clsPhotograph();
        //        }
        //    }
        //    else
        //    {
        //        inputBox.Close();
        //        return null;
        //    }
        //}
    }
}


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