using System;
using System.Collections.Generic;
using System.Text;
using DesktopApp;

namespace Database_Helpers
{
    public class UserData : iUserData
    {
        private iSqlServerDataAccess _database;
        public UserData(iSqlServerDataAccess database)
        {
            _database = database;
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

            string query = String.Format("INSERT INTO Employees " +
                "VALUES('{0}', '{1}','{2}','{3}','{4}','{5}', '{6}', '{7}')",
                newDriver.username, newDriver.HashPass, newDriver.name, newDriver.ID,
                newDriver.Phonenum, newDriver.Address, newDriver.Company);

            return _database.ExecuteQuery_NoReturnType(query);
        }

        /// <summary>
        ///     Add Lumber Associate to Employee table in database
        /// </summary>
        /// <param name="newLA"> Lumber Associate to be added</param>
        /// <returns> 0 is successfull, 1 if fail </returns>
        public int AddLumberAssociate(LumberAssociate newLA)
        {
            string query = String.Format("INSERT INTO Employees " +
            "VALUES('{0}', '{1}','{2}','{3}','{4}','{5}', '{6}', '(7}')",
            newLA.username, newLA.HashPass, newLA.ID,
            newLA.Phonenum, newLA.Company, newLA.Address, newLA.Company);

            return _database.ExecuteQuery_NoReturnType(query);
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

            string query = String.Format("INSERT INTO COMPANY " +
            "VALUES('{0}', '{1}','{2}','{3}','{4}','{5}', '{6}', '{7}')",
            newCompany.username, newCompany.HashPass, newCompany.ID,
            newCompany.Phonenum, newCompany.name, newCompany.Address, newCompany.NumEmployees);

            return _database.ExecuteQuery_NoReturnType(query);
        }

        /// <summary>
        ///     Add Lumber associate to Company table in database
        /// </summary>
        /// <param name="newStore"> Lumber Associate to be added to database</param>
        /// <returns> 0 is successfull, 1 if fail </returns>
        public int AddHardwarStore(HardwareStore newStore)
        {
            newStore.ID = GetRecentCompanyID();
            if (newStore.ID == -1)
                return -1;

            string query = String.Format("INSERT INTO COMPANY " +
            "VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
            newStore.username, newStore.HashPass, newStore.ID,
            newStore.Phonenum, newStore.name, newStore.Address, newStore.NumEmployees);

            return _database.ExecuteQuery_NoReturnType(query);
        }

        //public TruckDriver GetDriver(string username)
        

    }
}
