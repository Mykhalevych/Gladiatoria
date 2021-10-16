using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum GladiatorState {
    Rest,
    Prepare,
    InBattle
}

namespace Gladiatoria
{
    public partial class Main : Form {
        public struct structBattlePlayer {
            public int id;
            public string name;
            public string familyName;
            public string secondName;
            public bool sexMan;
            public string birthDate;
            public string photo;
            public double rating;
            public string country;
            public string location;
            public string club;
            public int winPoints;
            public int missHits;
            public int fouls;
            public int wins;
            public int draws;
            public int loses;
            public int battles;
            public GladiatorState state;
            //            public int country;
            //            public int location;
            //            public int club;
        }

        private Fight wFight;
        private AddGladiator wAddGladiator;

        private Dictionary<int, structBattlePlayer> _gladiators = new Dictionary<int, structBattlePlayer>();

        private Label[] lAdv;
        private Label[] lMisHit;
        private Label[] lFoul;

        public Main() {
            InitializeComponent();

            lAdv    = new Label[2] { lAdvBlue, lAdvYellow };
            lMisHit = new Label[2] { lMisHitBlue, lMisHitYellow };
            lFoul   = new Label[2] { lFoulBlue, lFoulYellow };

            EventManager.OnTimeOver += HandleTimeOver;

            EventManager.OnMisHit    += HandleMisHit;
            EventManager.OnFoul      += HandleFoul;
            EventManager.OnAdvantage += HandleAdvantage;

            EventManager.OnRatingRecalc += HandlerRecalcRating;
            EventManager.OnFightFinish  += HadlerFightFinish;

            this.Top = 0;
        }

        private void btnFigthWindow_Click(object sender, EventArgs e) {
            if (wFight == null) {
                wFight = new Fight();
            }

            if (wFight.Visible == false) {
                wFight.Show();

                btnFigthWindow.Text = "Сховати глядацьке вікно";

            }
            else {
                wFight.Hide();

                btnFigthWindow.Text = "Показати глядацьке вікно";
            }

            pFigth.Enabled = btnChangeColorsPlase.Enabled = btnToFight.Enabled = btnShowBattle.Enabled = btnShowNext.Enabled = wFight.Visible;
            btnLogoShow.Enabled = wFight.Visible;
        }

        private void btnAddGladiator_Click(object sender, EventArgs e) {
            wAddGladiator = new AddGladiator();

            wAddGladiator.ShowDialog();
            if (wAddGladiator.DialogResult == DialogResult.OK) {
                string FighterName = wAddGladiator.battlePlayer.familyName + " " + wAddGladiator.battlePlayer.name + " " + wAddGladiator.battlePlayer.secondName;
                int id = GladiatorsList.Rows.Count;
                wAddGladiator.battlePlayer.id = id;
                _gladiators[id] = wAddGladiator.battlePlayer;

                GladiatorsList.Rows.Insert(id, (id + 1).ToString(), FighterName, _gladiators[id].club, _gladiators[id].rating.ToString("n2"), "В очікуванні", _gladiators[id].battles.ToString(), _gladiators[id].wins.ToString(), _gladiators[id].loses.ToString(), _gladiators[id].draws.ToString(), _gladiators[id].winPoints.ToString(), _gladiators[id].missHits.ToString());
                //btnAddGladiator.Text = "OK";
                btnPrepare.Enabled = btnBackToRest.Enabled = btnEditGladiator.Enabled = GladiatorsList.Rows.Count > 0;
            }
            else {
                //btnAddGladiator.Text = "Cancel";
            }

            wAddGladiator.Dispose();
            //GC.Collect();
            this.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e) {
            int row = GladiatorsList.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(GladiatorsList.Rows[row].Cells[0].Value.ToString()) - 1;

            if (id >= 0) {
                wAddGladiator = new AddGladiator();

                wAddGladiator.FillForm(_gladiators[id]);

                wAddGladiator.ShowDialog();
                if (wAddGladiator.DialogResult == DialogResult.OK) {
                    string FighterName = wAddGladiator.battlePlayer.name + " " + wAddGladiator.battlePlayer.familyName + " " + wAddGladiator.battlePlayer.secondName;
                    _gladiators[id] = wAddGladiator.battlePlayer;

                    //                    GladiatorsList.Rows[id].Cells[0].Value = (id + 1).ToString();
                    GladiatorsList.Rows[row].Cells[1].Value = FighterName;
                    GladiatorsList.Rows[row].Cells[2].Value = _gladiators[id].club;
                    GladiatorsList.Rows[row].Cells["Rating"].Value = _gladiators[id].rating.ToString("n2");
                }

                wAddGladiator.Dispose();

                this.Focus();
            }
        }

