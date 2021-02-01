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
            string query = String.Format("INSERT INTO EMPLOYEES " +
                "VALUES('{0}', '{1}','{2}','{3}','{4}','{5}', '{6}')", 
                newDriver.username, newDriver.HashPass, newDriver.ID,
                newDriver.Phonenum, newDriver.Company, newDriver.Address);

            return _database.ExecuteQuery_NoReturnType(query);
        }

    }
}
