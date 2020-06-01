using System;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using RescueMe.Models;
using RescueMe.Sevices.Interface;
using System.Text;
using Microsoft.AspNetCore.Cors;

namespace RescueMeCoreAPI.Controllers
{
    //[EnableCors("AllowOrigin")]
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
        public ActionResult<string> Post([FromBody] SmsModel newSMS)
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
                return "SMS Sent";
            }
            catch (Exception xcp)
            {
                return xcp.Message;
            }
        }
        [HttpGet]
        [Route("GetUnsafeEmployee")]
        public IActionResult Get(int requestFor)
        {
            try
            {
                MessageConfiguration Msgconfig = new MessageConfiguration
                {
                    AccountSID = _configuration.GetSection("MessageConfiguration").GetSection("accountSID").Value,
                    AuthToken = _configuration.GetSection("MessageConfiguration").GetSection("authToken").Value,
                };

                var jsonResponse = _message.GetUnsafeEmployee(Msgconfig, requestFor);
                return new JsonResult(jsonResponse);
            }
            catch (Exception xcp)
            {
                return new JsonResult(xcp.Message);
            }
        }

        [HttpGet]
        [Route("GetNotification")]
        public IActionResult GetNotification()
        {
            try
            {
                var jsonResponse = _message.GetNotification();
                return new JsonResult(jsonResponse);
            }
            catch (Exception xcp)
            {
                return new JsonResult(xcp.Message);
            }
        }

        [HttpPost]
        [Route("InformEmployeeDetails")]
        public IActionResult InformEmployeeDetails([FromBody] UnsafeEmployeeModel Empdetails)
        {
            try
            {

                MessageConfiguration Msgconfig = new MessageConfiguration
                {
                    AccountSID = _configuration.GetSection("MessageConfiguration").GetSection("accountSID").Value,
                    AuthToken = _configuration.GetSection("MessageConfiguration").GetSection("authToken").Value,
                    FromMobileNo = _configuration.GetSection("MessageConfiguration").GetSection("fromMobileNo").Value,
                    RescueMessageText = _configuration.GetSection("MessageConfiguration").GetSection("RescueMessageText").Value
                };

                _message.InformEmployeeDetails(Empdetails, Msgconfig);
                return new JsonResult( "SMS Sent");
            }
            catch (Exception xcp)
            {
                return new JsonResult(xcp.Message);
            }
        }


    }
}