using Factory;
using LogicLayer;
using LogicLayer.Models.GamesFolder;
using LogicLayer.Models.UserFolder;
using LogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.Hosting;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Forms
{
    public partial class AddGame : Form
    {
        private IConfiguration Configuration { get; }
        GameService gameService = GameFactory.gameservice;
        Result result;
        private User loggedInUser;
        private List<GameImage> images = new List<GameImage>();
        public AddGame(User user)
        {
            InitializeComponent();
            populateGenreCombobox();
            populateFeaturesCombobox();
            this.loggedInUser = user;
            result = new Result("");
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
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

            CB_Genre1.SelectedIndexChanged += new EventHandler(this.CB_Genre1_SelectedIndexChanged);
            CB_Genre2.SelectedIndexChanged += new EventHandler(this.CB_Genre2_SelectedIndexChanged);
            CB_Genre3.SelectedIndexChanged += new EventHandler(this.CB_Genre3_SelectedIndexChanged);

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

            CB_Feature1.SelectedIndexChanged += new EventHandler(this.CB_Feature1_SelectedIndexChanged);
            CB_Feature2.SelectedIndexChanged += new EventHandler(this.CB_Feature2_SelectedIndexChanged);
            CB_Feature3.SelectedIndexChanged += new EventHandler(this.CB_Feature3_SelectedIndexChanged);
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

        private void StoreImageToObject(List<GameImage> images)
        {
            foreach (ListViewItem item in lv_ImageDetails.Items)
            {
                string detailImageUrl = item.SubItems[1].Text;
                GameImage detailImage = new GameImage(0, "Detail", "/Images/" + detailImageUrl + ".png");
                images.Add(detailImage);
            }

            GameImage coverArtImage = new GameImage(0, "Cover Art", "/Images/" + txt_CoverArt.Text + ".png");
            GameImage spotlightImage = new GameImage(0, "Spotlight", "/Images/" + txt_spotlight.Text + ".png");
            GameImage thumbnailImage = new GameImage(0, "Thumbnail", "/Images/" + txt_thumbnail.Text + ".png");

            images.Add(coverArtImage);
            images.Add(spotlightImage);
            images.Add(thumbnailImage);
        }


        private void StoreSpecificationsToObject(List<Specification> specifications)
        {
            Specification MiniSpecification = new Specification(0, "Minimum", txt_Minimum_OS.Text, txt_Minimum_Processor.Text, txt_Minimum_Memory.Text, txt_Minimum_Storage.Text, txt_Minimum_DirectX.Text, txt_Minimum_Graphics.Text, txt_Minimum_Other.Text, txt_Minimum_Logins.Text);
            Specification RecomSpecification = new Specification(0, "Recommended", txt_recommended_OS.Text, txt_recommended_Processor.Text, txt_recommended_Memory.Text, txt_recommended_Storage.Text, txt_recommended_DirectX.Text, txt_recommended_Graphics.Text, txt_recommended_Other.Text, txt_recommended_Logins.Text);
            specifications.Add(MiniSpecification);
            specifications.Add(RecomSpecification);
        }

        private void StoreGenreToObject(List<Genre> genres)
        {
            if (!string.IsNullOrEmpty(CB_Genre1.Text))
            {
                int genreId = gameService.GetGenreIdByName(CB_Genre1.Text);
                Genre newGenre = new Genre(genreId, CB_Genre1.Text);
                genres.Add(newGenre);
            }
            else
            {
                MessageBox.Show($"Please enter all required fields *");
            }
            if (!string.IsNullOrEmpty(CB_Genre2.Text))
            {
                int genreId = gameService.GetGenreIdByName(CB_Genre2.Text);
                Genre newGenre = new Genre(genreId, CB_Genre2.Text);
                genres.Add(newGenre);
            }
            else
            {
                MessageBox.Show($"Please enter all required fields *");
            }
            if (!string.IsNullOrEmpty(CB_Genre3.Text) && CB_Genre3.Text != "None")
            {
                int genreId = gameService.GetGenreIdByName(CB_Genre3.Text);
                Genre newGenre = new Genre(genreId, CB_Genre3.Text);
                genres.Add(newGenre);
            }
        }

        private void StoreFeatureToObject(List<Feature> features)
        {
            if (!string.IsNullOrEmpty(CB_Feature1.Text))
            {
                int genreId = gameService.GetFeatureIdByName(CB_Feature1.Text);
                Feature newFeature = new Feature(genreId, CB_Feature1.Text);
                features.Add(newFeature);
            }
            else
            {
                MessageBox.Show($"Please enter all required fields *");
            }
            if (!string.IsNullOrEmpty(CB_Feature2.Text))
            {
                int genreId = gameService.GetFeatureIdByName(CB_Feature2.Text);
                Feature newFeature = new Feature(genreId, CB_Feature2.Text);
                features.Add(newFeature);
            }
            else
            {
                MessageBox.Show($"Please enter all required fields *");
            }
            if (!string.IsNullOrEmpty(CB_Feature3.Text) && CB_Feature3.Text != "None")
            {
                int genreId = gameService.GetFeatureIdByName(CB_Feature3.Text);
                Feature newFeature = new Feature(genreId, CB_Feature3.Text);
                features.Add(newFeature);
            }
        }

        private void btn_SelectImage_Click(object sender, EventArgs e)
        {
            string imagePath = SelectImage();
            if (!string.IsNullOrEmpty(imagePath))
            {
                txt_CoverArt.Text = imagePath;
            }
        }

        private string SelectImage()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                // imagePath should point to the wwwroot folder
                string imagePath = Configuration["ImagePath"];

                openFileDialog.InitialDirectory = Path.Combine(imagePath, "Images");
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the full file path
                    string fullPath = openFileDialog.FileName;

                    // Make sure the full path starts with the imagePath
                    if (fullPath.StartsWith(imagePath))
                    {
                        // Remove the imagePath part from the fullPath
                        string relativePath = fullPath.Substring(imagePath.Length);

                        // Ensure it starts with a slash
                        if (!relativePath.StartsWith("\\"))
                        {
                            relativePath = "\\" + relativePath;
                        }

                        return relativePath;
                    }
                }
            }

            return string.Empty;
        }

        private void btn_SelectImage_Spotlight_Click(object sender, EventArgs e)
        {
            string imagePath = SelectImage();
            if (!string.IsNullOrEmpty(imagePath))
            {
                txt_spotlight.Text = imagePath;
            }
        }

        private void btn_SelectImage_Thumbnail_Click(object sender, EventArgs e)
        {
            string imagePath = SelectImage();
            if (!string.IsNullOrEmpty(imagePath))
            {
                txt_thumbnail.Text = imagePath;
            }
        }

        private void btn_Add_Detail_Image_Click_1(object sender, EventArgs e)
        {
            DetailImageForm detailImageForm = new DetailImageForm();
            if (detailImageForm.ShowDialog() == DialogResult.OK)
            {
                ListViewItem item = new ListViewItem((lv_ImageDetails.Items.Count + 1).ToString());
                item.SubItems.Add(detailImageForm.ImageUrl);
                lv_ImageDetails.Items.Add(item);
            }
        }

        private void btn_Remove_Click_1(object sender, EventArgs e)
        {
            if (lv_ImageDetails.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this image?", "Confirm Remove", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var itemToRemove = lv_ImageDetails.SelectedItems[0];

                    if (itemToRemove != null)
                    {
                        lv_ImageDetails.Items.Remove(itemToRemove);
                    }
                }
            }
        }

        private void btn_Add_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (result != null)
                {
                    result.ValidateFields(txt_Title.Text, txt_price.Text, txt_description.Text, txt_publisher.Text, txt_releasedate.Text, txt_Trailerurl.Text, CB_Genre1.Text, CB_Genre2.Text, CB_Feature1.Text, CB_Feature2.Text, txt_CoverArt.Text, txt_spotlight.Text, txt_thumbnail.Text);

                    string title = txt_Title.Text;
                    Decimal price = decimal.Parse(txt_price.Text);
                    string description = txt_description.Text;
                    string releaseDate = txt_releasedate.Text;
                    string publisher = txt_publisher.Text;
                    string trailer = txt_Trailerurl.Text;
                    List<Genre> genres = new List<Genre>();
                    List<Feature> features = new List<Feature>();
                    List<Specification> specifications = new List<Specification>();

                    StoreGenreToObject(genres);
                    StoreFeatureToObject(features);
                    StoreImageToObject(this.images);
                    StoreSpecificationsToObject(specifications);

                    Game game = new Game(0, title, price, description, releaseDate, publisher, this.images, genres, features, specifications, trailer);
                    gameService.AddGame(game);

                }
                else
                {
                    MessageBox.Show("Validation object is not initialized.");
                }

            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            Index index = new Index(loggedInUser);
            this.Close();
            index.Show();
        }
    }
}
