using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class MODELreadMeterRecord
   {
       private string _readMeterRecordId;
       private string _readMeterRecordIdLast;
       private string _lastNumberYearMonth;
       private int _NotReadMonthCount;
       private string _waterMeterId;
       private string _waterMeterNo;
       private int _waterMeterLastNumber;
       private int _waterMeterEndNumber;
       private int _SubMeterNumber;
       private int _totalNumber;
       private string _totalNumberDescribe;
       private decimal _avePrice;
       private string _avePriceDescribe;
       private decimal _waterTotalCharge;
       private decimal _extraChargePrice1;
       private decimal _extraChargePrice2;
       private decimal _extraChargePrice3;
       private decimal _extraChargePrice4;
       private decimal _extraChargePrice5;
       private decimal _extraChargePrice6;
       private decimal _extraChargePrice7;
       private decimal _extraChargePrice8;
       private decimal _extraCharge1;
       private decimal _extraCharge2;
       private decimal _extraCharge3;
       private decimal _extraCharge4;
       private decimal _extraCharge5;
       private decimal _extraCharge6;
       private decimal _extraCharge7;
       private decimal _extraCharge8;
       private decimal _extraTotalCharge;
       private string _trapezoidPrice;
       private string _extraCharge;
       private decimal _totalCharge;
       private decimal _OVERDUEMONEY;
       private int _readMeterRecordYear;
       private int _readMeterRecordMonth;
       private DateTime _readMeterRecordYearAndMonth;
       private DateTime _initialReadMeterMesDateTime;
       private DateTime _readMeterRecordDate;

       private string _waterMeterPositionName;
       private string _IsReverse;
       private string _waterMeterState;
       private string _waterMeterSizeId;
       private string _waterMeterSizeValue;
       private string _waterMeterTypeId;
       private string _waterMeterTypeName;
       private string _waterMeterTypeClassID;
       private string _waterMeterTypeClassName;
       private int _WATERFIXVALUE;
       private string _waterMeterProduct;
       private string _waterMeterSerialNumber;
       private string _ChannelNO;
       private string _waterMeterMode;
       private int _waterMeterMagnification;
       private int _waterMeterMaxRange;
       private string _chargerID;
       private string _chargerName;
       private string _meterReaderID;
       private string _meterReaderName;
       private string _checkState;
       private DateTime _checkDateTime;
       private string _checker;
       private string _chargeState;
       private string _chargeID;
       private string _waterUserId;
       private string _waterUserNO;
       private string _waterUserName;
       private string _waterUserNameCode;
       private string _waterUserTelphoneNO;
       private string _waterPhone;
       private string _areaNO;
       private string _pianNO;
       private string _duanNO;
       private string _communityID;
       private string _COMMUNITYNAME;
       private string _buildingNO;
       private string _unitNO;
       private string _createType;
       private string _waterUserAddress;
       private int _waterUserPeopleCount;
       private string _meterReadingID;
       private string _meterReadingPageNo;
       private string _meterReadingNO;
       private string _waterUserTypeId;
       private string _waterUserTypeName;
       private string _waterUserHouseType;
       private string _waterUserState;
       private string _waterUserchargeType;
       private DateTime _waterUserCreateDate;
       private string _agentsign;
       private string _bankId;
       private string _bankName;
       private string _BankAcountNumber;
       private string _waterMeterParentId;
       private string _isSummaryMeter;
       private string _SummaryMeterClass;
       private string _MEMO;
       private string _WATERMETERNUMBERCHANGESTATE;
       private int _ordernumber;
       private decimal _WATERUSERQQYE;
       private decimal _WATERUSERJSYE;
       private decimal _WATERUSERQQYEINFORM;
       private decimal _WATERUSERJSYEINFORM;
       private decimal _WATERUSERLJQF;
       private string _INFORMNO;
       private string _INFORMPRINTSIGN;
       private string _PRINTWORKERID;
       private string _PRINTWORKERNAME;
       private DateTime _INFORMPRINTDATETIME;
        /// <summary>
        /// 是否为阶梯水价
        /// </summary>
       private int _isTrapeZoid;

        //阶梯水价1、2、3对应的阶梯水量
       private string _TrapeZoid1;
       private string _TrapeZoid2;
       private string _TrapeZoid3;

       //阶梯水价1、2、3对应的阶梯水价
       private string _TrapeZoidPrice1;
       private string _TrapeZoidPrice2;
       private string _TrapeZoidPrice3;

        /// <summary>
        /// 未抄月数
        /// </summary>
       private int _WCYS;

       public string readMeterRecordId
       {
           get
           {
               return _readMeterRecordId;
           }
           set
           {
               _readMeterRecordId = value;
           }
       }
       public string readMeterRecordIdLast
       {
           get
           {
               return _readMeterRecordIdLast;
           }
           set
           {
               _readMeterRecordIdLast = value;
           }
       }
        /// <summary>
        /// 上期读数的年月
        /// </summary>
       public string lastNumberYearMonth
       {
           get
           {
               return _lastNumberYearMonth;
           }
           set
           {
               _lastNumberYearMonth = value;
           }
       }
       public int NotReadMonthCount
       {
           get
           {
               return _NotReadMonthCount;
           }
           set
           {
               _NotReadMonthCount = value;
           }
       }
       public string waterMeterId
       {
           get
           {
               return _waterMeterId;
           }
           set
           {
               _waterMeterId = value;
           }
       }
       public string waterMeterNo
       {
           get
           {
               return _waterMeterNo;
           }
           set
           {
               _waterMeterNo = value;
           }
       }
       public int waterMeterLastNumber
       {
           get
           {
               return _waterMeterLastNumber;
           }
           set
           {
               _waterMeterLastNumber = value;
           }
       }
       public int waterMeterEndNumber
       {
           get
           {
               return _waterMeterEndNumber;
           }
           set
           {
               _waterMeterEndNumber = value;
           }
       }
       public int SubMeterNumber
       {
           get
           {
               return _SubMeterNumber;
           }
           set
           {
               _SubMeterNumber = value;
           }
       }
       public int totalNumber
       {
           get
           {
               return _totalNumber;
           }
           set
           {
               _totalNumber = value;
           }
       }
       public string totalNumberDescribe
       {
           get
           {
               return _totalNumberDescribe;
           }
           set
           {
               _totalNumberDescribe = value;
           }
       }
       /// <summary>
       /// 平均单价
       /// </summary>
       public decimal avePrice
       {
           get
           {
               return _avePrice;
           }
           set
           {
               _avePrice = value;
           }
       }
       public string avePriceDescribe
       {
           get
           {
               return _avePriceDescribe;
           }
           set
           {
               _avePriceDescribe = value;
           }
       }
       /// <summary>
       /// 水费小计
       /// </summary>
       public decimal waterTotalCharge
       {
           get
           {
               return _waterTotalCharge;
           }
           set
           {
               _waterTotalCharge = value;
           }
       }
       public decimal extraChargePrice1
       {
           get
           {
               return _extraChargePrice1;
           }
           set
           {
               _extraChargePrice1 = value;
           }
       }
       public decimal extraChargePrice2
       {
           get
           {
               return _extraChargePrice2;
           }
           set
           {
               _extraChargePrice2 = value;
           }
       }
       public decimal extraChargePrice3
       {
           get
           {
               return _extraChargePrice3;
           }
           set
           {
               _extraChargePrice3 = value;
           }
       }
       public decimal extraChargePrice4
       {
           get
           {
               return _extraChargePrice4;
           }
           set
           {
               _extraChargePrice4 = value;
           }
       }
       public decimal extraChargePrice5
       {
           get
           {
               return _extraChargePrice5;
           }
           set
           {
               _extraChargePrice5 = value;
           }
       }
       public decimal extraChargePrice6
       {
           get
           {
               return _extraChargePrice6;
           }
           set
           {
               _extraChargePrice6 = value;
           }
       }
       public decimal extraChargePrice7
       {
           get
           {
               return _extraChargePrice7;
           }
           set
           {
               _extraChargePrice7 = value;
           }
       }
       public decimal extraChargePrice8
       {
           get
           {
               return _extraChargePrice8;
           }
           set
           {
               _extraChargePrice8 = value;
           }
       }
       public decimal extraCharge1
       {
           get
           {
               return _extraCharge1;
           }
           set
           {
               _extraCharge1 = value;
           }
       }
       public decimal extraCharge2
       {
           get
           {
               return _extraCharge2;
           }
           set
           {
               _extraCharge2 = value;
           }
       }
       public decimal extraCharge3
       {
           get
           {
               return _extraCharge3;
           }
           set
           {
               _extraCharge3 = value;
           }
       }
       public decimal extraCharge4
       {
           get
           {
               return _extraCharge4;
           }
           set
           {
               _extraCharge4 = value;
           }
       }
       public decimal extraCharge5
       {
           get
           {
               return _extraCharge5;
           }
           set
           {
               _extraCharge5 = value;
           }
       }
       public decimal extraCharge6
       {
           get
           {
               return _extraCharge6;
           }
           set
           {
               _extraCharge6 = value;
           }
       }
       public decimal extraCharge7
       {
           get
           {
               return _extraCharge7;
           }
           set
           {
               _extraCharge7 = value;
           }
       }
       public decimal extraCharge8
       {
           get
           {
               return _extraCharge8;
           }
           set
           {
               _extraCharge8 = value;
           }
       }
       /// <summary>
       /// 附加费小计
       /// </summary>
       public decimal extraTotalCharge
       {
           get
           {
               return _extraTotalCharge;
           }
           set
           {
               _extraTotalCharge = value;
           }
       }
       public string trapezoidPrice
       {
           get
           {
               return _trapezoidPrice;
           }
           set
           {
               _trapezoidPrice = value;
           }
       }
       public string extraCharge
       {
           get
           {
               return _extraCharge;
           }
           set
           {
               _extraCharge = value;
           }
       }
       /// <summary>
       /// 总应收费，含水费、附加费等费用
       /// </summary>
       public decimal totalCharge
       {
           get
           {
               return _totalCharge;
           }
           set
           {
               _totalCharge = value;
           }
       }
       /// <summary>
       /// 滞纳金
       /// </summary>
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
       public int readMeterRecordYear
       {
           get
           {
               return _readMeterRecordYear;
           }
           set
           {
               _readMeterRecordYear = value;
           }
       }
       public int readMeterRecordMonth
       {
           get
           {
               return _readMeterRecordMonth;
           }
           set
           {
               _readMeterRecordMonth = value;
           }
       }
       public DateTime readMeterRecordYearAndMonth
       {
           get
           {
               return _readMeterRecordYearAndMonth;
           }
           set
           {
               _readMeterRecordYearAndMonth = value;
           }
       }
       public DateTime initialReadMeterMesDateTime
       {
           get
           {
               return _initialReadMeterMesDateTime;
           }
           set
           {
               _initialReadMeterMesDateTime = value;
           }
       }
       public DateTime readMeterRecordDate
       {
           get
           {
               return _readMeterRecordDate;
           }
           set
           {
               _readMeterRecordDate = value;
           }
       }
       public int WATERFIXVALUE
       {
           get
           {
               return _WATERFIXVALUE;
           }
           set
           {
               _WATERFIXVALUE = value;
           }
       }
       public string waterMeterPositionName
       {
           get
           {
               return _waterMeterPositionName;
           }
           set
           {
               _waterMeterPositionName = value;
           }
       }
       public string IsReverse
       {
           get
           {
               return _IsReverse;
           }
           set
           {
               _IsReverse = value;
           }
       }
       public string waterMeterState
       {
           get
           {
               return _waterMeterState;
           }
           set
           {
               _waterMeterState = value;
           }
       }
       public string waterMeterSizeId
       {
           get
           {
               return _waterMeterSizeId;
           }
           set
           {
               _waterMeterSizeId = value;
           }
       }
       public string waterMeterSizeValue
       {
           get
           {
               return _waterMeterSizeValue;
           }
           set
           {
               _waterMeterSizeValue = value;
           }
       }
       public string waterMeterTypeId
       {
           get
           {
               return _waterMeterTypeId;
           }
           set
           {
               _waterMeterTypeId = value;
           }
       }  
       public string waterMeterTypeName
       {
           get
           {
               return _waterMeterTypeName;
           }
           set
           {
               _waterMeterTypeName = value;
           }
       }
       public string waterMeterTypeClassID
       {
           get
           {
               return _waterMeterTypeClassID;
           }
           set
           {
               _waterMeterTypeClassID = value;
           }
       }
       public string waterMeterTypeClassName
       {
           get
           {
               return _waterMeterTypeClassName;
           }
           set
           {
               _waterMeterTypeClassName = value;
           }
       }  
       public string waterMeterProduct
       {
           get
           {
               return _waterMeterProduct;
           }
           set
           {
               _waterMeterProduct = value;
           }
       }
       public string waterMeterSerialNumber
       {
           get
           {
               return _waterMeterSerialNumber;
           }
           set
           {
               _waterMeterSerialNumber = value;
           }
       }
       public string ChannelNO
       {
           get
           {
               return _ChannelNO;
           }
           set
           {
               _ChannelNO = value;
           }
       }
       public string waterMeterMode
       {
           get
           {
               return _waterMeterMode;
           }
           set
           {
               _waterMeterMode = value;
           }
       }
       public int waterMeterMagnification
       {
           get
           {
               return _waterMeterMagnification;
           }
           set
           {
               _waterMeterMagnification = value;
           }
       }
       public int waterMeterMaxRange
       {
           get
           {
               return _waterMeterMaxRange;
           }
           set
           {
               _waterMeterMaxRange = value;
           }
       }

       public string chargerID
       {
           get
           {
               return _chargerID;
           }
           set
           {
               _chargerID = value;
           }
       }
       public string chargerName
       {
           get
           {
               return _chargerName;
           }
           set
           {
               _chargerName = value;
           }
       }
       public string meterReaderID
       {
           get
           {
               return _meterReaderID;
           }
           set
           {
               _meterReaderID = value;
           }
       }
       public string meterReaderName
       {
           get
           {
               return _meterReaderName;
           }
           set
           {
               _meterReaderName = value;
           }
       }
       public string checkState
       {
           get
           {
               return _checkState;
           }
           set
           {
               _checkState = value;
           }
       }
       public DateTime checkDateTime
       {
           get
           {
               return _checkDateTime;
           }
           set
           {
               _checkDateTime = value;
           }
       }
       public string checker
       {
           get
           {
               return _checker;
           }
           set
           {
               _checker = value;
           }
       }
       public string chargeState
       {
           get
           {
               return _chargeState;
           }
           set
           {
               _chargeState = value;
           }
       }
       public string chargeID
       {
           get
           {
               return _chargeID;
           }
           set
           {
               _chargeID = value;
           }
       }

       public string waterUserId
       {
           get
           {
               return _waterUserId;
           }
           set
           {
               _waterUserId = value;
           }
       }
       public string waterUserNO
       {
           get
           {
               return _waterUserNO;
           }
           set
           {
               _waterUserNO = value;
           }
       }
       public string waterUserName
       {
           get
           {
               return _waterUserName;
           }
           set
           {
               _waterUserName = value;
           }
       }
       public string waterUserNameCode
       {
           get
           {
               return _waterUserNameCode;
           }
           set
           {
               _waterUserNameCode = value;
           }
       }
       public string waterUserTelphoneNO
       {
           get
           {
               return _waterUserTelphoneNO;
           }
           set
           {
               _waterUserTelphoneNO = value;
           }
       }
       public string waterPhone
       {
           get
           {
               return _waterPhone;
           }
           set
           {
               _waterPhone = value;
           }
       }
       public string areaNO
       {
           get
           {
               return _areaNO;
           }
           set
           {
               _areaNO = value;
           }
       }
       public string pianNO
       {
           get
           {
               return _pianNO;
           }
           set
           {
               _pianNO = value;
           }
       }
       public string duanNO
       {
           get
           {
               return _duanNO;
           }
           set
           {
               _duanNO = value;
           }
       }
       public string communityID
       {
           get
           {
               return _communityID;
           }
           set
           {
               _communityID = value;
           }
       }
       public string COMMUNITYNAME
       {
           get
           {
               return _COMMUNITYNAME;
           }
           set
           {
               _COMMUNITYNAME = value;
           }
       }
       public string buildingNO
       {
           get
           {
               return _buildingNO;
           }
           set
           {
               _buildingNO = value;
           }
       }
       public string unitNO
       {
           get
           {
               return _unitNO;
           }
           set
           {
               _unitNO = value;
           }
       }
       public string createType
       {
           get
           {
               return _createType;
           }
           set
           {
               _createType = value;
           }
       }
       public string waterUserAddress
       {
           get
           {
               return _waterUserAddress;
           }
           set
           {
               _waterUserAddress = value;
           }
       }
       public int waterUserPeopleCount
       {
           get
           {
               return _waterUserPeopleCount;
           }
           set
           {
               _waterUserPeopleCount = value;
           }
       }
       public string meterReadingID
       {
           get
           {
               return _meterReadingID;
           }
           set
           {
               _meterReadingID = value;
           }
       }
       public string meterReadingNO
       {
           get
           {
               return _meterReadingNO;
           }
           set
           {
               _meterReadingNO = value;
           }
       }
       public string meterReadingPageNo
       {
           get
           {
               return _meterReadingPageNo;
           }
           set
           {
               _meterReadingPageNo = value;
           }
       }
       public string waterUserTypeId
       {
           get
           {
               return _waterUserTypeId;
           }
           set
           {
               _waterUserTypeId = value;
           }
       }
       public string waterUserTypeName
       {
           get
           {
               return _waterUserTypeName;
           }
           set
           {
               _waterUserTypeName = value;
           }
       }
       public string waterUserHouseType
       {
           get
           {
               return _waterUserHouseType;
           }
           set
           {
               _waterUserHouseType = value;
           }
       }
       public string waterUserState
       {
           get
           {
               return _waterUserState;
           }
           set
           {
               _waterUserState = value;
           }
       }
       public string waterUserchargeType
       {
           get
           {
               return _waterUserchargeType;
           }
           set
           {
               _waterUserchargeType = value;
           }
       }
       public DateTime waterUserCreateDate
       {
           get
           {
               return _waterUserCreateDate;
           }
           set
           {
               _waterUserCreateDate = value;
           }
       }
       public string agentsign
       {
           get
           {
               return _agentsign;
           }
           set
           {
               _agentsign = value;
           }
       }
       public string bankId
       {
           get
           {
               return _bankId;
           }
           set
           {
               _bankId = value;
           }
       }
       public string bankName
       {
           get
           {
               return _bankName;
           }
           set
           {
               _bankName = value;
           }
       }
       public string BankAcountNumber
       {
           get
           {
               return _BankAcountNumber;
           }
           set
           {
               _BankAcountNumber = value;
           }
       }
        /// <summary>
        /// 是否为总表
        /// </summary>
       public string isSummaryMeter
       {
           get
           {
               return _isSummaryMeter;
           }
           set
           {
               _isSummaryMeter = value;
           }
       }
       public string SummaryMeterClass
       {
           get
           {
               return _SummaryMeterClass;
           }
           set
           {
               _SummaryMeterClass = value;
           }
       }
       public string waterMeterParentId
       {
           get
           {
               return _waterMeterParentId;
           }
           set
           {
               _waterMeterParentId = value;
           }
       }
        /// <summary>
        /// 抄表顺序
        /// </summary>
       public int ordernumber
       {
           get
           {
               return _ordernumber;
           }
           set
           {
               _ordernumber = value;
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
       public string WATERMETERNUMBERCHANGESTATE
       {
           get
           {
               return _WATERMETERNUMBERCHANGESTATE;
           }
           set
           {
               _WATERMETERNUMBERCHANGESTATE = value;
           }
       }
       public decimal WATERUSERQQYE
       {
           get
           {
               return _WATERUSERQQYE;
           }
           set
           {
               _WATERUSERQQYE = value;
           }
       }
       public decimal WATERUSERJSYE
       {
           get
           {
               return _WATERUSERJSYE;
           }
           set
           {
               _WATERUSERJSYE = value;
           }
       }
       public decimal WATERUSERQQYEINFORM
       {
           get
           {
               return _WATERUSERQQYEINFORM;
           }
           set
           {
               _WATERUSERQQYEINFORM = value;
           }
       }
       public decimal WATERUSERJSYEINFORM
       {
           get
           {
               return _WATERUSERJSYEINFORM;
           }
           set
           {
               _WATERUSERJSYEINFORM = value;
           }
       }
       public decimal WATERUSERLJQF
       {
           get
           {
               return _WATERUSERLJQF;
           }
           set
           {
               _WATERUSERLJQF = value;
           }
       }
       public string INFORMNO
       {
           get
           {
               return _INFORMNO;
           }
           set
           {
               _INFORMNO = value;
           }
       }
       public string INFORMPRINTSIGN
       {
           get
           {
               return _INFORMPRINTSIGN;
           }
           set
           {
               _INFORMPRINTSIGN = value;
           }
       }
       public string PRINTWORKERID
       {
           get
           {
               return _PRINTWORKERID;
           }
           set
           {
               _PRINTWORKERID = value;
           }
       }
       public string PRINTWORKERNAME
       {
           get
           {
               return _PRINTWORKERNAME;
           }
           set
           {
               _PRINTWORKERNAME = value;
           }
       }
       public DateTime INFORMPRINTDATETIME
       {
           get
           {
               return _INFORMPRINTDATETIME;
           }
           set
           {
               _INFORMPRINTDATETIME = value;
           }
       }
        //是否为阶梯水价
       public int isTrapeZoid
       {
           get
           {
               return _isTrapeZoid;
           }
           set
           {
               _isTrapeZoid = value;
           }
       }
       public string TrapeZoid1
       {
           get
           {
               return _TrapeZoid1;
           }
           set
           {
               _TrapeZoid1 = value;
           }
       }
       public string TrapeZoid2
       {
           get
           {
               return _TrapeZoid2;
           }
           set
           {
               _TrapeZoid2 = value;
           }
       }
       public string TrapeZoid3
       {
           get
           {
               return _TrapeZoid3;
           }
           set
           {
               _TrapeZoid3 = value;
           }
       }
       public string TrapeZoidPrice1
       {
           get
           {
               return _TrapeZoidPrice1;
           }
           set
           {
               _TrapeZoidPrice1 = value;
           }
       }
       public string TrapeZoidPrice2
       {
           get
           {
               return _TrapeZoidPrice2;
           }
           set
           {
               _TrapeZoidPrice2 = value;
           }
       }
       public string TrapeZoidPrice3
       {
           get
           {
               return _TrapeZoidPrice3;
           }
           set
           {
               _TrapeZoidPrice3 = value;
           }
       }
       //未抄月数
       public int WCYS
       {
           get
           {
               return _WCYS;
           }
           set
           {
               _WCYS = value;
           }
       }
    }
}
