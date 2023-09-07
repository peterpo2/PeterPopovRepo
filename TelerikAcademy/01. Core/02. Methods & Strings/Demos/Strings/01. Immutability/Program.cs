using System;

class Program
{
    static void Main()
    {
        string s1 = "abc";
        Console.WriteLine($"s1: {s1}");

        string s2 = s1;
        Console.WriteLine($"s2: {s2}");
        Console.WriteLine("Are s1 and s2 pointing to the same memory address?");
        bool sameMemoryUsed = Object.ReferenceEquals(s1, s2);
        Console.WriteLine($" {sameMemoryUsed} ");

        // Update s2
        s2 = s2 + "d";
        Console.WriteLine($"s2 updated to {s2}. Will that affect s1?");
        sameMemoryUsed = Object.ReferenceEquals(s1, s2);
        Console.WriteLine($" {sameMemoryUsed} ");

        // Follow this link for more information:
        // https://sharplab.io/#v2:EYLgxg9gTgpgtADwGwBYA0AXEUCuA7NAExAGoAfAAQCYBGAWAChHqACCmgdkYG9GX+2NJGxQsAsgEMAlngAUASj4DeDAWsEAGFgGcaLALwsARBOBgjAbiXrBATlkASI7pAtuugL5H5VpqpuaOlQGOjS+AXaOzlSu7lRePtbq7PbOehJ4hEEsErAsAA4QMhgyAOYsGBAVABYwOhIAtnVNDdAAnjmEhLDa2t7hAdQArLpoQYn+NtrBhtMsJMaElklqKVFzOPmEEhgwWZVu0x4AdCwA6lIANpc1OzkAZvcwYBihAPz9KwLDo+MD/B5GICGEA===
    }
}
