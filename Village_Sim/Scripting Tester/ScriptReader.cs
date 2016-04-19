using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace Scripting_Tester {
    public class ScriptReader {

        public Lua Reader;
        
        public ScriptReader() {
            Reader = new Lua();
            Reader.LoadCLRPackage();
            //Reader.DoString(@"import();");
        } 

        public void RegisterFunction() {

        }

    }
}
