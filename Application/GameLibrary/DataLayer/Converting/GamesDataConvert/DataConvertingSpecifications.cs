using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Models.GamesFolder;
using Newtonsoft.Json;

namespace DataLayer.Converting.GamesDataConvert
{
    public class DataConvertingSpecifications
    {
        public static List<Specification> ConvertDataToSpecification(DataRow row)
        {
            string SpecificationsJson = Convert.ToString(row["SpecificationsJson"])!;

            List<Specification> specifications = new List<Specification>();

            if (!string.IsNullOrEmpty(SpecificationsJson))
            {
                specifications = JsonConvert.DeserializeObject<List<Specification>>(SpecificationsJson);
            }

            return specifications;
        }
    }
}
