using System;
using System.Drawing;
using System.Windows.Forms;

namespace KrestikiNolikiKursovaya
{
    public partial class FastGameBot : Form
    {
        //подключаем наш игровой движок:
        private GameEngine engine = new GameEngine();
        private bool Ocup;
        public FastGameBot(bool Ocupation)
        {
            InitializeComponent();
            Ocup = Ocupation;
        }
        private void FillCell(Panel panel, int row, int column)
        {
            if (!engine.IsGameStarted())
            {
                //если игра не началась, не рисовать ничего на игровом поле и просто вернуться
                return;
            }
            Label markLabel = new Label();
            markLabel.Font = new Font(FontFamily.GenericMonospace, 50, FontStyle.Bold);
            markLabel.AutoSize = true;
            markLabel.Text = engine.GetCurrentMarkLabelText();
            markLabel.ForeColor = engine.GetCurrentMarkLabelColor();

         //   label2.Text = engine.GetWhooseNextTurnTitle();

            engine.MakeTurnAndFillGameFieldCell(row, column);

            panel.Controls.Add(markLabel);

            if (engine.IsWin())
            {
                // Движок вернул результат, что произошла победа одного из игроков
                MessageBox.Show("Победа! Выиграл " + engine.GetWinner(), "Крестики-Нолики", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearGameField();
            }
            else if (engine.IsDraw())
            {
                // Движок вернул результат, что произошла ничья
                MessageBox.Show("Ничья!", "Крестики-Нолики", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearGameField();
            }
            else
            {
                // Ещё остались свободные клетки на поле. Если ход компьютера - вызываем движок для определения клетки, которую
                // выберет комьютер для хода
                if (engine.GetCurrentTurn() == GameEngine.WhooseTurn.Player2CPU)
                {
                    Cell cellChosenByCpu = engine.MakeComputerTurnAndGetCell();
                    if (!cellChosenByCpu.IsErrorCell())
                    {
                        Panel panelCell = GetPanelCellControlByCell(cellChosenByCpu);
                        if (panelCell != null)
                        {
                            FillCell(panelCell, cellChosenByCpu.Row, cellChosenByCpu.Column);
                        }
                        else
                        {
                            // что-то пошло не так, мы не смогли найти верный элемент Panel по клетке, выбранной компьютером
                            // покажем ошибку
                            MessageBox.Show(
                                "Произошла ошибка: выбранная компьютером клетка не должна быть равна null!",
                                "Крестики-Нолики",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                    else
                    {
                        // что-то пошло не так, движок вернул спецклетку, хотя такого быть не должно.
                        // покажем ошибку
                        MessageBox.Show(
                            "Произошла ошибка: компьютер не смог выбрать клетку для хода!",
                            "Крестики-Нолики",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }
        private void btnRestart_MouseEnter( object sender, EventArgs e )
        {
            btnRestart.BackColor = Color.White;
            Cursor = Cursors.Hand;
        }
        private void btnRestart_MouseLeave(object sender, EventArgs e)
        {
            btnRestart.BackColor = Color.SteelBlue;
            Cursor = Cursors.Default;
        }
        //метод для изменения цвета панелей при наведении мышки
        private void PanelsMouseEnter(Panel ButtonPanel)
        {
            ButtonPanel.BackColor = Color.Khaki;
            Cursor = Cursors.Hand;
        }
        //метод для изменения цвета панелей при уводе мышки
        private void PanelsMouseLeave(Panel ButtonPanel)
        {
            ButtonPanel.BackColor = Color.Thistle;
            Cursor = Cursors.Default;
        }
        //метод для изменения цвета кнопки выйти при наведении мышки
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.White;
            Cursor = Cursors.Hand;
        }
        //метод для изменения цвета кнопки выйти при уводе мышки
        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.SteelBlue;
            Cursor = Cursors.Default;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
         this.Close();
            Application.OpenForms[0].Show();
        }

        private void panelCell0_0_MouseEnter(object sender, EventArgs e)
        {
            PanelsMouseEnter((Panel)sender);
        }

        private void panelCell0_0_MouseLeave(object sender, EventArgs e)
        {
            PanelsMouseLeave((Panel)sender);
        }
        private Panel GetPanelCellControlByCell(Cell cell)
        {
            if(cell == null || !cell.IsValidGameFieldCell()){
                return null;
            }
            string panelCtrlName = "panel" + cell.Row + "_" + cell.Column;
            foreach (Control ctrl in panel2.Controls)
            {
                if (ctrl.Name.Equals(panelCtrlName) && ctrl is Panel)
                    return (Panel)ctrl;
            }
            return null;
        }
        private void ClearGameField()
        {
            engine.ClearGameField();

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    Panel panelCell = GetPanelCellControlByCell(Cell.From(row, col));
                    if (panelCell != null)
                    {
                        panelCell.Controls.Clear();
                    }
                }
            }

            engine.SetPlayer1HumanTurn();
         //   label2.Text = engine.GetWhooseTurnTitle();
        }
        private void ResetGame()
        {
            ClearGameField();
            engine.StartGame(engine.GetCurrentMode());
         //   UpdateControls();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
        private void StartNewGameInSelectedMode(GameEngine.GameMode selectedMode)
        {
            engine.StartGame(selectedMode);
            
        }
        private void FastGameBot_Load(object sender, EventArgs e)
        {
            StartNewGameInSelectedMode(GameEngine.GameMode.PlayerVsCPU);
         //   label2.Text = "X";
        }
        private void panelCell0_0_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 0, 0);
        }

        private void panelCell0_1_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 0, 1);
        }

        private void panelCell0_2_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 0, 2);
        }

