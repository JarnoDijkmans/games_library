using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.GamesFolder
{
    public class Genre
    {
        public int GenreId { get; private set; }
        public string Name { get; private set; }

        public Genre(int GenreId, string name)
        {
            this.GenreId = GenreId;
            this.Name = name;
        }
    }
}
