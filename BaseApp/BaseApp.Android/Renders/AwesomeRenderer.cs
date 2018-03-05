using Android.Content;
using Android.Graphics;
using Android.Widget;
using BaseApp.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(AwesomeLabelRenderer))]
[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(AwesomeButtonRenderer))]

namespace BaseApp.Droid.Renders
{
    public class AwesomeLabelRenderer : LabelRenderer
    {
        Context _Context;
        public AwesomeLabelRenderer(Context context) : base(context)
        {
            _Context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            AwesomeUtil.CheckAndSetTypeFace(Control, _Context);
        }
    }

    public class AwesomeButtonRenderer : ButtonRenderer
    {
        Context _Context;
        public AwesomeButtonRenderer(Context context) : base(context)
        {
            _Context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            AwesomeUtil.CheckAndSetTypeFace(Control, _Context);
        }
    }

    internal static class AwesomeUtil
    {
        public static void CheckAndSetTypeFace(TextView view, Context Context)
        {
            if (view.Text.Length == 0) return;
            var text = view.Text;
            if (text.Length > 1 || text[0] < 0xf000)
            {
                return;
            }

            var font = Typeface.CreateFromAsset(Context.ApplicationContext.Assets, "fontawesome.ttf");
            view.Typeface = font;
        }
    }
}