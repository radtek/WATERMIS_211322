using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELWATERFEECHARGE
   {
       private string _CHARGEID;
       private int _TOTALNUMBERCHARGE;
       private decimal _EXTRACHARGECHARGE1;
       private decimal _EXTRACHARGECHARGE2;
       private decimal _WATERTOTALCHARGE;
       private decimal _EXTRATOTALCHARGE;
       private decimal _TOTALCHARGE;
       private decimal _OVERDUEMONEY;
       private string _CHARGETYPEID;
       private string _CHARGEClASS;
       private decimal _CHARGEBCYS;
       private decimal _CHARGEBCSS;
       private decimal _CHARGEYSQQYE;
       private decimal _CHARGEYSBCSZ;
       private decimal _CHARGEYSJSYE;
       private string _CHARGEWORKERID;
       private string _CHARGEWORKERNAME;
       private DateTime _CHARGEDATETIME;
       private string _INVOICEPRINTSIGN;
       private int _RECEIPTPRINTCOUNT;
       private string _RECEIPTNO;
       private string _POSRUNNINGNO;

       private string _DAYCHECKWORKERNAME;
       private string _DAYCHECKSTATE;
       private DateTime _DAYCHECKDATETIME;
       private string _DAYCHECKID;

       private string _MONTHCHECKWORKERNAME;
       private string _MONTHCHECKSTATE;
       private DateTime _MONTHCHECKDATETIME;
        
       private string _CHARGECANCEL;
       private decimal _CANCELYSQQYE;
       private decimal _CANCELYSBCSZ;
       private decimal _CANCELYSJSYE;
       private string _CANCELWORKERID;
       private string _CANCELWORKERNAME;
       private DateTime _CANCELDATETIME;
       private string _MEMO;
       private string _CANCELMEMO;

       public string CHARGEID
       {
           get
           {
               return _CHARGEID;
           }
           set
           {
               _CHARGEID = value;
           }
       }
       public int TOTALNUMBERCHARGE
       {
           get
           {
               return _TOTALNUMBERCHARGE;
           }
           set
           {
               _TOTALNUMBERCHARGE = value;
           }
       }
       public decimal EXTRACHARGECHARGE1
       {
           get
           {
               return _EXTRACHARGECHARGE1;
           }
           set
           {
               _EXTRACHARGECHARGE1 = value;
           }
       }
       public decimal EXTRACHARGECHARGE2
       {
           get
           {
               return _EXTRACHARGECHARGE2;
           }
           set
           {
               _EXTRACHARGECHARGE2 = value;
           }
       }
       public decimal WATERTOTALCHARGE
       {
           get
           {
               return _WATERTOTALCHARGE;
           }
           set
           {
               _WATERTOTALCHARGE = value;
           }
       }
       public decimal EXTRATOTALCHARGE
       {
           get
           {
               return _EXTRATOTALCHARGE;
           }
           set
           {
               _EXTRATOTALCHARGE = value;
           }
       }
       public decimal TOTALCHARGE
       {
           get
           {
               return _TOTALCHARGE;
           }
           set
           {
               _TOTALCHARGE = value;
           }
       }
       public decimal OVERDUEMONEY
       {
           get
           {
               return _OVERDUEMONEY;
           }
           set
           {
               _OVERDUEMONEY = value;
           }
       }
       public string CHARGETYPEID
       {
           get
           {
               return _CHARGETYPEID;
           }
           set
           {
               _CHARGETYPEID = value;
           }
       }
       public string CHARGEClASS
       {
           get
           {
               return _CHARGEClASS;
           }
           set
           {
               _CHARGEClASS = value;
           }
       }
       public decimal CHARGEBCYS
       {
           get
           {
               return _CHARGEBCYS;
           }
           set
           {
               _CHARGEBCYS = value;
           }
       }
       public decimal CHARGEBCSS
       {
           get
           {
               return _CHARGEBCSS;
           }
           set
           {
               _CHARGEBCSS = value;
           }
       }
       public decimal CHARGEYSQQYE
       {
           get
           {
               return _CHARGEYSQQYE;
           }
           set
           {
               _CHARGEYSQQYE = value;
           }
       }
       public decimal CHARGEYSBCSZ
       {
           get
           {
               return _CHARGEYSBCSZ;
           }
           set
           {
               _CHARGEYSBCSZ = value;
           }
       }
       public decimal CHARGEYSJSYE
       {
           get
           {
               return _CHARGEYSJSYE;
           }
           set
           {
               _CHARGEYSJSYE = value;
           }
       }
       public string CHARGEWORKERID
       {
           get
           {
               return _CHARGEWORKERID;
           }
           set
           {
               _CHARGEWORKERID = value;
           }
       }
       public string CHARGEWORKERNAME
       {
           get
           {
               return _CHARGEWORKERNAME;
           }
           set
           {
               _CHARGEWORKERNAME = value;
           }
       }
       public DateTime CHARGEDATETIME
       {
           get
           {
               return _CHARGEDATETIME;
           }
           set
           {
               _CHARGEDATETIME = value;
           }
       }
       public int RECEIPTPRINTCOUNT
       {
           get
           {
               return _RECEIPTPRINTCOUNT;
           }
           set
           {
               _RECEIPTPRINTCOUNT = value;
           }
       }
       public string INVOICEPRINTSIGN
       {
           get
           {
               return _INVOICEPRINTSIGN;
           }
           set
           {
               _INVOICEPRINTSIGN = value;
           }
       }
       public string RECEIPTNO
       {
           get
           {
               return _RECEIPTNO;
           }
           set
           {
               _RECEIPTNO = value;
           }
       }
       public string POSRUNNINGNO
       {
           get
           {
               return _POSRUNNINGNO;
           }
           set
           {
               _POSRUNNINGNO = value;
           }
       }

       public string DAYCHECKWORKERNAME
       {
           get
           {
               return _DAYCHECKWORKERNAME;
           }
           set
           {
               _DAYCHECKWORKERNAME = value;
           }
       }
       public string DAYCHECKSTATE
       {
           get
           {
               return _DAYCHECKSTATE;
           }
           set
           {
               _DAYCHECKSTATE = value;
           }
       }
       public DateTime DAYCHECKDATETIME
       {
           get
           {
               return _DAYCHECKDATETIME;
           }
           set
           {
               _DAYCHECKDATETIME = value;
           }
       }
       public string DAYCHECKID
       {
           get
           {
               return _DAYCHECKID;
           }
           set
           {
               _DAYCHECKID = value;
           }
       }

       public string MONTHCHECKWORKERNAME
       {
           get
           {
               return _MONTHCHECKWORKERNAME;
           }
           set
           {
               _MONTHCHECKWORKERNAME = value;
           }
       }
       public string MONTHCHECKSTATE
       {
           get
           {
               return _MONTHCHECKSTATE;
           }
           set
           {
               _MONTHCHECKSTATE = value;
           }
       }
       public DateTime MONTHCHECKDATETIME
       {
           get
           {
               return _MONTHCHECKDATETIME;
           }
           set
           {
               _MONTHCHECKDATETIME = value;
           }
       }

       public string CHARGECANCEL
       {
           get
           {
               return _CHARGECANCEL;
           }
           set
           {
               _CHARGECANCEL = value;
           }
       }
       public decimal CANCELYSQQYE
       {
           get
           {
               return _CANCELYSQQYE;
           }
           set
           {
               _CANCELYSQQYE = value;
           }
       }
       public decimal CANCELYSBCSZ
       {
           get
           {
               return _CANCELYSBCSZ;
           }
           set
           {
               _CANCELYSBCSZ = value;
           }
       }
       public decimal CANCELYSJSYE
       {
           get
           {
               return _CANCELYSJSYE;
           }
           set
           {
               _CANCELYSJSYE = value;
           }
       }
       public string CANCELWORKERID
       {
           get
           {
               return _CANCELWORKERID;
           }
           set
           {
               _CANCELWORKERID = value;
           }
       }
       public string CANCELWORKERNAME
       {
           get
           {
               return _CANCELWORKERNAME;
           }
           set
           {
               _CANCELWORKERNAME = value;
           }
       }
       public DateTime CANCELDATETIME
       {
           get
           {
               return _CANCELDATETIME;
           }
           set
           {
               _CANCELDATETIME = value;
           }
       }
       public string MEMO
       {
           get
           {
               return _MEMO;
           }
           set
           {
               _MEMO = value;
           }
       }
       public string CANCELMEMO
       {
           get
           {
               return _CANCELMEMO;
           }
           set
           {
               _CANCELMEMO = value;
           }
       }
    }
}
