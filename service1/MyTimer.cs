using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace service1
{
    public class MyTimer
    {
        int counter;
        MyHandler handler;
        public bool stop;
        public MyTimer(MyHandler handler, int counter)
        {
            this.handler = handler;
            this.counter = counter;
        }
        public void Begin()
        {
            ThreadStart threadStart = new ThreadStart(Run);
            Thread t = new Thread(threadStart);
            this.stop = false;
            t.Start();
        }
        private void Run()
        {
            while (this.counter > 0)
                if (!stop)
                {
                    counter--;
                    Thread.Sleep(1000); Message msg = new Message();
                    msg.Arg1 = counter;
                    handler.SendMessage(msg);
                }
        }
    }
}