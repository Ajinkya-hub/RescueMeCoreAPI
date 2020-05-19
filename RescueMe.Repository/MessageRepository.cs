using RescueMe.Models;
using RescueMe.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace RescueMe.Repository
{
    public class MessageRepository : IMessageRepository
    {
        public bool SendMessage(smsModel user, MessageConfiguration Msgconfig)
        {
            try
            {

                //foreach (var number in user.Numbers)
                //{
                //    TwilioClient.Init(Msgconfig.AccountSID, Msgconfig.AuthToken);

                //    var message = MessageResource.Create(
                //        body: Msgconfig.MobileMessageText,
                //        messagingServiceSid: null,
                //        from: new PhoneNumber(Msgconfig.FromMobileNo),
                //        to: new PhoneNumber(number)
                //    );
                //}

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
