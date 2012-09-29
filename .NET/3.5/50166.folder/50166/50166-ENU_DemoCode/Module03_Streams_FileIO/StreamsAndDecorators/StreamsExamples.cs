using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StreamsAndDecorators
{
    /// <summary>
    /// A stream that automatically dispatches output requests (writes) to multiple
    /// other streams, enabling a composite-like abstraction of a stream.
    /// Each of the operations in this class override an abstract method or property
    /// of the Stream class and implement it with regard to multiple output destinations.
    /// Read-related operations and the Seek operation are not supported.
    /// </summary>
    public class CompositeOutputStream : Stream
    {
        private readonly Stream[] _streams;

        public CompositeOutputStream(params Stream[] streams)
        {
            _streams = streams;
        }

        public override void Close()
        {
            Array.ForEach(_streams, s => s.Close());
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Flush()
        {
            Array.ForEach(_streams, s => s.Flush());
        }

        public override long Length
        {
            get { return (from s in _streams select s.Length).Max(); }
        }

        public override long Position
        {
            get
            {
                return _streams.First().Position;
            }
            set
            {
                Array.ForEach(_streams, s => s.Position = value);
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            Array.ForEach(_streams, s => s.SetLength(value));
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Array.ForEach(_streams, s => s.Write(buffer, offset, count));
        }
    }

    /// <summary>
    /// Serves as a base for all stream decorators.  Implements all
    /// abstract methods from the Stream class by delegating the work to
    /// the underlying stream (DecoratedStream) which is passed to the
    /// constructor.
    /// Derived classes are expected to override the relevant functionality
    /// while delegating the rest of the work to the decorated stream
    /// as in the base class.
    /// </summary>
    public abstract class DecoratingStream : Stream
    {
        private readonly Stream _stream;

        protected Stream DecoratedStream { get { return _stream; } }

        protected DecoratingStream(Stream stream)
        {
            _stream = stream;
        }

        public override bool CanRead
        {
            get { return _stream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return _stream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return _stream.CanWrite; }
        }

        public override void Flush()
        {
            _stream.Flush();
        }

        public override long Length
        {
            get { return _stream.Length; }
        }

        public override long Position
        {
            get
            {
                return _stream.Position;
            }
            set
            {
                _stream.Position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
        }

        public override void Close()
        {
            base.Close();
            _stream.Close();
        }
    }

    /// <summary>
    /// Implements simple XOR-based encryption and decryption over data
    /// written to and read from an underlying stream.  Delegation of most
    /// work is performed by inheritance from the DecoratingStream class.
    /// Only the Read and Write operations are overriden, and they perform
    /// the decryption and encryption respectively using an "encryption key"
    /// passed to the stream's constructor.
    /// </summary>
    public class XorEncryptionStream : DecoratingStream
    {
        private readonly byte _key;

        public XorEncryptionStream(Stream stream, byte key)
            : base(stream)
        {
            _key = key;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int read = base.Read(buffer, offset, count);
            for (int i = offset; i < offset + read; ++i)
                buffer[i] ^= _key;
            return read;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; ++i)
                buffer[i] ^= _key;
            base.Write(buffer, offset, count);
        }
    }

    class StreamsExamples
    {
        static void Main(string[] args)
        {
            //Demo of CompositeOutputStream
            CompositeOutputStream();

            //Demo of XorEncryptionStream
            XorEncryptionStream();

            //Demo of file streams
            FileStream();

            //Demo of stream readers and writers
            ReadersWriters();

            //Demo of binary readers and writers
            BinaryReadersWriters();
        }

        /// <summary>
        /// Demonstrates how a matrix of 10x10 double-precision numbers
        /// can be serialized to a binary file using the BinaryWriter class
        /// and then deserialized from the file using the BinaryReader class.
        /// Make note of the fact the matrix dimensions are serialized so that
        /// later on the matrix can be recreated.
        /// </summary>
        private static void BinaryReadersWriters()
        {
            double[,] matrix = new double[10, 10];
            for (int i = 0; i < 10; ++i)
                for (int j = 0; j < 10; ++j)
                    matrix[i, j] = i * j;

            BinaryWriter writer = new BinaryWriter(
                new FileStream("matrix.dat", FileMode.Create));
            writer.Write(matrix.GetUpperBound(0));
            writer.Write(matrix.GetUpperBound(1));
            for (int i = 0; i < 10; ++i)
                for (int j = 0; j < 10; ++j)
                    writer.Write(matrix[i, j]);
            writer.Close();

            BinaryReader reader = new BinaryReader(
                new FileStream("matrix.dat", FileMode.Open));
            int dim0 = reader.ReadInt32();
            int dim1 = reader.ReadInt32();
            double[,] newMatrix = new double[dim0, dim1];
            for (int i = 0; i < dim0; ++i)
                for (int j = 0; j < dim1; ++j)
                    newMatrix[i, j] = reader.ReadDouble();
            reader.Close();
        }

        /// <summary>
        /// Demonstrates the use of StreamWriter and StreamReader
        /// to write and read textual information with files.
        /// </summary>
        private static void ReadersWriters()
        {
            FileStream myFile = new FileStream("myfile.txt",
                FileMode.Create);
            StreamWriter writer = new StreamWriter(myFile);
            writer.WriteLine("From a stream writer!");
            writer.Close(); //This is critical!

            //Short-hand for creating a file
            StreamReader reader = new StreamReader("myfile.txt");
            Console.WriteLine(reader.ReadLine());
            reader.Close();
        }

        /// <summary>
        /// Demonstrates the fundamental FileStream APIs, including
        /// the file creation modes, file access modes, file sharing modes
        /// and various methods and properties for reading and writing
        /// data.  This example uses the Encoding.Unicode object to
        /// encode and decode strings from their byte array representations.
        /// </summary>
        private static void FileStream()
        {
            FileStream myFile = new FileStream("myfile.txt",
                FileMode.Create, FileAccess.ReadWrite);
            string greeting = "Good afternoon";
            byte[] output = Encoding.Unicode.GetBytes(greeting);
            myFile.Write(output, 0, output.Length);
            myFile.Close();

            myFile = new FileStream("myfile.txt",
                FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] input = new byte[myFile.Length];
            myFile.Read(input, 0, input.Length);
            myFile.Close();
            Console.WriteLine("Read from file: " +
                Encoding.Unicode.GetString(input));
        }

        /// <summary>
        /// Demonstrates the use of the XorEncryptionStream decorator (see above)
        /// for encrypting and decrypting data written to a file stream.
        /// Note that a StreamWriter/StreamReader pair would also work with a
        /// XorEncryptionStream as the underlying stream, enabling very powerful
        /// scenarios for combining stream decorators with other stream functionality.
        /// </summary>
        private static void XorEncryptionStream()
        {
            byte[] buf = Encoding.ASCII.GetBytes("Hello World" + Environment.NewLine);

            FileStream data = new FileStream("encrypted.dat", FileMode.Create);
            XorEncryptionStream encryptor = new XorEncryptionStream(data, 37);
            encryptor.Write(buf, 0, buf.Length);
            encryptor.Close();

            data = new FileStream("encrypted.dat", FileMode.Open);
            XorEncryptionStream decryptor = new XorEncryptionStream(data, 37);
            Console.WriteLine("Bytes read: " + decryptor.Read(buf, 0, buf.Length));
            decryptor.Close();
            Console.WriteLine(Encoding.ASCII.GetString(buf));
        }

        /// <summary>
        /// Demonstrates the use of the CompositeOutputStream stream adapter (see above)
        /// by directing output to the standard output stream and the standard error stream
        /// simultaneously.
        /// </summary>
        private static void CompositeOutputStream()
        {
            CompositeOutputStream output = new CompositeOutputStream(Console.OpenStandardOutput(), Console.OpenStandardError());

            byte[] buf = Encoding.ASCII.GetBytes("Hello World" + Environment.NewLine);
            output.Write(buf, 0, buf.Length);

            output.Close();
        }
    }
}
