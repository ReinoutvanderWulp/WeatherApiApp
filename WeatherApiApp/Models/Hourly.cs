using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApiApp.Models
{
    public class Hourly
    {
        public List<DateTime> time { get; set; }
        public List<float> temperature_2m { get; set; }
    }
}