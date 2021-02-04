using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    public interface iUserData
    {


        int GetRecentCompanyID();
        int AddTruckDriver(TruckDriver newDriver);
        int AddLumberAssociate(LumberAssociate newLA);
        int AddLumberCompany(LumberCompany newCompany);
        int AddHardwarStore(HardwareStore newStore);

        //public TruckDriver GetDriver(string username)

    }
}
