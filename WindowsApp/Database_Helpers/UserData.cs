using System;
using System.Collections.Generic;
using System.Text;
using DesktopApp;

namespace Database_Helpers
{
    class UserData
    {
        private iSqlServerDataAccess _database;
        public UserData(iSqlServerDataAccess database)
        {
            _database = database;
        }

        public int AddTruckDriver(TruckDriver newDriver)
        {
            string query = String.Format("INSERT INTO EMPLOYEE " +
                "VALUES('{0}', '{1}','{2}','{3}','{4}','{5}', '{6}')",
                newDriver.username, newDriver.HashPass, newDriver.ID,
                newDriver.Phonenum, newDriver.Company, newDriver.Address);

            return _database.ExecuteQuery_NoReturnType(query);
        }

        public int AddLumberAssociate(LumberAssociate newLA)
        {
            string query = String.Format("INSERT INTO EMPLOYEE " +
            "VALUES('{0}', '{1}','{2}','{3}','{4}','{5}', '{6}')",
            newLA.username, newLA.HashPass, newLA.ID,
            newLA.Phonenum, newLA.Company, newLA.Company);

            return _database.ExecuteQuery_NoReturnType(query);
        }

        public int AddLumberCompany(LumberAssociate newCompany)
        {
            string query = String.Format("INSERT INTO COMPANY " +
            "VALUES('{0}', '{1}','{2}','{3}','{4}','{5}', '{6}')",
            newCompany.username, newCompany.HashPass, newCompany.ID,
            newCompany.Phonenum, newCompany.Company, newCompany.Company);

            return _database.ExecuteQuery_NoReturnType(query);
        }

        public int AddHardwarStore(LumberAssociate newStore)
        {
            string query = String.Format("INSERT INTO COMPANY " +
            "VALUES('{0}', '{1}','{2}','{3}','{4}','{5}', '{6}')",
            newStore.username, newStore.HashPass, newStore.ID,
            newStore.Phonenum, newStore.Company, newStore.Company);

            return _database.ExecuteQuery_NoReturnType(query);
        }

    }
}
