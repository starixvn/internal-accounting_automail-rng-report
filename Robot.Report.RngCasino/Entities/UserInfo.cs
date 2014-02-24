// -----------------------------------------------------------------------
// <copyright file="RNGCasinoUserInfo.cs" company="Nexcel">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Robot.Report.RngCasino.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UserInfo
    {
        public int Index { get; set; }

        public string Member { get; set; }

        public string Agency { get; set; }

        public decimal WinlossAmountMYR { get; set; }

        public decimal WinlossAmountUserCurr { get; set; }
    }
}
