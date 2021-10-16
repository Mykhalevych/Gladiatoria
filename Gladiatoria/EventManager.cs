using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiatoria {
    public class EventManager {
        public delegate void BattleTimeOver();
        public static event BattleTimeOver OnTimeOver;

        public static void HandleTimeOver() {
            OnTimeOver?.Invoke();
        }

        public delegate void ChangeParameter(bool isBlue, int value);

        public static event ChangeParameter OnMisHit;
        public static void EventMisHit(bool isBlue, int value) {
            OnMisHit?.Invoke(isBlue, value);
        }

        public static event ChangeParameter OnFoul;
        public static void EventFoul(bool isBlue, int value) {
            OnFoul?.Invoke(isBlue, value);
        }

        public static event ChangeParameter OnAdvantage;
        public static void EventAdvantage(bool isBlue, int value) {
            OnAdvantage?.Invoke(isBlue, value);
        }

        public delegate void RatingRecalc(Main.structBattlePlayer blue, Main.structBattlePlayer yellow);
        public static event RatingRecalc OnRatingRecalc;
        public static void EventRatingRecalc(ref Main.structBattlePlayer blue, ref Main.structBattlePlayer yellow) {
            OnRatingRecalc?.Invoke(blue, yellow);
        }

        public static event RatingRecalc OnFightFinish;
        public static void EventFightFinish(ref Main.structBattlePlayer blue, ref Main.structBattlePlayer yellow) {
            OnFightFinish?.Invoke(blue, yellow);
        }
    }
}
