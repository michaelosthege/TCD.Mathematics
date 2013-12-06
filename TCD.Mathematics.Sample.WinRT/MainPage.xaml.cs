using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TCD.Mathematics;//get from NuGet

namespace TCD.Mathematics.Sample.WinRT
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //do some calculations
            Point3D p1 = new Point3D(3, 2, 1);
            Line3D l1 = new Line3D(new Point3D(0, 0, 2), new Vector3D(1, 0, 0));
            Plane3D e1 = new Plane3D(l1, new Point3D(1, 0, 0));

            Point3D p2 = p1.ProjectOnLine3D(l1);
            Point3D p3 = p1.ProjectOnPlane3D(e1);

            console.Text += "\nPoint1                : " + p1;
            console.Text += "\nLine1                 : " + l1;
            console.Text += "\nPlane1                : " + e1;
            console.Text += "\nPoint1 -> Line1       : " + p2;
            console.Text += "\nPoint1 -> Plane1      : " + p3;

            console.Text += "\n\nLine(Point2, Point3)  : " + new Line3D(p2, p3);

            Line3D il = new Line3D(new Point3D(1, 1, 2), new Point3D(7, 5, 3));
            Plane3D ip1 = new Plane3D(il, new Point3D(5, 5, 5));
            Plane3D ip2 = new Plane3D(il, new Point3D(5, -5, 5));

            Line3D il2 = Plane3D.IntersectPlane3Ds(ip1, ip2);

            console.Text += "\n\nLine1                 : " + il + "\nLine1 (reconstructed) : " + il2;


        }
    }
}
