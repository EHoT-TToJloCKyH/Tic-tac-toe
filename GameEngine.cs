using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Deployment.Internal;
using System.Windows.Forms.VisualStyles;

namespace KrestikiNolikiKursovaya
{
    internal class GameEngine
    {
        //символьные константы для обозначения незанятой клетки игрового поля (EMPTY_CELL), занятой крестиком (X_MARK) и ноликом (O_MARK).
        const char EMPTY_CELL = '-';
        const char X_MARK = 'X';
        const char O_MARK = 'O';
        //имена игроков
        public const string PLAYER_HUMAN_TITLE = "Игрок";
        public const string PLAYER_CPU_TITLE = "Компьютер";
        //поле игровой режим
        private GameMode Mode { get; set; } = GameMode.None;
        //поле чей ход
        private WhooseTurn Turn { get; set; } = WhooseTurn.Player1Human;
        //поле хранящее имя победителя
        private string Winner { get; set; } = "";
        //количество побед первого игрока, второго игрока и ничьих
        private int player1Score = 0;
        private int player2Score = 0;
        private int numberOfDraws = 0;
        //служебная переменная для обозначения первой поставленной рандомной клетки
        private bool firstRandom = false;
        private int Count = 0;
        Cell firstRandomCell;
        //задаёт текущий выбранный режим игры
        internal enum GameMode
        {
            None,
            PlayerVsPlayer,
            PlayerVsCPU
        }
        //индикатор текущего хода
        internal enum WhooseTurn
        {
            Player1Human,
            Player2Human,
            Player2CPU
        }
        //двумерный массив с игровым полем
        private char[][] gameField = new char[][]
        {
            new char[]{EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL},
            new char[]{EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL},
            new char[]{EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL},
            new char[]{EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL},
            new char[]{EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL},
            new char[]{EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL},
            new char[]{EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL},
            new char[]{EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL},
            new char[]{EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL},
            new char[]{EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL,EMPTY_CELL},

        };
        //возвращает значение текующего режима игры, хранящейся в поле Mode
        public GameMode GetCurrentMode()
        {
            return Mode;
        }
        public bool IsGameStarted()
        {
            return Mode != GameMode.None;
        }
        //возвращает текущее значение хода Turn для одного из игроков
        public WhooseTurn GetCurrentTurn()
        {
            return Turn;
        }
        //возвращает строку, содержащую имя игрока-победителя в игре
        public string GetWinner()
        {
            return Winner;
        }
        //возвращает true, если сейчас ход 1го игрока-человека
        public bool IsPlayer1HumanTurn()
        {
            return Turn == WhooseTurn.Player1Human;
        }
        //передает ход 1му игроку
        public void SetPlayer1HumanTurn()
        {
            Turn = WhooseTurn.Player1Human;
        }
        //сбрасывает счёт обоих игроков в 0, а также обнуляет счётчик игр, сыгранных вничью
        public void ResetScore()
        {
            player1Score = 0;
            player2Score = 0;
            numberOfDraws = 0;
        }
        //сбрасывает все счётчики, а также устанавливает значение режима игры в GameMode.None. Подготавливает движок к новой игре.
        public void PrepareForNewGame()
        {
            Mode = GameMode.None;
            ResetScore();
        }
        //начинает игру в выбранном режиме
        public void StartGame(GameMode gameMode)
        {
            if(gameMode == GameMode.None)
            {
                return;
            }
            ResetScore();
            Mode = gameMode;
            Turn = WhooseTurn.Player1Human;

        }
        public string GetCurrentPlayerTitle()
        {
            switch(Mode)
            {
                case GameMode.PlayerVsCPU:
                    return PLAYER_HUMAN_TITLE;
                case GameMode.PlayerVsPlayer:
                    return PLAYER_HUMAN_TITLE + " 1";
            }
            return "";
        }
        public string GetCurrentPlayer2Title()
        {
            switch(Mode)
            {
                case GameMode.PlayerVsCPU:
                    return PLAYER_CPU_TITLE;
                case GameMode.PlayerVsPlayer:
                    return PLAYER_HUMAN_TITLE + " 2";
            }
            return "";
        }
        //выводит текущую метку Х или O, в зависимости от того, чей сейчас ход
        public string GetCurrentMarkLabelText()
        {
            if (IsPlayer1HumanTurn())
                return X_MARK.ToString();
            else
                return O_MARK.ToString();
        }
        public Color GetCurrentMarkLabelColor()
        {
            if (IsPlayer1HumanTurn())
            {
                return Color.Gold;
            }
            else 
                return Color.Red;
        }
        public int GetPlayer1Score()
        {
            return player1Score;
        }
        public int GetPlayer2Score()
        {
            return player2Score;
        }
        /// <summary>
        /// Возвращает строку с именем игрока, чей ход в данный момент
        /// </summary>
        /// <returns>строка с именем игрока</returns>
        public string GetWhooseTurnTitle()
        {
            switch (Mode)
            {
                case GameMode.PlayerVsCPU:
                    return Turn == WhooseTurn.Player1Human ? PLAYER_HUMAN_TITLE : PLAYER_CPU_TITLE; 
                case GameMode.PlayerVsPlayer:
                    return Turn == WhooseTurn.Player1Human ? PLAYER_HUMAN_TITLE + " 1" : PLAYER_HUMAN_TITLE + " 2";

            }
            return "";
        }
        /// <summary>
        /// Возвращает строку с именем игрока, для которого будет следующий ход
        /// </summary>
        /// <returns>строка с именем игрока</returns>
        public string GetWhooseNextTurnTitle()
        {
            switch (Mode)
            {
                case GameMode.PlayerVsCPU:
                    return Turn == WhooseTurn.Player1Human ? PLAYER_CPU_TITLE : PLAYER_HUMAN_TITLE;
                case GameMode.PlayerVsPlayer:
                    return Turn == WhooseTurn.Player1Human ? PLAYER_HUMAN_TITLE + " 2" : PLAYER_HUMAN_TITLE + " 1";
            }
            return "";
        }
        /// <summary>
        /// Очищает игровое поле, заполняя каждую клетку признаком пустой клетки('-')
        /// </summary>
        public void ClearGameField()
        {
            for (int row = 0; row < 10; row++)
                for (int col = 0; col < 10; col++)
                    gameField[row][col] = EMPTY_CELL;
        }
        public void MakeTurnAndFillGameFieldCell(int row, int column)
        {
            if (IsPlayer1HumanTurn())
            {
                gameField[row][column] = X_MARK;
                if (Mode == GameMode.PlayerVsCPU)
                {
                    Turn = WhooseTurn.Player2CPU;
                }
                else if (Mode == GameMode.PlayerVsPlayer)
                {
                    Turn = WhooseTurn.Player2Human;
                }
            }
            else
            {
                gameField[row][column] = O_MARK;
                Turn = WhooseTurn.Player1Human;
            }
        }


