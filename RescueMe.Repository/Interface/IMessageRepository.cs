using RescueMe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RescueMe.Repository.Interface
{
    public interface IMessageRepository
    {
        bool SendMessage(smsModel user, MessageConfiguration Msgconfig);
    }
}
