using System;
using System.Collections.Generic;

namespace GalleryVersion2
{
    sealed class clsNameComparer : IComparer<clsWork>
    {
        //public int Compare(Object x, Object y)
        //{
        //    clsWork workClassX = (clsWork)x;
        //    clsWork workClassY = (clsWork)y;
        //    string lcNameX = workClassX.Name;
        //    string lcNameY = workClassY.Name;

        //    return lcNameX.CompareTo(lcNameY);
        //}

        private clsNameComparer() { }
        public static readonly clsNameComparer Instance = new clsNameComparer();

        public int Compare(clsWork x, clsWork y)
        {
            string lcNameX = x.Name;
            string lcNameY = y.Name;

            return lcNameX.CompareTo(lcNameY);
        }
    }
}
