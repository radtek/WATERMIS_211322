using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;
using System.ComponentModel;
using Common.DotNetCode;
using System.Drawing;

namespace Common.WinControl.Ryan.RegTextbox
{
    public class Info
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
    [ToolboxBitmap(typeof(RyanTextBox), "RyanTextBox.png")]
    public partial class RyanTextBox : TextBox, IRyanControl
    {
        private static ToolTip _tooltip;

        private bool EmptyValidate(Control ctl)
        {
            IRyanControl c = ctl as IRyanControl;
            _ValidateState = true;
            if (!c.AllowEmpty)
            {
                if ((c.RemoveSpace && ctl.Text.Trim() == "") || ctl.Text == "")
                {
                    c.EmptyMessage = "输入不能为空！";
                    ShowErrorMessage(ctl, c.EmptyMessage);
                    c.SelectAll();
                    //ctl.Focus();
                    _ValidateState = false;
                    return false;
                }
                else
                {
                    if (_tooltip != null) _tooltip.Dispose();

                }
            }
            else
            {
                if (_tooltip != null) _tooltip.Dispose();
            }
            return true;
        }
        private static bool RegexExpressionValidate(Control ctl)
        {
            IRyanControl c = ctl as IRyanControl;

            if (!((c.RemoveSpace && ctl.Text.Trim() == "") || ctl.Text == ""))
            {
                if (!string.IsNullOrEmpty(c.RegexExpression) &&
                    !Regex.IsMatch((c.RemoveSpace ? ctl.Text.Trim() : ctl.Text),
                    c.RegexExpression))
                {
                    ShowErrorMessage(ctl, c.ErrorMessage);
                    c.SelectAll();
                    ctl.Focus();
                    return false;
                }
            }

            return true;
        }

        private string ChgDot(string _oldText)
        {
            return _oldText.Replace('。', '.');
        }
        private bool InputTypeValidate(Control ctl)
        {
            IRyanControl c = ctl as IRyanControl;

            switch (_InputType)
            {
                case EMInputTypes.文本:
                    _ValidateState = true;
                    break;
                case EMInputTypes.数字:
                    ctl.Text = StringCS.ToDBC(ctl.Text);
                    c.RegexExpression = "^([0-9]{1,})$";
                    c.ErrorMessage = "请输入整数数字。格式：[0-9]！";
                    _ValidateState = RegexExpressionValidate(ctl);
                    break;
                case EMInputTypes.货币:
                    ctl.Text = ChgDot(StringCS.ToDBC(ctl.Text));
                    c.RegexExpression = "^([1-9]\\d*|0)(\\.\\d+)?$";
                    c.ErrorMessage = "请输入货币类型。格式[9999999999.9999]！";
                    _ValidateState = RegexExpressionValidate(ctl);
                    break;
                case EMInputTypes.日期:
                    ctl.Text = StringCS.ToDBC(ctl.Text);
                    //c.RegexExpression = "^[+-]?\\d*[.]?\\d*$";
                    //c.ErrorMessage = "请输入日期类型。格式[2000-01-01]！";
                    //_ValidateState = RegexExpressionValidate(ctl);
                    DateTime _dt = DateTime.Now;
                    if (DateTime.TryParse(ctl.Text, out _dt))
                    {
                        _ValidateState = true;
                    }
                    else
                    {
                        c.ErrorMessage = "请输入日期类型。格式[2000-01-01]！";
                        ShowErrorMessage(ctl, c.ErrorMessage);
                        c.SelectAll();
                        _ValidateState = false;
                    }
                    break;
                case EMInputTypes.身份证:
                    ctl.Text = StringCS.ToDBC(ctl.Text);
                    if (IDCardValidation.CheckIDCard(ctl.Text))
                    {
                        _ValidateState = true;
                    }
                    else
                    {
                        c.ErrorMessage = "请输入正确的身份证号码。";
                        _ValidateState = false;
                    }
                    break;
                case EMInputTypes.手机号:
                    ctl.Text = StringCS.ToDBC(ctl.Text);
                    c.RegexExpression = "^(13|14|15|17|18)\\d{9}$";
                    c.ErrorMessage = "请输入正确的手机号。";
                    _ValidateState = RegexExpressionValidate(ctl);
                    break;
                case EMInputTypes.IP地址:
                    ctl.Text = StringCS.ToDBC(ctl.Text);
                    c.RegexExpression = "^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$";
                    c.ErrorMessage = "请输入正确格式的IP地址。格式[202.202.202.202]。";
                    _ValidateState = RegexExpressionValidate(ctl);
                    break;
                default:
                    _ValidateState = true;
                    break;
            }
            return _ValidateState;
        }

