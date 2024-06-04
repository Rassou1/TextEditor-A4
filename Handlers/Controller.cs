using Assignment4_CS_GUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_CS_GUI.Handlers
{
    internal class Controller
    {
         SharedBuffer buffer;
        const int bufferSize = 20;
        ReaderHandler readerHandler;
        ModifierHandler modifierHandler;
        WriterHandler writerHandler;

         RichTextBox richTextDestination;
        ListBox listLog;

        public Controller(RichTextBox richTextDestination, ListBox listLog)
        {
            this.richTextDestination = richTextDestination;
            this.listLog = listLog;
        }

        

        public void AddToDestination(string s, Boolean clear = false)
        {
            if (!string.IsNullOrEmpty(s))
            {
                if (richTextDestination.InvokeRequired)
                {
                    richTextDestination.Invoke(new Action(() => UpdateDestination(s)));
                }
                else
                {
                    UpdateDestination(s);
                }
            }
        }

        public void UpdateDestination(string s)
        {
            List<string> strings = richTextDestination.Lines.ToList();
            strings.Add(s);
            richTextDestination.Lines = strings.ToArray();
        }

        public void AddToLog(string s, Boolean clear = false)
        {
            if(!string.IsNullOrEmpty(s))
            {
                if(listLog.InvokeRequired)
                {
                    listLog.Invoke(new Action(() => listLog.Items.Add(s)));
                }
                else
                {
                    listLog.Items.Add(s);
                }
            }
        }

        public void StartThreads(string[] strings, string stringToFind, string stringToReplace)
        {
            writerHandler = new WriterHandler(strings, buffer, 4);
            modifierHandler = new ModifierHandler(buffer, 3, stringToFind, stringToReplace);
            readerHandler = new ReaderHandler(buffer, 1);
        }

        public void StopThreads()
        {
            readerHandler.KillReaders();
            modifierHandler.KillModifiers();
            writerHandler.KillWriters();
        }
       

        public void Execute(string[] strings, string stringToFind, string stringToReplace)
        {
            buffer = new SharedBuffer(bufferSize, this);
            StartThreads(strings, stringToFind, stringToReplace);
        }
    }
}
