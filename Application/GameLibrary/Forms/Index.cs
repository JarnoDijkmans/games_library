using Factory;
using LogicLayer.Models.GamesFolder;
using LogicLayer.Models.UserFolder;
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
    public partial class Index : Form
    {
        GameService gameService = GameFactory.gameservice;
        private Game selectedGame;
        private User loggedInUser;
        public Index(User loggedinUser)
        {
            InitializeComponent();
            lbl_Welcome.Text = $"Welcome {loggedinUser.DisplayName}!";
            this.loggedInUser = loggedinUser;
        }

        private void btn_showall_Click(object sender, EventArgs e)
        {

            var gamelist = gameService.GetGames();
            lv_games.Items.Clear();
            foreach (Game game in gamelist)
            {
                ListViewItem gameinfo = new ListViewItem(new[] { game.GameId.ToString(), game.Title, game.Price.ToString(), game.ReleaseDate, game.Publisher });
                lv_games.Items.Add(gameinfo);
            }
        }

        private void lv_games_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_games.SelectedItems.Count > 0)
            {
                txt_modify.Visible = true;
                btn_Modify.Visible = true;
                string selectedGameId = lv_games.SelectedItems[0].SubItems[0].Text;
                int gameId = int.Parse(selectedGameId);
                selectedGame = gameService.GetGameById(gameId);
            }
            else
            {
                txt_modify.Visible = false;
                btn_Modify.Visible = false;
                selectedGame = null;
            }
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (selectedGame != null)
            {
                GameEditForm editForm = new GameEditForm(selectedGame, loggedInUser);
                this.Hide();
                editForm.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_AddNewGame_Click(object sender, EventArgs e)
        {
            AddGame addGame = new AddGame(loggedInUser);
            this.Hide();
            addGame.Show();
        }

        private void btn_See_payments_Click(object sender, EventArgs e)
        {
            PaymentForms payForms = new PaymentForms(loggedInUser);
            this.Hide();
            payForms.Show();
        }
    }
}