        private Cell GetHorizontalCellForAttackOrDefence(char checkMark)
        {
            for (int row = 0; row < 10; row++)
            {
                int currentSumHorizontal = 0;
                int freeCol = -1;
                for (int col = 0; col < 10; col++)
                {
                    if (gameField[row][col] == checkMark)
                    {
                        currentSumHorizontal++;
                    }
                    else if (gameField[row][col] == EMPTY_CELL)
                    {
                        freeCol = col;
                        currentSumHorizontal = 0;
                    }
                    if (col == 9)
                    {
                        if (currentSumHorizontal == 4 && gameField[row][5] == EMPTY_CELL)
                            return Cell.From(row, 5);
                    }
                    else
                    if (currentSumHorizontal == 4 && gameField[row][col + 1] == EMPTY_CELL)
                    {
                        return Cell.From(row, col + 1);
                    }
                    else
                    if (freeCol >= 0)
                    {

                        if (currentSumHorizontal == 4 && gameField[row][freeCol] == EMPTY_CELL)
                        {
                            return Cell.From(row, freeCol);
                        }
                    }
                }
            }
            return Cell.ErrorCell();
        }


        private Cell GetVerticalCellForAttackOrDefence(char checkMark)
        {
            for (int col = 0; col < 10; col++)
            {
                int currentSumVert = 0;
                int freeRow = -1;
                for (int row = 0; row < 10; row++)
                {
                    if (gameField[row][col] == checkMark)
                    {
                        currentSumVert++;
                    }
                    else
                    if (gameField[row][col] == EMPTY_CELL)
                    {
                        freeRow = row;
                        currentSumVert = 0;
                    }
                    if(row == 9)
                    {
                        if(currentSumVert == 4 && gameField[5][col] == EMPTY_CELL)
                        {
                            return Cell.From(5,col);
                        }
                    }
                    else if(currentSumVert == 4 && gameField[row+1][col] == EMPTY_CELL)
                    {
                        return Cell.From(row+1,col);
                    }
                    else if (freeRow >= 0)
                    {
                        if(currentSumVert == 4 && gameField[freeRow][col] == EMPTY_CELL)
                        {
                            return Cell.From(freeRow,col);
                        }
                    }
                }
            }
            return Cell.ErrorCell();
        }

