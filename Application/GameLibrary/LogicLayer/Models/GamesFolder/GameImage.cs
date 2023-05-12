using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.GamesFolder
{
    public class GameImage
    {
        public int ImageId { get; private set; }
        public string ImageType { get; private set; }
        public string ImageURL { get; private set; }

        public GameImage (int imageId, string imageType, string imageURL) 
        {
            this.ImageId = imageId;
            this.ImageType = imageType;
            this.ImageURL = imageURL;
        }

    }
}
