using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace UsingPInvoke
{
    /// <summary>
    /// Demonstrates the use of P/Invoke and reverse P/Invoke for interoperability
    /// between managed code and a C-style DLL with exported functions.
    /// </summary>
    unsafe class PInvoke
    {
        [DllImport(@"..\..\..\..\Debug\NativeLibrary.dll")]
        static extern bool IsPrime(int number);

        [DllImport(@"..\..\..\..\Debug\NativeLibrary.dll", CharSet = CharSet.Unicode)]
        static extern void wputs(string s);

        [DllImport(@"..\..\..\..\Debug\NativeLibrary.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsValid([MarshalAs(UnmanagedType.LPWStr)] string text);

        [StructLayout(LayoutKind.Sequential)]
        struct ITEM
        {
            public ITEM(uint data)
            {
                dwData = data;
            }
            public uint dwData;
        }
        [DllImport(@"..\..\..\..\Debug\NativeLibrary.dll")]
        static extern void Find(ITEM[] items, int count, ref ITEM lookup, out int index);

        [DllImport(@"..\..\..\..\Debug\NativeLibrary.dll")]
        static unsafe extern void Find(ITEM* items, int count, ITEM* lookup, int* index);

        [DllImport(@"..\..\..\..\Debug\NativeLibrary.dll", CharSet = CharSet.Ansi)]
        static extern void FillString(StringBuilder text, char fill);

        delegate bool IsMatch(string text);

        [DllImport(@"..\..\..\..\Debug\NativeLibrary.dll", CharSet = CharSet.Ansi)]
        static extern int FindMatch(IsMatch match);

        [DllImport(@"..\..\..\..\Debug\NativeLibrary.dll", CharSet = CharSet.Ansi)]
        static extern void StoreMatch(IsMatch match);

        [DllImport(@"..\..\..\..\Debug\NativeLibrary.dll", CharSet = CharSet.Ansi)]
        static extern void UseMatch();

        static void Main(string[] args)
        {
            //Simple examples of interop with integers and strings:
            Array.ForEach(Enumerable.Range(2, 100).Where(IsPrime).ToArray(), Console.WriteLine);
            Console.WriteLine(IsValid(null));
            Console.WriteLine(IsValid("Hey!"));
            
            //Marshaling an array of items.  Note that the ITEM structure is duplicated
            //in the C and C# code.  The process of duplication can be streamlined by using
            //an automatic tool such as the P/Invoke Signature Assistant.
            ITEM[] items = { new ITEM(0), new ITEM(1), new ITEM(6), new ITEM(18) };
            ITEM lookup = new ITEM(6);
            int index;
            Find(items, items.Length, ref lookup, out index);
            Console.WriteLine(index);

            //Marshaling arrays and structures as pointers, using unsafe code and the
            //fixed statement to obtain a pointer.  In this example, a pointer to the middle
            //of the array (the 3rd element) is passed to the Find method.
            unsafe
            {
                fixed (ITEM* p = &items[2])
                {
                    Find(p, items.Length - 2, &lookup, &index);
                    Console.WriteLine(index);
                }
            }

            //Marshaling a mutable string using StringBuilder:
            StringBuilder text = new StringBuilder("Hello");
            FillString(text, 'a');
            Console.WriteLine(text);

            //Marshaling delegates with an anonymous method:
            IsMatch match = delegate(string s) { return s.StartsWith("Go"); };
            Console.WriteLine(FindMatch(match));

            //Marshaling delegates with a lambda expression:
            match = s => s.StartsWith("I");
            Console.WriteLine(FindMatch(match));

            //Callback on garbage-collected delegate:
            //StoreMatch(new PInvoke().Matcher);
            //GC.Collect();
            //UseMatch();

            //Marshaling delegates which are stored by native code and invoked later.
            //The lifetime of such delegates must be explicitly managed to ensure that
            //the delegate is not garbage collected while native code still has a
            //reference to it through a native function pointer.
            match = new PInvoke().Matcher;
            StoreMatch(match);
            GC.Collect();
            UseMatch();
            GC.KeepAlive(match);    //Keeps the delegate alive
        }

        bool Matcher(string s)
        {
            return !String.IsNullOrEmpty(s);
        }
    }
}
