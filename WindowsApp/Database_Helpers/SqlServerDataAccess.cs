using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DesktopApp;
using Core.Interfaces;
using Core.Classes;

namespace Database_Helpers
{
    public class SqlServerDataAccess : iSqlServerDataAccess
    {
        public enum UserType { TD, LA, HS, LC };

        private static string _serverAddress = "jarethsp.database.windows.net";
        private static string _serverPort = "5433";
        private static string _databaseName = "SeniorProject";
        private static string _serverUsername = "jarethdodson";
        private static string _serverPassword = "Payezezo21.";
        private static int _curUserId;
        private static TruckDriver _curTD;
        private static LumberAssociate _curLA;
        private static HardwareStore _curHS;
        private static LumberCompany _curLC;
        private static UserType _curUserType;

        private int FAIL = 0;
        private int PASS = 1;

        #region public properties
        //public properties

        /// <summary>
        /// The address for the SQL server
        /// </summary>
        public static string ServerAddress
        {
            get => _serverAddress;
            set => _serverAddress = ServerAddress;
        }

        /// <summary>
        /// The Port for the SQL server
        /// </summary>
        public static string ServerPort
        {
            get => _serverPort;
            set => _serverPort = ServerPort;
        }

        /// <summary>
        /// The name of the database to connect too
        /// </summary>
        public static string ServerDatabaseName
        {
            get => _databaseName;
            set => _databaseName = ServerDatabaseName;
        }

        /// <summary>
        /// The username of the username for connecting to the SQL server
        /// </summary>
        public static string ServerUsername
        {
            get => _serverUsername;
            set => _serverUsername = ServerUsername;
        }

        /// <summary>
        /// The password for the username to connect to the SQL server
        /// </summary>
        public static string ServerPassword
        {
            get => _serverPassword;
            set => _serverPassword = ServerPassword;
        }

        /// <summary>
        /// ID of the current user
        /// </summary>
        public static int ID
        {
            get => _curUserId;
            set => _curUserId = ID;
        }

        /// <summary>
        /// Current Truck Driver user info
        /// </summary>
        public static TruckDriver CurTD
        {
            get => _curTD;
            set => _curTD = CurTD;
        }

        /// <summary>
        /// Current Lumber Associate user info
        /// </summary>
        public static LumberAssociate CurLA
        {
            get => _curLA;
            set => _curLA = CurLA;
        }

        /// <summary>
        /// Current Hardware Store user info
        /// </summary>
        public static HardwareStore CurHS
        {
            get => _curHS;
            set => _curHS = CurHS;
        }

        /// <summary>
        /// Current Lumber Company user info
        /// </summary>
        public static LumberCompany CurLC
        {
            get => _curLC;
            set => _curLC = CurLC;  
        }

        /// <summary>
        /// Type of user
        /// </summary>
        public static UserType CurUserType
        {
            get => _curUserType;
            set => _curUserType = CurUserType;
        }

        #endregion

        /// <summary>
        /// Create Connection string for SQL database
        /// </summary>
        /// <returns>
        /// String used for connecting to an SQL database
        /// </returns>
        public static string GetConnectionString()
        {
            return "server=" + ServerAddress + "; database=" + ServerDatabaseName + "; UID=" + ServerUsername + "; password=" + ServerPassword;
        }

        public int ExecuteQuery_NoReturnType(string sql)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand comm = new SqlCommand(sql, con);

                try
                {
                    con.Open();
                    comm.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return FAIL;
                }
            }

