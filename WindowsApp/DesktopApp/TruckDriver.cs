using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    class TruckDriver
    {
        private string m_trUsername { get; set; }
        private string m_trHashPass { get; set; }
        private string m_trName { get; set; }
        private int m_trPhoneNum { get; set; }
        private string m_trAddress { get; set; }
        private string m_trCompany { get; set; }
        private int m_trID { get; set; }
        private List<Order> m_trOrders { get; set; }
        public TruckDriver(string username, string hashpass, string name, int num, string address, string company)
        {
            m_trUsername = username;
            m_trHashPass = hashpass;
            m_trName = name;
            m_trPhoneNum = num;
            m_trAddress = address;
            m_trCompany = company;
            //Grab greatest ID number from database and increment by and set m_trID to new ID 
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
    }
}
