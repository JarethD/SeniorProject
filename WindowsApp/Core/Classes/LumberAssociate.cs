using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Classes
{
    public class LumberAssociate
    {
        private string m_laUsername;
        public string username
        {
            get => m_laUsername;
            set => m_laUsername = username;
        }
        private string m_laHashPass;
        public string HashPass
        {
            get => m_laHashPass;
            set => m_laHashPass = HashPass;
        }
        public long m_laID;
        public long ID
        {
            get => m_laID;
            set => m_laID = ID;
        }

        private string m_laName;
        public string name
        {
            get => m_laName;
            set => m_laName = name;
        }
        private long m_laPhoneNumber;
        public long Phonenum
        {
            get => m_laPhoneNumber;
            set => m_laPhoneNumber = Phonenum;
        }
        private string m_laCompany;
        public string Company
        {
            get => m_laCompany;
            set => m_laCompany = Company;
        }
        private List<Order> m_laOrders;
        public List<Order> Orders
        {
            get => m_laOrders;
            set => m_laOrders = Orders;
        }

        public long m_laCompanyID;
        public long laCompanyID
        {
            get => m_laCompanyID;
            set => m_laCompanyID = laCompanyID;
        }

        private string m_laAddress;
        public string Address
        {
            get => m_laAddress;
            set => m_laAddress = Address;
        }

        public LumberAssociate()
        { }
        public LumberAssociate(string username, string hashpass, //int id, 
            string name, long id, long phoneNumber, string address, long companyID)//, int companyID) string company, 
        {
            m_laOrders = new List<Order>();
            m_laUsername = username;
            if (hashpass == " ")
                m_laHashPass = "\0";
            else
                m_laHashPass = hashpass;
            m_laID = id;
            m_laName = name;
            m_laPhoneNumber = phoneNumber;
            m_laAddress = address;
            //m_laCompany = company;
            m_laID = 0;
            m_laCompanyID = companyID;
        }

        public void AddOrder(Order newOrder)
        {
            m_laOrders.Append(newOrder);
        }
        public void DeleteOrder(Order oldOrder)
        {
            m_laOrders.Remove(oldOrder);
        }

        public void SortByPriority()
        {
            List<Order> tempList = new List<Order>();
            for (int i = 0; i < 3; i++) // 3 is amount of items in priority enum
            { 
                foreach (Order order in m_laOrders)
                {
                    if (order.m_oPriority == (priority)i)
                    {
                        tempList.Append(order); 
                    }
                }
            }
            if (m_laOrders.Count != 0)
            {
                m_laOrders.Clear();
                foreach (Order order in tempList)
                {
                    m_laOrders.Append(order);
                }
            }
        }
        public void SortByStatus()
        {
            List<Order> tempList = new List<Order>();
            
            for(int i = 0; i < 4; ++i)
            {
                foreach(Order order in m_laOrders)
                {
                    if(order.m_oStatus == (status)i)
                    {
                        tempList.Append(order);
                    }
                }
            }
            if(m_laOrders.Count != 0)
            {
                m_laOrders.Clear();
                foreach(Order order in tempList)
                {
                    m_laOrders.Append(order);
                }
            }
        }
    }
}
