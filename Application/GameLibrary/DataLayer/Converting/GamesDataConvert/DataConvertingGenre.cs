using LogicLayer.Models.GamesFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Converting.GamesDataConvert
{
    public class DataConvertingGenre
    {
        public static List<Genre> ConvertDataRowToGenres(DataRow row)
        {
            string genreIds = Convert.ToString(row["GenreIDs"])!;
            string name = Convert.ToString(row["Genres"])!;

            List<Genre> genres = new List<Genre>();

            if (!string.IsNullOrEmpty(genreIds))
            {
                string[] genreIdArray = genreIds.Split(',');
                string[] genreNameArray = name.Split(',');

                for (int i = 0; i < genreIdArray.Length; i++)
                {
                    if (int.TryParse(genreIdArray[i].Trim(), out int genreId))
                    {
                        string genreName = genreNameArray.Length > i ? genreNameArray[i].Trim() : "";
                        Genre genre = new Genre(genreId, genreName);
                        genres.Add(genre);
                    }
                }
            }
            return genres;
        }
    }
}
