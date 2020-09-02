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

                        

                        //var txt = new TextView(Context);
                        //txt.Text = "HalloHallo";
                        //txt.SetBackgroundColor(Android.Graphics.Color.Red);
                        //txt.LayoutParameters = parms1;

                        var count = _relativeLayout.ChildCount;


                        ExtendedTabbedPage page = e.NewElement as ExtendedTabbedPage;
                        var contentView = page.TabHeaderContent;

                        var renderer = Platform.CreateRendererWithContext(contentView, this.Context);
                        
                        if (Platform.GetRenderer(contentView) == null)
                        {
                            Platform.SetRenderer(contentView, renderer);
                        }

                            AWidget.RelativeLayout.LayoutParams layoutParms = new AWidget.RelativeLayout.LayoutParams(
                                                    LayoutParams.MatchParent, (int)contentView.HeightRequest);
                        layoutParms.AddRule(AWidget.LayoutRules.Above, bottomNavigationView.Id);



                        
                        //Platform.SetRenderer(renderer)
                        renderer.Tracker.UpdateLayout();
                        var nativeView = renderer.View;

                        
                        //view.SetBackground(Android.Widget.FrameLayout);
                        nativeView.LayoutParameters = layoutParms;
                        //SetNativeControl
                        //view.Layout(0, 0, (int)tb.TabHeaderContent.WidthRequest, (int)tb.TabHeaderContent.HeightRequest);
                        //view.tr
                        _relativeLayout.AddView(nativeView);
                        //_relativeLayout.UpdateViewLayout(view, parms1);
                        //var view = ConvertFormsToNative(tb.TabHeaderContent, new Rectangle(0, 0, 100, 100));

                        //_relativeLayout.AddView(view, count);
                        //_relativeLayout.AddView(view);

                        //_relativeLayout.AddView(txt, count);
                    }
                }
            }
        }

        //internal static IVisualElementRenderer Convert(Xamarin.Forms.View source, Context context)
        //{
        //    var render = Platform.GetRenderer(source);
        //    render = Platform.CreateRendererWithContext(source, context);
        //    Platform.SetRenderer(source, render);
        //    return render;
        //}

        //public static Android.Views.View ConvertFormsToNative(Xamarin.Forms.View view, Rectangle size)
        //{
        //    //Gets a null exception
        //    var vRenderer = Platform.GetRenderer(view);
        //    var viewGroup = vRenderer.View;
        //    vRenderer.Tracker.UpdateLayout();
        //    var layoutParams = new Android.Views.ViewGroup.LayoutParams((int)size.Width, (int)size.Height);
        //    viewGroup.LayoutParameters = layoutParams;
        //    view.Layout(size);
        //    viewGroup.Layout(0, 0, (int)view.WidthRequest, (int)view.HeightRequest);
        //    return viewGroup;
        //}

    }
}