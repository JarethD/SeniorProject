using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Classes;
namespace Core.Interfaces
{
    public interface iSqlServerDataAccess
    {
        int ExecuteQuery_SingleID(string sql);
        int ExecuteQuery_NoReturnType(string sql);
        TruckDriver ExecuteQuery_SingleTD(string sql);
        LumberAssociate ExecuteQuery_SingleLA(string sql);
        LumberCompany ExecuteQuery_SingleLC(string sql);
        HardwareStore ExecuteQuery_SingleHS(string sql);

    }


}
