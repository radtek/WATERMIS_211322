
using System.Data;
using System.Collections;
namespace DBinterface.IDAL
{
    public interface EquipMent_IDAL
    {
        DataTable GetEquipment();

        int UpdateEquipment(int meid, string LoginID);

        int DeleteEquipment(int meid);

        DataTable GetLoginUser();

        DataTable GetLoginUserInID();

        DataTable GetMeterRepairYear();

        DataTable GetMeterRepair(Hashtable strWhere);

        DataTable GetUserSuggest(Hashtable ht);

        DataTable GetWaterUserGPS();

        DataTable GetMeterTrack(string LoginID,string datetime);

        int DeleteMeterRepair(int MRID);
    }
}
