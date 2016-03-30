using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Village_Sim.Helpers {
    public class TimeSystem {

        public TimeSpan CurrentTime { get; set; }
        public float littleTime;
        public bool isRunning;
        public EventHandler eventHandler;

        public float Speed;

        Game Game;

        public TimeSystem(VillageSim game) {
            CurrentTime = new TimeSpan();
            littleTime = 0;
            isRunning = true;
            Game = game;
            Speed = 1;
            game.inputHandler.onSpaceBar += new InputHandler.InputEvent(Pause);
            game.inputHandler.onSlowDown += new InputHandler.InputEvent(SlowDown);
            game.inputHandler.onSpeedUp += new InputHandler.InputEvent(SpeedUp);

            eventHandler = new EventHandler();
            TimeEvent te = new TimeEvent(TimeSpan.FromHours(4), TimeSpan.FromHours(4), TimeEventType.Static);
            te.onActivate += new TimeEvent.Event(Spawn);
            eventHandler.AddEvent(te);
        }

        public void Spawn() {
            
        }

        public void Update(GameTime gameTime) {
            
            if (isRunning)
                littleTime += gameTime.ElapsedGameTime.Milliseconds;
            if (littleTime >= 100) {
                CurrentTime = CurrentTime.Add(TimeSpan.FromMinutes(1 * Speed));
                littleTime = 0;
            }

            eventHandler.Update(gameTime, this);
        }
        
        public void SpeedUp() {
            if (Speed < 1) {
                Speed += 0.1f;
            }
            else if (Speed < 15) {
                Speed += 1;
            }
            
        }

        public void SlowDown() {
            if (Speed > 1) {
                Speed -= 1;
            }
            else if (Speed > 0) {
                Speed -= 0.1f;
            }
        }

        public void Pause() {
            if (isRunning)
                isRunning = false;
            else {
                isRunning = true;
            }
        }

    }
}
