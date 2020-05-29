using RescueMe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RescueMe.Sevices.Interface
{
    public interface IMessageService
    {
        bool SendMessage(SmsModel message, MessageConfiguration Msgconfig);
        List<UnsafeEmployeeModel> GetUnsafeEmployee(MessageConfiguration Msgconfig, int requestfor);
    }
}
