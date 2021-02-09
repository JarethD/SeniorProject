using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;
using Core.Classes;


namespace Database_Helpers
{
    public class UserData : iUserData
    {
        private iSqlServerDataAccess _database;
        private SqlServerDataAccess _db;
        public UserData(iSqlServerDataAccess database)
        {
            _database = database;
        }

        public UserData(SqlServerDataAccess database)
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
                newDriver.ID, newDriver.Phonenum, newDriver.Address, newDriver.CompID );
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
                newLA.ID, newLA.Phonenum,  newLA.Address, newLA.laCompanyID);
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
            string query = String.Format("INSERT INTO [dbo].[Orders] VALUES" +
                " ({0}, '{1}', '{2}', '{3}', {4}, {5}, {6})",
                order.m_oID, order.m_oDescription, order.m_oLocationTo,
                order.m_oLocationFrom, (int)order.m_oStatus, (int)order.m_oPriority, order.m_oDriverID);

            return _db.ExecuteQuery_NoReturnType(query);
        }

        //public TruckDriver GetDriver(string username)
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
    }
}
