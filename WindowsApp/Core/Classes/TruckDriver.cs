using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Classes
{
    public class TruckDriver
    {
        private string m_trUsername;
        public string username
        {
            get => m_trUsername;
            set => m_trUsername = username;
        }
        private string m_trHashPass;
        public string HashPass
        {
            get => m_trHashPass;
            set => m_trHashPass = HashPass;
        }
        private string m_trName;
        public string name
        {
            get => m_trName;
            set => m_trName = name;
        }
        private long m_trPhoneNum;
        public long Phonenum
        {
            get => m_trPhoneNum;
            set => m_trPhoneNum = Phonenum;
        }
        private string m_trAddress;
        public string Address
        {
            get => m_trAddress;
            set => m_trAddress = Address;
        }
        private string m_trCompany;
        public string Company
        {
            get => m_trCompany;
            set => m_trCompany = Company;
        }
        public long m_trID;
        public long ID
        {
            get => m_trID;
            set => m_trID = ID;
        }
        private List<Order> m_trOrders;
        public List<Order> Orders
        {
            get => m_trOrders;
            set => m_trOrders = Orders;
        }

        private long m_trCompID;
        public long CompID
        {
            get => m_trCompID;
            set => m_trCompID = CompID;
        }

        public TruckDriver(string username, string hashpass, string name, long phonenum, string address, string company)
        {
            m_trUsername = username;
            m_trHashPass = hashpass;
            m_trName = name;
            m_trPhoneNum = phonenum;
            m_trAddress = address;
            m_trCompany = company;
         }

        public TruckDriver()
        {
            m_trUsername = "";
            m_trHashPass = "";
            m_trName = "";
            m_trPhoneNum = 0;
            m_trID = 0;
            m_trAddress = "";
            m_trCompany = "";
        }
        public void AddOrder(Order newOrder)
        {
            m_trOrders.Append(newOrder);
        }
        public void DeleteOrder(Order oldOrder)
        {
            m_trOrders.Remove(oldOrder);
        }

        public void SortByPriority()
        {
            List<Order> tempList = new List<Order>();
            for (int i = 0; i < 3; i++) // 3 is amount of items in priority enum
            {
                foreach (Order order in m_trOrders)
                {
                    if (order.m_oPriority == (priority)i)
                    {
                        tempList.Append(order);
                    }
                }
            }
            if (m_trOrders.Count != 0)
            {
                m_trOrders.Clear();
                foreach (Order order in tempList)
                {
                    m_trOrders.Append(order);
                }
            }
        }
        public void SortByStatus()
        {
            List<Order> tempList = new List<Order>();

            for (int i = 0; i < 4; ++i)
            {
                foreach (Order order in m_trOrders)
                {
                    if (order.m_oStatus == (status)i)
                    {
                        tempList.Append(order);
                    }
                }
            }
            if (m_trOrders.Count != 0)
            {
                m_trOrders.Clear();
                foreach (Order order in tempList)
                {
                    m_trOrders.Append(order);
                }
            }
        }

        public bool IsEmpty()
        {
            if (m_trUsername == "")
                if (m_trHashPass == "")
                    if (m_trName == "")
                        if (m_trPhoneNum == 0)
                            if (m_trID == 0)
                                if (m_trAddress == "")
                                    if (m_trCompany == "")
                                        return true;
            return false;
        }
    }
}