        private Cell GetDiagonalCellForAttackOrDefence(char checkMark)
        {
            int diagonal1Sum = 0;
            int diagonal2Sum = 0;
            int freeCol1 = -1, freeRow1 = -1;
            int freeCol2 = -1, freeRow2 = -1;
            for (int row = 0; row < 10; row++)
            {
                if (gameField[row][row] == checkMark)
                {
                    diagonal1Sum++;
                }
                else if (gameField[row][row] == EMPTY_CELL)
                {
                    diagonal1Sum = 0;
                    freeCol1 = row;
                    freeRow1 = row;
                }
                if (gameField[row][9-row] == checkMark)
                {
                    diagonal2Sum++;
                }
                else if (gameField[row][9-row] == EMPTY_CELL)
                {
                    diagonal2Sum = 0;
                    freeCol2 = row;
                    freeRow2 = row;
                }
                if(row == 9)
                {
                    if(diagonal1Sum == 4 && gameField[row][5] == EMPTY_CELL)
                    {
                        return Cell.From(row, 5);
                    }
                    else if(diagonal2Sum == 4 && gameField[5][row] == EMPTY_CELL)
                    {
                        return Cell.From(5,row);
                    }
                }
                else
                if (diagonal1Sum == 4 && gameField[row + 1][row+1] == EMPTY_CELL)
                {
                    return Cell.From(row+1, row + 1);
                }
                else if (diagonal2Sum == 4 && gameField[9 - row - 1][ 9-row-1] == EMPTY_CELL)
                {
                    return Cell.From(9-row-1,9-row-1);
                }
            }

            return Cell.ErrorCell();
        }
        private Cell ComputerTryAttackHorizontalCell()
        {
            return GetHorizontalCellForAttackOrDefence(O_MARK);
        }

        private Cell ComputerTryAttackVerticalCell()
        {
            return GetVerticalCellForAttackOrDefence(O_MARK);
        }

        private Cell ComputerTryAttackDiagonalCell()
        {
            return GetDiagonalCellForAttackOrDefence(O_MARK);
        }

        private Cell ComputerTryDefendHorizontalCell()
        {
            return GetHorizontalCellForAttackOrDefence(X_MARK);
        }

        private Cell ComputerTryDefendVerticalCell()
        {
            return GetVerticalCellForAttackOrDefence(X_MARK);
        }

        private Cell ComputerTryDefendDiagonalCell()
        {
            return GetDiagonalCellForAttackOrDefence(X_MARK);
        }

        private Cell ComputerTryAttackCell()
        {
            // Пытаемся атаковать по горизонтальным клеткам
            Cell attackedHorizontalCell = ComputerTryAttackHorizontalCell();
            if (!attackedHorizontalCell.IsErrorCell())
            {
                return attackedHorizontalCell;
            }

            // Пытаемся атаковать по вертикальным клеткам
            Cell attackedVerticalCell = ComputerTryAttackVerticalCell();
            if (!attackedVerticalCell.IsErrorCell())
            {
                return attackedVerticalCell;
            }

            // Пытаемся атаковать по диагональным клеткам
            Cell attackedDiagonalCell = ComputerTryAttackDiagonalCell();
            if (!attackedDiagonalCell.IsErrorCell())
            {
                return attackedDiagonalCell;
            }

            // Нет приемлемых клеток для атаки - возвращаем спецклетку с признаком ошибки
            return Cell.ErrorCell();
        }

