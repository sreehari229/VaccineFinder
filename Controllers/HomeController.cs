using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public string Showinfoloc(string dis, string dt)
        {
            var client = new RestClient("https://cdn-api.co-vin.in/api/v2/appointment/sessions/public/findByDistrict?district_id=512&date=31-03-2021");
            client.Timeout = -1;
            
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<ShowinfolocModel>(response.Content);
            return "Success";
        }


    }
}