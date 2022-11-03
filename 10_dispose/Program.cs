using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_dispose
{
    class HardClass : IDisposable
    {
        int[] array = null;
        bool isConnected = false;

        public HardClass()
        {
            Connect();
            array = new int[1000];
        }
        public void Connect()
        {
            isConnected = true;
            Console.WriteLine("Connected!");
        }
        public void Disconnect()
        {
            isConnected = false;
            Console.WriteLine("Disconnected!");
        }
        public void BadOperation()
        {
            throw new Exception("Error!");
        }

        // some fields that require cleanup
        private bool isDisposed = false; // to detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                Console.WriteLine("Dispose!");
                if (disposing)
                {
                    // dispose-only, i.e. non-finalizable logic
                }

                // shared cleanup logic
                Disconnect();

                isDisposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // finalise
        ~HardClass()
        {
            Console.WriteLine("Finilize!");
            Dispose(false);
        }
    }

    class Program
    {
        static void TestHardWork()
        {
            //GC.Collect(0);

            //HardClass hard = new HardClass();
            //try
            //{
            //    // TODO...
            //    hard.BadOperation();
            //}
            //finally
            //{
            //    hard.Dispose();
            //}

            //................ the same
            using (HardClass hard = new HardClass())
            {
                //TODO...
                hard.BadOperation();

            } // auto invole Dispose()
           
                      
        }
        static void Main(string[] args)
        {
            TestHardWork();

            GC.Collect();
            Console.ReadKey();
        }
    }
}
