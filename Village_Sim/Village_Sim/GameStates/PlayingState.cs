using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Village_Sim.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Village_Sim.Sprites;

namespace Village_Sim.GameStates {
    public class PlayingState : GameState {

        TimeSystem timeSystem;
        Spawn s;

        public PlayingState(VillageSim game)
            :base(game){
            timeSystem = new TimeSystem(game);
            s = new Spawn(game);
            TimeEvent spawn = new TimeEvent(TimeSpan.FromHours(0), TimeSpan.FromDays(1), TimeEventType.Repeating);
            spawn.onActivate += new TimeEvent.Event(Spawn);
            timeSystem.eventHandler.AddEvent(spawn);
        }

        public void Spawn() {
            s.SpawnVillagers(10);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Game.background, new Vector2(0, 0), Color.White);
            foreach (Villager v in s.villagers) {
                v.Draw(spriteBatch);
            }
            
            spriteBatch.DrawString(Game.font, "Current Time: " + timeSystem.CurrentTime + "    Speed: " + Math.Round(timeSystem.Speed, 1), new Vector2(10, 13), Color.Black);
            if (!timeSystem.isRunning) {
                spriteBatch.DrawString(Game.font, "PAUSED", new Vector2(100, 35), Color.Red);
            }

            
        }

        public override void Update(GameTime gameTime) {
            Game.inputHandler.Update();
            timeSystem.Update(gameTime);
        }
    }
}
