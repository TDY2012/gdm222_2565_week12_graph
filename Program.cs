using System;

class Program
{
    static void Main(string[] args)
    {
        Graph<string> g = new Graph<string>();
        g.AddNode("hello", -1);
        g.AddNode("world", 1);
        g.InsertNode(1, "new", 2);

        for(int i=0; i<g.GetLength(); i++)
        {
            Console.WriteLine(g.Get(i));
        }
    }
}