using System;
using System.Collections.Generic;
using System.Text;
using Core.Classes;

namespace Sql_database
{
    public class UserAccess
    {

        private DBAccess _db;

        public UserAccess(DBAccess database)
        {
            _db = database;
        }

        public long GetRecentCompanyID()
        {
            string query = String.Format("SELECT MAX(ID) FROM Company");
            long newID = _db.ExecuteQuery_SingleID(query);
            return ++newID;
        }

        public long GetRecentEmployeeID()
        {
            string query = String.Format("SELECT MAX(ID) FROM Employees");
            long newID = _db.ExecuteQuery_SingleID(query);
            return ++newID;
        }

        public long GetOrderID()
        {
            string query = string.Format("SELECT MAX(OrderID) FROM Orders");
            long newID = _db.ExecuteQuery_SingleID(query);
            return ++newID;
        }

        public bool SetLatAndLong(int OrderID, double latitude, double longitude)
        {
            bool pass = true;
            string query = string.Format("UPDATE Orders " +
                "SET longitude={0}, latitude={1} " +
                "WHERE OrderID={2}", longitude, latitude, OrderID);
            _db.ExecuteQuery_NoReturnType(query);
            //_db.ExecuteQuery_GetOrder(query);
            return pass;
        }

        #region Add to Database
        /// <summary>
        ///     Add Truck Driver to Employee table in database
        /// </summary>
        /// <param name="newDriver"> Truck Driver to be added</param>
        /// <returns> 0 is successfull, 1 if fail </returns>
        public int AddTruckDriver(TruckDriver newDriver)
        {
            long newID = GetRecentEmployeeID();
            newDriver.m_trID = newID;
            //if ((newDriver.ID - 1) == -1)
            //    return -1;

            string query = String.Format("INSERT INTO [dbo].[Employees] " +
 "VALUES");
            string values = string.Format(" ('{0}', '{1}','{2}',",
                newDriver.username, newDriver.HashPass, newDriver.name);
            string values2 = string.Format("{0}, {1},'{2}', {3})",
                newDriver.ID, newDriver.Phonenum, newDriver.Address, newDriver.CompID);
            query += values;
            query += values2;

            return _db.ExecuteQuery_NoReturnType(query);
        }

        /// <summary>
        ///     Add Lumber Associate to Employee table in database
        /// </summary>
        /// <param name="newLA"> Lumber Associate to be added</param>
        /// <returns> 0 is successfull, 1 if fail </returns>
        public int AddLumberAssociate(LumberAssociate newLA)
        {
            long newID = GetRecentEmployeeID();
            newLA.m_laID = newID;
            //if ((newLA.ID - 1) == -1)
            //    return -1;

            string query = String.Format("INSERT INTO [dbo].[Employees] " +
            "VALUES");
            string values = string.Format(" ('{0}', '{1}','{2}',",
                newLA.username, newLA.HashPass, newLA.name);
            string values2 = string.Format("{0}, {1},'{2}',{3})",
                newLA.ID, newLA.Phonenum, newLA.Address, newLA.laCompanyID);
            query += values;
            query += values2;
            return _db.ExecuteQuery_NoReturnType(query);
        }

        /// <summary>
        ///     Add Lumber Company to Company table in database
        /// </summary>
        /// <param name="newCompany"> Lum</param>
        /// <returns> 0 is successfull, 1 if fail </returns>
        public int AddLumberCompany(LumberCompany newCompany)
        {
            long newID = GetRecentCompanyID();
            newCompany.m_lcID = newID;
            if ((newCompany.ID - 1) == -1)
                return -1;

            string query = String.Format("INSERT INTO [dbo].[Company] " +
            "VALUES");
            string values = string.Format(" ('{0}', '{1}',{2},",
                newCompany.username, newCompany.HashPass, newCompany.ID);
            string values2 = string.Format("{0}, '{1}','{2}')",
                newCompany.Phonenum, newCompany.name, newCompany.Address);
            query += values;
            query += values2;

            return _db.ExecuteQuery_NoReturnType(query);
        }

        /// <summary>
        ///     Add Lumber associate to Company table in database
        /// </summary>
        /// <param name="newStore"> Lumber Associate to be added to database</param>
        /// <returns> 0 is successfull, 1 if fail </returns>
        public int AddHardwareStore(HardwareStore newStore)
        {
            long newID = GetRecentCompanyID();
            newStore.m_hsID = newID;
            if ((newStore.ID - 1) == -1)
                return -1;

            string query = String.Format("INSERT INTO [dbo].[Company] " +
            "VALUES");
            string values = string.Format(" ('{0}', '{1}',{2},",
                newStore.username, newStore.HashPass, newStore.ID);
            string values2 = string.Format("{0}, '{1}','{2}')",
                newStore.Phonenum, newStore.name, newStore.Address);
            query += values;
            query += values2;
            return _db.ExecuteQuery_NoReturnType(query);
        }

