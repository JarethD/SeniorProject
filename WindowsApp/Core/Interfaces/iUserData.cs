using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Classes;

namespace Core.Interfaces
{
    public interface iUserData
    {


        int GetRecentCompanyID();
        int AddTruckDriver(TruckDriver newDriver);
        int AddLumberAssociate(LumberAssociate newLA);
        int AddLumberCompany(LumberCompany newCompany);
        int AddHardwareStore(HardwareStore newStore);

        //public TruckDriver GetDriver(string username)

    }


}
