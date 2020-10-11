using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Gms.Vision;
using Android.Gms.Vision.Texts;
using Android.Graphics;
using Android.Support.V4.App;
using Android;
using Android.Util;
using Android.Content.PM;
using static Android.Gms.Vision.Detector;
using Java.Lang;
using Java.IO;
using System.Text.RegularExpressions;
using Android.Webkit;

namespace AppNaturaRevendedora {
    [Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity {
        private Button btnComprar;
        private Button btnCarrinho;
        private Button btnAjuda;
        private WebView webViewInicial;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            btnComprar = FindViewById<Button>(Resource.Id.btnComprar);
            btnCarrinho = FindViewById<Button>(Resource.Id.btnCarrinho);
            webViewInicial = FindViewById<WebView>(Resource.Id.webViewInicial);

            btnComprar.Click += BtnComprar_Click;
            btnCarrinho.Click += BtnCarrinho_Click;

            btnAjuda = FindViewById<Button>(Resource.Id.btnAjuda);
            btnAjuda.Click += BtnAjuda_Click;

            webViewInicial.SetWebViewClient(new ExtendWebViewClient());
            webViewInicial.LoadUrl("https://www.natura.com.br/c/tudo-em-promocoes");

            webViewInicial.Settings.DomStorageEnabled = true;

            WebSettings webSettings = webViewInicial.Settings;
            webSettings.JavaScriptEnabled = true;
        }

        internal class ExtendWebViewClient : WebViewClient {
            public override bool ShouldOverrideUrlLoading(WebView view, string url) {
                view.LoadUrl(url);
                return true;
            }
        }

        private void BtnCarrinho_Click(object sender, System.EventArgs e) {
            StartActivity(typeof(ListaCarrinho));
        }

        private void BtnAjuda_Click(object sender, System.EventArgs e) {
            StartActivity(typeof(chat));
        }

        private void BtnComprar_Click(object sender, System.EventArgs e) {
            StartActivity(typeof(ColetaCodigo));
        }
    }
}