        private void btnShowNext_Click(object sender, EventArgs e) {
            wFight.pFight.Visible = false;
            wFight.pBefore.Visible = true;
            wFight.pBefore.Dock = DockStyle.Fill;
        }

        private void btnShowBattle_Click(object sender, EventArgs e) {
            wFight.pBefore.Visible = false;
            wFight.pFight.Visible = true;
            wFight.pFight.Dock = DockStyle.Fill;
        }

        private void btnPrepare_Click(object sender, EventArgs e) {
            int row = GladiatorsList.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(GladiatorsList.Rows[row].Cells[0].Value.ToString()) - 1;

            if (wFight == null) {
                MessageBox.Show("Вікно бою не відкрито!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id >= 0) {
                if (_gladiators[id].state == GladiatorState.Rest) {
                    structBattlePlayer tmp = _gladiators[id];
                    if (wFight.IsBluePrepareFree()) {
                        wFight.PrepearingBlue(ref tmp);
                        tmp.state = GladiatorState.Prepare;
                        GladiatorsList.Rows[row].DefaultCellStyle.BackColor = Color.Blue;
                        GladiatorsList.Rows[row].Cells["State"].Value = "Готується до бою";
                    }
                    else if (wFight.IsYellowPrepareFree()) {
                        wFight.PrepearingYellow(ref tmp);
                        tmp.state = GladiatorState.Prepare;
                        GladiatorsList.Rows[row].DefaultCellStyle.BackColor = Color.Yellow;
                        GladiatorsList.Rows[row].Cells["State"].Value = "Готується до бою";
                    }
                    _gladiators[id] = tmp;
                }
            }
        }

        private void btnBackToRest_Click(object sender, EventArgs e) {
            int row = GladiatorsList.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(GladiatorsList.Rows[row].Cells[0].Value.ToString()) - 1;

            if (id >= 0 && _gladiators[id].state == GladiatorState.Prepare) {
                if (wFight.BackToRest(_gladiators[id].id)) {
                    structBattlePlayer tmp = _gladiators[id];
                    tmp.state = GladiatorState.Rest;
                    GladiatorsList.Rows[row].Cells["State"].Value = "В очікуванні";
                    GladiatorsList.Rows[row].DefaultCellStyle.BackColor = Color.White;
                    _gladiators[id] = tmp;
                }
            }
        }

        private void btnToFight_Click(object sender, EventArgs e) {
            if (wFight.ToHort(Convert.ToInt32(TimeRoundDef.Value))) {
                Timer.Text = wFight.GetLeftTime();

                SetGladiatorState(wFight.GetGladiatorIdBlue(), GladiatorState.InBattle);
                SetGladiatorState(wFight.GetGladiatorIdYellow(), GladiatorState.InBattle);

                btnToFight.Enabled = false;
                btnToRest.Enabled = true;

                for (int side = 0; side < 2; ++side) {
                    lAdv[side].Text    = "0";
                    lMisHit[side].Text = "0";
                    lFoul[side].Text   = "0";
                }
            }
        }

        private void btnPlus1_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            int correctSec = Convert.ToInt32(btn.Text);

            Timer.Text = wFight.CorrectionTimer(correctSec);            
        }

