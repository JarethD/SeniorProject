using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    public class LumberAssociate : Order
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
        private int m_laID;
        public int ID
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

        private int m_laCompanyID;
        public int laCompanyID
        {
            get => m_laCompanyID;
            set => m_laCompanyID = laCompanyID;
        }

        public LumberAssociate()
        { }
        public LumberAssociate(string username, string haspass, int id, 
            string name, long phoneNumber, string company, int companyID)
        {
            m_laOrders = new List<Order>();
            m_laUsername = username;
            m_laHashPass = haspass;
            m_laID = id;
            m_laName = name;
            m_laPhoneNumber = phoneNumber;
            m_laCompany = company;
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
