using System;
using LowFragmentationHeap;

namespace LowFragmentationHeapTester
{
    class Program
    {
        static void Main(string[] args)
        {
            LFHBuffer.InitializeLFH();
            LFHBuffer buf = new LFHBuffer(1000);

            for (int i = 0; i < buf.Length; ++i)
                buf[i] = (byte)(i % 256);

            byte[] mgd = new byte[buf.Length];
            buf.Read(mgd, 0, 0, buf.Length);

            foreach (byte b in mgd)
                Console.Write(b + " ");
        }
    }
}
