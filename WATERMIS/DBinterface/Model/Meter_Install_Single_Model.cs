using System;
namespace DBinterface.Model
{
	/// <summary>
	/// Meter_Install_Single:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Meter_Install_Single
	{
		public Meter_Install_Single()
		{}
		#region Model
		private string _singleid;
		private int _sd;
		private int? _acceptid;
		private int? _querykey;
		private string _loginid;
		private string _username;
		private DateTime? _acceptdate;
		private string _waterusertypeid;
		private int? _state=0;
		private string _flowid;
		private string _applyuser;
		private byte[] _waterusername;
		private DateTime? _submitdate= DateTime.Now;
		private string _contractno;
		private string _wateruseraddress;
		private bool _isboost= false;
		private int? _wateruserpeoplecount;
		private string _wateruserhousetype;
		private string _waterphone;
		/// <summary>
		/// 
		/// </summary>
		public string SingleID
		{
			set{ _singleid=value;}
			get{return _singleid;}
		}
		/// <summary>
		/// 流水号
		/// </summary>
		public int SD
		{
			set{ _sd=value;}
			get{return _sd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AcceptID
		{
			set{ _acceptid=value;}
			get{return _acceptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? QueryKey
		{
			set{ _querykey=value;}
			get{return _querykey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string loginId
		{
			set{ _loginid=value;}
			get{return _loginid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AcceptDate
		{
			set{ _acceptdate=value;}
			get{return _acceptdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string waterUserTypeId
		{
			set{ _waterusertypeid=value;}
			get{return _waterusertypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FlowID
		{
			set{ _flowid=value;}
			get{return _flowid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplyUser
		{
			set{ _applyuser=value;}
			get{return _applyuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] waterUserName
		{
			set{ _waterusername=value;}
			get{return _waterusername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SubmitDate
		{
			set{ _submitdate=value;}
			get{return _submitdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContractNO
		{
			set{ _contractno=value;}
			get{return _contractno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string waterUserAddress
		{
			set{ _wateruseraddress=value;}
			get{return _wateruseraddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsBoost
		{
			set{ _isboost=value;}
			get{return _isboost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? waterUserPeopleCount
		{
			set{ _wateruserpeoplecount=value;}
			get{return _wateruserpeoplecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string waterUserHouseType
		{
			set{ _wateruserhousetype=value;}
			get{return _wateruserhousetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string waterPhone
		{
			set{ _waterphone=value;}
			get{return _waterphone;}
		}
		#endregion Model

	}
}

