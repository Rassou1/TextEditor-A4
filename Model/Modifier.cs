using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Assignment4_CS_GUI.Handlers;

namespace Assignment4_CS_GUI.Model
{
    internal class Modifier
    {
        SharedBuffer buffer;
        ModifierHandler handler;

        bool isRunning = true;

        string stringToFind;
        string stringToReplace;

        public bool IsRunning { get { return isRunning; } set { isRunning = value; } }

        public Modifier(SharedBuffer buffer, string stringToFind, string stringToReplace, ModifierHandler handler)
        {
            this.buffer = buffer;
            this.stringToFind = stringToFind; 
            this.stringToReplace = stringToReplace;
            this.handler = handler;
        }
        public void Run()
        {
            while (isRunning)
            {
                try
                {
                    lock (handler)
                    {
                        buffer.Modify(stringToFind, stringToReplace);
                    }
                }
                catch (Exception ex)
                {
                    isRunning = false;
                }
            }
        }
    }
}
