using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace service1
{
    public class MyHandler : Handler
    {
        int couner = 0;
        Context context;

        [System.Obsolete]
        public MyHandler(Context context)
        {
            this.context = context;
        }
        public override void HandleMessage(Message msg)
        {
            Toast.MakeText(context, "" + msg.Arg1, ToastLength.Long).Show();
        }
    }
}