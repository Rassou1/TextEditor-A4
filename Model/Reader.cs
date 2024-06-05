using Assignment4_CS_GUI.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_CS_GUI.Model
{
    internal class Reader
    {
        SharedBuffer buffer;
        ReaderHandler handler;
        bool isRunning = true;
        public bool IsRunning { get { return isRunning; } set { isRunning = value; } }

        public Reader(SharedBuffer buffer, ReaderHandler handler)
        {
            this.buffer = buffer;
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
                        buffer.Read();
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
