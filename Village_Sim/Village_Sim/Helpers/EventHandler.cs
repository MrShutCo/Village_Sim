using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village_Sim.Helpers {
    public class EventHandler {

        public List<TimeEvent> TimeEvents { get; set; }

        public EventHandler() {
            TimeEvents = new List<TimeEvent>();
        }

        ///Here we can actually add functionality to do the setup stuff. 
        /// Right now, we can add two types of events
        /// Static: Happens once in N amount of time
        /// Repeating: Happens every N timeSpan, starting from when it was created (Maybe change this)

        //Occurs every timeSpan, and start happens x-time from now
        public void AddEvent(TimeEvent te) {
            TimeEvents.Add(te);
        }

        public void Update(GameTime gameTime, TimeSystem ts) {
            foreach(TimeEvent te in TimeEvents) {
                te.Update(ts.CurrentTime);
            }
        }

    }
}
