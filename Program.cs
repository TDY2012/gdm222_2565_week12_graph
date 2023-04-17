using System;

class Program
{
    static void Main(string[] args)
    {
        Graph<string> g = new Graph<string>();
        g.AddNode("A");
        g.AddNode("B");
        g.AddNode("C");
        g.InsertNode(2, "D");
        g.AddEdge(0, 1, 1);
        g.AddEdge(0, 3, 1);
        g.AddEdge(1, 2, 1);
        g.AddEdge(3, 2, 1);
        g.RemoveNode(1);

        Console.WriteLine("Part 1: ");
        for(int i=0; i<g.GetNodeCount(); i++)
        {
            Console.WriteLine(g.GetNode(i));
        }

        Console.WriteLine("Part 2: ");
        LinkedList<string> nodeValueList = g.GetAllNode();
        for(int i=0; i<nodeValueList.GetLength(); i++)
        {
            Console.WriteLine(nodeValueList.Get(i));
        }
    }
}