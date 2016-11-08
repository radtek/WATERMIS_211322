
using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class ModelMeter_WorkResolveFee_Invoice_Detail
   {
       private string _InvoicePrintID;

       public string InvoicePrintID
       {
           get { return _InvoicePrintID; }
           set { _InvoicePrintID = value; }
       }
       private int _DetailIndex;

       public int DetailIndex
       {
           get { return _DetailIndex; }
           set { _DetailIndex = value; }
       }
       private string _FeeItem;

       public string FeeItem
       {
           get { return _FeeItem; }
           set { _FeeItem = value; }
       }
       private string _FeeItemInvoiceTitle;

       public string FeeItemInvoiceTitle
       {
           get { return _FeeItemInvoiceTitle; }
           set { _FeeItemInvoiceTitle = value; }
       }
       private decimal _Quatity;

       public decimal Quatity
       {
           get { return _Quatity; }
           set { _Quatity = value; }
       }
       private decimal _Price;

       public decimal Price
       {
           get { return _Price; }
           set { _Price = value; }
       }
       private decimal _TaxPercent;

       public decimal TaxPercent
       {
           get { return _TaxPercent; }
           set { _TaxPercent = value; }
       }
       private decimal _TaxMoney;

       public decimal TaxMoney
       {
           get { return _TaxMoney; }
           set { _TaxMoney = value; }
       }
       private decimal _TotalMoney;

       public decimal TotalMoney
       {
           get { return _TotalMoney; }
           set { _TotalMoney = value; }
       }
    }
}
