using Assignment4_CS_GUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_CS_GUI.Handlers
{
    internal class WriterHandler
    {
        Writer writer;
        SharedBuffer buffer;

        public Thread[] threads;
        string[] stringArray;
        
        int currentIndex = 0;

        object lockObj = new object();

        public WriterHandler(string[] stringArray, SharedBuffer buffer, int numberOfThreads)
        {
            this.stringArray = stringArray;
            this.buffer = buffer;

            writer = new Writer(buffer, this);
            threads = new Thread[numberOfThreads];

            CreateWriters();
        }

        public string GetStringFromList()
        {
            lock(lockObj)
            {
                string returnString = null;
                if(currentIndex < stringArray.Length)
                {
                    returnString = stringArray[currentIndex];
                    currentIndex++;
                }
                return returnString;
            }
        }

        public void CreateWriters()
        {
            for(int i = 0; i< threads.Length; i++) 
            {
                threads[i] = new Thread(writer.Run);
                threads[i].Name = "Writer" + i;
                threads[i].Start();
            }
        }

        public void KillWriters()
        {
            for (int i = 0; i < threads.Length; i++)
            {
                writer.IsRunning = false;
                if ((threads[i]!= null) && (threads[i].IsAlive))
                {
                    threads[i] = null;
                }
            }
        }


    }
}
