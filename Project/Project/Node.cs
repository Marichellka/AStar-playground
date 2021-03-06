namespace Project
{
    public class Node
    {
        private bool Barrier { get; } 
        private int Cost { get; set; }
        private int X = 0;
        private int Y = 0;
        private bool Marked { get; set; }
        private Node Parent { get; set; }

        public Node(int column, int row, char elem)
        {
            X = column;
            Y = row;
            if (elem == 'X') Barrier = true;
            else Barrier = false;
        } 
    }
}