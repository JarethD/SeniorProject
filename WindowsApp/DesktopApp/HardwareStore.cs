using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    class HardwareStore
    {
        private string m_hsAddress { get; set; }
        private string m_hsName { get; set; }
        private int m_hsPhoneNum { get; set; }
        private int m_hsNumEmployees { get; set; }
        private List<TruckDriver> m_hsEmployees { get; set; }
        private int m_hsID { get; set; }

        public HardwareStore(string companyName, string address, int phoneNum)
        {
            m_hsAddress = address;
            m_hsName = companyName;
            m_hsPhoneNum = phoneNum;

            // On login, grab list of employees and set list equal
            // set NumEmployees equal to size of list
            // Grab ID from database and increase and set m_lcID
        }
    }
}
