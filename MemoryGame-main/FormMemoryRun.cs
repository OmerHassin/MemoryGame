using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using B20_Ex05_01.MemoryGameUtils;
using B20_Ex05_01.UIFolder;
using b20_ex05_01.memorygameutils;

namespace B20_Ex05_01
{
    internal class FormMemoryRun : Form
    {
        private const int k_ButtonSize = 85;
        private const int k_ButtonMargin = 6;
        private const int k_MarginSize = 12;
        private const int k_ScoreBoardSize = 120;
        private const int k_LableMargin = 24;

        private readonly int r_NumOfColunms;
        private readonly int r_NumOfRows;
        private readonly List<Button> r_ButtonsList;
        private Board<Image> m_GameBoard;
        private Cell<Image> m_FirstChoice;
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private Player m_PlayerPlaying;
        private Computer m_ComputerPlayer;
        private Label CurrentPlayerLable;
        private Label PlayerTwoLable;
        private Label PlayerOneLable;
        private int m_NumOfMatchesRemain;
        private bool m_IsFirstMove;
        private bool m_ComputerMode;

        internal FormMemoryRun(string i_FirstPlayeName, string i_SecondPlayeName, string i_BoardSize, bool i_ComputerMode)
        {
            r_NumOfColunms = i_BoardSize[0] - '0';
            r_NumOfRows = i_BoardSize[4] - '0';
            r_ButtonsList = new List<Button>();

            initializeDataBoard();
            initializeFormBoard();
            initializePlayers(i_FirstPlayeName, i_SecondPlayeName, i_ComputerMode);
            initializeScoreBoard();
        }

        private void initializeDataBoard()
        {
            Cell<Image>[,] dataMatrix = BoardCreaterUtils.CreateImageBoard(r_NumOfColunms, r_NumOfRows);
            m_GameBoard = new Board<Image>(r_NumOfColunms, r_NumOfRows, dataMatrix);
            m_NumOfMatchesRemain = (r_NumOfRows * r_NumOfColunms) / 2;
        }

        private void initializeFormBoard()
        {
            int width, height;
            width = (k_MarginSize * 2) + (k_ButtonSize * r_NumOfColunms) + (k_ButtonMargin * (r_NumOfColunms - 1));
            height = k_ScoreBoardSize + (k_ButtonSize * r_NumOfRows) + (k_ButtonMargin * (r_NumOfRows - 1));
            this.ClientSize = new Size(width, height);

            for (int i = 0; i < r_NumOfColunms; i++)
            {
                for (int j = 0; j < r_NumOfRows; j++)
                {
                    initializeButton(i, j);
                }
            }
        }

        private void initializeButton(int i_currentButtonCol, int i_CurrentButtonRow)
        {
            Button button = new Button();
            button.Location = new Point(k_MarginSize + (i_currentButtonCol * (k_ButtonSize + k_ButtonMargin)), k_MarginSize + (i_CurrentButtonRow * (k_ButtonSize + k_ButtonMargin)));
            button.Name = string.Format("{0}", (i_currentButtonCol * r_NumOfRows) + i_CurrentButtonRow);
            button.Size = new Size(k_ButtonSize, k_ButtonSize);
            button.Text = string.Empty;
            button.UseVisualStyleBackColor = true;
            button.Click += Button_Click;
            this.Controls.Add(button);
            r_ButtonsList.Add(button);
        }

        private void initializePlayers(string i_FirstPlayeName, string i_SecondPlayeName, bool i_ComputerMode)
        {
            m_PlayerOne = new Player(i_FirstPlayeName, false, Color.LightGreen);
            m_PlayerTwo = new Player(i_SecondPlayeName, i_ComputerMode, Color.Thistle);

            if (i_ComputerMode)
            {
                m_ComputerPlayer = new Computer(r_ButtonsList);
                m_ComputerMode = i_ComputerMode;
            }

            m_IsFirstMove = true;
            m_PlayerPlaying = m_PlayerOne;
        }

        private void initializeScoreBoard()
        {
            this.CurrentPlayerLable = new Label();
            this.PlayerTwoLable = new Label();
            this.PlayerOneLable = new Label();

            this.CurrentPlayerLable.AutoSize = true;
            this.CurrentPlayerLable.Location = new System.Drawing.Point(9, k_LableMargin + (r_NumOfRows * (k_ButtonSize + k_ButtonMargin)));
            this.CurrentPlayerLable.Name = "CurrentPlayerLable";

            this.PlayerOneLable.AutoSize = true;
            this.PlayerOneLable.BackColor = m_PlayerOne.Color;
            this.PlayerOneLable.Location = new System.Drawing.Point(9, CurrentPlayerLable.Location.Y + k_LableMargin);
            this.PlayerOneLable.Name = "PlayerOneLable";

            this.PlayerTwoLable.AutoSize = true;
            this.PlayerTwoLable.BackColor = m_PlayerTwo.Color;
            this.PlayerTwoLable.Location = new System.Drawing.Point(9, PlayerOneLable.Location.Y + k_LableMargin);
            this.PlayerTwoLable.Name = "PlayerTwoLable";

            this.Controls.Add(this.PlayerOneLable);
            this.Controls.Add(this.PlayerTwoLable);
            this.Controls.Add(this.CurrentPlayerLable);
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "FormMemoryRun";
            this.RightToLeftLayout = true;
            this.Text = "Memory Game";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            updateScoreBoard();
        }

