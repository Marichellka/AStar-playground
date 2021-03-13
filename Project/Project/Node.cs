namespace Project
{
    public class Node
    {
        public bool Barrier { get; } 
        public int Cost { get; set; }
        public int EstimatedCost{ get; set; }
        public int X { get; }
        public int Y { get; }
        public bool Marked { get; set; }
        public Node Parent { get; set; }
        public char Sign { get; set; }

        public Node(int column, int row, char elem)
        {
            X = column;
            Y = row;
            Sign = elem;
            if (elem == 'X')
            {
                Barrier = true;
            }
            else
            {
                Barrier = false;
            }
        } 
    }
}