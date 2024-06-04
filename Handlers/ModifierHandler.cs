using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment4_CS_GUI.Model;

namespace Assignment4_CS_GUI.Handlers
{
    internal class ModifierHandler
    {
        Modifier modifier;
        Thread[] threads;
        SharedBuffer buffer;

        public ModifierHandler(SharedBuffer buffer, int numberOfThreads, string stringToFind, string stringToReplace)
        {
            this.buffer = buffer;
            threads = new Thread[numberOfThreads];
            modifier = new Modifier(buffer, stringToFind, stringToReplace);
            CreateModifier(stringToFind, stringToReplace);
        }

        public void CreateModifier(string stringToFind, string stringToReplace)
        {
            for(int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(modifier.Run());
                threads[i].Name = "Modifier" + i;
                threads[i].Start();
            }
        }

        public void KillModifiers()
        {
            for (int i = 0; i < threads.Length; i++)
            {
                modifier.IsRunning = false;
                if ((threads[i] != null) && (threads[i].IsAlive))
                {
                    threads[i] = null;
                }
            }
        }
    }
}
