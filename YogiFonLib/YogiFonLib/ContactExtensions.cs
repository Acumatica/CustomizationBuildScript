using PX.Data.EP;
using PX.Data;
using PX.Objects.AP;
using PX.Objects.CR.MassProcess;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.EP;
using PX.Objects;
using PX.SM;
using PX.TM;
using System.Collections.Generic;
using System;

namespace PX.Objects.CR
{
  public class ContactExt : PXCacheExtension<PX.Objects.CR.Contact>
  {
    #region UsrPersonalIDType
    [PXDBString(1)]
    [PXUIField(DisplayName = "Personal ID Type")]
    [PXStringList(
  new string[] { "P", "D", "S" },
  new string[] { "Passport", "Driver's License", "Social Security Number" })]
    public virtual string UsrPersonalIDType { get; set; }
    public abstract class usrPersonalIDType : IBqlField { }
    #endregion

    #region UsrPersonalID
    [PXDBString(15)]
    [PXUIField(DisplayName="Personal ID")]

    public virtual string UsrPersonalID { get; set; }
    public abstract class usrPersonalID : IBqlField { }
    #endregion

    #region UsrCreditRecordVerified
    [PXDBBool]
    [PXUIField(DisplayName="Credit Record Verified")]

    public virtual bool? UsrCreditRecordVerified { get; set; }
    public abstract class usrCreditRecordVerified : IBqlField { }
    #endregion
  }
}