// -----------------------------------------------------------------------
// <copyright file="NumberExtension.cs" company="Nexel">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Robot.Report.RngCasino.Helper.Implement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class NumberExtension
    {
        public static string WinLossFormat(object value, byte decDigits)
        {
            if (value != null)
            {
                return @String.Format("{0:0,0.00}", value);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
