using System;
using System.Collections.Generic;
using System.Text;

namespace DBinterface.Model
{
    public class Meter_Model
    {
        public Meter_Model()
        { }
        #region Model
        private string _meterid;
        private int _watermeterstartnumber = 0;
        private int? _meterstate = 0;
        private string _wateruserid;
        private string _watermeterpositionname;
        private string _watermeterpositionid;
        private string _watermetersizeid;
        private string _watermetertypeid;
        private int? _waterfixvalue = 0;
        private string _watermeterproduct;
        private string _watermeterserialnumber;
        private string _watermetermode;
        private string _issummarymeter = "1";
        private string _watermeterparentid;
        private int? _watermetermagnification = 1;
        private int? _watermetermaxrange = 99999;
        private DateTime? _watermeterproofreadingdate;
        private int? _watermeteproofreadingperiod = 0;
        private DateTime? _startusedatetime;
        private string _memo;
        private DateTime? _createdate = DateTime.Now;
        private DateTime? _scrapdate;
        private string _scrapreason;
        /// <summary>
        /// 
        /// </summary>
        public string MeterID
        {
            set { _meterid = value; }
            get { return _meterid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int waterMeterStartNumber
        {
            set { _watermeterstartnumber = value; }
            get { return _watermeterstartnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MeterState
        {
            set { _meterstate = value; }
            get { return _meterstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string waterUserId
        {
            set { _wateruserid = value; }
            get { return _wateruserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string waterMeterPositionName
        {
            set { _watermeterpositionname = value; }
            get { return _watermeterpositionname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string waterMeterPositionId
        {
            set { _watermeterpositionid = value; }
            get { return _watermeterpositionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string waterMeterSizeId
        {
            set { _watermetersizeid = value; }
            get { return _watermetersizeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string waterMeterTypeId
        {
            set { _watermetertypeid = value; }
            get { return _watermetertypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? WATERFIXVALUE
        {
            set { _waterfixvalue = value; }
            get { return _waterfixvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string waterMeterProduct
        {
            set { _watermeterproduct = value; }
            get { return _watermeterproduct; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string waterMeterSerialNumber
        {
            set { _watermeterserialnumber = value; }
            get { return _watermeterserialnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string waterMeterMode
        {
            set { _watermetermode = value; }
            get { return _watermetermode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string isSummaryMeter
        {
            set { _issummarymeter = value; }
            get { return _issummarymeter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string waterMeterParentId
        {
            set { _watermeterparentid = value; }
            get { return _watermeterparentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? waterMeterMagnification
        {
            set { _watermetermagnification = value; }
            get { return _watermetermagnification; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? waterMeterMaxRange
        {
            set { _watermetermaxrange = value; }
            get { return _watermetermaxrange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? waterMeterProofreadingDate
        {
            set { _watermeterproofreadingdate = value; }
            get { return _watermeterproofreadingdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? waterMeteProofreadingPeriod
        {
            set { _watermeteproofreadingperiod = value; }
            get { return _watermeteproofreadingperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? STARTUSEDATETIME
        {
            set { _startusedatetime = value; }
            get { return _startusedatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MEMO
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ScrapDate
        {
            set { _scrapdate = value; }
            get { return _scrapdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ScrapReason
        {
            set { _scrapreason = value; }
            get { return _scrapreason; }
        }
        #endregion Model

    }
}

