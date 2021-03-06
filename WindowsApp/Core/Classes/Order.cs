﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Classes
{
    public enum status : int { NOT = 0, ROUTE = 1, PROGRESS = 2, DONE = 3 };
    public enum priority : int { LOW = 2, MEDIUM = 1, HIGH = 0 };
    public class Order
    {
        // Order ID represents ID of a truck driver that creates order 
        //Change ID name?
        public long m_oDriverID { get; set; }
        public long m_oID { get; set; }
        public string m_oName { get; set; }
        public string m_oDescription { get; set; }
        public string m_oLocationTo { get; set; }
        public string m_oLocationFrom { get; set; }
        public status m_oStatus { get; set; }
        public priority m_oPriority { get; set; }
        public double m_longitude { get; set; }
        public double m_latitude { get; set; }
        public Order()
        {
            // empty ctor
        }

        public Order(string name, string desc, string locFrom, string locTo,
            status curStatus, priority curPriority)
        {
            m_oName = name;
            m_oDescription = desc;
            m_oLocationFrom = locFrom;
            m_oLocationTo = locTo;
            m_oStatus = curStatus;
            m_oPriority = curPriority;
        }

        public Order(long id, string desc, string locTo, string locFrom,
            status curStatus, priority curPriority, long dID)
        {
            m_oID = id;
            m_oDescription = desc;
            m_oLocationFrom = locFrom;
            m_oLocationTo = locTo;
            m_oStatus = curStatus;
            m_oPriority = curPriority;
            m_oDriverID = dID;
        }

        public Order(long id, string desc, string locTo, string locFrom,
            status curStatus, priority curPriority, long dID,
            double longitude, double latitude)
        {
            m_oID = id;
            m_oDescription = desc;
            m_oLocationFrom = locFrom;
            m_oLocationTo = locTo;
            m_oStatus = curStatus;
            m_oPriority = curPriority;
            m_oDriverID = dID;
            m_longitude = longitude;
            m_latitude = latitude;
        }

        public override string ToString()
        {
            return String.Format("ID: {0}, To: {1}, From: {2}", m_oID, m_oLocationTo, m_oLocationFrom);
        }
    }
}
