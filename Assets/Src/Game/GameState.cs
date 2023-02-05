namespace Game.Src.Game
{
    public enum States
    {
        Boot,
        Menu,
        Game,
        Lost
    }

    public class GameState
    {
        public delegate void OnStateChangeHandle(States before, States after);

        public OnStateChangeHandle OnStateChange;


        private States _state = States.Boot;


        public void Transition(States st)
        {
            OnStateChange?.Invoke(_state, st);
            _state = st;
        }
    }
}