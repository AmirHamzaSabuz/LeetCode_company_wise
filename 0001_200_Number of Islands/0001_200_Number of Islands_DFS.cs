


using System;

namespace IslandsCounter
{
	public class Solution
	{
		public int NumIslands(char[][] grid)
		{
			int rows = grid.Length;
			int cols = grid[0].Length;
			int count = 0;

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					if (grid[row][col] == '1')
					{
						DFS(grid, row, col);
						count++;
					}
				}
			}

			return count;
		}

		private void DFS(char[][] grid, int row, int col)
		{
			if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length || grid[row][col] == '0')
			{
				return;
			}

			grid[row][col] = '0'; // Mark visited

			DFS(grid, row - 1, col); // Up
			DFS(grid, row + 1, col); // Down
			DFS(grid, row, col - 1); // Left
			DFS(grid, row, col + 1); // Right
		}
	}
	
    class Program
    {
        static void Main(string[] args)
        {
            // Example grid with islands represented by '1'
            char[][] grid = new char[][]
            {
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '0', '0', '1', '0', '0' },
                new char[] { '0', '0', '0', '1', '1' }
            };

            Solution solution = new Solution();
            int numIslands = solution.NumIslands(grid);

            Console.WriteLine("Number of islands: " + numIslands);
        }
    }
}

