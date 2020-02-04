using Android.Content;
using Android.Support.Design.Widget;
using Android.Widget;
using PrismPages.Controls;
using PrismPages.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using AWidget = Android.Widget;

[assembly: ExportRenderer(typeof(PrismPages.Controls.ExtendedTabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace PrismPages.Droid.Renderers
{
    public class ExtendedTabbedPageRenderer : TabbedPageRenderer
    {
        AWidget.RelativeLayout _relativeLayout;
        ExtendedTabbedPage _page;

        public ExtendedTabbedPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if(ViewGroup.GetChildAt(0) is AWidget.RelativeLayout relativeLayout)
                {
                    _relativeLayout = relativeLayout;

                    if (relativeLayout.GetChildAt(1) is BottomNavigationView bottomNavigationView)
                    {

                        AWidget.RelativeLayout.LayoutParams parms1 = new AWidget.RelativeLayout.LayoutParams(
                            LayoutParams.MatchParent, 200);
                        parms1.AddRule(AWidget.LayoutRules.Above, bottomNavigationView.Id);

                        var txt = new TextView(Context);
                        txt.Text = "HalloHallo";
                        txt.SetBackgroundColor(Android.Graphics.Color.Red);
                        txt.LayoutParameters = parms1;

                        var count = _relativeLayout.ChildCount;

                        ExtendedTabbedPage tb = e.NewElement as ExtendedTabbedPage;
                        //Android.Provider.SyncStateContract.Helpers.

                        var viewRenderer = Platform.CreateRendererWithContext(tb.TabHeaderContent, Context);
                        viewRenderer.Tracker.UpdateLayout();
                        //viewRenderer.View.SetBackgroundColor(Android.Graphics.Color.Red);
                        viewRenderer.View.LayoutParameters = parms1;

                        _relativeLayout.AddView(viewRenderer.View, count);

                        //_relativeLayout.AddView(txt, count);

                    }
                }
            }
        }
    }
}