using Game.Src.Game.Services;

namespace Game.Src.Game
{
    public class GameServices
    {
        public UIService UI { get; set; }
        public GameState State { get; set; }

        public AudioService Audio { get; set; }
    }
}