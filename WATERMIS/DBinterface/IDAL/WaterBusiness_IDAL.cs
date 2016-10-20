using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace DBinterface.IDAL
{
    public interface WaterBusiness_IDAL
    {
        DataTable GetWaterUserList(Control.ControlCollection Controls);

        DataTable GetWaterMeterByUserID(string waterUserId);

        Hashtable GetWaterUserInfos(string waterUserId);

        bool IsDisabledUser(string waterUserId);

        bool IsDisabledUser(string TableName, string waterUserId);

        float GetUserWaterPrice(string waterUserId);

        DataTable GetWaterUserFee(string waterUserId);
    }
}
