// -----------------------------------------------------------------------
// <copyright file="RNGCasinoCustomerCriteria.cs" company="Nexcel">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Robot.Report.RngCasino.Criteria
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
using Fanex.NAP.Framework.Data;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CustomerWinLossCriteria : CriteriaBase
    {
        public int sentTime { get; set; }

        public decimal winlostMYR { get; set; }

        public override string GetSettingKey()
        {
            return "";
        }
    }
}
