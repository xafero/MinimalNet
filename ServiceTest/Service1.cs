using System.ServiceProcess;
using System;

namespace ServiceTest
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Console.WriteLine("I'm starting...");
        }

        protected override void OnStop()
        {
            Console.WriteLine("I'm stopping...");
        }
    }
}
