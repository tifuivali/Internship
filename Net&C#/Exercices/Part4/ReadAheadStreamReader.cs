using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    public class ReadAheadStreamReader:IDisposable

    {

        private readonly StreamReader _reader;

        private readonly Queue<string> _readAheadQueue = new Queue<string>();



        public ReadAheadStreamReader(StreamReader reader)

        {

            _reader = reader;

        }



        public string ReadLine()

        {

            if (_readAheadQueue.Count > 0)

                return _readAheadQueue.Dequeue();



            return _reader.ReadLine();

        }



        public string PeekLine()

        {

            if (_readAheadQueue.Count > 0)

                return _readAheadQueue.Peek();



            string line = _reader.ReadLine();



            if (line != null)

                _readAheadQueue.Enqueue(line);



            return line;

        }

        public void Dispose()
        {
            _reader.Close();
        }
    }
}
