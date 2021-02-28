using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    class Location
    {
        public Location()
        { 
            m_xcoord = 0; 
            m_ycoord = 0; 
        }


        private double m_xcoord;
        public double xcoord
        {
            get => m_xcoord;
            set => m_xcoord = xcoord;
        }

        private double m_ycoord;
        public double ycoord
        {
            get => m_ycoord;
            set => m_ycoord = ycoord;
        }
    }
}
