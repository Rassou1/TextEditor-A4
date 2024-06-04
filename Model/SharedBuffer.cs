using Assignment4_CS_GUI.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment4_CS_GUI.Model
{
    internal class SharedBuffer
    {
        int readerPos = 0;
        int writerPos = 0;
        int modifierPos = 0;

        private BufferItem[] buffer;
        private Controller controller;

        object lockObj = new object();

        public SharedBuffer(int bufferSize, Controller controller)
        {
            this.controller = controller;
            buffer = new BufferItem[bufferSize];
            InitializeBuffer();
        }

        public void InitializeBuffer()
        {
            for(int i= 0; i < buffer.Length; i++)
            {
                buffer[i] = new BufferItem();
            }
        }

        public void Read(string s)
        {
            Monitor.Enter(lockObj);

            while (buffer[readerPos].Status != BufferStatus.Checked)
            {
                Monitor.Wait(lockObj);
            }

            controller.AddToDestination(buffer[readerPos].TextString);

            string text = $"{Thread.CurrentThread.Name} - read: {buffer[readerPos]}"; //finish this line
            controller.AddToLog(text);

                buffer[readerPos].Status = BufferStatus.Empty;
               
                readerPos = readerPos + 1 % buffer.Length;
            
            
            Monitor.PulseAll(lockObj);
            Monitor.Exit(lockObj);
        }

        public void Modify(string stringToFind, string stringToReplace)
        {
            Monitor.Enter(lockObj);
            while (buffer[modifierPos].Status != BufferStatus.Empty)
            {
                Monitor.Wait(lockObj);
            }

            string bufferString = buffer[modifierPos].TextString;

            while(bufferString.Contains(stringToFind) && !stringToFind.Equals(stringToReplace))
            {
                bufferString = bufferString.Replace(stringToFind, stringToReplace);

                string s = $"{Thread.CurrentThread.Name} - modified: {buffer[modifierPos]}"; //finish this line
                controller.AddToLog(s);
            }
            buffer[modifierPos].TextString = bufferString;
            buffer[modifierPos].Status = BufferStatus.Checked;
            modifierPos = modifierPos+1%buffer.Length;
            Monitor.PulseAll(lockObj);
            Monitor.Exit(lockObj);
        }

        public void Write(string s)
        {
            Monitor.Enter(lockObj);

            while (buffer[writerPos].Status != BufferStatus.Empty)
            {
                Monitor.Wait(lockObj);
            }
            if(s != null)
            {
                buffer[writerPos].TextString = s;
                buffer[writerPos].Status = BufferStatus.New;
                string text = $"{Thread.CurrentThread.Name} - wrote: {buffer[writerPos]}"; //finish this line
                controller.AddToLog(text);
                writerPos = writerPos + 1 % buffer.Length;
            }
            else
            {
                Thread.CurrentThread.Interrupt();
            }
            Monitor.PulseAll(lockObj);
            Monitor.Exit(lockObj);
        }

        public void SignalClose()
        {
            controller.StopCurrentThreads();
        }


    }
}
