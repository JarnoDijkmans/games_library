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
            populateFeaturesCombobox();
        }


        private void populateGenreCombobox()
        {
            List<Genre> genres = gameService.GetGenres();
            CB_Genre3.Items.Add("None");
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
                else CB_Genre3.SelectedItem = "None";
            }
        }

        private void populateFeaturesCombobox()
        {
            List<Feature> Features = gameService.GetFeatures();
            CB_Feature3.Items.Add("None");

            foreach (var feature in Features)
            {
                CB_Feature1.Items.Add(feature.Name);
                CB_Feature2.Items.Add(feature.Name);
                CB_Feature3.Items.Add(feature.Name);
            }

            if (gameToEdit.Features != null)
            {
                if (gameToEdit.Features.Count > 0)
                    CB_Feature1.SelectedItem = gameToEdit.Features[0].Name;

                if (gameToEdit.Features.Count > 1)
                    CB_Feature2.SelectedItem = gameToEdit.Features[1].Name;

                if (gameToEdit.Features.Count > 2)
                    CB_Feature3.SelectedItem = gameToEdit.Features[2].Name;
                else CB_Feature3.SelectedItem = "None";
            }

            CB_Feature1.SelectedIndexChanged += new EventHandler(this.CB_Feature1_SelectedIndexChanged);
            CB_Feature2.SelectedIndexChanged += new EventHandler(this.CB_Feature2_SelectedIndexChanged);
            CB_Feature3.SelectedIndexChanged += new EventHandler(this.CB_Feature3_SelectedIndexChanged);
        }




        private void populateGameToEdit()
        {
            txt_Title.Text = gameToEdit.Title;
            txt_price.Text = gameToEdit.Price.ToString();
            txt_description.Text = gameToEdit.Description;
            txt_releasedate.Text = gameToEdit.ReleaseDate.ToString();
            txt_publisher.Text = gameToEdit.Publisher;
            txt_Trailerurl.Text = gameToEdit.Trailer;
            txt_CoverArt.Text = GetImageUrlByType("Cover Art");
            txt_spotlight.Text = GetImageUrlByType("Spotlight");
            txt_thumbnail.Text = GetImageUrlByType("Thumbnail");

            

        }

        private string GetImageUrlByType(string imageType)
        {
            return gameToEdit.Images.Where(image => image.ImageType == imageType).Select(image => image.ImageURL).FirstOrDefault();
        }

        private void CB_Feature1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Feature1.SelectedItem == CB_Feature2.SelectedItem)
                CB_Feature2.SelectedItem = null;

            if (CB_Feature1.SelectedItem == CB_Feature3.SelectedItem)
                CB_Feature3.SelectedItem = null;
        }

        private void CB_Feature2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Feature2.SelectedItem == CB_Feature1.SelectedItem)
                CB_Feature1.SelectedItem = null;

            if (CB_Feature2.SelectedItem == CB_Feature3.SelectedItem)
                CB_Feature3.SelectedItem = null;
        }

        private void CB_Feature3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Feature3.SelectedItem == CB_Feature1.SelectedItem)
                CB_Feature1.SelectedItem = null;

            if (CB_Feature3.SelectedItem == CB_Feature2.SelectedItem)
                CB_Feature2.SelectedItem = null;
        }

        private void CB_Genre1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Genre1.SelectedItem == CB_Genre2.SelectedItem)
                CB_Genre2.SelectedItem = null;

            if (CB_Genre1.SelectedItem == CB_Genre3.SelectedItem)
                CB_Genre3.SelectedItem = null;
        }

        private void CB_Genre2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Genre2.SelectedItem == CB_Genre1.SelectedItem)
                CB_Genre1.SelectedItem = null;

            if (CB_Genre2.SelectedItem == CB_Genre3.SelectedItem)
                CB_Genre3.SelectedItem = null;
        }

        private void CB_Genre3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Genre3.SelectedItem == CB_Genre1.SelectedItem)
                CB_Genre1.SelectedItem = null;

            if (CB_Genre3.SelectedItem == CB_Genre2.SelectedItem)
                CB_Genre2.SelectedItem = null;
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {

        }
    }
}
