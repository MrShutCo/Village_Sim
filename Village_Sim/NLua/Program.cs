using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace NLua {
    class Program {
        static void Main(string[] args) {
            LuaTester l = new LuaTester();
        }
    }

    public class OtherThing {
        public OtherThing() {

        }

        public void OtherFunction(int i, string s) {
            Console.WriteLine("Number: {0}, Word: {1}", i, s);
        }
    }

    public class LuaTester {

        Lua state;

        public LuaTester() {
            OtherThing other = new OtherThing();
            state = new Lua();
            state.RegisterFunction("Stuff", this, this.GetType().GetMethod("DoStuff"));
            state.RegisterFunction("Other", other, other.GetType().GetMethod("OtherFunction"));
            state.DoString("Stuff('hello')");
            state.DoString("Other(4,'hello')");
            Console.ReadLine();
        }

        public void DoStuff(string hello) {
            Console.WriteLine("Word said: {0}", hello);
        }

    }

}
