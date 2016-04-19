using NLua;
using System;

namespace Village_Sim {
    public class Script
    {
        Lua state;

        public Script()
        {

            state = new Lua ();
            state.LoadCLRPackage();
            state.DoString(@"
                                import ('Village_Sim', 'Village_Sim.Helpers') -- Load helpers
                                import ('Village_Sim', 'Village_Sim.GameStates') -- Load states
                                import ('Village_Sim', 'Village_Sim') -- Load default dir
                                
                                -- Import basic stuff
                                import('VillageSim')
                                import('GameState')
                                import('PlayingState')
                                import('Script')
                                import('Spawn')
                            ");
        }

        public void addReference(Object obj, string name)
        {
            state[name] = obj;
        }

        public void spawn()
        {
            state.DoString(@"
                  test:Spawn()
               ");
        }

    }
}
