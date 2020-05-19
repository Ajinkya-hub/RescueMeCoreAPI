using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using RescueMe.Models;
using RescueMe.Sevices.Interface;

namespace RescueMeCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageService _message;
        IConfiguration _configuration;
        public MessageController(IMessageService Message, IConfiguration configuration)
        {
            _message = Message;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("InformEmployees")]
        public ActionResult<string> Post([FromBody] smsModel newSMS)
        {
            try
            {

                MessageConfiguration Msgconfig = new MessageConfiguration
                {
                    AccountSID = _configuration.GetSection("MessageConfiguration").GetSection("accountSID").Value,
                    AuthToken = _configuration.GetSection("MessageConfiguration").GetSection("authToken").Value,
                    FromMobileNo = _configuration.GetSection("MessageConfiguration").GetSection("fromMobileNo").Value,
                    MobileMessageText = _configuration.GetSection("MessageConfiguration").GetSection("mobileMessageText").Value
                };

                _message.SendMessage(newSMS, Msgconfig);
                return  "SMS Sent";
            }
            catch (Exception xcp)
            {
                return  xcp.Message;
            }
        }
    }
}