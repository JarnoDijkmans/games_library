using LogicLayer.Models.GamesFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Converting.GamesDataConvert
{
    public class DataConvertingImages
    {
        public static List<GameImage> ConvertDataToImage(DataRow row)
        {
            string ImageIds = Convert.ToString(row["ImageIDs"])!;
            string ImageTypes = Convert.ToString(row["ImageTypes"])!;
            string ImageURLs = Convert.ToString(row["ImageURLs"])!;

            List<GameImage> gameImages = new List<GameImage>();

            if (!string.IsNullOrEmpty(ImageIds))
            {
                string[] genreIdArray = ImageIds.Split(',');
                string[] ImageTypesArray = ImageTypes.Split(',');
                string[] ImageURLsArray = ImageURLs.Split(',');

                for (int i = 0; i < genreIdArray.Length; i++)
                {
                    if (int.TryParse(genreIdArray[i].Trim(), out int imageId))
                    {
                        string imageType = ImageTypesArray.Length > i ? ImageTypesArray[i].Trim() : "";
                        string imageURL = ImageURLsArray.Length > i ? ImageURLsArray[i].Trim() : "";
                        GameImage image = new GameImage(imageId, imageType, imageURL);
                        gameImages.Add(image);
                    }
                }
            }
            return gameImages;
        }
    }
}