        private static bool InvokeCustomerEvent(Control ctl)
        {
            PropertyInfo pi = ctl.GetType().GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
            if (pi != null)
            {
                EventHandlerList ehl = (EventHandlerList)pi.GetValue(ctl, null);
                if (ehl != null)
                {
                    FieldInfo fi = ctl.GetType().GetField("CustomerValidated", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                    if (fi != null)
                    {
                        Delegate d = fi.GetValue(ctl) as Delegate;
                        if (d != null)
                        {
                            CustomerEventArgs ce = new CustomerEventArgs();
                            ce.Value = ctl.Text;
                            ce.Validated = true;
                            d.DynamicInvoke(ctl, ce);
                            if (!ce.Validated)
                            {
                                ShowErrorMessage(ctl, ce.ErrorMessage);
                                (ctl as IRyanControl).SelectAll();
                                ctl.Focus();
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private static Control _ShowControl;

        private static void ShowErrorMessage(Control ctl, string err)
        {
            if (_tooltip != null) _tooltip.Dispose();
            _tooltip = new ToolTip();
            _tooltip.ToolTipIcon = ToolTipIcon.Warning;
            _tooltip.IsBalloon = true;
            _tooltip.ToolTipTitle = "提示";
            _tooltip.AutoPopDelay = 5000;
            //_tooltip.ShowAlways = true;
            if (err == null) err = " ";
            TextBox tb = (TextBox)ctl;
            tb.BackColor = Color.MistyRose;
            int l = err.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).Length;
            _ShowControl = ctl;
            _tooltip.Show(err, ctl, new System.Drawing.Point(5, -60 - l * 18 + (ctl.Height - 21) / 2));
            _ShowTime.Start();
        }

        #region IRyanControl 成员

        //private static string[] _InputTypes = { "", "", "", "", "", "", "" };

        public enum EMInputTypes
        {
            IP地址 = 6,
            手机号 = 5,
            身份证 = 4,
            日期 = 3,
            货币 = 2,
            数字 = 1,
            文本 = 0
        }

        private EMInputTypes _InputType;

        public EMInputTypes InputType
        {
            get
            {
                return _InputType;
            }
            set
            {
                _InputType = value;
            }
        }

        private bool _ValidateState = false;
        public bool ValidateState
        {
            get { return _ValidateState; }
            set { _ValidateState = value; }
        }

        private string _regExp = string.Empty;
        public string RegexExpression
        {
            get { return _regExp; }
            set { _regExp = value; }
        }

        private bool _allEmpty = false;
        public bool AllowEmpty
        {
            get { return _allEmpty; }
            set { _allEmpty = value; }
        }

        private bool _removeSpace = false;
        public bool RemoveSpace
        {
            get { return _removeSpace; }
            set { _removeSpace = value; }
        }

        private string _empMsg = string.Empty;
        public string EmptyMessage
        {
            get { return _empMsg; }
            set { _empMsg = value; }
        }

        private string _errMsg = string.Empty;
        public string ErrorMessage
        {
            get { return _errMsg; }
            set { _errMsg = value; }
        }

        public event CustomerValidatedHandler CustomerValidated;

        public void SelectAll()
        {
            base.SelectAll();
        }
        #endregion

        private static System.Timers.Timer _ShowTime = new System.Timers.Timer(6000);

        public void CheckInput()
        {
            if (!EmptyValidate(this)) return;

            if (!InputTypeValidate(this)) return;

            if (!InvokeCustomerEvent(this)) return;
            TextBox tb = (TextBox)this;
            tb.BackColor = Color.White;
        }

        protected override void OnLeave(EventArgs e)
        {
            CheckInput();
            _ShowTime.Enabled = true;

        }

        //protected override void OnEnter(EventArgs e)
        //{
        //    if (_tooltip != null)
        //        _tooltip.Active = true;
        //}

        protected override void OnCreateControl()
        {
            _ShowTime.Elapsed += new System.Timers.ElapsedEventHandler(TimeOut);
        }

        public void TimeOut(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (_tooltip != null)
                {
                    if (_tooltip.Active)
                    {
                        _tooltip.Hide(_ShowControl);
                        _ShowTime.Stop();
                    }
                }
                else
                {
                    _ShowTime.Stop();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
