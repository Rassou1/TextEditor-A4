using Assignment4_CS_GUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_CS_GUI.Handlers
{
    internal class ReaderHandler
    {
        Reader reader;
        Thread[] threads;
        SharedBuffer buffer;

        public ReaderHandler(SharedBuffer buffer, int numberOfThreads)
        {
            this.buffer = buffer;
            threads = new Thread[numberOfThreads];
            reader = new Reader(buffer, this);
            CreateReaders();
        }

        public void CreateReaders()
        {
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(reader.Run);
                threads[i].Name = "Reader" + i;
                threads[i].Start();
            }
        }

        public void KillReaders()
        {
            for (int i = 0; i < threads.Length; i++)
            {
                reader.IsRunning = false;
                if ((threads[i] != null) && (threads[i].IsAlive))
                {
                    threads[i] = null;
                }
            }
        }
    }
}
