using System.Collections.Generic;

public class GameOfLifeClass
{
    List<Point> points = new List<Point>();
    int[][] original = null;
    int[][] board = null;

    public void GameOfLife(int[][] board)
    {
        this.board = board;
        original = new int[board.Length][];
        CloneBoard();
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                GetNextState(i, j);
            }
        }
    }

    public void CloneBoard()
    {
        int i = 0;
        foreach (int[] arr in board)
        {
            original[i] = new int[arr.Length];
            int j = 0;
            foreach (int num in arr)
            {
                original[i][j++] = num;
            }
            i++;
        }
    }

    private void GetNextState(int i, int j)
    {
        if (original[i][j] == 1 && GetLiveNeighbors(i, j) < 2)
        {
            board[i][j] = 0;
        }

        else if (original[i][j] == 1 && GetLiveNeighbors(i, j) < 4)
        {
            board[i][j] = 1;
        }

        else if (original[i][j] == 1 && GetLiveNeighbors(i, j) > 3)
        {
            board[i][j] = 0;
        }

        else if (original[i][j] == 0 && GetLiveNeighbors(i, j) == 3)
        {
            board[i][j] = 1;
        }
    }

    private int GetLiveNeighbors(int i, int j)
    {
        int count = 0;
        Point northWest = new Point(i - 1, j - 1);
        Point west = new Point(i, j - 1);
        Point southWest = new Point(i + 1, j - 1);
        Point south = new Point(i + 1, j);
        Point southEast = new Point(i + 1, j + 1);
        Point east = new Point(i, j + 1);
        Point northEast = new Point(i - 1, j + 1);
        Point north = new Point(i - 1, j);
        points.Add(northWest);
        points.Add(west);
        points.Add(southWest);
        points.Add(south);
        points.Add(southEast);
        points.Add(east);
        points.Add(northEast);
        points.Add(north);
        foreach (Point p in points)
        {
            if (p.i >= 0 && p.j >= 0)
            {
                if (p.i < original.Length && p.j < original[p.i].Length)
                {
                    if (original[p.i][p.j] == 1)
                        count++;
                }
            }
        }
        points.Clear();
        return count;
    }
}

public class Point
{
    public int i;
    public int j;

    public Point(int i, int j)
    {
        this.i = i;
        this.j = j;
    }
}