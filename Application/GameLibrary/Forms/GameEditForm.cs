using Factory;
using LogicLayer;
using LogicLayer.Models.GamesFolder;
using LogicLayer.Models.UserFolder;
using LogicLayer.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Forms
{
    public partial class GameEditForm : Form
    {
        private Game gameToEdit;
        private User loggedInUser;
        GameService gameService = GameFactory.gameservice;
        IConfiguration Configuration;
        Result result;
        public GameEditForm(Game game, User user)
        {
            InitializeComponent();
            gameToEdit = game;
            loggedInUser = user;
            populateGameToEdit();
            populateGenreCombobox();
            populateFeaturesCombobox();
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

            if (gameToEdit.Genres != null)
            {
                if (gameToEdit.Genres.Count > 0)
                    CB_Genre1.SelectedItem = gameToEdit.Genres[0].Name;

                if (gameToEdit.Genres.Count > 1)
                    CB_Genre2.SelectedItem = gameToEdit.Genres[1].Name;

                if (gameToEdit.Genres.Count > 2)
                    CB_Genre3.SelectedItem = gameToEdit.Genres[2].Name;
                else CB_Genre3.SelectedItem = "None";

                CB_Genre1.SelectedIndexChanged += new EventHandler(this.CB_Genre1_SelectedIndexChanged);
                CB_Genre2.SelectedIndexChanged += new EventHandler(this.CB_Genre2_SelectedIndexChanged);
                CB_Genre3.SelectedIndexChanged += new EventHandler(this.CB_Genre3_SelectedIndexChanged);
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
            var detailImages = GetImageUrlsByTypeList("Detail");
            for (int i = 0; i < detailImages.Count; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(detailImages[i]);
                lv_ImageDetails.Items.Add(item);
            }

            txt_Minimum_OS.Text = gameToEdit.MinimumSpecs().OS;
            txt_Minimum_Processor.Text = gameToEdit.MinimumSpecs().Processor;
            txt_Minimum_Memory.Text = gameToEdit.MinimumSpecs().Memory;
            txt_Minimum_Storage.Text = gameToEdit.MinimumSpecs().Storage;
            txt_Minimum_DirectX.Text = gameToEdit.MinimumSpecs().DirectX;
            txt_Minimum_Graphics.Text = gameToEdit.MinimumSpecs().Graphics;
            txt_Minimum_Other.Text = gameToEdit.MinimumSpecs().Other;
            txt_Minimum_Logins.Text = gameToEdit.MinimumSpecs().Logins;

            txt_recommended_OS.Text = gameToEdit.RecommendedSpecs().OS;
            txt_recommended_Processor.Text = gameToEdit.RecommendedSpecs().Processor;
            txt_recommended_Memory.Text = gameToEdit.RecommendedSpecs().Memory;
            txt_recommended_Storage.Text = gameToEdit.RecommendedSpecs().Storage;
            txt_recommended_DirectX.Text = gameToEdit.RecommendedSpecs().DirectX;
            txt_recommended_Graphics.Text = gameToEdit.RecommendedSpecs().Graphics;
            txt_recommended_Other.Text = gameToEdit.RecommendedSpecs().Other;
            txt_recommended_Logins.Text = gameToEdit.RecommendedSpecs().Logins;
        }

        private string GetImageUrlByType(string imageType)
        {
            return gameToEdit.Images.Where(image => image.ImageType == imageType).Select(image => image.ImageURL).FirstOrDefault();
        }

        private List<string> GetImageUrlsByTypeList(string imageType)
        {
            return gameToEdit.Images.Where(image => image.ImageType == imageType).Select(image => image.ImageURL).ToList();
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
            try
            {
                if (result != null)
                {
                    result.ValidateFields(txt_Title.Text, txt_price.Text, txt_description.Text, txt_publisher.Text, txt_releasedate.Text, txt_Trailerurl.Text, CB_Genre1.Text, CB_Genre2.Text, CB_Feature1.Text, CB_Feature2.Text, txt_CoverArt.Text, txt_spotlight.Text, txt_thumbnail.Text);
                    int gameID = gameToEdit.GameId;
                    string title = txt_Title.Text;
                    Decimal price = decimal.Parse(txt_price.Text);
                    string description = txt_description.Text;
                    string releaseDate = txt_releasedate.Text;
                    string publisher = txt_publisher.Text;
                    string trailer = txt_Trailerurl.Text;

                    UpdateGameImages();
                    UpdateSpecifications();
                    UpdateGenre();
                    UpdateFeatures();
                    Game game = new Game(gameID, title, price, description, releaseDate, publisher, gameToEdit.Images, gameToEdit.Genres, gameToEdit.Features, gameToEdit.Specifications, trailer);
                    if (gameService.UpdateGame(game) == true )
                    {
                        MessageBox.Show("Game Succesfully updated!");
                    }
                    else { MessageBox.Show("Oops something went wrong, Please try again, or ask for help."); }


                }
                else { MessageBox.Show("Validation object is not initialized."); }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Add_Detail_Image_Click(object sender, EventArgs e)
        {
            DetailImageForm detailImageForm = new DetailImageForm();
            if (detailImageForm.ShowDialog() == DialogResult.OK)
            {

                gameToEdit.Images.Add(new GameImage(0, "Detail", detailImageForm.ImageUrl));

                lv_ImageDetails.Items.Clear();
                var detailImages = GetImageUrlsByTypeList("Detail");
                for (int i = 0; i < detailImages.Count; i++)
                {
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.SubItems.Add(detailImages[i]);
                    lv_ImageDetails.Items.Add(item);
                }
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (lv_ImageDetails.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this image?", "Confirm Remove", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var itemToRemove = lv_ImageDetails.SelectedItems[0];

                    var imageToRemove = gameToEdit.Images.FirstOrDefault(image => image.ImageURL == itemToRemove.SubItems[1].Text);
                    if (imageToRemove != null)
                    {
                        gameToEdit.Images.Remove(imageToRemove);
                    }

                    lv_ImageDetails.Items.Clear();
                    var detailImages = GetImageUrlsByTypeList("Detail");
                    for (int i = 0; i < detailImages.Count; i++)
                    {
                        ListViewItem item = new ListViewItem((i + 1).ToString());
                        item.SubItems.Add(detailImages[i]);
                        lv_ImageDetails.Items.Add(item);
                    }
                }
            }
        }

        private void UpdateGameImages()
        {
            int detailIndex = 0;

            for (int i = 0; i < gameToEdit.Images.Count; i++)
            {
                if (gameToEdit.Images[i].ImageType == "Cover Art")
                {
                    gameToEdit.Images[i] = new GameImage(gameToEdit.Images[i].ImageId, gameToEdit.Images[i].ImageType, txt_CoverArt.Text);
                }
                else if (gameToEdit.Images[i].ImageType == "Spotlight")
                {
                    gameToEdit.Images[i] = new GameImage(gameToEdit.Images[i].ImageId, gameToEdit.Images[i].ImageType, txt_spotlight.Text);
                }
                else if (gameToEdit.Images[i].ImageType == "Thumbnail")
                {
                    gameToEdit.Images[i] = new GameImage(gameToEdit.Images[i].ImageId, gameToEdit.Images[i].ImageType, txt_thumbnail.Text);
                }
                else if (gameToEdit.Images[i].ImageType == "Detail")
                {
                    gameToEdit.Images[i] = new GameImage(gameToEdit.Images[i].ImageId, gameToEdit.Images[i].ImageType, lv_ImageDetails.Items[detailIndex].SubItems[1].Text);
                    detailIndex++;
                }
            }
        }

        private void UpdateSpecifications()
        {
            for (int i = 0; i < gameToEdit.Specifications.Count; i++)
            {
                if (gameToEdit.Specifications[i].SpecificationType == "Minimum")
                {
                    gameToEdit.Specifications[i] = new Specification(
                        gameToEdit.Specifications[i].SpecificationID,
                        gameToEdit.Specifications[i].SpecificationType,
                        txt_Minimum_OS.Text,
                        txt_Minimum_Processor.Text,
                        txt_Minimum_Memory.Text,
                        txt_Minimum_Storage.Text,
                        txt_Minimum_DirectX.Text,
                        txt_Minimum_Graphics.Text,
                        txt_Minimum_Other.Text,
                        txt_Minimum_Logins.Text
                    );
                }
                else if (gameToEdit.Specifications[i].SpecificationType == "Recommended")
                {
                    gameToEdit.Specifications[i] = new Specification(
                        gameToEdit.Specifications[i].SpecificationID,
                        gameToEdit.Specifications[i].SpecificationType,
                        txt_recommended_OS.Text,
                        txt_recommended_Processor.Text,
                        txt_recommended_Memory.Text,
                        txt_recommended_Storage.Text,
                        txt_recommended_DirectX.Text,
                        txt_recommended_Graphics.Text,
                        txt_recommended_Other.Text,
                        txt_recommended_Logins.Text
                    );
                }
            }
        }

        private void UpdateGenre()
        {
            if (!string.IsNullOrEmpty(CB_Genre1.Text) && gameToEdit.Genres.Count > 0)
            {
                int genreId = gameService.GetGenreIdByName(CB_Genre1.Text);
                gameToEdit.Genres[0] = new Genre(genreId, CB_Genre1.Text);
            }
            else
            {
                int genreId = gameService.GetGenreIdByName(CB_Genre1.Text);
                Genre newGenre = new Genre(genreId, CB_Genre1.Text);
                gameToEdit.Genres.Add(newGenre);
            }
            if (!string.IsNullOrEmpty(CB_Genre2.Text) && gameToEdit.Genres.Count > 1)
            {
                int genreId = gameService.GetGenreIdByName(CB_Genre2.Text);
                gameToEdit.Genres[1] = new Genre(genreId, CB_Genre2.Text);
            }
            else
            {
                int genreId = gameService.GetGenreIdByName(CB_Genre2.Text);
                Genre newGenre = new Genre(genreId, CB_Genre2.Text);
                gameToEdit.Genres.Add(newGenre);
            }
            if (!string.IsNullOrEmpty(CB_Genre3.Text) && gameToEdit.Genres.Count > 2 && CB_Genre3.Text != "None")
            {
                int genreId = gameService.GetGenreIdByName(CB_Genre3.Text);
                gameToEdit.Genres[2] = new Genre(genreId, CB_Genre3.Text);
            }
            else
            {
                if (CB_Genre3.Text != "None")
                {
                    int genreId = gameService.GetGenreIdByName(CB_Genre3.Text);
                    Genre newGenre = new Genre(genreId, CB_Genre3.Text);
                    gameToEdit.Genres.Add(newGenre);
                }

                if (CB_Genre3.Text == "None")
                {
                    if (gameToEdit.Genres.Count > 2)
                    {
                        Genre genre = gameToEdit.Genres[2];
                        gameToEdit.Genres.Remove(genre);
                    }

                }
            }
        }

        private void UpdateFeatures()
        {
            if (!string.IsNullOrEmpty(CB_Feature1.Text) && gameToEdit.Features.Count > 0)
            {
                int featureId = gameService.GetFeatureIdByName(CB_Feature1.Text);
                gameToEdit.Features[0] = new Feature(featureId, CB_Feature1.Text);
            }
            else
            {
                int featureId = gameService.GetFeatureIdByName(CB_Feature1.Text);
                Feature newFeature = new Feature(featureId, CB_Feature1.Text);
                gameToEdit.Features.Add(newFeature);
            }
            if (!string.IsNullOrEmpty(CB_Feature2.Text) && gameToEdit.Features.Count > 1)
            {
                int featureId = gameService.GetFeatureIdByName(CB_Feature2.Text);
                gameToEdit.Features[1] = new Feature(featureId, CB_Feature2.Text);
            }
            else
            {
                int featureId = gameService.GetFeatureIdByName(CB_Feature2.Text);
                Feature newFeature = new Feature(featureId, CB_Feature2.Text);
                gameToEdit.Features.Add(newFeature);
            }
            if (!string.IsNullOrEmpty(CB_Feature3.Text) && gameToEdit.Features.Count > 2 && CB_Feature3.Text != "None")
            {
                int featureId = gameService.GetFeatureIdByName(CB_Feature3.Text);
                gameToEdit.Features[2] = new Feature(featureId, CB_Feature3.Text);
            }
            else
            {
                if (CB_Feature3.Text != "None")
                {
                    int featureId = gameService.GetFeatureIdByName(CB_Feature3.Text);
                    Feature newFeature = new Feature(featureId, CB_Feature3.Text);
                    gameToEdit.Features.Add(newFeature);
                }

                if (CB_Feature3.Text == "None")
                {
                    if (gameToEdit.Features.Count > 2)
                    {
                        Feature feature = gameToEdit.Features[2];
                        gameToEdit.Features.Remove(feature);

                    }
                }
            }
        }

        private string SelectImage()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                string imagePath = Configuration["ImagePath"];

                openFileDialog.InitialDirectory = Path.Combine(imagePath, "Images");
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fullPath = openFileDialog.FileName;
                    if (fullPath.StartsWith(imagePath))
                    {
                        string relativePath = fullPath.Substring(imagePath.Length);

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

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            Index index = new Index(loggedInUser);
            this.Hide();
            index.Show();

        }

        private void btn_SelectImage_Click(object sender, EventArgs e)
        {
            string imagePath = SelectImage();
            if (!string.IsNullOrEmpty(imagePath))
            {
                txt_CoverArt.Text = imagePath;
            }
        }

        private void btn_selectImage_Spotlight_Click(object sender, EventArgs e)
        {
            string imagePath = SelectImage();
            if (!string.IsNullOrEmpty(imagePath))
            {
                txt_spotlight.Text = imagePath;
            }
        }

        private void btn_selectImage_thumbnail_Click(object sender, EventArgs e)
        {
            string imagePath = SelectImage();
            if (!string.IsNullOrEmpty(imagePath))
            {
                txt_thumbnail.Text = imagePath;
            }
        }
    }
}
