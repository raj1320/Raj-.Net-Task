
using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTasksDay2
{
    internal class DepartmentClass
    {
        static int DeptIDSalut=1101;
        private int _DepartmentID;
        private string _DepartmentName=string.Empty;
        public DepartmentClass(int DepartmentID,string DepartmentName)
        {
             this.DepartmentID = DepartmentID;
             this.DepartmentName = DepartmentName;
        }

        public int DepartmentID{ get { return _DepartmentID; } set { _DepartmentID = value; } }
        public string DepartmentName { get { return _DepartmentName; } set { _DepartmentName = value; } }


        public static List<DepartmentClass> AddDepartmentToList()
        {
            List<DepartmentClass> DepartmentList = new List<DepartmentClass>()
            { new DepartmentClass(DeptIDSalut++,"IT"),
              new DepartmentClass(DeptIDSalut++,"Marketing"),
              new DepartmentClass(DeptIDSalut++,"Sales"),
              new DepartmentClass(DeptIDSalut++,"HR"),
              new DepartmentClass(DeptIDSalut++,"Production")
            };



            return DepartmentList;
        }

    }
}
