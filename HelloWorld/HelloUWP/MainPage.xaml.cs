using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Profile;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public string DeviceFamily = String.Format("Device info: {0}", AnalyticsInfo.VersionInfo.DeviceFamily.ToString());
        public event PropertyChangedEventHandler PropertyChanged;

        public string Dimensions { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            this.SizeChanged += ScreenSizeChanged;
        }

        private void ScreenSizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Dimensions = String.Format("{0} x {1}", Window.Current.Bounds.Width, Window.Current.Bounds.Height);
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Dimensions)));
            }
        }
    }
}
