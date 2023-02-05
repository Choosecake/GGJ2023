using System;

namespace Game.Src.Game.Services
{
    public class Screen
    {
        public int Layer { get; }
        public String DocumentPath { get; }
        public Type Presenter { get; }


        public Screen(string documentPath, Type presenter, int layer)
        {
            DocumentPath = documentPath;
            Presenter = presenter;
            Layer = layer;
        }
    }
}