using Factory;
using LogicLayer.Models.Discount;
using LogicLayer.Models.GamesFolder;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class GameEditForm : Form
    {
        private Game gameToEdit;
        GameService gameService = GameFactory.gameservice;
        public GameEditForm(Game game)
        {
            InitializeComponent();
            gameToEdit = game;
            populateGameToEdit();
            populateGenreCombobox();
        }


        private void populateGenreCombobox()
        {
            List <Genre> genres = gameService.GetGenres();
            foreach (var genre in genres)
            {
                CB_Genre1.Items.Add(genre.Name);
                CB_Genre2.Items.Add(genre.Name);
                CB_Genre3.Items.Add(genre.Name);
            }

            if (gameToEdit.Genres != null)
            {
                if (gameToEdit.Genres.Count > 0)
                    CB_Genre1.SelectedItem = gameToEdit.Genres[0].Name;

                if (gameToEdit.Genres.Count > 1)
                    CB_Genre2.SelectedItem = gameToEdit.Genres[1].Name;

                if (gameToEdit.Genres.Count > 2)
                    CB_Genre3.SelectedItem = gameToEdit.Genres[2].Name;
            }
        }

        private void populateGameToEdit()
        {
            txt_Title.Text = gameToEdit.Title;
            txt_price.Text = gameToEdit.Price.ToString();
            txt_description.Text = gameToEdit.Description;
            txt_releasedate.Text= gameToEdit.ReleaseDate.ToString();
            txt_publisher.Text = gameToEdit.Publisher;
            txt_Trailerurl.Text = gameToEdit.Trailer;
        }

    }
}
