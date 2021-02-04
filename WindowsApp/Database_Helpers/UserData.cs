using System;
using System.Collections.Generic;
using System.Text;
using DesktopApp;

namespace Database_Helpers
{
    public class UserData
    {
        private iSqlServerDataAccess _database;
        public UserData(iSqlServerDataAccess database)
        {
            _database = database;
        }

        /// <summary>
        ///     Add Truck Driver to Employee table in database
        /// </summary>
        /// <param name="newDriver"> Truck Driver to be added</param>
        /// <returns> 0 is successfull, 1 if fail </returns>
        public int AddTruckDriver(TruckDriver newDriver)
        {
            string query = String.Format("INSERT INTO EMPLOYEE " +
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
            string query = String.Format("INSERT INTO EMPLOYEE " +
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
            string query = String.Format("INSERT INTO COMPANY " +
            "VALUES('{0}', '{1}','{2}','{3}','{4}','{5}', '{6}')",
            newCompany.username, newCompany.HashPass, newCompany.ID,
            newCompany.Phonenum, newCompany.name, newCompany.Address);

            return _database.ExecuteQuery_NoReturnType(query);
        }

        /// <summary>
        ///     Add Lumber associate to Company table in database
        /// </summary>
        /// <param name="newStore"> Lumber Associate to be added to database</param>
        /// <returns> 0 is successfull, 1 if fail </returns>
        public int AddHardwarStore(HardwareStore newStore)
        {
            string query = String.Format("INSERT INTO COMPANY " +
            "VALUES('{0}', '{1}','{2}','{3}','{4}','{5}', '{6}')",
            newStore.username, newStore.HashPass, newStore.ID,
            newStore.Phonenum, newStore.name, newStore.Address);

            return _database.ExecuteQuery_NoReturnType(query);
        }

        //public TruckDriver GetDriver(string username)
        

    }
}
