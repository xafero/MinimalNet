using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NativeTest
{
    static class Program
    {
        enum COMPUTER_NAME_FORMAT
        {
            ComputerNameNetBIOS,
            ComputerNameDnsHostname,
            ComputerNameDnsDomain,
            ComputerNameDnsFullyQualified,
            ComputerNamePhysicalNetBIOS,
            ComputerNamePhysicalDnsHostname,
            ComputerNamePhysicalDnsDomain,
            ComputerNamePhysicalDnsFullyQualified
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool GetComputerNameEx(COMPUTER_NAME_FORMAT NameType,
            StringBuilder lpBuffer, ref uint lpnSize);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SuperStruct Nonsense(SomeDelegate proc, bool shit);

        private delegate void SomeDelegate(ref uint handle, ISomeDeep deep);

        private struct SuperStruct { internal ISomeDeep Deep; public void Crap() { } }

        private interface ISomeDeep { string Name { get; } event EventHandler OnMouseExploding; }

        private static void NeverCalled()
        {
            SomeDelegate dlgt = null;
            SuperStruct structi = Nonsense(dlgt, true);
            Console.WriteLine(structi.Deep);
            ISomeDeep deep = null;
            Console.WriteLine(deep.Name);
            structi.Crap();
            Console.WriteLine(typeof(SuperStruct).Assembly.FullName);
            deep.OnMouseExploding += Deep_OnMouseExploding;
        }

        private static void Deep_OnMouseExploding(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        [STAThread]
        static void Main()
        {
            bool success;
            var name = new StringBuilder(260);
            uint size = 260;
            success = GetComputerNameEx(COMPUTER_NAME_FORMAT.ComputerNameDnsHostname, name, ref size);
            Console.WriteLine($"{success} -> {name}");
        }
    }
}