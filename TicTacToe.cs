using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KrestikiNolikiKursovaya
{
    public partial class TicTacToeMenu : Form
    {
        public TicTacToeMenu()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFastVsFriend_Click(object sender, EventArgs e)
        {
            this.Hide();
            FastGameFriend fastGameFriendFrm = new FastGameFriend();
            fastGameFriendFrm.Show();
        }

        private void btnAboutTheGame_Click(object sender, EventArgs e)
        {
            Information informationFrm = new Information();
            informationFrm.ShowDialog();
        }

        private void btnFastVsComp_Click(object sender, EventArgs e)
        {
            this.Hide();
            FastGameBot fastGameBotFrm = new FastGameBot(false);
            fastGameBotFrm.Show();
        }

        private void btnOcupVsFriend_Click(object sender, EventArgs e)
        {
            this.Hide();
            OcupationVsFriend ocupationVsFriendFrm = new OcupationVsFriend();
            ocupationVsFriendFrm.Show();
        }
    }
}
