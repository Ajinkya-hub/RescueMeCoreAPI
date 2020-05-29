using RescueMe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RescueMe.Repository.Interface
{
    public interface IMessageRepository
    {
        bool SendMessage(SmsModel user, MessageConfiguration Msgconfig);
        List<UnsafeEmployeeModel> GetUnsafeEmployee(MessageConfiguration Msgconfig, int requestfor);
    }
}
