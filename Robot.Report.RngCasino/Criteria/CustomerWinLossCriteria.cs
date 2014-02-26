// -----------------------------------------------------------------------
// <copyright file="CustomerWinLossCriteria.cs" company="Nexcel">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Robot.Report.RngCasino.Criteria
{
    using System;
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CustomerWinLossCriteria : CriteriaBase
    {
        [SpParam(SqlParamName = "senttime")]
        public DateTime SentTime { get; set; }

        [SpParam(SqlParamName = "amount")]
        public decimal WinLoss { get; set; }

        [SpParam(SqlParamName = "hours")]
        public int Duration { get; set; }

        public override bool IsValid()
        {
            return true;
        }

        public override string GetSettingKey()
        {
            return "RNGCasinoCustomerWinLoss";
        }
    }
}
