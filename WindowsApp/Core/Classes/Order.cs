using System;
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
        public int m_oDriverID { get; set; }
        public int m_oID { get; set; }
        public string m_oName { get; set; }
        public string m_oDescription { get; set; }
        public string m_oLocationTo { get; set; }
        public string m_oLocationFrom { get; set; }
        public status m_oStatus { get; set; }
        public priority m_oPriority { get; set; }
        
        public Order()
        {
            // empty ctor
        }

        public Order(string name, string desc, string locFrom, string locTo, status curStatus, priority curPriority)
        {
            m_oName = name;
            m_oDescription = desc;
            m_oLocationFrom = locFrom;
            m_oLocationTo = locTo;
            m_oStatus = curStatus;
            m_oPriority = curPriority;
        }
    }
}
