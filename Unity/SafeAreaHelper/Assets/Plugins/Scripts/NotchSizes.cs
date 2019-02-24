namespace FGOL.SafeAreaHelper
{
    public struct NotchSizes
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public override string ToString()
        {
            return $"({Left},{Top},{Right},{Bottom})";
        }
    }
}
