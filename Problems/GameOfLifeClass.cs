using System.Collections.Generic;

public class GameOfLifeClass
{
    private readonly List<Point> _points = new List<Point>();
    private int[][] _original = null;
    private int[][] _board = null;

    public void GameOfLife(int[][] board)
    {
        this._board = board;
        _original = new int[board.Length][];
        CloneBoard();
        for (var i = 0; i < board.Length; i++)
        {
            for (var j = 0; j < board[i].Length; j++)
            {
                GetNextState(i, j);
            }
        }
    }

    public void CloneBoard()
    {
        var i = 0;
        foreach (var arr in _board)
        {
            _original[i] = new int[arr.Length];
            var j = 0;
            foreach (var num in arr)
            {
                _original[i][j++] = num;
            }
            i++;
        }
    }

    private void GetNextState(int i, int j)
    {
        if (_original[i][j] == 1 && GetLiveNeighbors(i, j) < 2)
        {
            _board[i][j] = 0;
        }

        else if (_original[i][j] == 1 && GetLiveNeighbors(i, j) < 4)
        {
            _board[i][j] = 1;
        }

        else if (_original[i][j] == 1 && GetLiveNeighbors(i, j) > 3)
        {
            _board[i][j] = 0;
        }

        else if (_original[i][j] == 0 && GetLiveNeighbors(i, j) == 3)
        {
            _board[i][j] = 1;
        }
    }

    private int GetLiveNeighbors(int i, int j)
    {
        var count = 0;
        var northWest = new Point(i - 1, j - 1);
        var west = new Point(i, j - 1);
        var southWest = new Point(i + 1, j - 1);
        var south = new Point(i + 1, j);
        var southEast = new Point(i + 1, j + 1);
        var east = new Point(i, j + 1);
        var northEast = new Point(i - 1, j + 1);
        var north = new Point(i - 1, j);
        _points.Add(northWest);
        _points.Add(west);
        _points.Add(southWest);
        _points.Add(south);
        _points.Add(southEast);
        _points.Add(east);
        _points.Add(northEast);
        _points.Add(north);
        foreach (var p in _points)
        {
            if (p.i >= 0 && p.j >= 0)
            {
                if (p.i < _original.Length && p.j < _original[p.i].Length)
                {
                    if (_original[p.i][p.j] == 1)
                        count++;
                }
            }
        }
        _points.Clear();
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