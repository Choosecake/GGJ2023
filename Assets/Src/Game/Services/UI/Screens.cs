using Game.Presenters;

namespace Game.Src.Game.Services
{
    public static class Screens
    {
        public static readonly Screen MainMenu = new Screen("Assets/UI/Menu.uxml", typeof(MenuPresenter), 0);
        public static readonly Screen Options = new Screen("Assets/UI/Options.uxml", typeof(OptionsPresenter), 0);
    }
}