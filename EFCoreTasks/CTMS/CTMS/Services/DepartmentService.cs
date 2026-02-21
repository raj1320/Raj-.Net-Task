using CTMS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTMS.Services
{
    public class DepartmentService
    {
        public static Department FetchInputDepartmentService()
        {
            return new Department(); 
        }

        public static int FetchInputDepartmentIdService()
        {
            return 0; 
        }
        public static void ShowDepartStateDepartmentService(List<Department> departments)
        {

        }

        public static void ShowListOfTrainingDepartmentService(List<Department> ListOfDepartments)
        {

        }
    }
}