            return PASS;
        }

        public TruckDriver ExecuteQuery_SingleTD(string sql)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand com = new SqlCommand(sql, con);

                int userID = 0;
                string userName = "";
                string hash = "";
                long phonenumber = 00000000000;
                string name = "";
                string address = "";
                long compid = 0;
                try { con.Open(); }
                catch (Exception) { return null; }

                try
                {
                    SqlDataReader read = com.ExecuteReader();

                    if (read.Read())
                    {
                        userName = read.GetString(0);
                        hash = read.GetString(1);
                        name = read.GetString(2);
                        userID = read.GetInt32(3);
                        phonenumber = read.GetInt64(4);
                        address = read.GetString(5);
                        compid = read.GetInt64(6);
                    }

                    read.Close();
                }
                catch (Exception) { return null; }

                // Create New Truck Driver
                TruckDriver td = new TruckDriver
                {
                    ID = userID,
                    username = userName,
                    HashPass = hash,
                    CompID = compid,
                    Address = address,
                    Phonenum = phonenumber,
                    name = name,        // Wouldn't hurt to change truck driver variable to Name
                    Orders = new List<Order>()
                };
                return td;
            }
        }

        public LumberAssociate ExecuteQuery_SingleLA(string sql)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand com = new SqlCommand(sql, con);

                int userID = 0;
                string userName = "";
                string hash = "";
                long phonenumber = 00000000000;
                string name = "";
                string address = "";
                long compid = 0;
                try { con.Open(); }
                catch (Exception) { return null; }

                try
                {
                    SqlDataReader read = com.ExecuteReader();

                    if (read.Read())
                    {
                        userName = read.GetString(0);
                        hash = read.GetString(1);
                        name = read.GetString(2);
                        userID = read.GetInt32(3);
                        phonenumber = read.GetInt64(4);
                        address = read.GetString(5);
                        compid = read.GetInt64(6);
                    }

                    read.Close();
                }
                catch (Exception) { return null; }

                // Create New Truck Driver
                LumberAssociate la = new LumberAssociate
                {
                    ID = userID,
                    username = userName,
                    HashPass = hash,
                    name = name,
                    Phonenum = phonenumber,
                    Address = address,
                    laCompanyID = ID,
                    Orders = new List<Order>()
                };
                return la;
            }
        }

        public LumberCompany ExecuteQuery_SingleLC(string sql)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand com = new SqlCommand(sql, con);

                int userID = 0;
                string userName = "";
                string hash = "";

                try { con.Open(); }
                catch (Exception) { return null; }

                try
                {
                    SqlDataReader read = com.ExecuteReader();

                    if (read.Read())
                    {
                        userName = read.GetString(0);
                        hash = read.GetString(1);
                        userID = read.GetInt32(2);
                    }

                    read.Close();
                }
                catch (Exception) { return null; }

                // Create New Truck Driver
                LumberCompany lc = new LumberCompany
                {
                    ID = userID,
                    username = userName,
                    HashPass = hash,
                    Employees = new List<TruckDriver>()
                };
                return lc;
            }
        }

        public HardwareStore ExecuteQuery_SingleHS(string sql)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand com = new SqlCommand(sql, con);

                int userID = 0;
                string userName = "";
                string hash = "";

                try { con.Open(); }
                catch (Exception) { return null; }

                try
                {
                    SqlDataReader read = com.ExecuteReader();

                    if (read.Read())
                    {
                        userName = read.GetString(0);
                        hash = read.GetString(1);
                        userID = read.GetInt32(2);
                    }

                    read.Close();
                }
                catch (Exception) { return null; }

                // Create New Truck Driver
                HardwareStore hs = new HardwareStore
                {
                    ID = userID,
                    username = userName,
                    HashPass = hash,
                    hsEmployees = new List<LumberAssociate>()
                };
                return hs;
            }
        }

        public int ExecuteQuery_SingleID(string sql)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand com = new SqlCommand(sql, con);

                int userID = 0;
                string userName = "";
                string hash = "";

                try { con.Open(); }
                catch (Exception) { return -1; }

                try
                {
                    SqlDataReader read = com.ExecuteReader();

                    if (read.Read())
                    {
                        userName = read.GetString(0);
                        hash = read.GetString(1);
                        userID = read.GetInt32(2);
                    }

                    read.Close();
                }
                catch (Exception) { return -1; }

                return userID;
            }
        }

        public void ExecuteQuery_GetOrderTD(TruckDriver driver)
        {
            string query = "SELECT Order FROM ORDER WHERE ID = '" + driver.ID + "';";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                SqlCommand com = new SqlCommand(query, con);

                con.Open();
                SqlDataReader read = com.ExecuteReader();

                while(read.Read()) //Reads single line
                {
                    //Order Datamember = read.GetInt32(0) EXAMPLE
                }
            }
        }

        //public List<Order> ExecuteQuery_GetOrderLA(LumberAssociate associate)
    }
}
        

   