using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    class LumberAssociate : Order
    {
        private string m_laUsername { get; set; }
        private string m_laHashPass { get; set; }
        private int m_laID { get; set; }
        private string m_laName { get; set; }
        private long m_laPhoneNumber { get; set; }
        private string m_laCompany { get; set; }
        private List<Order> m_laOrders { get; set; }

        private int m_laCompanyID { get; set; }

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
