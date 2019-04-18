using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class StringStream : IStream
    {
        private string value;

        private int alreadyReadChars = 0;

        public StringStream(string value)
        {
            this.value = value;
        }

        public char ReadNext()
        {
	    if (AtEnd()) {
		throw new IndexOutOfRangeException("Stream is empty!");
	    }
            return value[alreadyReadChars++];
        }

        public bool AtEnd()
        {
            return value.Length == alreadyReadChars;
        }
    }
}