        private void panelCell0_3_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 0, 3);
        }

        private void panelCell0_4_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 0, 4);
        }

        private void panelCell0_5_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 0, 5);
        }

        private void panelCell0_6_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 0, 6);
        }

        private void panelCell0_7_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 0, 7);
        }

        private void panelCell0_8_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 0, 8);
        }

        private void panelCell0_9_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 0, 9);
        }

        private void panel1_0_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 1, 0);
        }

        private void panel1_1_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 1, 1);
        }

        private void panel1_2_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 1, 2);
        }

        private void panel1_3_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 1, 3);
        }

        private void panel1_4_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 1, 4);
        }

        private void panel1_5_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 1, 5);
        }

        private void panel1_6_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 1, 6);
        }

        private void panel1_7_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 1, 7);
        }

        private void panel1_8_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 1, 8);
        }

        private void panel1_9_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 1, 9);
        }

        private void panel2_0_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 2, 0);
        }

        private void panel2_1_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 2, 1);
        }

        private void panel2_2_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 2, 2);
        }

        private void panel2_3_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 2, 3);
        }

        private void panel2_4_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 2, 4);
        }

        private void panel2_5_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 2, 5);
        }

        private void panel2_6_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 2, 6);
        }

        private void panel2_7_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 2, 7);
        }

        private void panel2_8_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 2, 8);
        }

        private void panel2_9_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 2, 9);
        }

        private void panel3_0_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 3, 0);
        }

        private void panel3_1_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 3, 1);
        }

        private void panel3_2_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 3, 2);
        }

        private void panel3_3_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 3, 3);
        }

        private void panel3_4_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 3, 4);
        }

        private void panel3_5_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 3, 5);
        }

        private void panel3_6_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 3, 6);
        }

        private void panel3_7_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 3, 7);
        }

        private void panel3_8_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 3, 8);
        }

        private void panel3_9_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 3, 9);
        }

        private void panel4_0_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 4, 0);
        }

        private void panel4_1_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 4, 1);
        }

        private void panel4_2_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 4, 2);
        }

        private void panel4_3_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 4, 3);
        }

        private void panel4_4_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 4, 4);
        }

        private void panel4_5_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 4, 5);
        }

        private void panel4_6_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 4, 6);
        }

        private void panel4_7_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 4, 7);
        }

        private void panel4_8_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 4, 8);
        }

        private void panel4_9_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 4, 9);
        }

        private void panel5_0_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 5, 0);
        }

        private void panel5_1_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 5, 1);
        }

        private void panel5_2_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 5, 2);
        }

        private void panel5_3_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 5, 3);
        }

        private void panel5_4_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 5, 4);
        }

        private void panel5_5_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 5, 5);
        }

        private void panel5_6_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 5, 6);
        }

        private void panel5_7_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 5, 7);
        }

        private void panel5_8_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 5, 8);
        }

        private void panel5_9_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 5, 9);
        }

        private void panel6_0_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 6, 0);
        }

        private void panel6_1_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 6, 1);
        }

        private void panel6_2_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 6, 2);
        }

        private void panel6_3_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 6, 3);
        }

        private void panel6_4_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 6, 4);
        }

        private void panel6_5_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 6, 5);
        }

        private void panel6_6_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 6, 6);
        }

        private void panel6_7_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 6, 7);
        }

        private void panel6_8_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 6, 8);
        }

        private void panel6_9_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 6, 9);
        }

        private void panel7_0_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 7, 0);
        }

        private void panel7_1_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 7, 1);
        }

        private void panel7_2_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 7, 2);
        }

        private void panel7_3_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 7, 3);
        }

        private void panel7_4_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 7, 4);
        }

        private void panel7_5_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 7, 5);
        }

        private void panel7_6_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 7, 6);
        }

        private void panel7_7_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 7, 7);
        }

        private void panel7_8_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 7, 8);
        }

        private void panel7_9_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 7, 9);
        }

        private void panel8_0_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 8, 0);
        }

        private void panel8_1_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 8, 1);
        }

        private void panel8_2_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 8, 2);
        }

        private void panel8_3_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 8, 3);
        }

        private void panel8_4_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 8, 4);
        }

        private void panel8_5_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 8, 5);
        }

        private void panel8_6_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 8, 6);
        }

        private void panel8_7_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 8, 7);
        }

        private void panel8_8_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 8, 8);
        }

        private void panel8_9_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 8, 9);
        }

        private void panel9_0_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 9, 0);
        }

        private void panel9_1_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 9, 1);
        }

        private void panel9_2_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 9, 2);
        }

        private void panel9_3_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 9, 3);
        }

        private void panel9_4_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 9, 4);
        }

        private void panel9_5_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 9, 5);
        }

        private void panel9_6_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 9, 6);
        }

        private void panel9_7_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 9, 7);
        }

        private void panel9_8_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 9, 8);
        }

        private void panel9_9_Click(object sender, EventArgs e)
        {
            FillCell((Panel)sender, 9, 9);
        }
    }
}
