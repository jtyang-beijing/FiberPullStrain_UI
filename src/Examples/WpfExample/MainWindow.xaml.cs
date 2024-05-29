using Fiber.ScatterGraph;
using FiberPullStrain;
using FiberPullStrain.CustomControl.view;
using System;
using System.Windows;

namespace FiberPull
{
    public partial class MainWindow : Window {

        public SerialCommunication serialCommunication;
        public MainViewModel viewModel;
        public MainWindow() {
            InitializeComponent();
            myButtonControls._mainwindow = this;
            CartGraph.Graph = ScatterGraphGenerator.GenerateScatterGraph();
            //CartGraph.Render += AddPoint;
            serialCommunication = new SerialCommunication();
            viewModel = new MainViewModel(serialCommunication);
            this.DataContext = viewModel;
            viewModel.lb_Current_Distance_Content_Changed += ViewModel_lb_Current_Distance_Content_Changed;
            
        }

        Point newPoint = new Point();
        private void ViewModel_lb_Current_Distance_Content_Changed(object sender, EventArgs e)
        {
            float.TryParse(viewModel.lb_Current_Distance, out float x);
            float.TryParse(viewModel.lb_Current_Force, out float y);
            newPoint.X = x; newPoint.Y = y;
            AddPoint1(newPoint);
            float.TryParse(myButtonControls.inBoxDistance.inputBox.Text, out float a);
            if (a == x) viewModel.IsRunning = false;
        }

        //private int i = 0;
        public void AddPoint1(Point point)
        {
            var series = CartGraph.Graph.State.Series[0];
            var pt = DateTime.UtcNow.Ticks;
            var str = pt.ToString();
            var offset = series.Points.Count;
            series.Add(str, (float)point.X, (float)point.Y);
            CartGraph.Graph.State.Update(0.0f);
        }

        public void AddPoint(TimeSpan deltaTime)
        {
            var r = new Random();
            var seriesIdx = r.Next(CartGraph.Graph.State.Series.Count);
            var series = CartGraph.Graph.State.Series[seriesIdx];
            var (x, y) = ScatterGraphGenerator.GenNormalDistPt(r);
            var pt = DateTime.UtcNow.Ticks;
            var str = pt.ToString();
            var offset = series.Points.Count;
            series.Add(str, x, y);
            CartGraph.Graph.State.Update((float)deltaTime.TotalSeconds);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await serialCommunication.SearchAllCOMports();
            if(serialCommunication.myPort.IsOpen) 
            { 
                serialCommunication.myPort.WriteLine("p"); 
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (serialCommunication.myPort.IsOpen) serialCommunication.myPort.Close();
            //myButtonControls._mainwindow.Close();
            //App.Current.Shutdown();
        }
        //
        // private void RenderLeftControl(TimeSpan deltaTime) {
        //     GL.ClearColor(Color4.Black);
        //     GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        //     
        //     _cartesianGraph.State.Update((float) deltaTime.TotalSeconds);
        //     
        //     
        //     GL.Viewport(0,0,LeftGLControl.FrameBufferWidth, LeftGLControl.FrameBufferHeight);
        //     var aspect = (1.0f * LeftGLControl.FrameBufferWidth) / LeftGLControl.FrameBufferHeight;
        //     _cartesianGraph.State.Camera.Current.AspectRatio = aspect;
        //     _cartesianGraph.State.Camera.Target.AspectRatio = aspect;
        //
        //     _cartesianGraph.Render();
        //     // _netGraph.Render();
        // }

        // private void RenderRightControl(TimeSpan deltaTime) {
        //     GL.ClearColor(Color4.Black);
        //     GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        //     
        //     _netGraph.State.Update((float) deltaTime.TotalSeconds);
        //     
        //     GL.Viewport(0,0,RightGLControl.FrameBufferWidth, RightGLControl.FrameBufferHeight);
        //     var aspect = (1.0f * RightGLControl.FrameBufferWidth) / RightGLControl.FrameBufferHeight;
        //     _netGraph.Camera.Current.AspectRatio = aspect;
        //     _netGraph.Camera.Target.AspectRatio = aspect;
        //     
        //     _netGraph.Render();
        // }
    }
}