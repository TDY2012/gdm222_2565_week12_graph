class GraphEdge<T>
{
    private GraphNode<T> src;
    private GraphNode<T> dst;
    private double weight;

    public GraphEdge(GraphNode<T> src, GraphNode<T> dst, double weight)
    {
        this.src = src;
        this.dst = dst;
        this.weight = weight;
    }

    public GraphNode<T> GetSrc()
    {
        return this.src;
    }

    public GraphNode<T> GetDst()
    {
        return this.dst;
    }

    public double GetWeight()
    {
        return this.weight;
    }

    public override string ToString()
    {
        return string.Format("GraphEdge( {0} --{1}--> {2} )", this.GetSrc(), this.GetWeight(), this.GetDst());
    }
}