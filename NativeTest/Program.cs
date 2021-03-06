﻿using System;
using System.Collections.Generic;
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

            var myFun = GetMySpecialMeth<SomeDelegate, ISomeDeep>(false, null, 0);
            Console.WriteLine(myFun);

            var mySun = GetMySpecialMeth<ISet<ISomeDeep>>(true, 1);
            Console.WriteLine(mySun);

            var myCan = GetMySpecialMeth<SomeDelegate[], ISomeDeep>(false, null, 2);
            Console.WriteLine(myCan);

            IDictionary<string, SomeDelegate> dict = new Dictionary<string, SomeDelegate>();
            Console.WriteLine(dict["hello"]);

            ISet<ISomeDeep> set = new HashSet<ISomeDeep>();
            Console.WriteLine(set.Add(null));

            IList<SuperStruct> list = new List<SuperStruct>();
            Console.WriteLine(list[1]);

            SomeDelegate[] delgts = new SomeDelegate[12];
            Console.WriteLine(delgts[3]);

            SomeDelegate[,] delgts2 = new SomeDelegate[12, 45];
            Console.WriteLine(delgts2[3, 1]);

            SomeDelegate[,,] delgts3 = new SomeDelegate[12, 45, 78];
            Console.WriteLine(delgts3[3, 1, 2]);
        }

        private static T GetMySpecialMeth<T, U>(bool me, U deep, int x) { throw new NotImplementedException(); }

        private static T GetMySpecialMeth<T>(bool me, int x) { throw new NotImplementedException(); }

        private static void Deep_OnMouseExploding(object sender, EventArgs e) { throw new NotImplementedException(); }

        private class Constri<A, B, C> 
            where A : new() where B : ISomeDeep where C : IDictionary<ISomeDeep, Tuple<DateTime, SomeDelegate>> { }

        private static void GetConstri<A, B, C, D>(A a, B b, C[] c, D d) 
            where A : IList<DateTime> where B : struct where C : HashSet<SomeDelegate> where D : class { }

        private static IDictionary<T, Tuple<ISomeDeep, SomeDelegate, U, bool>> Specialize<T, U>()
            where T : IDictionary<T, Tuple<ISomeDeep, SomeDelegate, U, bool>>
            where U : Tuple<ISet<T>, ISomeDeep, SomeDelegate, U, bool>
        {
            return null;
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