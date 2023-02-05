using Game.Presenters;

namespace Game.Src.Game.Services
{
    public static class Screens
    {
        public static readonly Screen MainMenu = new Screen("Assets/UI/Menu.uxml", typeof(MenuPresenter), 0);
        public static readonly Screen Options = new Screen("Assets/UI/Options.uxml", typeof(OptionsPresenter), 0);
        public static readonly Screen HUD = new Screen("Assets/UI/InGameHUD.uxml", typeof(InGameHUDPresenter), 0);
        public static readonly Screen EndGame = new Screen("Assets/UI/EndGame.uxml", typeof(EndGamePresenter), 0);
    }

}