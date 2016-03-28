using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village_Sim.Helpers { 

    public enum TimeEventType {
        Static,
        Repeating
    }

    public class TimeEvent {

        public TimeSpan StartTime { get; set; }
        public TimeSpan Frequency;
        public TimeSpan Duration { get { return Duration.Duration(); } set { } }
        //Means if we are checking for it
        public bool isActive;
        public TimeEventType EventType { get; set; }

        public delegate void Event();

        public event Event onActivate = delegate { };

        ///Right, so we want a few types of events
        /// 1: Event that happens only once, at a certain time, instantly
        /// 2: Event that happens periodically
        /// 3: Event that happens for a certain time length
        /// 

       //Constructor for one time event
        public TimeEvent(TimeSpan start, TimeSpan duration, TimeEventType tet) {
            StartTime = start;
            Duration = duration;
            EventType = tet;
            isActive = true;
            if (EventType == TimeEventType.Repeating) {
                Frequency = duration;
            }
            //EventType = eventType;
        }

        public void Update(TimeSpan currentTime) {
            if (currentTime >= StartTime) {
                if (isActive) onActivate();
                //If we want to repeat, then we simply reset said timer
                if (EventType == TimeEventType.Repeating) {
                    StartTime = currentTime + Frequency;
                } else if (EventType == TimeEventType.Static) {
                    isActive = false;
                }
            }
        }

    }
}
