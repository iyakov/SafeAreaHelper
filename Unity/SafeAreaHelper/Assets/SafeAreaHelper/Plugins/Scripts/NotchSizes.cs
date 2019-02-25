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
            return $"({Left};{Top};{Right};{Bottom})";
        }

        public override int GetHashCode()
        {
            int hashCode = -1819631549;
            hashCode = hashCode * -1521134295 + Left.GetHashCode();
            hashCode = hashCode * -1521134295 + Top.GetHashCode();
            hashCode = hashCode * -1521134295 + Right.GetHashCode();
            hashCode = hashCode * -1521134295 + Bottom.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object other)
        {
            return other is NotchSizes sizes &&
                   Left == sizes.Left &&
                   Top == sizes.Top &&
                   Right == sizes.Right &&
                   Bottom == sizes.Bottom;
        }

        public static bool operator ==(NotchSizes left, NotchSizes right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NotchSizes left, NotchSizes right)
        {
            return !(left == right);
        }
    }
}
