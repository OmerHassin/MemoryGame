using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using B20_Ex05_01;

namespace B20_Ex05_Din_312526551_Omer_312273493
{
    public class FormMemoryGameSettings : Form
    {
        private const int k_MinSize = 4;
        private const int k_MaxSize = 6;

        private readonly List<string> r_OptionalSizes;
        private int m_SizeToShowIndex;
        private TextBox FirstPlayerNameText;
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private TextBox SecondPlayerNameText;
        private Label FirstNameLable;
        private Label SecondNameLable;
        private Label BoardSizeLable;
        private Button ChangeModeButton;
        private Button ChangeSizeButton;
        private Button StartButton;

        public FormMemoryGameSettings()
        {
            InitializeComponent();
            m_SizeToShowIndex = 0;
            r_OptionalSizes = new List<string>();
            initializeLiOpttinalSizesList();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FirstPlayerNameText = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SecondPlayerNameText = new System.Windows.Forms.TextBox();
            this.FirstNameLable = new System.Windows.Forms.Label();
            this.SecondNameLable = new System.Windows.Forms.Label();
            this.BoardSizeLable = new System.Windows.Forms.Label();
            this.ChangeModeButton = new System.Windows.Forms.Button();
            this.ChangeSizeButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FirstPlayerNameText
            // 
            this.FirstPlayerNameText.Location = new System.Drawing.Point(133, 6);
            this.FirstPlayerNameText.Name = "FirstPlayerNameText";
            this.FirstPlayerNameText.Size = new System.Drawing.Size(100, 20);
            this.FirstPlayerNameText.TabIndex = 0;
            this.FirstPlayerNameText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // SecondPlayerNameText
            // 
            this.SecondPlayerNameText.Enabled = false;
            this.SecondPlayerNameText.Location = new System.Drawing.Point(133, 37);
            this.SecondPlayerNameText.Name = "SecondPlayerNameText";
            this.SecondPlayerNameText.Size = new System.Drawing.Size(100, 20);
            this.SecondPlayerNameText.TabIndex = 2;
            this.SecondPlayerNameText.Text = "- computer -";
            this.SecondPlayerNameText.TextChanged += new System.EventHandler(this.SecondPlayerName_TextChanged);
            // 
            // FirstNameLable
            // 
            this.FirstNameLable.AutoSize = true;
            this.FirstNameLable.Location = new System.Drawing.Point(12, 9);
            this.FirstNameLable.Name = "FirstNameLable";
            this.FirstNameLable.Size = new System.Drawing.Size(92, 13);
            this.FirstNameLable.TabIndex = 3;
            this.FirstNameLable.Text = "First Player Name:";
            this.FirstNameLable.Click += new System.EventHandler(this.label1_Click);
            // 
            // SecondNameLable
            // 
            this.SecondNameLable.AutoSize = true;
            this.SecondNameLable.Location = new System.Drawing.Point(12, 37);
            this.SecondNameLable.Name = "SecondNameLable";
            this.SecondNameLable.Size = new System.Drawing.Size(110, 13);
            this.SecondNameLable.TabIndex = 4;
            this.SecondNameLable.Text = "Second Player Name:";
            this.SecondNameLable.Click += new System.EventHandler(this.label2_Click);
            // 
            // BoardSizeLable
            // 
            this.BoardSizeLable.AutoSize = true;
            this.BoardSizeLable.Location = new System.Drawing.Point(12, 107);
            this.BoardSizeLable.Name = "BoardSizeLable";
            this.BoardSizeLable.Size = new System.Drawing.Size(61, 13);
            this.BoardSizeLable.TabIndex = 5;
            this.BoardSizeLable.Text = "Board Size:";
            // 
            // ChangeModeButton
            // 
            this.ChangeModeButton.Location = new System.Drawing.Point(263, 34);
            this.ChangeModeButton.Name = "ChangeModeButton";
            this.ChangeModeButton.Size = new System.Drawing.Size(123, 23);
            this.ChangeModeButton.TabIndex = 6;
            this.ChangeModeButton.Text = "Against a Friend";
            this.ChangeModeButton.UseVisualStyleBackColor = true;
            this.ChangeModeButton.Click += new System.EventHandler(this.ChangeModeBottom_Click);
            // 
            // ChangeSizeButton
            // 
            this.ChangeSizeButton.BackColor = System.Drawing.Color.Plum;
            this.ChangeSizeButton.Location = new System.Drawing.Point(11, 123);
            this.ChangeSizeButton.Name = "ChangeSizeButton";
            this.ChangeSizeButton.Size = new System.Drawing.Size(93, 81);
            this.ChangeSizeButton.TabIndex = 7;
            this.ChangeSizeButton.Text = "4 x 4";
            this.ChangeSizeButton.UseVisualStyleBackColor = false;
            this.ChangeSizeButton.Click += new System.EventHandler(this.ChangeSizeButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.StartButton.Location = new System.Drawing.Point(285, 176);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 8;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // FormMemoryGameSettings
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(395, 216);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ChangeSizeButton);
            this.Controls.Add(this.ChangeModeButton);
            this.Controls.Add(this.BoardSizeLable);
            this.Controls.Add(this.SecondNameLable);
            this.Controls.Add(this.FirstNameLable);
            this.Controls.Add(this.SecondPlayerNameText);
            this.Controls.Add(this.FirstPlayerNameText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMemoryGameSettings";
            this.ShowIcon = false;
            this.Text = "Memory Game - Settings";
            this.Load += new System.EventHandler(this.FormMemoryGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void initializeLiOpttinalSizesList()
        {
            string stringToAdd;
            for(int i_Col = k_MinSize; i_Col <= k_MaxSize; i_Col++)
            {
                for (int j_Row = k_MinSize; j_Row <= k_MaxSize; j_Row++)
                {
                    if ((i_Col * j_Row) % 2 == 0)
                    {
                        stringToAdd = string.Format("{0} x {1}", i_Col, j_Row);
                        r_OptionalSizes.Add(stringToAdd);
                    }
                }
            }
        }

        private void FormMemoryGame_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ChangeModeBottom_Click(object sender, EventArgs e)
        {
            SecondPlayerNameText.Enabled = !SecondPlayerNameText.Enabled;
            if (SecondPlayerNameText.Enabled)
            {
                ChangeModeButton.Text = "Against Computer";
                SecondPlayerNameText.Text = string.Empty;
            }
            else
            {
                ChangeModeButton.Text = "Against a Friend";
                SecondPlayerNameText.Text = "- computer - ";
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMemoryRun form = new FormMemoryRun(
                FirstPlayerNameText.Text,
                SecondPlayerNameText.Text,
                r_OptionalSizes[m_SizeToShowIndex % r_OptionalSizes.Count],
                !SecondPlayerNameText.Enabled);
            form.ShowDialog();
        }

        private void SecondPlayerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangeSizeButton_Click(object sender, EventArgs e)
        {
            m_SizeToShowIndex++;
            ChangeSizeButton.Text = r_OptionalSizes[m_SizeToShowIndex % r_OptionalSizes.Count];
        }

    }
}
