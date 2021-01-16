using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    class TruckDriver
    {
        private string m_trName { get; set; }
        private int m_trPhoneNum { get; set; }
        private string m_trAddress { get; set; }
        private string m_trCompany { get; set; }
        private int m_trID { get; set; }
        public TruckDriver(string name, int num, string address, string company)
        {
            m_trName = name;
            m_trPhoneNum = num;
            m_trAddress = address;
            m_trCompany = company;
            //Grab greatest ID number from database and increment by and set m_trID to new ID 
        }
    }
}
