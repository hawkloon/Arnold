using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    public class BlockingStream : Stream
    {
        private readonly Queue<byte> buffer = new Queue<byte>();
        private readonly object lockObj = new object();
        private bool isClosed = false;

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => true;
        public override long Length => throw new NotSupportedException();
        public override long Position { get; set; }

        public override void Flush() { }

        public override int Read(byte[] destBuffer, int offset, int count)
        {
            int bytesRead = 0;
            while (bytesRead < count)
            {
                lock (lockObj)
                {
                    while (buffer.Count == 0)
                    {
                        if (isClosed) return 0;
                        Monitor.Wait(lockObj);
                    }

                    while (buffer.Count > 0 && bytesRead < count)
                    {
                        destBuffer[offset + bytesRead] = buffer.Dequeue();
                        bytesRead++;
                    }
                }
            }
            return bytesRead;
        }

        public override void Write(byte[] srcBuffer, int offset, int count)
        {
            lock (lockObj)
            {
                for (int i = 0; i < count; i++)
                    buffer.Enqueue(srcBuffer[offset + i]);

                Monitor.PulseAll(lockObj);
            }
        }

        public override void Close()
        {
            lock (lockObj)
            {
                isClosed = true;
                Monitor.PulseAll(lockObj);
            }
            base.Close();
        }

        // Not supported
        public override long Seek(long offset, SeekOrigin origin)
        {
            return 0;
        }
        public override void SetLength(long value)
        {
            return;
        }
    }
}
