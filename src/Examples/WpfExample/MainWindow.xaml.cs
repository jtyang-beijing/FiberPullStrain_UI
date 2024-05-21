using Fiber.ScatterGraph;
using System;
using System.Windows;

namespace FiberPull
{
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            CartGraph.Graph = ScatterGraphGenerator.GenerateScatterGraph();
            CartGraph.Render += AddPoint;

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