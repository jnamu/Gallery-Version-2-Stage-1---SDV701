using System;
using System.Collections.Generic;

namespace GalleryVersion2
{
    sealed class clsDateComparer : IComparer<clsWork>
    {
        //public int Compare(Object x, Object y)
        //{
        //    clsWork lcWorkX = (clsWork)x;
        //    clsWork lcWorkY = (clsWork)y;
        //    DateTime lcDateX = lcWorkX.Date;
        //    DateTime lcDateY = lcWorkY.Date;

        //    return lcDateX.CompareTo(lcDateY);
        //}

        private clsDateComparer() { }
        public static readonly clsDateComparer Instance = new clsDateComparer();

        public int Compare(clsWork x, clsWork y)
        {
            DateTime lcDateX = x.Date;
            DateTime lcDateY = y.Date;

            return lcDateX.CompareTo(lcDateY);
        }
    }
}
