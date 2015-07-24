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
    using RemotingRef;
    using Robot.Report.RngCasino.Configuration;

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
                var currencyList = GetCurrencyList();
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
                            Currency = Converter.ToInt(row.currency),
                            CurrencyName = currencyList[Converter.ToInt(row.currency)],
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
                    result = SendProblemEmail(customerList, mailTo, cc, bcc, title, subject);
                }
                else
                {
                    result = SendEmptyEmail(title, mailTo, cc, bcc, fromDate, toDate);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return result;
        }

        private bool SendProblemEmail(List<UserInfo> customerList, string mailTo, string cc, string bcc, string title, string subject)
        {
            string appLocation = AppDomain.CurrentDomain.BaseDirectory;
            var template = File.ReadAllText(appLocation + @"/Templates/EmailTemplate.cshtml");
            var content = RazorEngine.Razor.Parse(template, customerList);
            var result = EmailHelper.SendMail(mailTo, cc, bcc, title, subject, content, null);

            return result;
        }

        // Legacy code by Jacob. Should be reviewed and removed at new code
        private bool SendEmptyEmail(string title, string mailTo, string cc, string bcc, DateTime fromDate, DateTime toDate)
        {
            var winloss = AppSetting.WinLoss;
            var subject = string.Format(EmailSetting.EmptySubject, AppSetting.BaseCurrency, NumberExtension.WinLossFormat(winloss, 0), fromDate, toDate);
            
            string appLocation = AppDomain.CurrentDomain.BaseDirectory;
            var template = File.ReadAllText(appLocation + @"/Templates/EmptyEmailTemplate.cshtml");
            var content = RazorEngine.Razor.Parse(template);
            var result = EmailHelper.SendMail(mailTo, cc, bcc, title, subject, content, null);
            
            return result;
        }

        public Dictionary<int, string> GetCurrencyList()
        {
            var currencyCriteria = new GetCurrencyListCriteria();
            var currencyList = new Dictionary<int, string>();
            try
            {
                var rowData = this.GetReportData<dynamic>(currencyCriteria);
                if (rowData != null)
                {
                    foreach (var row in rowData)
                    {
                        currencyList.Add(Converter.ToInt(row.exchangeid), Converter.ToString2(row.currency));
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return currencyList;
        }
    }
}
