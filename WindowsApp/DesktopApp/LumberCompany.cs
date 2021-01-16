using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    class LumberCompany
    {
        private string m_lcAddress { get; set; }
        private string m_lcName { get; set; }
        private int m_lcPhoneNum { get; set; }
        private int m_lcNumEmployees { get; set; }
        private List<TruckDriver> m_lcEmployees { get; set; }
        private int m_lcID { get; set; }

        public LumberCompany(string companyName, string address, int phoneNum)
        {
            m_lcAddress = address;
            m_lcName = companyName;
            m_lcPhoneNum = phoneNum;

            // On login, grab list of employees and set list equal
            // set NumEmployees equal to size of list
            // Grab ID from database and increase and set m_lcID
        }
    }
}
