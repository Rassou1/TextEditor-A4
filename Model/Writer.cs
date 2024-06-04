﻿using Assignment4_CS_GUI.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_CS_GUI.Model
{
    internal class Writer
    {
        private SharedBuffer buffer;
        private WriterHandler handler;
        
        private bool isRunning = true;
        public bool IsRunning { get { return isRunning; } set { isRunning = value; } }

        public Writer(SharedBuffer buffer,  WriterHandler handler)
        {
            this.handler = handler;
            this.buffer = buffer;
        }

        public void Run()
        {
            while (isRunning)
            {
                try
                {
                    lock (handler)
                    {
                        string toWrite = handler.GetStringFromList();
                        buffer.Write(toWrite);
                    }
                }
                catch(Exception)
                {
                    isRunning = false;
                }
            }

            buffer.SignalClose();
        }
    }
}
