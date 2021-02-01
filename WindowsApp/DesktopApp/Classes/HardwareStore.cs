using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    public class HardwareStore
    {
        private string m_hsUsername { get; set; }
        public string username
        {
            get => m_hsUsername;
            set => m_hsUsername = username;
        }
        private string m_hsHashPass { get; set; }
        public string HashPass
        {
            get => m_hsHashPass;
            set => m_hsHashPass = HashPass;
        }
        private string m_hsAddress;
        public string Address
        {
            get => m_hsAddress;
            set => m_hsAddress = Address;
        }
        private string m_hsName;
        public string name
        {
            get => m_hsName;
            set => m_hsName = name;
        }
        private long m_hsPhoneNum;
        public long Phonenum
        {
            get => m_hsPhoneNum;
            set => m_hsPhoneNum = Phonenum;
        }
        private int m_hsNumEmployees;
        public int NumEmployees
        {
            get => m_hsNumEmployees;
            set => m_hsNumEmployees = NumEmployees;
        }
        private List<LumberAssociate> m_hsEmployees;
        public List<LumberAssociate> hsEmployees
        { 
            get => m_hsEmployees; 
            set => m_hsEmployees = hsEmployees; 
        }
        private int m_hsID;
        public int ID
        {
            get => m_hsID;
            set => m_hsID = ID;
        }
        
        public HardwareStore()
        { }
        public HardwareStore(string username, string hashpass, string companyName, 
            string address, long phoneNum, int storeID, int id)
        {
            m_hsUsername = username;
            m_hsHashPass = hashpass;
            m_hsAddress = address;
            m_hsName = companyName;
            m_hsPhoneNum = phoneNum;
            m_hsID = storeID;
            m_hsID = id;

            // On login, grab list of employees and set list equal
            // set NumEmployees equal to size of list
            // Grab ID from database and increase and set m_lcID
        }

        public void AddLA(LumberAssociate associate)
        {
            m_hsEmployees.Append(associate);
        }

        public void DeleteLA(LumberAssociate associate)
        {
            m_hsEmployees.Remove(associate);
        }
    }
}
