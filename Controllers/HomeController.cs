using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using VaccineFinder.Models;

namespace VaccineFinder.Controllers
{
    public class HomeController : Controller
    {
        //Using Models.Location
        public ActionResult Index()
        {
            var client = new RestClient("https://cdn-api.co-vin.in/api/v2/admin/location/states");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<LocationState>(response.Content);
            return View(result);
        }

        public ActionResult ShowDistricts(string st)
        {
            string link = "https://cdn-api.co-vin.in/api/v2/admin/location/districts/" + st;
            var client = new RestClient(link);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<LocationDistrict>(response.Content);
            return View(result);

        }

       

        public ActionResult Showinfoloc(string dis, string dt)
        {
            string datenow = DateTime.Now.ToString("dd-MM-yyyy");
            string link = "https://cdn-api.co-vin.in/api/v2/appointment/sessions/public/findByDistrict?district_id=" + dis + "&date=" + datenow;
            var client = new RestClient(link);
            
            client.Timeout = -1;
            
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            List<Sessions> result = new List<Sessions>();
            var obj = JObject.Parse(response.Content);
            foreach (var item in obj["sessions"])
            {             
                result.Add(new Sessions
                {
                    center_id = item["center_id"].ToString(),
                    name = item["name"].ToString(),
                    //address = item["address"].ToString(),
                    //state_name = item["state_name"].ToString(),
                    //district_name = item["district_name"].ToString(),
                    block_name = item["block_name"].ToString(),
                    //pincode = item["pincode"].ToString(),
                    from = item["from"].ToString(),
                    to = item["to"].ToString(),
                    //lat = item["lat"].ToString(),
                    //loclg = item["long"].ToString(),
                    fee_type = item["fee_type"].ToString(),
                    //session_id = item["session_id"].ToString(),
                    available_capacity_dose1 = item["available_capacity_dose1"].ToString(),
                    available_capacity_dose2 = item["available_capacity_dose2"].ToString(),
                    available_capacity = item["available_capacity"].ToString(),
                    fee = item["fee"].ToString(),
                    min_age_limit = item["min_age_limit"].ToString(),
                    vaccine = item["vaccine"].ToString(),
                    slots = item["slots"].Values<string>().ToList(),
                }) ;
            }
            
            return View(result);
        }


    }
}