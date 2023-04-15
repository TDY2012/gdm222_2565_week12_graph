class GraphNode<T>
{
    private T value;
    private LinkedList<GraphEdge<T>> inGraphEdgeList = null;
    private LinkedList<GraphEdge<T>> outGraphEdgeList = null;

    public GraphNode(T value)
    {
        this.SetValue(value);
        this.inGraphEdgeList = new LinkedList<GraphEdge<T>>();
        this.outGraphEdgeList = new LinkedList<GraphEdge<T>>();
    }

    public T GetValue()
    {
        return this.value;
    }

    public void SetValue(T value)
    {
        this.value = value;
    }

    public LinkedList<GraphEdge<T>> GetInGraphEdge()
    {
        return this.inGraphEdgeList.Copy();
    }

    public LinkedList<GraphEdge<T>> GetOutGraphEdge()
    {
        return this.outGraphEdgeList.Copy();
    }

    public void MakeOutGraphEdge(GraphNode<T> dst, double weight)
    {
        this.InsertOutGraphEdge(this.outGraphEdgeList.GetLength(), dst, weight);
    }

    public void AcceptInGraphEdge(GraphEdge<T> graphEdge)
    {
        this.inGraphEdgeList.Add(graphEdge);
    }

    public void InsertOutGraphEdge(int index, GraphNode<T> dst, double weight)
    {
        GraphEdge<T> graphEdge = new GraphEdge<T>(this, dst, weight);
        this.outGraphEdgeList.Insert(index, graphEdge);
        dst.AcceptInGraphEdge(graphEdge);
    }

    public void CutOutGraphEdge(int index)
    {
        GraphEdge<T> graphEdge = this.outGraphEdgeList.Get(index);
        GraphNode<T> dst = graphEdge.GetDst();
        dst.ReleaseInGraphEdge(graphEdge);
        this.outGraphEdgeList.Remove(index);
    }

    public void ReleaseInGraphEdge(GraphEdge<T> graphEdge)
    {
        for(int i=0; i<this.inGraphEdgeList.GetLength(); i++)
        {
            if(this.inGraphEdgeList.Get(i) == graphEdge)
            {
                this.inGraphEdgeList.Remove(i);
                break;
            }
        }
    }

    public override string ToString()
    {
        return string.Format("GraphNode( {0} )", this.GetValue());
    }
}