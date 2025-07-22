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
    public partial class OcupationVsFriend : Form
    {
        public Panel chosenPanel = new Panel();
        public enum Turn
        {
            Player1, Player2
        };
        public Color LearnedColor;
        public Turn CurrentTurn;
        private int RedCount = 0;
        private int GoldCount = 0;
        public OcupationVsFriend()
        {
            InitializeComponent();

        }
        public void Panel_Click(object sender, EventArgs e)
        {
            chosenPanel = (Panel)sender;
            
            FastGameFriend fastgmfrm = new FastGameFriend(chosenPanel,this);
            fastgmfrm.ShowDialog();

        }
        private void PanelsMouseEnter(Panel pnl)
        {
            if (pnl.BackColor == Color.Red)
                pnl.BackColor = Color.Gold;
            else if (pnl.BackColor == Color.Gold)
                pnl.BackColor = Color.Red;
        }
        private void PanelsMouseLeave(Panel pnl)
        {
            if (pnl.BackColor == Color.Gold)
                pnl.BackColor = Color.Red;
            else if (pnl.BackColor == Color.Red)
                pnl.BackColor = Color.Gold;
        }
        public void Panel_MouseEnter(object sender, EventArgs e)
        {
            PanelsMouseEnter((Panel)sender);
        }
        public void Panel_MouseLeave(object sender, EventArgs e)
        {
            PanelsMouseLeave((Panel)sender);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[0].Show();
        }
        private void OcupationVsFriend_Activated(object sender, EventArgs e)
        {
        }

        private void OcupationVsFriend_Load(object sender, EventArgs e)
        {
            foreach(Control ctrl in panel1.Controls)
            {
                if(ctrl.BackColor == Color.Red)
                {
                    ctrl.MouseEnter += Panel_MouseEnter;
                    ctrl.MouseLeave += Panel_MouseLeave;
                    ctrl.Click += Panel_Click;
                }
            }
        }
        private bool CheckWinOcup()
        {
            RedCount = 0;
            GoldCount = 0;
            foreach(Control ctrl in panel1.Controls)
            {
                if (ctrl.BackColor == Color.Red)
                    RedCount++;
                if(ctrl.BackColor == Color.Gold)
                    GoldCount++;
            }
            if( RedCount == 16 ||  GoldCount == 16)
                return true;
            else
                return false;
        }

        private void OcupationVsFriend_MouseEnter(object sender, EventArgs e)
        {
            if (CheckWinOcup())
            {
                if (RedCount == 16)
                    MessageBox.Show("Выиграл Игрок 2(Нолики)");
                else
                    MessageBox.Show("Выиграл Игрок 1(Крестики)");
                this.Close();
                Application.OpenForms[0].Show();
            }
        }
    }
}
