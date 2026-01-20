using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Words
{
    public partial class FormPlay : Form
    {
        int cellSize = FormGame.cellSize;
        int levelDifficulty = FormGame.levelDifficulty;
        int currentColumn = 0;
        int currentRow = 0;
        string rightWord = null;

        public FormPlay()
        {
            InitializeComponent();
        }

        private void FormPlay_Load(object sender, EventArgs e)
        {
            rightWord = RightWord();
            Field();
            EditRow();
            MessageBox.Show(rightWord);
        }

        string RightWord()
        {
            string[] easyWords = (File.ReadAllText("easyWords.txt").Split(' '));
            string[] midWords = (File.ReadAllText("midWords.txt").Split(' '));
            string[] hardWords = (File.ReadAllText("hardWords.txt").Split(' '));

            string[,] listWords = new string[3, 25];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (i == 0) listWords[i, j] = easyWords[j];
                    else if (i == 1) listWords[i, j] = midWords[j];
                    else listWords[i, j] = hardWords[j];
                }
            }

            Random rand = new Random();
            int indexWord = rand.Next(25);
            string word = listWords[levelDifficulty, indexWord];

            return word;
        }

        void EditRow()
        {
            for( int i = 0; i < dataGridViewField.Rows.Count; i++)
            {
                if (i != currentRow) dataGridViewField.Rows[i].ReadOnly = true;
            }
        }

        private void Field()
        {
            dataGridViewField.Width = cellSize * 70 + 2;
            dataGridViewField.Height = 352;
            dataGridViewField.Location = new Point(135 - levelDifficulty * 35, 70);

            for (int i = 0; i < cellSize; i++)
            {
                dataGridViewField.Columns.Add(new DataGridViewTextBoxColumn { Width = 70 });
            }

            dataGridViewField.Rows.Add(5);

            foreach (DataGridViewRow row in dataGridViewField.Rows)
            {
                row.Height = 70;
            }

        }

        private void dataGridViewField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsCyrillicChar(e.KeyChar))
            {
                dataGridViewField.CurrentCell.Style.Font = new Font("Impact", 20, FontStyle.Bold);
                dataGridViewField.CurrentCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewField.CurrentCell.Value = e.KeyChar.ToString().ToUpper();

                MoveToNextCell();
            }
            e.Handled = true;
        }

        bool IsCyrillicChar(char c)
        {
            return (c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == 'Ё' || c == 'ё';
        }
        void MoveToNextCell()
        {
            int nextCol = dataGridViewField.CurrentCell.ColumnIndex + 1;

            // Если достигли конца строки
            if (nextCol >= dataGridViewField.ColumnCount)
            {
                nextCol = dataGridViewField.ColumnCount - 1;
            }

            // Устанавливаем следующую ячейку текущей
            dataGridViewField.CurrentCell = dataGridViewField[nextCol, currentRow];
        }

        private void dataGridViewField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && IsRowFull())
            {
                CheckWord();
                if (currentRow <= 3) currentRow++;
                else
                {
                    MessageBox.Show($"Вы не угадали\nБыло загадно слово: {rightWord}");
                    Final();
                }
                dataGridViewField.CurrentCell = dataGridViewField[0, currentRow];
                EditRow();
            }
            e.Handled = true;

            if (e.KeyCode == Keys.Back)
            {
                dataGridViewField.CurrentCell.Value = null;
                if (dataGridViewField.CurrentCell.ColumnIndex > 0)
                    dataGridViewField.CurrentCell = dataGridViewField[dataGridViewField.CurrentCell.ColumnIndex - 1, currentRow];
            }
        }

        bool IsRowFull()
        {
            for (int col = 0; col < dataGridViewField.Columns.Count; col++)
            {
                if (dataGridViewField[col, currentRow].Value == null) return false;
            }

            return true;
        }

        void CheckWord()
        {
            int count = 0;
            for (int i = 0; i < dataGridViewField.ColumnCount; i++)
            {
                for (int j = 0; j < rightWord.Length; j++)
                {
                    if (dataGridViewField[i, currentRow].Value.ToString() == rightWord[j].ToString().ToUpper())
                    {
                        if (dataGridViewField[i, currentRow].Value.ToString() == rightWord[i].ToString().ToUpper())
                            dataGridViewField[i, currentRow].Style.BackColor = Color.Green;

                        else
                            dataGridViewField[i, currentRow].Style.BackColor = Color.Yellow;

                    }
                }
            }

            for (int i = 0; i < dataGridViewField.ColumnCount; i++)
            {
                if (dataGridViewField[i, currentRow].Style.BackColor == Color.Green) count++; 
            }
            
            if (count == dataGridViewField.ColumnCount)
            {
                MessageBox.Show("Вы угадали слово!");
                Final();
            }
        }

        void Final()
        {
            DialogResult result = MessageBox.Show("Начать заново?", "5 слов", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                FormPlay formPlay = new FormPlay();
                this.Hide();
                formPlay.ShowDialog();
            }
            else
            {
                FormGame formGame = new FormGame();
                this.Hide();
                formGame.ShowDialog();
            }
        }
    }
}
