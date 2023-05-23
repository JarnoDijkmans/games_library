using Factory;
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
            populateCombobox();
        }


        private void populateCombobox()
        {
            List <Genre> genres = gameService.GetGenres();
            foreach (var genre in genres)
            {
                CB_Genre1.Items.Add(genre.Name);
                CB_Genre2.Items.Add(genre.Name);
                CB_Genre3.Items.Add(genre.Name);
            }
        }
    }
}
