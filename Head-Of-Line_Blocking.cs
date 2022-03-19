using System;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;


//Head-of-line blocking is when a slow request holds up the processing of subsequent requests
namespace HeadOfLine_Blocking_Ex
{
    class MainClass
    {
        //Time for each backend to sleep
        const int BE1 = 1000;
        const int BE2 = 6500;
        const int BE3 = 3000;

        // main class represents a web application
        public static void Main(string[] args)
        {
            //Display wait times for each simulated backend call
            Console.WriteLine("BackEnd1 Sleep time: " + BE1 + "ms");
            Console.WriteLine("BackEnd2 Sleep time: " + BE2 + "ms");
            Console.WriteLine("BackEnd3 Sleep time: " + BE3 + "ms");
            //stopwatch to measure time elapsed for backend calls   
            Stopwatch sW = new Stopwatch();
            sW.Start();
            //Run all three backend calls in parallel
            Parallel.Invoke(
                () => BackEnd1(),
                () => BackEnd2(),
                () => BackEnd3());
            sW.Stop();
            //Time elapsed should be close to the largest BE value
            Console.WriteLine("Time elapsed: " + sW.Elapsed.TotalMilliseconds + "ms");
        }

        // backend 1
        private static void BackEnd1(){
            Thread.Sleep(BE1);
        }

        // backend 2 
        private static void BackEnd2()
        {
            Thread.Sleep(BE2);
        }

        // backend 3
        private static void BackEnd3()
        {
            Thread.Sleep(BE3);
        }
    }
}
