using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Classes
{
    public class LumberCompany
    {
        private string m_lcUsername;
        public string username
            {
            get => m_lcUsername;
            set => m_lcUsername = username;
            }
        private string m_lcHashPass; 
        public string HashPass
        { 
            get => m_lcHashPass;
            set => m_lcHashPass = HashPass; 
        }
        private string m_lcAddress;
        public string Address
        {
            get => m_lcAddress;
            set => m_lcAddress = Address;
        }
        private string m_lcName;
        public string name
        { 
            get => m_lcName;
            set => m_lcName = name; 
        }
        private long m_lcPhoneNum;
        public long Phonenum
        { 
            get => m_lcPhoneNum; 
            set => m_lcPhoneNum = Phonenum; 
        }
        private int m_lcNumEmployees;
        public int NumEmployees
        { 
            get => m_lcNumEmployees; 
            set => m_lcNumEmployees = NumEmployees; 
        }
        private List<TruckDriver> m_lcEmployees; 
        public List<TruckDriver> Employees
        { 
            get => m_lcEmployees; 
            set => m_lcEmployees = Employees; 
        }
        //private long m_lcID;
        public long ID
        { 
            get => m_lcID;
            set { m_lcID = ID; } 
        }
        public long m_lcID;
        public LumberCompany()
        {
            m_lcName = "";
            m_lcHashPass = "";
            m_lcAddress = "";
            m_lcUsername = "";
            m_lcPhoneNum = 0;
            m_lcID = 0;
            m_lcEmployees = new List<TruckDriver>();
        }
        public LumberCompany(string username, string hashpass, long id, string companyName, string address, long phoneNum)//, int id)
        {
            m_lcUsername = username;
            m_lcHashPass = hashpass;
            m_lcAddress = address;
            m_lcName = companyName;
            m_lcPhoneNum = phoneNum;
            m_lcID = id;
            m_lcEmployees = new List<TruckDriver>();
            m_lcNumEmployees = 0;
            //m_lcID = id;
            // On login, grab list of employees and set list equal
            // set NumEmployees equal to size of list
            // Grab ID from database and increase and set m_lcID
        }



        public LumberCompany(LumberCompany company)
        {
            m_lcAddress = company.m_lcAddress;
            m_lcUsername = company.m_lcUsername;
            m_lcHashPass = company.m_lcHashPass;
            m_lcName = company.m_lcName;
            m_lcPhoneNum = company.m_lcPhoneNum;
            m_lcNumEmployees = company.m_lcNumEmployees;
            m_lcID = company.m_lcID;
            m_lcEmployees = company.m_lcEmployees;
        }



        //public static bool operator== (LumberCompany lhd, LumberCompany rhd)
        //{
        //    if (lhd.m_lcAddress != rhd.m_lcAddress)
        //        return false;
        //    if (lhd.m_lcUsername != rhd.m_lcUsername)
        //        return false;
        //    if (lhd.m_lcHashPass != rhd.m_lcHashPass)
        //        return false;
        //    if (lhd.m_lcID != rhd.m_lcID)
        //        return false;
        //    if (lhd.m_lcName != rhd.m_lcName)
        //        return false;
        //    if (lhd.m_lcNumEmployees != rhd.m_lcNumEmployees)
        //        return false;
        //    if (lhd.m_lcPhoneNum != rhd.m_lcPhoneNum)
        //        return false;
        //    if (lhd.m_lcEmployees != rhd.m_lcEmployees)
        //        return false;


        //    return true;
        //}
        //public static bool operator!= (LumberCompany lhd, LumberCompany rhd)
        //{
        //    return !(lhd == rhd);
        //}
        //public override bool Equals(object o)
        //{
        //    return true;
        //}
        //public override int GetHashCode()
        //{
        //    return 0;
        //}
        public void AddTD(TruckDriver driver)
        {
            m_lcEmployees.Append(driver);
        }

        public void DeleteTD(TruckDriver driver)
        {
            m_lcEmployees.Remove(driver);
        }
    }
}
