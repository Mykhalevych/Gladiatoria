using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Gladiatoria {
    public partial class Fight : Form {
        private const string _flagFolder = "../../Images/CountriesFlags/";
        private const string _logosClubs = "../../Images/ClubsLogos/";
        private const string _fightersPhoto = "../../Images/FightersPhoto/";
        private const string _noPhotoPic = "no_photo";

        private Label[] lName;
        private Label[] lRating;
        private Label[] lAge;
        private Label[] lClub;
        private Label[] lWinPoints;
        private Label[] lHits;
        private Label[] lFouls;
        private Label[] lWins;
        private Label[] lLoss;
        private Label[] lDraw;
        private Label[] lTotal;
        private PictureBox[] picPlayer;
        private PictureBox[] picCountry;
        private PictureBox[] picLogo;

        private Label[] lFNextName;
        private Label[] lFNextRating;
        private Label[] lFNextAge;
        private PictureBox[] picFNext;

        private Label[] lFightName;
        private Label[] lFightRating;
        private Label[] lFightAge;
        private Label[] lFightAdv;
        private Label[] lFightMH;
        private Label[] lFightFoul;
        private PictureBox[] picFight;

        private Object _gladiatorBluePrep;
        private Object _gladiatorYellowPrep;

        private Object _gladiatorBlueFight;
        private Object _gladiatorYellowFight;

        private FightStat _fightStat = new FightStat();
        public Fight() {
            InitializeComponent();

            lName = new Label[2] { lNameB, lNameY };
            lRating = new Label[2] { lRatingB, lRatingY };
            lAge = new Label[2] { lAgeB, lAgeY };
            lClub = new Label[2] { lClubB, lClubY };
            lWinPoints = new Label[2] { lWinPointsB, lWinPointsY };
            lHits = new Label[2] { lHitsB, lHitsY };
            lFouls = new Label[2] { lFoulsB, lFoulsY };
            lWins = new Label[2] { lWinsB, lWinsY };
            lLoss = new Label[2] { lLossB, lLossY };
            lDraw = new Label[2] { lDrawB, lDrawY };
            lTotal = new Label[2] { lTotalB, lTotalY };
            picCountry = new PictureBox[2] { picCountryB, picCountryY };
            picPlayer = new PictureBox[2] { picPlayerB, picPlayerY };
            picLogo = new PictureBox[2] { picLogoB, picLogoY };

            lFNextName = new Label[2] { lFNextNameB, lFNextNameY };
            lFNextRating = new Label[2] { lFNextRatingB, lFNextRatingY };
            lFNextAge = new Label[2] { lFNextAgeB, lFNextAgeY };
            picFNext = new PictureBox[2] { picFNextB, picFNextY };

            lFightName = new Label[2] { lFightNameB, lFightNameY };
            lFightRating = new Label[2] { lFightRatingB, lFightRatingY };
            lFightAge = new Label[2] { lFightAgeB, lFightAgeY };
            lFightAdv = new Label[2] { lFightAdvB, lFightAdvY };
            lFightMH = new Label[2] { lFightMHB, lFightMHY };
            lFightFoul = new Label[2] { lFightFoulB, lFightFoulY };
            picFight = new PictureBox[2] { picFightB, picFightY };

            for (int side = 0; side < 2; ++side) {
                lName[side].Text = lFNextName[side].Text = lRating[side].Text = lFNextRating[side].Text = lAge[side].Text = lFNextAge[side].Text = "";
                lClub[side].Text = lWinPoints[side].Text = lHits[side].Text = lFouls[side].Text = lWins[side].Text = lLoss[side].Text = lDraw[side].Text = lTotal[side].Text = "";
                picCountry[side].Image = picLogo[side].Image = null;
                picPlayer[side].Image = picFNext[side].Image = null;

                lFightName[side].Text = lFightRating[side].Text = lFightAge[side].Text = lFightAdv[side].Text = lFightMH[side].Text = lFightFoul[side].Text = "";
                picFight[side].Image = null;
            }

            lTimer.Text = _fightStat.GetLeftTime();
            lResult.Text = "";

            EventManager.OnMisHit += HandleMisHit;
            EventManager.OnFoul += HandleFoul;
            EventManager.OnAdvantage += HandleAdvantage;
        }

        public void PrepearingBlue(ref Main.structBattlePlayer BlueGladiator) {
            _gladiatorBluePrep = BlueGladiator;
            PrepearingGladiator(ref BlueGladiator, true);
        }

        public void PrepearingYellow(ref Main.structBattlePlayer YellowGladiator) {
            _gladiatorYellowPrep = YellowGladiator;
            PrepearingGladiator(ref YellowGladiator, false);
        }

        private int GetAge(DateTime birthDate) {
            return DateTime.Now.Year - birthDate.Year + ((DateTime.Now.Month < birthDate.Month ||
                    (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day)) ? -1 : 0);
        }
        private void PrepearingGladiator(ref Main.structBattlePlayer Gladiator, bool isBlue) {
            int side = isBlue ? 0 : 1;

            lName[side].Text = lFNextName[side].Text = $"{Gladiator.name} {Gladiator.familyName}";
            lRating[side].Text = lFNextRating[side].Text = Gladiator.rating.ToString("n2");
            lAge[side].Text = lFNextAge[side].Text = GetAge(Convert.ToDateTime(Gladiator.birthDate)).ToString();

            lClub[side].Text = Gladiator.club;
            lWinPoints[side].Text = Gladiator.winPoints.ToString();
            lHits[side].Text = Gladiator.missHits.ToString();
            lFouls[side].Text = Gladiator.fouls.ToString();
            lWins[side].Text = Gladiator.wins.ToString();
            lLoss[side].Text = Gladiator.loses.ToString();
            lDraw[side].Text = Gladiator.draws.ToString();
            lTotal[side].Text = Gladiator.battles.ToString();

            string pathCountry = _flagFolder + Gladiator.country.ToLower() + ".png";
            if (File.Exists(pathCountry)) {
                picCountry[side].Image = Image.FromFile(pathCountry);
            }

            string pathLogo = _logosClubs + Gladiator.club.ToLower() + ".png";
            if (File.Exists(pathLogo)) {
                picLogo[side].Image = Image.FromFile(pathLogo);
            }

            string pathPhoto = (Gladiator.photo != null) ? Gladiator.photo : (_fightersPhoto + _noPhotoPic + ".png");
            if (File.Exists(pathPhoto)) {
                picPlayer[side].Image = picFNext[side].Image = Image.FromFile(pathPhoto);
            }
        }

        public bool IsBluePrepareFree() {
            return _gladiatorBluePrep == null;
        }

        public bool IsYellowPrepareFree() {
            return _gladiatorYellowPrep == null;
        }

        public bool BackToRest(int id) {
            return CheckPrepGladiator(ref _gladiatorBluePrep, id, true) || CheckPrepGladiator(ref _gladiatorYellowPrep, id, false);
        }

        private bool CheckPrepGladiator(ref Object gladiator, int id, bool isBlue) {
            bool res = false;
            int side = isBlue ? 0 : 1;

            if (gladiator != null) {
                Main.structBattlePlayer tmp = (Main.structBattlePlayer)gladiator;
                if (tmp.id == id) {
                    res = true;

                    lName[side].Text = lFNextName[side].Text = lRating[side].Text = lFNextRating[side].Text = lAge[side].Text = lFNextAge[side].Text = "";
                    lClub[side].Text = lWinPoints[side].Text = lHits[side].Text = lFouls[side].Text = lWins[side].Text = lLoss[side].Text = lDraw[side].Text = lTotal[side].Text = "";
                    picCountry[side].Image = picLogo[side].Image = null;
                    picPlayer[side].Image = picFNext[side].Image = null;

                    gladiator = null;
                }
            }

            return res;
        }

        public bool ToHort(int sec) {
            bool res = false;

            if (_gladiatorBluePrep != null && _gladiatorYellowPrep != null) {

                PrepToFight(true);
                PrepToFight(false);

                _gladiatorBlueFight = _gladiatorBluePrep;
                _gladiatorYellowFight = _gladiatorYellowPrep;

                _gladiatorBluePrep = null;
                _gladiatorYellowPrep = null;

                _fightStat.ResetStat(sec);
                _fightStat.GetLeftTime();

                res = true;
            }

            lResult.Text = "";

            return res;
        }

        private void PrepToFight(bool isBlue) {
            int side = isBlue ? 1 : 0;

            lFightName[side].Text = lName[side].Text;
            lFightRating[side].Text = lRating[side].Text;
            lFightAge[side].Text = lAge[side].Text;

            lFightAdv[side].Text = "0";
            lFightMH[side].Text = "0";
            lFightFoul[side].Text = "0";

            picFight[side].Image = picPlayer[side].Image;

            // Clear next info
            lName[side].Text = lFNextName[side].Text = lRating[side].Text = lFNextRating[side].Text = lAge[side].Text = lFNextAge[side].Text = "";
            lClub[side].Text = lWinPoints[side].Text = lHits[side].Text = lFouls[side].Text = lWins[side].Text = lLoss[side].Text = lDraw[side].Text = lTotal[side].Text = "";
            picCountry[side].Image = picLogo[side].Image = null;
            picPlayer[side].Image = picFNext[side].Image = null;
        }

        public string GetLeftTime() {
            return lTimer.Text = _fightStat.GetLeftTime();
        }

        public string CorrectionTimer(int sec) {
            return lTimer.Text = _fightStat.CorrectionTimer(sec);
        }

        public string ResetTimer(int sec) {
            return lTimer.Text = _fightStat.ResetTimer(sec);
        }

        public void StartStopTimer() {
            _fightStat.StartStopTimer();
        }

        public int GetGladiatorIdBlue() {
            return GetGladiatorId(_gladiatorBlueFight);
        }

        public int GetGladiatorIdYellow() {
            return GetGladiatorId(_gladiatorYellowFight);
        }

        public int GetGladiatorId(Object gladiator) {
            int res = -1;
            if (gladiator != null) {
                var tmp = (Main.structBattlePlayer)gladiator;
                res = tmp.id;
            }

            return res;
        }

        private void HandleMisHit(bool isBlue, int value) {
            int side = isBlue ? 0 : 1;

            lFightMH[side].Text = value.ToString();
        }

        private void HandleFoul(bool isBlue, int value) {
            int side = isBlue ? 0 : 1;

            lFightFoul[side].Text = value.ToString();
        }

        private void HandleAdvantage(bool isBlue, int value) {
            int side = isBlue ? 0 : 1;

            lFightAdv[side].Text = value.ToString();
        }

        public void AddBattleEvent(BattleEventSide side, BattleEventType type) {
            _fightStat.AddBattleEvent(side, type);
        }

        public void ChangeColorsPlaces() {
            if (tableGladiators.Controls.GetChildIndex(pFightBlue) == 0) {
                ChangeColorPlaces(tableGladiators, pFightYellow, pFightBlue);
                ChangeColorPlaces(tableNext, pNextYellow, pNextBlue);
                ChangeColorPlaces(tableBefore, tBeforeY, tBeforeB, 1, 3);
            }
            else {
                ChangeColorPlaces(tableGladiators, pFightBlue, pFightYellow);
                ChangeColorPlaces(tableNext, pNextBlue, pNextYellow);
                ChangeColorPlaces(tableBefore, tBeforeB, tBeforeY, 1, 3);
            }
        }

        public void ChangeColorPlaces(TableLayoutPanel panel, Control left, Control right, int lc = 0, int rc = 1, int lr = 0, int rr = 0) {
            panel.Controls.Remove(left);
            panel.Controls.Remove(right);

            panel.Controls.Add(left, lc, lr);
            panel.Controls.Add(right, rc, rr);
        }

        public void RevertLastFightEvent() {
            _fightStat.RevertEvent();
        }

        public void CalcVictory(BattleEventSide side, int methodType, bool isJudjeDecision = false) {
            Main.structBattlePlayer blue = (Main.structBattlePlayer)_gladiatorBlueFight;
            Main.structBattlePlayer yellow = (Main.structBattlePlayer)_gladiatorYellowFight;

            if (side == BattleEventSide.Blue) {
                CalcRating(ref blue, ref yellow, side, methodType, isJudjeDecision);
            }
            else if (side == BattleEventSide.Yellow) {
                CalcRating(ref yellow, ref blue, side, methodType, isJudjeDecision);
            }
            else {
                CalcRatingDraw(ref blue, ref yellow, methodType);
            }

            lRatingB.Text = blue.rating.ToString("n2");
            lRatingY.Text = yellow.rating.ToString("n2");

            EventManager.EventRatingRecalc(ref blue, ref yellow);
        }

        private void CalcRating(ref Main.structBattlePlayer winner, ref Main.structBattlePlayer loser, BattleEventSide side, int methodType, bool isJudjeDecision) {
            winner.battles += 1;
            loser.battles += 1;
            winner.wins += 1;
            loser.loses += 1;

            int wMisHit = _fightStat.GetMisHits(side == BattleEventSide.Blue);
            int lMisHit = _fightStat.GetMisHits(side != BattleEventSide.Blue);
            int wWP = _fightStat.GetAdvantage(side == BattleEventSide.Blue);

            double wbRating = 0;
            double lbRating = 0;

            switch (methodType) {
                case 0:
                    CalcRatingFirstMethod((double)wMisHit, (double)lMisHit, (double)wWP, ref wbRating, ref lbRating);
                    double wrOld = winner.rating;
                    double lrOld = loser.rating;
                    winner.winPoints += (int)wWP;
                    winner.missHits += (int)wMisHit;
                    loser.missHits += (int)lMisHit;

                    winner.rating = winner.winPoints / (winner.missHits == 0 ? 1.0 : winner.missHits);
                    loser.rating = loser.winPoints / (loser.missHits == 0 ? 1.0 : loser.missHits);
                    wbRating = winner.rating - wrOld;
                    lbRating = loser.rating - lrOld;
                    break;

                case 1:
                    CalcRatingSecondMethod((double)wMisHit, (double)lMisHit, (double)wWP, ref wbRating, ref lbRating);
                    winner.rating += wbRating;
                    loser.rating += lbRating;
                    break;

                case 2:
                    CalcRatingTherdMethod((double)wMisHit, (double)lMisHit, (double)wWP, ref wbRating, ref lbRating);
                    winner.rating += wbRating;
                    loser.rating += lbRating;
                    break;
            }


            lResult.Text = $"Перемога {winner.name} {winner.secondName} ({(side == BattleEventSide.Blue ? "блакитний" : "жовтий")} боєць).{(isJudjeDecision ? " За рішенням суддів." : "")}\nБали рейтингу за перемогу: {wbRating.ToString("n2")}\nБали рейтингу за поразку: {lbRating.ToString("n2")}";
        }

        private void CalcRatingDraw(ref Main.structBattlePlayer blue, ref Main.structBattlePlayer yellow, int methodType) {
            blue.battles += 1;
            yellow.battles += 1;
            blue.draws += 1;
            yellow.draws += 1;

            int bMisHit = _fightStat.GetMisHits(true);
            int yMisHit = _fightStat.GetMisHits(false);
            int bWP = _fightStat.GetAdvantage(true);
            int yWP = _fightStat.GetAdvantage(false);

            double bbRating = 0;
            double ybRating = 0;

            switch (methodType) {
                case 0:
                    CalcRatingDrawFirstMethod((double)bMisHit, (double)yMisHit, (double)bWP, (double)yWP, ref bbRating, ref ybRating);
                    break;

                case 1:
                    CalcRatingDrawSecondMethod((double)bMisHit, (double)yMisHit, (double)bWP, (double)yWP, ref bbRating, ref ybRating);
                    break;

                case 2:
                    CalcRatingDrawTherdMethod((double)bMisHit, (double)yMisHit, (double)bWP, (double)yWP, ref bbRating, ref ybRating);
                    break;
            }

            blue.rating += bbRating;
            yellow.rating += ybRating;
        }

        private void CalcRatingFirstMethod(double wMisHit, double lMisHit, double wWP, ref double wbRating, ref double lbRating) {
            wbRating = wWP / ((wMisHit == 0) ? 1.0 : wMisHit);
            lbRating = -1;
        }

        private void CalcRatingDrawFirstMethod(double bMisHit, double yMisHit, double bWP, double yWP, ref double bbRating, ref double ybRating) {

        }

        private void CalcRatingSecondMethod(double wMisHit, double lMisHit, double wWP, ref double wbRating, ref double lbRating) {
            wbRating = wWP - (wMisHit * 0.1);
            lbRating = -1 - (lMisHit * 0.1);
        }
        private void CalcRatingDrawSecondMethod(double bMisHit, double yMisHit, double bWP, double yWP, ref double bbRating, ref double ybRating) {
            bbRating = bWP - (bMisHit * 0.1);
            ybRating = yWP - (yMisHit * 0.1);
        }

        private void CalcRatingTherdMethod(double wMisHit, double lMisHit, double wWP, ref double wbRating, ref double lbRating) {
            wbRating = wWP + ((lMisHit - wMisHit) * 0.1);
            lbRating = -1 + ((wMisHit - lMisHit) * 0.1);
        }
        private void CalcRatingDrawTherdMethod(double bMisHit, double yMisHit, double bWP, double yWP, ref double bbRating, ref double ybRating) {
            bbRating = bWP + ((yMisHit - bMisHit) * 0.1);
            ybRating = yWP + ((bMisHit - yMisHit) * 0.1);
        }

        public void FinishFihgt() {
            Main.structBattlePlayer blue = (Main.structBattlePlayer)_gladiatorBlueFight;
            Main.structBattlePlayer yellow = (Main.structBattlePlayer)_gladiatorYellowFight;

            EventManager.EventFightFinish(ref blue, ref yellow);

            for (int side = 0; side < 2; ++side) {
                lFightName[side].Text = lFightRating[side].Text = lFightAge[side].Text = lFightAdv[side].Text = lFightMH[side].Text = lFightFoul[side].Text = "";
                picFight[side].Image = null;
            }

            lTimer.Text = _fightStat.GetLeftTime();
            lResult.Text = "";

            _gladiatorBlueFight = null;
            _gladiatorYellowFight = null;
        }
    }
}
