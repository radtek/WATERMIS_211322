using System;
using System.Collections.Generic;
using System.Text;

namespace DBinterface.Model
{
   public class Log_Model
    {
       public Log_Model()
		{}
		#region Model
		private string _taskid;
		private string _resolveid;
		private int _pointsort;
		private string _loginid;
		private string _username;
		private int _state=0;
		private string _useropinion;
		private bool _ispass= true;
		private bool _isgoback= false;
		private string _ip;
		private string _computername;
		private string _matter;
		private DateTime? _createdate= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public string TaskID
		{
			set{ _taskid=value;}
			get{return _taskid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResolveID
		{
			set{ _resolveid=value;}
			get{return _resolveid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PointSort
		{
			set{ _pointsort=value;}
			get{return _pointsort;}
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
		public int State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserOpinion
		{
			set{ _useropinion=value;}
			get{return _useropinion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsPass
		{
			set{ _ispass=value;}
			get{return _ispass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsGoBack
		{
			set{ _isgoback=value;}
			get{return _isgoback;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ComputerName
		{
			set{ _computername=value;}
			get{return _computername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Matter
		{
			set{ _matter=value;}
			get{return _matter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model
    }
}
