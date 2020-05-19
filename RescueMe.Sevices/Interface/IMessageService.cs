using RescueMe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RescueMe.Sevices.Interface
{
    public interface IMessageService
    {
        bool SendMessage(smsModel message, MessageConfiguration Msgconfig);
    }
}
