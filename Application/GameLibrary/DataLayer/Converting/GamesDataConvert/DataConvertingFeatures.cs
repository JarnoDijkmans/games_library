using LogicLayer.Models.GamesFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Converting.GamesDataConvert
{
    public class DataConvertingFeatures
    {
        public static List<Feature> ConvertDataRowToFeatures(DataRow row)
        {
            string featureIds = Convert.ToString(row["FeatureIDs"])!;
            string name = Convert.ToString(row["Features"])!;

            List<Feature> features = new List<Feature>();

            if (!string.IsNullOrEmpty(featureIds))
            {
                string[] featureIdArray = featureIds.Split(',');
                string[] featureNameArray = name.Split(',');

                for (int i = 0; i < featureIdArray.Length; i++)
                {
                    if (int.TryParse(featureIdArray[i].Trim(), out int featureId))
                    {
                        string featureName = featureNameArray.Length > i ? featureNameArray[i].Trim() : "";
                        Feature feature = new Feature(featureId, featureName);
                        features.Add(feature);
                    }
                }
            }

            return features;
        }
    }
}
