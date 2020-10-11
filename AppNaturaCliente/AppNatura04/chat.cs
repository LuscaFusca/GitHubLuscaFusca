using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace AppNaturaCliente {
    [Activity(Label = "chat")]
    public class chat : Activity {

        WebView webView;
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.chat);

            webView = FindViewById<WebView>(Resource.Id.webView);
            webView.SetWebViewClient(new ExtendWebViewClient());
            webView.LoadUrl("https://mdh-chat.metasix.solutions/livechat?mode=popout");

            WebSettings webSettings = webView.Settings;
            webSettings.JavaScriptEnabled = true;
        }
    }

    internal class ExtendWebViewClient : WebViewClient {
        public override bool ShouldOverrideUrlLoading(WebView view, string url) {
            view.LoadUrl(url);
            return true;
        }
    }
}