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

        public int GetRecentCompanyID()
        {
            string query = String.Format("SELECT MAX(ID) FROM COMPANY");
            int newID = _database.ExecuteQuery_SingleID(query);
            return ++newID;
        }

        /// <summary>
        ///     Add Truck Driver to Employee table in database
        /// </summary>
        /// <param name="newDriver"> Truck Driver to be added</param>
        /// <returns> 0 is successfull, 1 if fail </returns>
        public int AddTruckDriver(TruckDriver newDriver)
        {

            string query = String.Format("INSERT INTO [dbo].[Employees] " +
 "VALUES");
            string values = string.Format(" ('{0}', '{1}','{2}',",
                newDriver.username, newDriver.HashPass, newDriver.name);
            string values2 = string.Format("{0}, {1},'{2}'," +
                "'{3}')", newDriver.ID, newDriver.Phonenum, newDriver.Company, newDriver.Address);
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
            string query = String.Format("INSERT INTO [dbo].[Employees] " +
            "VALUES");
            string values = string.Format(" ('{0}', '{1}','{2}',",
                newLA.username, newLA.HashPass, newLA.name);
            string values2 = string.Format("{0}, {1},'{2}'," +
                "'{3}')", newLA.ID, newLA.Phonenum, newLA.Company, newLA.Address);
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
            newCompany.ID = GetRecentCompanyID();
            if (newCompany.ID == -1)
                return -1;

            string query = String.Format("INSERT INTO [dbo].[Employees] " +
            "VALUES");
            string values = string.Format(" ('{0}', '{1}','{2}',",
                newCompany.username, newCompany.HashPass, newCompany.name);
            string values2 = string.Format("{0}, {1},'{2}'," +
                "'{3}')", newCompany.ID, newCompany.Phonenum,  newCompany.Address, newCompany.NumEmployees);
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
            newStore.ID = GetRecentCompanyID();
            if (newStore.ID == -1)
                return -1;

            string query = String.Format("INSERT INTO COMPANY " +
            "VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
            newStore.username, newStore.HashPass, newStore.ID,
            newStore.Phonenum, newStore.name, newStore.Address, newStore.NumEmployees);

            return _db.ExecuteQuery_NoReturnType(query);
        }

        //public TruckDriver GetDriver(string username)
        

    }
}
