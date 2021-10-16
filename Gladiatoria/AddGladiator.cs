using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gladiatoria
{
    public partial class AddGladiator : Form
    {
        public Main.structBattlePlayer battlePlayer;

        List<System.Windows.Forms.TextBox> tbListObjects;

        public AddGladiator()
        {
            InitializeComponent();

            tbListObjects = new List<System.Windows.Forms.TextBox>();


            tbListObjects.Add(tbName);
            tbListObjects.Add(tbFamyliName);
            //tbListObjects.Add(tbSecondName);
            tbListObjects.Add(tbRating);
            tbListObjects.Add(tbCountry);
            tbListObjects.Add(tbLocation);
            tbListObjects.Add(tbClub);

            battlePlayer.photo = "../../Images/FightersPhoto/no_photo";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sender != btnSave) {
                Hide();
                return;
            }

            foreach(TextBox tbElement in tbListObjects) {
                if (tbElement.Text.Length == 0)
                {
                    tbElement.Focus();
                    tbElement.BackColor = Color.Red;
                    return;
                }
                else
                {
                    tbElement.BackColor = SystemColors.Window;
                }
            }

            battlePlayer.name       = tbName.Text;
            battlePlayer.familyName = tbFamyliName.Text;
            battlePlayer.secondName = tbSecondName.Text;
            battlePlayer.sexMan     = cbSex.SelectedIndex == 0;

            battlePlayer.birthDate  = dtpBirfthday.Text;
            battlePlayer.rating     = Convert.ToDouble(tbRating.Text);
            battlePlayer.country    = tbCountry.Text;
            battlePlayer.location   = tbLocation.Text;
            battlePlayer.club       = tbClub.Text;

            battlePlayer.battles    = Convert.ToInt32(nBattles.Value);
            battlePlayer.wins       = Convert.ToInt32(nWins.Value);
            battlePlayer.loses      = Convert.ToInt32(nLosers.Value);
            battlePlayer.draws      = battlePlayer.battles - (battlePlayer.wins + battlePlayer.loses);
            battlePlayer.winPoints  = Convert.ToInt32(nWP.Value);
            battlePlayer.missHits   = Convert.ToInt32(nMH.Value);

            Hide();
            DialogResult = (sender == btnSave) ? DialogResult.OK : DialogResult.Cancel;
        }

        private void btnLoadPhoto_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                picGladiator.Image = Image.FromFile(openFileDialog1.FileName);
                battlePlayer.photo = openFileDialog1.FileName;
            }
        }

        public void FillForm(Main.structBattlePlayer gladiator) {
            tbName.Text         = gladiator.name;
            tbFamyliName.Text   = gladiator.familyName;
            tbSecondName.Text   = gladiator.secondName;
            cbSex.SelectedIndex = gladiator.sexMan ? 0 : 1;

            dtpBirfthday.Text   = gladiator.birthDate;
            tbRating.Text       = gladiator.rating.ToString();
            tbCountry.Text      = gladiator.country;
            tbLocation.Text     = gladiator.location;
            tbClub.Text         = gladiator.club;

            nBattles.Value = Convert.ToDecimal(gladiator.battles);
            nWins.Value    = Convert.ToDecimal(gladiator.wins);
            nLosers.Value  = Convert.ToDecimal(gladiator.loses);
            nWP.Value      = Convert.ToDecimal(gladiator.winPoints);
            nMH.Value      = Convert.ToDecimal(gladiator.missHits);

            if (gladiator.photo != null) {
                openFileDialog1.FileName = gladiator.photo;
                picGladiator.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
