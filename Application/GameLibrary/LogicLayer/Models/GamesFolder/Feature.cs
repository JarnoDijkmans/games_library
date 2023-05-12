using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.GamesFolder
{
    public class Feature
    {
        public int FeatureID { get; private set; }
        public string Name { get; private set; }

        public Feature (int featureID, string name)
        {
            FeatureID = featureID;
            Name = name;
        }
    }
}
