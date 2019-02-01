﻿using BQA.DataBase.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace BQA.Common
{
    public class EmailService
    {
        public static bool Send(string toEmail, string subject, string body)
        {
            try
            {
                CaiDatHeThong caiDat = Common.LayCaiDat();
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.EnableSsl = true;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 25;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(
                    caiDat.Email,
                    "123456");
                var msg = new MailMessage
                {
                    IsBodyHtml = true,
                    BodyEncoding = Encoding.UTF8,
                    From = new MailAddress(
                        caiDat.Email),
                    Subject = subject,
                    Body = body,
                    Priority = MailPriority.Normal,
                };
                msg.To.Add(toEmail);
                smtpClient.Send(msg);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool Send(string toEmail, string subject, string body, string fromEmail, string password)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.EnableSsl = true;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 25;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(fromEmail, password);
                var msg = new MailMessage
                {
                    IsBodyHtml = true,
                    BodyEncoding = Encoding.UTF8,
                    From = new MailAddress(fromEmail),
                    Subject = subject,
                    Body = body,
                    Priority = MailPriority.Normal,
                };

                msg.To.Add(toEmail);

                smtpClient.Send(msg);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}