using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTestingProject
{
    public class PropertyMapper
    {
        public void SetEmployeeNationality(Employee employee)
        {
            if(employee.isIndian == true)
            {
                employee.nationality = Nationalities.Indian;
            }            
        }
    }
}