        private void btnStartTimer_Click(object sender, EventArgs e) {
            wFight.StartStopTimer();

            StartStopBtnChange();
        }

        private void SetGladiatorState(int id, GladiatorState state) {
            structBattlePlayer tmp = _gladiators[id];

            for (int i = 0; i < GladiatorsList.RowCount; ++i) {
                if (Convert.ToInt32(GladiatorsList.Rows[i].Cells[0].Value.ToString()) - 1 == id) {
                    tmp.state = state;
                    GladiatorsList.Rows[i].Cells["State"].Value = (state == GladiatorState.Rest) ? "В очікуванні" : (state == GladiatorState.Prepare) ? "Готується до бою" : "На хорті";
                    break;
                }
            }

            _gladiators[id] = tmp;
        }

        private void SetGladiatorRating(int id) {
            //structBattlePlayer tmp = _gladiators[id];

            for (int i = 0; i < GladiatorsList.RowCount; ++i) {
                if (Convert.ToInt32(GladiatorsList.Rows[i].Cells[0].Value.ToString()) - 1 == id) {
                    GladiatorsList.Rows[i].Cells["Rating"].Value = _gladiators[id].rating.ToString("n2");
                    GladiatorsList.Rows[i].Cells["Battles"].Value = _gladiators[id].battles.ToString();
                    GladiatorsList.Rows[i].Cells["Wins"].Value = _gladiators[id].wins.ToString();
                    GladiatorsList.Rows[i].Cells["Loses"].Value = _gladiators[id].loses.ToString();
                    GladiatorsList.Rows[i].Cells["Draws"].Value = _gladiators[id].draws.ToString();
                    GladiatorsList.Rows[i].Cells["WinPoints"].Value = _gladiators[id].winPoints.ToString();
                    GladiatorsList.Rows[i].Cells["MisHits"].Value = _gladiators[id].missHits.ToString();
                    break;
                }
            }

            //_gladiators[id] = tmp;
        }

        private void SetGladiatorColor(int id, Color color) {
            for (int i = 0; i < GladiatorsList.RowCount; ++i) {
                if (Convert.ToInt32(GladiatorsList.Rows[i].Cells[0].Value.ToString()) - 1 == id) {
                    GladiatorsList.Rows[i].DefaultCellStyle.BackColor = color;
                    break;
                }
            }
        }

        private void btnResetTimer_Click(object sender, EventArgs e) {
            Timer.Text = wFight.ResetTimer(Convert.ToInt32(TimeRoundDef.Value));
        }

        private void timer1_Tick(object sender, EventArgs e) {
            Timer.Text = wFight.GetLeftTime();
        }

        private void HandleTimeOver() {
            if (btnStartTimer.Text.ToUpper() == "СТОП") {
                StartStopBtnChange();
            }
        }

        private void StartStopBtnChange() {
            if (btnStartTimer.Text.ToUpper() == "СТАРТ") {
                btnStartTimer.Text = "СТОП";

                btnPlus1.Enabled = btnPlus10.Enabled = btnMinus1.Enabled = btnMinus10.Enabled = btnResetTimer.Enabled = false;

                timer1.Enabled = true;
            }
            else {
                btnStartTimer.Text = "СТАРТ";

                btnPlus1.Enabled = btnPlus10.Enabled = btnMinus1.Enabled = btnMinus10.Enabled = btnResetTimer.Enabled = true;

                timer1.Enabled = false;
            }

            Timer.Text = wFight.GetLeftTime();
        }

        private void HandleMisHit(bool isBlue, int value) {
            int side = isBlue ? 0 : 1;

            lMisHit[side].Text = value.ToString();
        }

        private void HandleFoul(bool isBlue, int value) {
            int side = isBlue ? 0 : 1;

            lFoul[side].Text = value.ToString();
        }

