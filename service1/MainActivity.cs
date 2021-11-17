using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace service1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnStart, btnStop;
        TextView tv;
        MyHandler myHandler;
        MyTimer myTimer;

        [System.Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            btnStart = (Button)FindViewById(Resource.Id.btn1);
            btnStop = (Button)FindViewById(Resource.Id.btn2);
            tv = (TextView)FindViewById(Resource.Id.tv1);
            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;
            myHandler = new MyHandler(this);
        }

        private void BtnStop_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MyService));
            StopService(intent);
        }

        private void BtnStart_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MyService));
            intent.PutExtra("counter", 5);
            StartService(intent);
        }

    

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}