using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Newtonsoft.Json;
using TopSpotsAPI.Models;

namespace TopSpotsAPI.Controllers
{
    public class TopSpotsController : ApiController
    {

        [HttpGet, Route("api/topspots")]
        public IHttpActionResult GetTopSpots()
        {
            string topSpots = File.ReadAllText("C:\\Users\\SCali\\dev\\TopSpotsAPI\\TopSpotsAPI\\topspots.json");
            TopSpot[] TopSpotsArray = JsonConvert.DeserializeObject<TopSpot[]>(topSpots);
            return Ok(TopSpotsArray);
        }

        [HttpPost]
        public IHttpActionResult PostTopSpot(TopSpot TopSpot)
        {
            TopSpot.Name = "Origin Code Academy";
            TopSpot.Description = "Coding Bootcamp";
           // TopSpot.Location[0] = 32.7151;
         //   TopSpot.Location[1] = -117.1642;
            return Ok(TopSpot);
        }
    }
}
