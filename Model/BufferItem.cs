using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_CS_GUI.Model
{
    internal class BufferItem
    {
        private string textString;
        private BufferStatus status;

        public BufferStatus Status { get { return status; } set { status = value; } }
        public string TextString { get { return textString; } set { textString = value; } }
    }
}
