using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Words
{
    public partial class FormGame : Form
    {
        /* 0 - легкий
         * 1 - средний
         * 2 - сложный */

        public static int levelDifficulty = 1;
        public static int cellSize = 4;

        public FormGame()
        {
            InitializeComponent();
        }

        private void buttonDifficulty_Click(object sender, EventArgs e)
        {
            if (levelDifficulty == 1)
            {
                levelDifficulty = 2;
                cellSize = 5;
                buttonDifficulty.Text = "Сложная";
            }
            else if (levelDifficulty == 2)
            {
                levelDifficulty = 0;
                cellSize = 3;
                buttonDifficulty.Text = "Легкая";
            }
            else
            {
                cellSize = 4;
                levelDifficulty = 1;
                buttonDifficulty.Text = "Средняя";
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            FormPlay formPlay = new FormPlay();
            this.Hide();
            formPlay.ShowDialog();
        }
    }
}