        private Cell ComputerTryDefendCell()
        {
            // Пытаемся защищаться по горизонтальным клеткам
            Cell defendedHorizontalCell = ComputerTryDefendHorizontalCell();
            if (!defendedHorizontalCell.IsErrorCell())
            {
                return defendedHorizontalCell;
            }

            // Пытаемся защищаться по вертикальным клеткам
            Cell defendedVerticalCell = ComputerTryDefendVerticalCell();
            if (!defendedVerticalCell.IsErrorCell())
            {
                return defendedVerticalCell;
            }

            // Пытаемся защищаться по диагональным клеткам
            Cell defendedDiagonalCell = ComputerTryDefendDiagonalCell();
            if (!defendedDiagonalCell.IsErrorCell())
            {
                return defendedDiagonalCell;
            }

            // Нет приемлемых клеток для обороны - возвращаем спецклетку с признаком ошибки
            return Cell.ErrorCell();
        }
        private Cell ComputerTrySelectRandomFreeCell()
        {
            Random random = new Random();
            int randomRow, randomCol;
            const int max_attempts = 1000; 
            int current_attempt = 0;
            do
            {
                randomRow = random.Next(10);
                randomCol = random.Next(10);
                current_attempt++;
            } while (gameField[randomRow][randomCol] != EMPTY_CELL && current_attempt <= max_attempts);
            
            if (current_attempt > max_attempts)
            {
                // мы не смогли выбрать рандомную свободную клетку за 1000 попыток, поэтому выбираем вручную
                // ближайшую клетку простым перебором по всем клеткам игрового поля
                for (int row = 0; row < 10; row++)
                {
                    for (int col = 0; col < 10; col++)
                    {
                        if (gameField[row][col] == EMPTY_CELL)
                        {
                            // клетка свободна, сразу возвращаем её
                            return Cell.From(row, col);
                        }
                    }
                }
            }
            if (firstRandom == true)
            {
                Count++;
                if (Count + firstRandomCell.Row <= 9 && Count + firstRandomCell.Column <= 9)
                {
                    if (gameField[firstRandomCell.Row + Count][firstRandomCell.Column + Count] == EMPTY_CELL)
                    {
                        return new Cell(firstRandomCell.Row + Count, firstRandomCell.Column + Count);
                    }
                }
                else
                if (Count + firstRandomCell.Row <= 9)
                {
                    if (gameField[firstRandomCell.Row + Count][firstRandomCell.Column] == EMPTY_CELL)
                    {

                        return new Cell(firstRandomCell.Row + Count, firstRandomCell.Column);
                    }
                }
                else if (Count + firstRandomCell.Column <= 9)
                {
                    if (gameField[firstRandomCell.Row][firstRandomCell.Column + Count] == EMPTY_CELL)
                    {
                        return new Cell(firstRandomCell.Row, firstRandomCell.Column + Count);
                    }
                }
                else
                    firstRandom = false;
                
            }
            if (firstRandom == false)
            {
                firstRandom = true;
                firstRandomCell = new Cell(randomRow, randomCol);
            }
            return Cell.From(randomRow, randomCol);
        }
        /// <summary>
        /// Возвращает true, если есть хотя бы одна незанятая клетка на игровом поле и false в противном случае
        /// </summary>
        /// <returns>true при наличии хотя бы одной свободной клетки на поле, иначе false</returns>
        public bool IsAnyFreeCell()
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (gameField[row][col] == EMPTY_CELL)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Cell MakeComputerTurnAndGetCell()
        {
            // Стратегия 1 - компьютер пытается сначала атаковать, если ему до победы остался всего лишь один ход
            Cell attackedCell = ComputerTryAttackCell();
            if (!attackedCell.IsErrorCell())
            {
                return attackedCell;
            }

            // Стратегия 2 - если нет приемлемых клеток для атаки, компьютер попытается найти клетки, которые нужно защитить,
            // чтобы предотвратить победу человека
            Cell defendedCell = ComputerTryDefendCell();
            if (!defendedCell.IsErrorCell())
            {
                return defendedCell;
            }

            // Стратегия 3 - у комьютера нет приемлемых клеток для атаки и защиты, поэтому ему нужно выбрать произвольную свободную клетку
            // для его очередного хода
            if (IsAnyFreeCell())
            {
                Cell randomFreeCell = ComputerTrySelectRandomFreeCell();
                return randomFreeCell;
            }

            return Cell.ErrorCell();
        }
        /// <summary>
        /// Возвращает true и увеличивает счётчик ничьих, если произошла очередная ничья.        
        /// </summary>
        /// <returns>true, если произошла ничья, в противном случае false</returns>
        public bool IsDraw()
        {
            bool isNoFreeCellsLeft = !IsAnyFreeCell();
            if (isNoFreeCellsLeft)
            {
                numberOfDraws++;
            }
            return isNoFreeCellsLeft;
        }
        /// <summary>
        /// Проверяет наличие победы какого-либо из игроков по горизонтальным клеткам игрового поля
        /// </summary>
        /// <returns></returns>
        private bool CheckWinOnHorizontalCellsAndUpdateWinner()
        {
            for (int row = 0; row < 10; row++)
            {
                int sumX = 0; int sumO = 0;
                for (int col = 0; col < 10; col++)
                {
                    if (gameField[row][col] == X_MARK)
                    {
                        sumX++;
                        if (sumX == 5)
                        {
                            // X победили
                            Winner = Mode == GameMode.PlayerVsPlayer ? PLAYER_HUMAN_TITLE + " 1" : PLAYER_HUMAN_TITLE;
                            player1Score++;
                            return true;
                        }

                    }
                    else
                        sumX = 0;
                    if (gameField[row][col] == O_MARK)
                    {
                        sumO++;
                        if(sumO == 5)
                        {
                            // O победили
                            Winner = Mode == GameMode.PlayerVsPlayer ? PLAYER_HUMAN_TITLE + " 2" : PLAYER_CPU_TITLE;
                            player2Score++;
                            return true;
                        }
                    }
                    else
                        sumO = 0;
                }
          
            }
            return false;
        }

