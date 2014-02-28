// -----------------------------------------------------------------------
// <copyright file="CustomerWinLossService.cs" company="Nexcel">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Robot.Report.RngCasino.Business
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Fanex.Common;
    using Robot.Report.RngCasino.Criteria;
    using Robot.Report.RngCasino.Entities;
    using Robot.Report.RngCasino.Helper.Implement;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CustomerWinLossService : ServiceBase
    {
        /// <summary>
        /// Get list customer.
        /// </summary>
        /// <param name="duration">The period win loss tickets are calculated.</param>
        /// <param name="sentTime">The time mail is sent.</param>
        /// <param name="winlostMYR">Win loss MYR.</param>
        /// <returns>List of customers.</returns>
        public List<UserInfo> GetCustomerWinLoss(DateTime fromDate, DateTime toDate, decimal winlost)
        {
            var customerList = new List<UserInfo>();
            var customerCriteria = new CustomerWinLossCriteria();
            try
            {
                customerCriteria.FromDate = fromDate;
                customerCriteria.ToDate = toDate;
                customerCriteria.WinLoss = winlost;
               
                var rowData = this.GetReportData<dynamic>(customerCriteria);
                if (rowData != null)
                {
                    foreach (var row in rowData)
                    {
                        var customerInfo = new UserInfo() 
                        { 
                            Member = Converter.ToString2(row.member),
                            Agency = Converter.ToString2(row.agent),
                            WinlossBaseCurrency = Converter.ToDecimal(row.winlost_rm),
                            Winloss = Converter.ToDecimal(row.winlost)
                        };
                        customerList.Add(customerInfo);
                    }                   
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return customerList;
        }

        /// <summary>
        /// Send mail.
        /// </summary>
        /// <param name="duration">Period time to calculate win loss.</param>
        /// <param name="sentTime">Content of mail.</param>
        /// <param name="winlostMYR">Win loss in Base Currency.</param>
        /// <param name="subject">Subject of mail.</param>
        /// <param name="title">Title of mail.</param>
        /// <param name="mailTo">Address mail of received person.</param>
        /// <param name="cc">Cc address of mail.</param>
        /// <param name="bcc">Bcc address of mail.</param>
        /// <returns>Check mail is sent or not.</returns>
        public bool SendMail(DateTime fromDate, DateTime toDate, decimal winlost, string subject, string title, string mailTo, string cc, string bcc)
        {
            var result = false;
            try
            {
                var customerList = GetCustomerWinLoss(fromDate, toDate, winlost);
                if (customerList != null && customerList.Count > 0)
                {
                    string appLocation = AppDomain.CurrentDomain.BaseDirectory;
                    var template = File.ReadAllText(appLocation + @"/Templates/EmailTemplate.cshtml");
                    var content = RazorEngine.Razor.Parse(template, customerList);
                    result = EmailHelper.SendMail(mailTo, cc, bcc, title, subject, content, null);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return result;
        }
    }
}
