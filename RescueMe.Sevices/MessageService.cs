using RescueMe.Models;
using RescueMe.Repository.Interface;
using RescueMe.Sevices.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RescueMe.Sevices
{
    public class MessageService : IMessageService
    {
        IMessageRepository _messageRepo;
        public MessageService(IMessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
        }

        public bool SendMessage(smsModel message, MessageConfiguration Msgconfig)
        {
            return _messageRepo.SendMessage(message, Msgconfig);
        }

    }
}