        /// <summary>
        /// Проверяет наличие победы какого-либо из игроков по вертикальным клеткам игрового поля
        /// </summary>
        /// <returns></returns>
        private bool CheckWinOnVerticalCellsAndUpdateWinner()
        {
            for (int col = 0; col < 10; col++)
            {
                int sumX = 0; int sumO = 0;
                for (int row = 0; row <10; row++)
                {
                    if (gameField[row][col] == X_MARK)
                    {
                        sumX++;
                        if (sumX == 5)
                        {
                            // X победили
                            Winner = Mode == GameMode.PlayerVsPlayer ? PLAYER_HUMAN_TITLE + " 1" : PLAYER_HUMAN_TITLE;
                            player1Score++;
                            return true;
                        }
                    }
                    else
                        sumX = 0;
                    if (gameField[row][col] == O_MARK)
                    {
                        sumO++;
                        if (sumO == 5)
                        {
                            // O победили
                            Winner = Mode == GameMode.PlayerVsPlayer ? PLAYER_HUMAN_TITLE + " 2" : PLAYER_CPU_TITLE;
                            player2Score++;
                            return true;
                        }
                    }
                    else
                        sumO = 0;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверяет наличие победы какого-либо из игроков по диагональным клеткам игрового поля
        /// </summary>
        /// <returns></returns>
        private bool CheckWinOnDiagonalCellsAndUpdateWinner()
        {
            for(int y = 0; y < 6; y++)
            {
                for(int x = 0; x < 6; x++)
                {
                    char ch = gameField[y][x];
                    bool win = true;
                    for(int i = 1; i < 5; i++)
                    {
                        if (gameField[y + i][x + i] != ch)
                        {
                            win = false;
                            break;
                        }
                    }
                    if (win)
                    {
                        if(ch == X_MARK)
                        {
                            Winner = Mode == GameMode.PlayerVsPlayer ? PLAYER_HUMAN_TITLE + " 1" : PLAYER_HUMAN_TITLE;
                            player2Score++;
                            return true;
                        }
                        else if(ch == O_MARK)
                        {
                            Winner = Mode == GameMode.PlayerVsPlayer ? PLAYER_HUMAN_TITLE + " 2" : PLAYER_CPU_TITLE;
                            player2Score++;
                            return true;
                        }
                    }
                }
            }
            for (int y = 4; y < 10; y++)
            {
                for(int x = 0; x < 6; x++)
                {
                    char ch = gameField[y][x];
                    bool win = true;
                    for(int i = 1;i < 5; i++)
                    {
                        if (gameField[y - i][x+i] != ch)
                        {
                            win=false;
                            break;
                        }
                    }
                    if (win)
                    {
                        if (ch == X_MARK)
                        {
                            Winner = Mode == GameMode.PlayerVsPlayer ? PLAYER_HUMAN_TITLE + " 1" : PLAYER_HUMAN_TITLE;
                            player2Score++;
                            return true;
                        }
                        else if (ch == O_MARK)
                        {
                            Winner = Mode == GameMode.PlayerVsPlayer ? PLAYER_HUMAN_TITLE + " 2" : PLAYER_CPU_TITLE;
                            player2Score++;
                            return true;
                        }
                    }
                }
            }
            return false;

        }
        /// <summary>
        /// Возвращает true, если кто-то из игроков выиграл
        /// </summary>
        /// <returns>true, если какой-то из игроков выиграл, иначе false</returns>
        public bool IsWin()
        {
            if (CheckWinOnHorizontalCellsAndUpdateWinner())
            {
                return true;
            }

            if (CheckWinOnVerticalCellsAndUpdateWinner())
            {
                return true;
            }

            if (CheckWinOnDiagonalCellsAndUpdateWinner())
            {
                return true;
            }

            return false;
        }
    }
}
