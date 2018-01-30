using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Common;
using PX.Data;
using PX.Objects.CA;
using PX.Objects.CM;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.Objects.SO;
using PX.SM;
using PX.Objects.AR.CCPaymentProcessing;
using PX.Objects;
using PX.Objects.AR;
using PX.Objects.CT;

namespace PX.Objects.AR
{
    public class CustomerMaint_Extension : PXGraphExtension<CustomerMaint>
    {
		#region Event Handlers

		protected void Contact_UsrPersonalID_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e)
	    {
		    //Personal ID was modified; credit record has to be verified again
		    sender.SetValue<ContactExt.usrCreditRecordVerified>(e.Row, false);
	    }
	    #endregion

		public PXAction<PX.Objects.AR.Customer> verifyCreditRecord;

        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Verify Credit Record")]
        protected void VerifyCreditRecord()
        {
            Contact contact = Base.DefContact.Current;
            if (contact == null) return;

            PXCache contactCache = Base.DefContact.Cache;
            ContactExt contactExt = contactCache.GetExtension<ContactExt>(contact);
            if (String.IsNullOrEmpty(contactExt.UsrPersonalID))
            {
                throw new PXException("The credit verification failed. Personal ID is invalid.");
            }
            else
            {
                //This is where you would do the actual verification of the credit
                //record through a credit agency web service.
                contactExt.UsrCreditRecordVerified = true;
                contactCache.Update(contact);
            }
        }
    }
}