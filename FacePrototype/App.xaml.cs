namespace FacePrototype
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new MainPage()) { Title = "FacePrototype" };
            window.MinimumHeight = 540; // set minimal window height
            window.MinimumWidth = 960; // set minimal window width
            return window;
        }
    }
}
