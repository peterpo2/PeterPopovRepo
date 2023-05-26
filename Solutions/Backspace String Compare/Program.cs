namespace Backspace_String_Compare
{
    internal class Program
    {
        public bool BackspaceCompare(string S, string T)
        {
            Stack<char> s1 = new Stack<char>(),
                        s2 = new Stack<char>();

            foreach (var c in S)
                if (c != '#')
                    s1.Push(c);
                else if (s1.Count > 0)
                    s1.Pop();

            foreach (var c in T)
                if (c != '#')
                    s2.Push(c);
                else if (s2.Count > 0)
                    s2.Pop();

            if (s1.Count != s2.Count)
                return false;

            while (s1.Count > 0)
                if (s1.Pop() != s2.Pop())
                    return false;

            return true;
        }
    }
}