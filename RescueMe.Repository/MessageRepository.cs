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
        public List<UnsafeEmployeeModel> GetUnsafeEmployee(MessageConfiguration Msgconfig)
        {

            // get the responses from Twilio account below are the test data...
            List<UnsafeEmployeeModel> unsafeEmployees = new List<UnsafeEmployeeModel>()
            {
                new UnsafeEmployeeModel {
                    PID = "P10456342",
                    Name = "Employee 1",
                    PhoneNumber = "+919561423305",
                    Postcode = "411006",
                    DependentLocality = "commerzone It Park",
                    PostTown = "Yerwada",
                    AddressCoordinates = new AddressCoordinates()
                    {
                        Longitude = 73.883518,
                        Latitude  = 18.562729
                    },
                    W3W = "rationed.weedy.partied",
                    //populate other properties  
                },
                  new UnsafeEmployeeModel {
                    PID = "P10455789",
                    Name = "Employee 2",
                    PhoneNumber = "+917045642656",
                    Postcode = "411006",
                    DependentLocality = "commerzone It Park",
                    PostTown = "Yerwada",
                    AddressCoordinates = new AddressCoordinates()
                    {
                        Latitude = 18.562729,
                        Longitude = 73.883547
                    },
                    W3W = "investors.gazette.kidney",
                    //populate other properties  
                },
                  new UnsafeEmployeeModel {
                    PID = "P10454858",
                    Name = "Employee 3",
                    PhoneNumber = "+918055394560",
                    Postcode = "411006",
                    DependentLocality = "commerzone It Park",
                    PostTown = "Yerwada",
                    AddressCoordinates = new AddressCoordinates()
                    {
                       Longitude = 73.883547,
                        Latitude  = 18.562702
                    },
                    W3W = "rephrase.grandest.fortified",
                    //populate other properties  
                },
                  new UnsafeEmployeeModel {
                    PID = "P10452906",
                    Name = "Employee 4",
                    PhoneNumber = "+918051423305",
                    Postcode = "411006",
                    DependentLocality = "commerzone It Park",
                    PostTown = "Yerwada",
                    AddressCoordinates = new AddressCoordinates()
                    {
                        Latitude = 18.562702,
                        Longitude = 73.883518,
                    },
                    W3W = "parsnip.lookout.trek",
                    //populate other properties  
                },
                  new UnsafeEmployeeModel {
                    PID = "P10456878",
                    Name = "Employee 5",
                    PhoneNumber = "+919561423305",
                    Postcode = "411006",
                    DependentLocality = "commerzone It Park",
                    PostTown = "Yerwada",
                    AddressCoordinates = new AddressCoordinates()
                    {
                        Latitude = 18.562675,
                        Longitude = 73.883717,
                    },
                    W3W = "manual.both.besotted",
                    //populate other properties  
                },
            };

            return unsafeEmployees;
        }

        public bool SendMessage(SmsModel user, MessageConfiguration Msgconfig)
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
