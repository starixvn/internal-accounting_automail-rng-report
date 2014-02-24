// -----------------------------------------------------------------------
// <copyright file="RNGCasinoAutomailService.cs" company="Nexcel">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Robot.Report.RngCasino.Business
{
    using System;
    using System.Collections.Generic;
    using Robot.Report.RngCasino.Criteria;
    using Robot.Report.RngCasino.Entities;
    using Robot.Report.RngCasino.Helper;
    using System.Linq;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CustomerWinLossService : ServiceBase
    {
        public List<UserInfo> GetRNGCasinoCustomer(int sentTime, decimal winlostMYR)
        {
            var customerList = new List<UserInfo>();
            var customerCriteria = new CustomerWinLossCriteria();
            try
            {
                customerCriteria.sentTime = sentTime;
                customerCriteria.winlostMYR = winlostMYR;
                var rowData = base.GetReportData<dynamic>(customerCriteria);
                if (rowData != null)
                {

                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        public bool RNGCasinoSendMail(string content, string title, string mailTo, string cc, string bcc)
        {
            var result = false;
            try
            {
            
            }
            catch (Exception ex)
            {
                
            }
            return result;
        }
    }
}