        public int AddOrder(Order order)
        {
            order.m_oID = GetOrderID();

            string query = String.Format("INSERT INTO [dbo].[Orders] VALUES" +
                " ({0}, '{1}', '{2}', '{3}', {4}, {5}, {6})",
                order.m_oID, order.m_oDescription, order.m_oLocationTo,
                order.m_oLocationFrom, (int)order.m_oStatus, (int)order.m_oPriority, order.m_oDriverID);

            return _db.ExecuteQuery_NoReturnType(query);
        }

        #endregion

        #region Deletion Functions
        public int DeleteHardwareStore(long tdID)
        {
            string query = String.Format("DELETE FROM [dbo].[Company] WHERE ID={0}",
                tdID);
            return _db.ExecuteQuery_NoReturnType(query);
        }

        public int DeleteLumberCompany(long lcID)
        {
            string query = String.Format("DELETE FROM [dbo].[Company] WHERE AND ID={0}",
                lcID);
            return _db.ExecuteQuery_NoReturnType(query);
        }

        public int DeleteLumberAssociate(long laID)
        {
            string query = String.Format("DELETE FROM [dbo].[Employees] WHERE ID={0}",
                laID);
            return _db.ExecuteQuery_NoReturnType(query);
        }

        public int DeleteTruckDriver(long tdID)
        {
            string query = String.Format("DELETE FROM [dbo].[Employees] WHERE AND ID={0}",
                tdID);
            return _db.ExecuteQuery_NoReturnType(query);
        }

        public int DeletOrder(Order oldOrder)
        {
            string query = String.Format("DELETE FROM [dbo].[Orders] WHERE OrderID={0}", oldOrder.m_oID);
            return _db.ExecuteQuery_NoReturnType(query);
        }
        #endregion

        #region Get From Databases Functions
        public TruckDriver GetTruckDriver(string username)
        {
            string query = String.Format("SELECT [Username] ,[Hashpass], [Name] ,[ID] ,[PhoneNumber] ,[Address] ,[Company] " +
                " FROM[dbo].[Employees] WHERE Username = '{0}'", username);
            TruckDriver tempDriver = new TruckDriver(_db.ExecuteQuery_SingleTD(query));
            //tempDriver = _db.ExecuteQuery_SingleTD(query);
            return tempDriver;
        }

        public LumberAssociate GetLumberAssociate(string username)
        {
            string query = String.Format("SELECT [Username] ,[Hashpass], [Name] ,[ID] ,[PhoneNumber] ,[Address] ,[Company] " +
                " FROM[dbo].[Employees] WHERE Username = '{0}'", username);
            return _db.ExecuteQuery_SingleLA(query);
        }

        public LumberCompany GetLumberCompany(string username)
        {
            string query = String.Format("SELECT [Username] ,[Hashpass] ,[ID] ,[PhoneNumber] ,[CompName] ,[Address] " +
                " FROM[dbo].[Company] WHERE Username = '{0}'", username);
            LumberCompany company = new LumberCompany(_db.ExecuteQuery_SingleLC(query));
            //company = _db.ExecuteQuery_SingleLC(query);
            return company;
        }
        public HardwareStore GetHardwareStore(string username)
        {
            string query = String.Format("SELECT [Username] ,[Hashpass] ,[ID] ,[PhoneNumber] ,[CompName] ,[Address] " +
                " FROM[dbo].[Company] WHERE Username = '{0}'", username);
            return _db.ExecuteQuery_SingleHS(query);
        }

        public List<Order> GetOrders(long DriverID)
        {
            string query = String.Format("SELECT" +
                " [OrderID] ,[Description] ,[LocationTo]," +
                "[LocationFrom],[Status],[Priority],[DriverID]" +
                "FROM[dbo].[Orders]" +
                "WHERE DriverID = {0}", DriverID);
            return _db.ExecuteQuery_GetOrderTD(query);
        }

        public List<Order> GetOrders(string LocationTo)
        {
            string query = String.Format("SELECT" +
            " [OrderID] ,[Description] ,[LocationTo]," +
            "[LocationFrom],[Status],[Priority],[DriverID]" +
            "FROM[dbo].[Orders]" +
            "WHERE LocationTo = '{0}'", LocationTo);
            return _db.ExecuteQuery_GetOrderTD(query);
        }
        #endregion
    }
}
