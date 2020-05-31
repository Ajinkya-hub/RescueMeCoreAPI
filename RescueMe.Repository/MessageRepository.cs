﻿using RescueMe.Models;
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
        public List<UnsafeEmployeeModel> GetUnsafeEmployee(MessageConfiguration Msgconfig, int requestfor)
        {
            if (requestfor == 1)
            {
                return new List<UnsafeEmployeeModel>()
                {
                    new UnsafeEmployeeModel
                    {
                        PID = "P10453841",
                        Name = "Oliver Taylor",
                        PhoneNumber = "+918055394560",
                        Postcode = "411021",
                        DependentLocality = "Pashan",
                        PostTown = "Sus Gaon",
                        AddressCoordinates = new AddressCoordinates()
                        {
                            Longitude = 73.7560682,
                            Latitude = 18.5530548
                        },
                        W3W = "shade.fortnight.call",
                    }
                };
             }

            // get the responses from Twilio account below are the test data...

            List<UnsafeEmployeeModel> unsafeEmployees = new List<UnsafeEmployeeModel>()
            {
                new UnsafeEmployeeModel {
                    PID = "P10456342",
                    Name = "Joanne Taylor",
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
                    Name = "Joe Walsh",
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
                    Name = "Joe Miller",
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
                    Name = "George Williams",
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
                    Name = "Thomas Byrne",
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

                foreach (var number in user.Numbers)
                {
                    TwilioClient.Init(Msgconfig.AccountSID, Msgconfig.AuthToken);

                    var message = MessageResource.Create(
                        body: Msgconfig.MobileMessageText,
                        messagingServiceSid: null,
                        from: new PhoneNumber(Msgconfig.FromMobileNo),
                        to: new PhoneNumber(number)
                    );
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InformEmployeeDetails(UnsafeEmployeeModel notifications, MessageConfiguration Msgconfig)
        {
            var MobileMessageText = Msgconfig.RescueMessageText;
            MobileMessageText = MobileMessageText.Replace("{Name}", notifications.Name);
            MobileMessageText = MobileMessageText.Replace("{PhoneNumber}", notifications.PhoneNumber);
            MobileMessageText = MobileMessageText.Replace("{DependentLocality}", notifications.DependentLocality);
            MobileMessageText = MobileMessageText.Replace("{Latitude}", notifications.AddressCoordinates.Latitude.ToString());
            MobileMessageText = MobileMessageText.Replace("{Longitude}", notifications.AddressCoordinates.Longitude.ToString());
            
            TwilioClient.Init(Msgconfig.AccountSID, Msgconfig.AuthToken);

            var message = MessageResource.Create(
                body: MobileMessageText,
                messagingServiceSid: null,
                from: new PhoneNumber(Msgconfig.FromMobileNo),
                to: new PhoneNumber("+917045642656")
            );

            return true;
        }

        public List<Notifications> GetNotification()
        {
            return new List<Notifications>()
            {
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 2 mark their status as Safe." 
                },
                new Notifications {
                    Status = "Unsafe",
                    Message = "Joanne Taylor mark their status as unsafe.Location has been updated on floor map."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 3 mark their status as Safe."
                },
                new Notifications {
                    Status = "Unsafe",
                    Message = "Joe Walsh mark their status as unsafe.Location has been updated on floor map."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 5 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 44 mark their status as Safe."
                },
                new Notifications {
                    Status = "Unsafe",
                    Message = "Sophie Miller mark their status as unsafe.Location has been updated on floor map."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 7 mark their status as Safe."
                },
                new Notifications {
                    Status = "Unsafe",
                    Message = "George Williams mark their status as unsafe.Location has been updated on floor map."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 9 mark their status as Safe."
                },
                new Notifications {
                    Status = "Unsafe",
                    Message = "Thomas Byrne mark their status as unsafe.Location has been updated on floor map."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 38 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 39 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 40 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 41 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 42 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 43 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 11 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 12 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 13 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 14 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 15 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 16 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 17 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 18 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 19 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 20 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 21 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 22 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 23 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 24 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 25 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 26 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 27 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 28 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 29 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 30 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 31 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 32 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 33 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 34 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 35 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 36 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 37 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 11 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 12 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 13 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 14 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 15 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 16 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 17 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 18 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 19 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 20 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 21 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 22 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 23 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 24 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 25 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 26 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 27 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 28 mark their status as Safe."
                },
                 new Notifications {
                    Status = "Safe",
                    Message = "Employee 29 mark their status as Safe."
                },
                new Notifications {
                    Status = "Safe",
                    Message = "Employee 30 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 31 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 32 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 33 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 34 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 35 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 36 mark their status as Safe."
                },new Notifications {
                    Status = "Safe",
                    Message = "Employee 37 mark their status as Safe."
                },
            };

        }
    }
}
