using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Audio.Resources;
using System;

namespace Audio
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _buttonPlay;
        private Button _buttonPause;
        private Button _buttonResume;
        private Button _buttonStop;
        private MediaPlayer _player;
        private int _position;
        private Button Pick;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            UIReferences();
            UIClickEvent();
        }

        private void UIClickEvent()
        {
            _buttonPlay.Click += ButtonPlay_Click;
            _buttonPause.Click += ButtonPause_Click;
            _buttonResume.Click += ButtonResume_Click;
            _buttonStop.Click += ButtonStop_Click;
            Pick.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Pick));
            StartActivity(intent);
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            _player.Stop();
        }

        private void ButtonResume_Click(object sender, EventArgs e)
        {
            _player.SeekTo(_position);
            _player.Start();
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            _player.Pause();
            _position = _player.CurrentPosition;

        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            _player = MediaPlayer.Create(this, Resource.Raw.Stay);
            _player.Start();
        }

        private void UIReferences()
        {
            _buttonPlay = FindViewById<Button>(Resource.Id.buttonPlay);
            _buttonPause = FindViewById<Button>(Resource.Id.buttonPause);
            _buttonResume = FindViewById<Button>(Resource.Id.buttonResume);
            _buttonStop = FindViewById<Button>(Resource.Id.buttonStop);
            Pick = FindViewById<Button>(Resource.Id.Pick);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}