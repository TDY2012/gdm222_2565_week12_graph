class Graph<T>
{
    private GraphNode<T> head = null;
    private int length = 0;

    public void AddNode(T value, double weight)
    {
        GraphNode<T> graphNode = new GraphNode<T>(value);
        if(this.head == null)
        {
            this.head = graphNode;
        }
        else
        {
            GraphNode<T> ptr = this.GetGraphNode(this.length - 1);
            ptr.MakeOutGraphEdge(graphNode, weight);
        }
        this.length++;
    }

    public void InsertNode(int index, T value, double weight)
    {
        GraphNode<T> graphNode = new GraphNode<T>(value);
        if(index == 0)
        {
            graphNode.MakeOutGraphEdge(this.head, weight);
            this.head = graphNode;
        }
        else
        {
            GraphNode<T> ptr = this.GetGraphNode(index - 1);
            ptr.InsertOutGraphEdge(0, graphNode, weight);
        }
        this.length++;
    }

    //  Depth-frist traverse.
    private GraphNode<T> Traverse(GraphNode<T> ptr, ref int iteration, ref LinkedList<GraphNode<T>> visitedNodeList)
    {
        visitedNodeList.Add(ptr);

        if(iteration <= 0)
        {
            return ptr;
        }
        
        GraphNode<T> nextPtr;

        //  Recursive across outgoing graph edges.
        LinkedList<GraphEdge<T>> ptrOutGraphEdge = ptr.GetOutGraphEdge();
        for(int i=0; i<ptrOutGraphEdge.GetLength(); i++)
        {
            nextPtr = ptrOutGraphEdge.Get(i).GetDst();
            
            bool isVisited = false;
            for(int j=0; j<visitedNodeList.GetLength(); j++)
            {
                if(visitedNodeList.Get(j) == nextPtr)
                {
                    isVisited = true;
                    break;
                }
            }

            if(isVisited)
            {
                continue;
            }

            iteration--;
            ptr = this.Traverse(nextPtr, ref iteration, ref visitedNodeList);

            if(iteration <= 0)
            {
                return ptr;
            }
        }

        //  Recursive across incoming graph edges.
        LinkedList<GraphEdge<T>> ptrInGraphEdge = ptr.GetInGraphEdge();
        for(int i=0; i<ptrInGraphEdge.GetLength(); i++)
        {
            nextPtr = ptrInGraphEdge.Get(i).GetDst();
            
            bool isVisited = false;
            for(int j=0; j<visitedNodeList.GetLength(); j++)
            {
                if(visitedNodeList.Get(j) == nextPtr)
                {
                    isVisited = true;
                    break;
                }
            }

            if(isVisited)
            {
                continue;
            }

            iteration--;
            ptr = this.Traverse(nextPtr, ref iteration, ref visitedNodeList);

            if(iteration <= 0)
            {
                return ptr;
            }
        }

        return ptr;
    }

    private GraphNode<T> GetGraphNode(int index)
    {
        GraphNode<T> ptr = this.head;
        int iteration = index;
        LinkedList<GraphNode<T>> visitedNodeList = new LinkedList<GraphNode<T>>();
        return this.Traverse(ptr, ref iteration, ref visitedNodeList);
    }

    public T Get(int index)
    {
        return this.GetGraphNode(index).GetValue();
    }

    public int GetLength()
    {
        return this.length;
    }
}