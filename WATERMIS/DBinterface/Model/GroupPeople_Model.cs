using System;
using System.Collections.Generic;
using System.Text;

namespace DBinterface.Model
{
   public class GroupPeople_Model
    {
       public Guid GroupPeopleID { get; set; }
       public string waterMeterTypeId { get; set; }
       public string waterMeterType { get; set; }
       public string waterMeterTypeValue { get; set; }
       public string waterUserTypeId { get; set; }
       public string waterUserTypeName { get; set; }
       public string waterUserType { get; set; }
       public int waterUserHouseTypeID { get; set; }
       public string waterUserHouseType { get; set; }
       public int UserCount_Apply { get; set; }
       public int? UserCount_Check { get; set; }
       public bool IsBoot { get; set; }
       public DateTime? CreateDate { get; set; }
       public string CreateUser { get; set; }
       public DateTime? ModifyDate { get; set; }
       public string ModifyUser { get; set; }
       public string VerifyUser { get; set; }
       public string VerifyUserID { get; set; }
       public DateTime? VerifyDate { get; set; }
    }
}