        private void switchTurn()
        {
            if (m_PlayerPlaying == m_PlayerOne)
            {
                m_PlayerPlaying = m_PlayerTwo;
            }
            else
            {
                m_PlayerPlaying = m_PlayerOne;
            }
        }

        private void updateScoreBoard()
        {
            this.CurrentPlayerLable.BackColor = m_PlayerPlaying.Color;
            this.CurrentPlayerLable.Text = string.Format("CurrentPlayer: {0} ", m_PlayerPlaying.Name);
            this.PlayerOneLable.Text = string.Format("{0}: {1} Pair{2}", m_PlayerOne.Name, m_PlayerOne.Points, BoardCreaterUtils.SingleOrPloural(m_PlayerOne.Points));
            this.PlayerTwoLable.Text = string.Format("{0}: {1} Pair{2}", m_PlayerTwo.Name, m_PlayerTwo.Points, BoardCreaterUtils.SingleOrPloural(m_PlayerTwo.Points));
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button buttonClicked = sender as Button;
            doWhenClicked(buttonClicked);
            Refresh();

            Cell<Image> cellClicked = m_GameBoard.GetCell(int.Parse(buttonClicked.Name));

            if (m_IsFirstMove)
            {
                m_FirstChoice = cellClicked;
            }
            else
            {
                endOfTurn(cellClicked);
            }

            m_IsFirstMove = !m_IsFirstMove;

            if (m_NumOfMatchesRemain == 0)
            {
                finishGame();
            }
            else if (m_IsFirstMove && m_PlayerPlaying.Computer)
            {
                playComputerTurn();
            }
        }

        private void doWhenClicked(Button i_ButtonClicked)
        {
            Cell<Image> cellClicked = m_GameBoard.GetCell(int.Parse(i_ButtonClicked.Name));
            cellClicked.Reveald = true;
            i_ButtonClicked.Image = cellClicked.Value;
            i_ButtonClicked.FlatStyle = FlatStyle.Flat;
            i_ButtonClicked.ForeColor = m_PlayerPlaying.Color;
            i_ButtonClicked.FlatAppearance.BorderSize = 3;
            i_ButtonClicked.Click -= Button_Click;
        }

        private void endOfTurn(Cell<Image> i_SecondChoice)
        {
            if (m_FirstChoice.Value.Equals(i_SecondChoice.Value))
            {
                matchFound(i_SecondChoice);
            }
            else
            {
                matchNotFound(i_SecondChoice);
            }
            
            updateScoreBoard();
        }

        private void matchFound(Cell<Image> i_SecondChoice)
        {
            m_NumOfMatchesRemain--;
            m_PlayerPlaying.Points++;
            if (m_ComputerMode)
            {
                m_ComputerPlayer.RemoveMatchedButtons(r_ButtonsList[m_FirstChoice.Index], r_ButtonsList[i_SecondChoice.Index]);
            }
        }

        private void matchNotFound(Cell<Image> i_SecondChoice)
        {
            Thread.Sleep(1000);
            hideCell(m_FirstChoice);
            hideCell(i_SecondChoice);
            if (m_PlayerPlaying.Computer)
            {
                m_ComputerPlayer.ReturnButtons(r_ButtonsList[m_FirstChoice.Index], r_ButtonsList[i_SecondChoice.Index]);
            }

            switchTurn();
        }

        private void playComputerTurn()
        {
            Thread.Sleep(500);
            m_ComputerPlayer.ChooseButton();
            Thread.Sleep(250);
            m_ComputerPlayer.ChooseButton();
        }

        private void hideCell(Cell<Image> i_CellToHide)
        {
            Button button = r_ButtonsList[i_CellToHide.Index];
            i_CellToHide.Reveald = false;
            button.Image = null;
            button.FlatStyle = FlatStyle.Standard;
            button.ForeColor = default;
            button.Click += Button_Click;
        }

        private void finishGame()
        {
            this.Hide();
            string msg = string.Format(
@"{0} {1}  -  {2} {3}
The game is over.The winner is {4}
Would you like to have another game?",
                 m_PlayerOne.Name,
                 m_PlayerOne.Points,
                 m_PlayerTwo.Points,
                 m_PlayerTwo.Name,
                 winner());

            if (MessageBox.Show(msg, "Game Is Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.No)
            {
                this.Close();
            }
            else
            {
                initializeDataBoard();
                initializePlayers(m_PlayerOne.Name, m_PlayerTwo.Name, m_ComputerMode);
                resetButtons();
                updateScoreBoard();
                this.Show();
            }
        }

        private string winner()
        {
            string winner;
            if (m_PlayerOne.Points > m_PlayerTwo.Points)
            {
                winner = m_PlayerOne.Name;
            }
            else if (m_PlayerTwo.Points > m_PlayerOne.Points)
            {
                winner = m_PlayerTwo.Name;
            }
            else
            {
                winner = "nobody! It's a tie.";
            }

            return winner;
        }

        private void resetButtons()
        {
            for (int i = 0; i < r_ButtonsList.Count; i++)
            {
                hideCell(m_GameBoard.GetCell(i));
            }
        }
    }
}
