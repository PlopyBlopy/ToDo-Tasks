using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TDT.Helpers;

namespace ToDoTask.Models
{
    public class WindowManager : WindowFactory
    {
        private static WindowManager _instance;
        private static readonly object _lock = new object();

        private WindowInfo _curMainWindow;
        private WindowInfo _curFloatWindow;
        private WindowSubInfo _curSubWindow;

        public Window CurMainWindow
        { get { return _curMainWindow.WindowView; } }

        public Window CurFloatWindow
        { get { return _curFloatWindow.WindowView; } }

        public UserControl CurSubWindow
        { get { return _curSubWindow.WindowSubView; } }

        public static WindowManager Instance
        {
            get
            {
                if (_instance != null)
                {
                    lock (_lock)
                    {
                        return _instance;
                    }
                }
                throw new NullReferenceException("The WindowManager is not initialized!");
            }
        }

        public static void Initialize(IServiceProvider serviceProvider, WindowRegistry initialWindow)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new WindowManager(serviceProvider, initialWindow);
                }
            }
        }

        private WindowManager(IServiceProvider serviceProvider, WindowRegistry initialRegistry) : base(serviceProvider)
        {
            SetMainWindow(initialRegistry);
            OpenSubWindow(WindowSubRegistry.TaskSubWindow);
        }

        private void WindowStartupSettings(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void FloatWindowStartupSettings(Window window)
        {
            window.Owner = _curMainWindow.WindowView;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void SetMainWindow(WindowRegistry registry)
        {
            Window window = GetWindow<Window>(registry);

            if (window != null)
            {
                _curMainWindow = new WindowInfo { WindowView = window, Registry = registry };
                WindowStartupSettings(_curMainWindow.WindowView);
                window.Show();
            }
            else
            {
                throw new ArgumentException($"Window with registry {registry} is not registered.");
            }
        }

        public void OpenFloatWindow(WindowRegistry registry)
        {
            if (registry != _curMainWindow.Registry) //&& registry != _curFloatWindow.Registry
            {
                Window window = GetWindow<Window>(registry);

                if (window != null)
                {
                    if (_curFloatWindow != null)
                        CloseCurrentFloatWindow();

                    _curFloatWindow = new WindowInfo { WindowView = window, Registry = registry };
                    FloatWindowStartupSettings(_curFloatWindow.WindowView);
                    window.Show();
                }
            }
        }

        public void OpenSubWindow(WindowSubRegistry registry)
        {
            var contentControl = FindContentControl(_curMainWindow.WindowView);

            if (contentControl != null) // && registry != _curSubWindow.Registry
            {
                var window = GetWindow<UserControl>(registry);

                if (window != null)
                {
                    if (_curSubWindow != null)
                        CloseCurrentSubWindow();

                    _curSubWindow = new WindowSubInfo { WindowSubView = window, Registry = registry };
                    contentControl.Content = _curSubWindow.WindowSubView;
                }
            }
        }

        //private void CloseCurrentMainWindow()
        //{
        //    _curMainWindow?.WindowView.Close();
        //    _curMainWindow = null;
        //}

        public void CloseCurrentFloatWindow()
        {
            _curFloatWindow?.WindowView?.Close();
            _curFloatWindow = null;
            _curMainWindow.WindowView.Focus();
        }

        private void CloseCurrentSubWindow()
        {
            if (_curMainWindow != null)
            {
                var contentControl = FindContentControl(_curMainWindow.WindowView);

                if (contentControl != null)
                    contentControl.Content = null;
            }

            _curSubWindow = null;
        }

        private T GetWindow<T>(Enum registry) where T : class
        {
            if (registry is WindowRegistry windowRegistry)
            {
                if (_windowFactories.TryGetValue(windowRegistry, out var window))
                {
                    return window() as T;
                }
            }
            if (registry is WindowSubRegistry windowSubRegistry)
            {
                if (_windowSubFactories.TryGetValue(windowSubRegistry, out var window))
                {
                    return window() as T;
                }
            }
            return null!;
        }

        private ContentControl FindContentControl(DependencyObject depObj)
        {
            var contentControl = FindVisualChildHlp.FindVisualChild<ContentControl>(depObj, "ContentControl_SubWindow");

            if (contentControl != null)
                return contentControl;
            return null;
        }
    }
}