using System;
using System.Collections.Generic;
//using System.Windows.Forms;

namespace GalleryVersion2
{
    [Serializable()] 
    public class clsWorksList : List<clsWork>
    {
        //private static clsNameComparer _NameComparer = new clsNameComparer();
        //private static clsDateComparer _DateComparer = new clsDateComparer();
        private byte _sortOrder;

        public byte SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }
        
        public void AddWork(char prWork)
        {
            clsWork lcWork = clsWork.NewWork(prWork);
            //clsWork lcWork = clsWork.NewWork(lcWork);
            if (lcWork != null)
            {
                Add(lcWork);
            }
        }
       
        //public void DeleteWork(int prIndex)
        //{
        //    if (prIndex >= 0 && prIndex < this.Count)
        //    {
        //        if (MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            this.RemoveAt(prIndex);
        //        }
        //    }
        //}
        
        //public void EditWork(int prIndex)
        //{
        //    if (prIndex >= 0 && prIndex < this.Count)
        //    {
        //        clsWork lcWork = (clsWork)this[prIndex];
        //        lcWork.EditDetails();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Sorry no work selected #" + Convert.ToString(prIndex));
        //    }
        //}

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsWork lcWork in this)
            {
                lcTotal += lcWork.Value;
            }
            return lcTotal;
        }

         public void SortByName()
         {
             Sort(clsNameComparer.Instance);
         }
    
        public void SortByDate()
        {
            Sort(clsDateComparer.Instance);
        }
    }
}
