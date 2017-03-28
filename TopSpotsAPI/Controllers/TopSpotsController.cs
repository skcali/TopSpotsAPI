using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Newtonsoft.Json;
using TopSpotsAPI.Models;
using System.Collections.Generic;

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

        [HttpPost, Route("api/topspots")]
        public IHttpActionResult Post(TopSpot topSpot)
        {
            string topSpots = File.ReadAllText("C:\\Users\\SCali\\dev\\TopSpotsAPI\\TopSpotsAPI\\topspots.json");
            List<TopSpot> TopSpotsArray = JsonConvert.DeserializeObject<List<TopSpot>>(topSpots);
            TopSpotsArray.Add(topSpot);
            topSpots = JsonConvert.SerializeObject(TopSpotsArray);
            File.WriteAllText("C:\\Users\\SCali\\dev\\TopSpotsAPI\\TopSpotsAPI\\topspots.json", topSpots);
            return Ok();
        }
        [HttpDelete, Route("api/topspots")]
        public IHttpActionResult Delete(TopSpot topSpot)
        {
            string topSpots = File.ReadAllText("C:\\Users\\SCali\\dev\\TopSpotsAPI\\TopSpotsAPI\\topspots.json");
            List<TopSpot> TopSpotsArray = JsonConvert.DeserializeObject<List<TopSpot>>(topSpots);
            TopSpotsArray.Remove(topSpot);
            topSpots = JsonConvert.SerializeObject(TopSpotsArray);
            File.WriteAllText("C:\\Users\\SCali\\dev\\TopSpotsAPI\\TopSpotsAPI\\topspots.json", topSpots);
            return Ok();
        }
    }
}
