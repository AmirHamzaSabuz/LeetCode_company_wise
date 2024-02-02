public class Solution
{
    public int NumIslands(char[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int count = 0;

        bool[,] visited = new bool[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (grid[row][col] == '1' && !visited[row, col])
                {
                    count++;
                    BFS(grid, visited, row, col); // Line 28: Corrected parenthesis
                }
            }
        }

        return count;
    }

    private void BFS(char[][] grid, bool[,] visited, int row, int col)
    {
        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((row, col));
        visited[row, col] = true;

        int[] dirR = { 0, 0, 1, -1 };
        int[] dirC = { 1, -1, 0, 0 };

        while (queue.Count > 0)
        {
            (int currRow, int currCol) = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int newRow = currRow + dirR[i];
                int newCol = currCol + dirC[i];

                if (isValid(newRow, newCol, grid.Length, grid[0].Length) &&
                    grid[newRow][newCol] == '1' && !visited[newRow, newCol])
                {
                    queue.Enqueue((newRow, newCol)); // Line 57: Corrected parenthesis
                    visited[newRow, newCol] = true;
                }
            }
        }
    }

    private bool isValid(int row, int col, int rows, int cols)
    {
        return row >= 0 && row < rows && col >= 0 && col < cols;
    }
}
