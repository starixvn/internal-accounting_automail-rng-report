// -----------------------------------------------------------------------
// <copyright file="MailSend.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Net.Mail;

namespace Robot.Report.RngCasino.Entities
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MailSend
    {
        public string To { get; set; }

        public string Cc { get; set; }

        public string Bcc { get; set; }

        public string Title { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public MailAttachment Attachment { get; set; }

        public AlternateView AltView { get; set; }
    }
}
