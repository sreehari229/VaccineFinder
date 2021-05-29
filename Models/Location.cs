using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineFinder.Models
{
    public class LocationState
    {
        public List<States> states { get; set; }
        public string ttl1 { get; set; } = " ";

    }
    public class States 
    {
        public string state_id { get; set; } = " ";
        public string state_name { get; set; } = " ";
        public string state_name_1 { get; set; } = " ";
    }


    public class LocationDistrict
    {
        public List<Districts> districts { get; set; }
        public string ttl1 { get; set; } = " ";
    }

    public class Districts
    {
        public string state_id { get; set; } = " ";
        public string district_id { get; set; } = " ";
        public string district_name { get; set; } = " ";
        public string district_name_1 { get; set; } = " ";
    }



    public class ShowinfolocModel
    {
        public List<Sessions> session { get; set; }
    }
    public class Sessions
    {
        public string center_id { get; set; } = " ";
        public string name { get; set; } = " ";
        //public string name_1 { get; set; } = " ";
        public string address { get; set; } = " ";
        //public string address_1 { get; set; } = " ";
        public string state_name { get; set; } = " ";
        //public string state_name_l { get; set; } = " ";
        public string district_name { get; set; } = " ";

        //public string district_name_l { get; set; } = " ";
        public string block_name { get; set; } = " ";
        //public string block_name_l { get; set; } = " ";
        public string pincode { get; set; } = " ";
        public string lat { get; set; } = " ";
        public string loclg { get; set; } = " ";
        public string from { get; set; } = " ";
        public string to { get; set; } = " ";
        public string fee_type { get; set; } = " ";
        public string fee { get; set; } = " ";
        public string session_id { get; set; } = " ";
        public string date { get; set; } = " ";
        public string available_capacity { get; set; } = " ";
        public string available_capacity_dose1 { get; set; } = " ";
        public string available_capacity_dose2 { get; set; } = " ";
        public string min_age_limit { get; set; } = " ";
        public string vaccine { get; set; } = " ";
        //public List<string> slots { get; set; }
        public string slots { get; set; } = " ";

    }
}