        private void HandleAdvantage(bool isBlue, int value) {
            int side = isBlue ? 0 : 1;

            lAdv[side].Text = value.ToString();
        }

        private void RegisterBattleEvent(Button sender, BattleEventType type) {
            BattleEventSide side = (BattleEventSide)Convert.ToInt32(sender.Tag.ToString());

            wFight.AddBattleEvent(side, type);
        }
        private void btnMisHitBlue_Click(object sender, EventArgs e) {
            RegisterBattleEvent((Button)sender, BattleEventType.MisHit);
        }

        private void btnFoulBlue_Click(object sender, EventArgs e) {
            RegisterBattleEvent((Button)sender, BattleEventType.Foul);
        }

        private void btnAdvHitBlue_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            BattleEventSide side = (BattleEventSide)Convert.ToInt32(btn.Tag.ToString());
            BattleEventSide apponent = side == BattleEventSide.Blue ? BattleEventSide.Yellow : BattleEventSide.Blue;

            wFight.AddBattleEvent(apponent, BattleEventType.MisHit);
            wFight.AddBattleEvent(side, BattleEventType.Advantage);
        }

        private void btnAdvBlue_Click(object sender, EventArgs e) {
            RegisterBattleEvent((Button)sender, BattleEventType.Advantage);
        }

        private void btnChangeColorsPlase_Click(object sender, EventArgs e) {
            wFight.ChangeColorsPlaces();
        }

        private void btnChangeColors_Click(object sender, EventArgs e) {
            if (tableJudje.Controls.GetChildIndex(tableJudjeBlue) < tableJudje.Controls.GetChildIndex(tableJudjeYellow)) {
                wFight.ChangeColorPlaces(tableJudje, tableJudjeYellow, tableJudjeBlue, 3, 1);
                wFight.ChangeColorPlaces(tableJudje, tableButtonsYellow, tableButtonsBlue, 3, 1, 1, 1);
            }
            else {
                wFight.ChangeColorPlaces(tableJudje, tableJudjeBlue, tableJudjeYellow, 3, 1);
                wFight.ChangeColorPlaces(tableJudje, tableButtonsBlue, tableButtonsYellow, 3, 1, 1, 1);
            }
        }

        private void btnLogoShow_Click(object sender, EventArgs e) {
            wFight.pBefore.Visible = false;
            wFight.pFight.Visible = false;
        }

        private void btnRevert_Click(object sender, EventArgs e) {
            wFight.RevertLastFightEvent();
        }

        private void btnWinYellow_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            BattleEventSide side = (BattleEventSide)Convert.ToInt32(btn.Tag.ToString());

            wFight.CalcVictory(side, (rbFaleev.Checked ? 0 : (rbMihas.Checked ? 1 : 2)));
        }

        private void HandlerRecalcRating(structBattlePlayer blue, structBattlePlayer yellow) {
            _gladiators[blue.id] = blue;
            _gladiators[yellow.id] = yellow;

            SetGladiatorRating(blue.id);
            SetGladiatorRating(yellow.id);

        }

        private void HadlerFightFinish(structBattlePlayer blue, structBattlePlayer yellow) {
            SetGladiatorColor(blue.id, Color.White);
            SetGladiatorColor(yellow.id, Color.White);

            SetGladiatorState(blue.id, GladiatorState.Rest);
            SetGladiatorState(yellow.id, GladiatorState.Rest);
        }

        private void btnToRest_Click(object sender, EventArgs e) {
            btnToFight.Enabled = true;
            btnToRest.Enabled = false;

            wFight.FinishFihgt();
        }

        private void btnDraw_Click(object sender, EventArgs e) {

        }

        private void btnWinJudjeYellow_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            BattleEventSide side = (BattleEventSide)Convert.ToInt32(btn.Tag.ToString());

            wFight.CalcVictory(side, (rbFaleev.Checked ? 0 : (rbMihas.Checked ? 1 : 2)), true);
        }
    }
}
