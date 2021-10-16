using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Gladiatoria {
    struct GladiatorStat {
        public int advantage;
        public int misHits;
        public int fouls;
        public void Reset() {
            advantage = misHits = fouls = 0;
        }
    }

    public enum BattleEventType {
        MisHit,
        Foul,
        Advantage,
    }
    public enum BattleEventSide {
        Blue,
        Yellow,
        Both
    }
    struct BattleEvent {
        public int time;
        public BattleEventSide side;
        public BattleEventType type;
        public bool overtime;

        public BattleEvent(BattleEventSide side, BattleEventType type) {
            this.side = side;
            this.type = type;
            this.time = 0;
            this.overtime = false;
        } 
    }
    class FightStat {
        private int _leftTime; // in msec
        private int _elapsedTime;
        private Stopwatch clock = new Stopwatch();
        private bool isOvertime;

        private GladiatorStat _blueGladiator;
        private GladiatorStat _yellowGladiator;

        private List<BattleEvent> BattleStat = new List<BattleEvent>();

        public void ResetStat(int sec) {
            _leftTime = sec * 1000;
            _elapsedTime = 0;

            isOvertime = false;

            BattleStat.Clear();

            _blueGladiator.Reset();
            _yellowGladiator.Reset();
        }

        public string CorrectionTimer(int sec) {
            _leftTime += sec * 1000;
            _elapsedTime -= sec * 1000;


            return GetLeftTime();
        }

        public string ResetTimer(int sec) {
            _leftTime = sec * 1000;
            _elapsedTime = 0;

            return GetLeftTime();
        }

        public string GetLeftTime() {
            int timer = clock.IsRunning ? (_leftTime - Convert.ToInt32(clock.Elapsed.TotalMilliseconds)) : _leftTime;
            if (timer <= 0) {
                timer = 0;
                clock.Stop();
                EventManager.HandleTimeOver();
            }

            int sec = (timer / 1000) % 60;
            int min = timer / 60000;

            string time = String.Format("{0:00}:{1:00}", min, sec); // $"{min.ToString()}:{((sec < 10) ? $"0{sec.ToString()}" : sec.ToString())}";

            return time;
        }

        private int AddParameter(ref int param) {
            return ++param;
        }
        private int RevertParameter(ref int param) {
            return --param;
        }

        public int AddAdvantage(bool isBlue) {
            return (isBlue ? AddParameter(ref _blueGladiator.advantage) : AddParameter(ref _yellowGladiator.advantage));
        }
        public int RevertAdvantage(bool isBlue) {
            return (isBlue ? RevertParameter(ref _blueGladiator.advantage) : RevertParameter(ref _yellowGladiator.advantage));
        }

        public int GetAdvantage(bool isBlue) {
            return (isBlue ? _blueGladiator.advantage : _yellowGladiator.advantage);
        }

        public int AddMisHits(bool isBlue) {
            return (isBlue ? AddParameter(ref _blueGladiator.misHits) : AddParameter(ref _yellowGladiator.misHits));
        }
        public int RevertMisHits(bool isBlue) {
            return (isBlue ? RevertParameter(ref _blueGladiator.misHits) : RevertParameter(ref _yellowGladiator.misHits));
        }
        public int GetMisHits(bool isBlue) {
            return (isBlue ? _blueGladiator.misHits : _yellowGladiator.misHits);
        }

        public int AddFoul(bool isBlue) {
            return (isBlue ? AddParameter(ref _blueGladiator.fouls) : AddParameter(ref _yellowGladiator.fouls));
        }
        public int RevertFoul(bool isBlue) {
            return (isBlue ? RevertParameter(ref _blueGladiator.fouls) : RevertParameter(ref _yellowGladiator.fouls));
        }
        public int GetFouls(bool isBlue) {
            return (isBlue ? _blueGladiator.fouls : _yellowGladiator.fouls);
        }

        public void StartStopTimer() {
            if (clock.IsRunning) {
                clock.Stop();

                int time = Convert.ToInt32(clock.Elapsed.TotalMilliseconds);

                if (time >= _leftTime) {
                    _elapsedTime += _leftTime;
                    _leftTime = 0;
                }
                else {
                    _elapsedTime += time;
                    _leftTime -= time;
                }
            }
            else if (_leftTime > 0) {
                clock.Reset();
                clock.Start();
            }
            else {
                EventManager.HandleTimeOver();
            }
        }

        public void AddBattleEvent(BattleEventSide side, BattleEventType type) {
            BattleEvent battleEvent = new BattleEvent (side, type);
            battleEvent.time = clock.IsRunning ? (_elapsedTime + Convert.ToInt32(clock.Elapsed.TotalMilliseconds)) : _elapsedTime;
            battleEvent.overtime = isOvertime;

            BattleStat.Add(battleEvent);

            if (side != BattleEventSide.Yellow) {
                MakeEvent(type, true);
            }

            if (side != BattleEventSide.Blue) {
                MakeEvent(type, false);
            }
        }

        private void MakeEvent(BattleEventType type, bool isBlue) {
            switch (type) {
                case BattleEventType.MisHit:
                    EventManager.EventMisHit(isBlue, AddMisHits(isBlue));
                    break;

                case BattleEventType.Foul:
                    EventManager.EventFoul(isBlue, AddFoul(isBlue));
                    break;

                case BattleEventType.Advantage:
                    EventManager.EventAdvantage(isBlue, AddAdvantage(isBlue));
                    break;
            }
        }

        private void RevertEvent(BattleEventType type, bool isBlue) {
            switch (type) {
                case BattleEventType.MisHit:
                    EventManager.EventMisHit(isBlue, RevertMisHits(isBlue));
                    break;

                case BattleEventType.Foul:
                    EventManager.EventFoul(isBlue, RevertFoul(isBlue));
                    break;

                case BattleEventType.Advantage:
                    EventManager.EventAdvantage(isBlue, RevertAdvantage(isBlue));
                    break;
            }
        }

        public void RevertEvent() {
            if (BattleStat.Count == 0) return;

            BattleEvent lastEvent = BattleStat.Last();

            if (lastEvent.side != BattleEventSide.Yellow) {
                RevertEvent(lastEvent.type, true);
            }

            if (lastEvent.side != BattleEventSide.Blue) {
                RevertEvent(lastEvent.type, false);
            }

            BattleStat.RemoveAt(BattleStat.Count - 1);
        }
    }
}
