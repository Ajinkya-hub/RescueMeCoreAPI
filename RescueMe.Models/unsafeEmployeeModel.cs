using System;
using System.Collections.Generic;
using System.Text;

namespace RescueMe.Models
{
    public class UnsafeEmployeeModel
    {
        public string PID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }        
        public string Postcode { get; set; }
        public string DependentLocality { get; set; }
        public string PostTown { get; set; }
        public AddressCoordinates AddressCoordinates { get; set; }
        public String W3W { get; set; }

    }

    public class AddressCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
