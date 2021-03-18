using System;

namespace ComplexDataStructures
{

    public class SnakeGame
    {

        /** Initialize your data structure here.
            @param width - screen width
            @param height - screen height 
            @param food - A list of food positions
            E.g food = [[1,1], [1,0]] means the first food is positioned at [1,1], the second is at [1,0]. */
        private readonly char[,] _board;

        private readonly int[,] _food;
        private int _score;
        private int _nextFoodIndex;
        private readonly Tuple<int, int> _snakeTail;
        private int _r;
        private int _c;
        private readonly int _w;
        private readonly int _h;
        public SnakeGame(int width, int height, int[,] food)
        {
            _w = width;
            _h = height;
            _board = new char[_h, _w];
            _score = 0;
            this._food = food;
            _board[0, 0] = 'S';
            _snakeTail = new Tuple<int, int>(0, 0);
            _r = 0;
            _c = 0;
            _nextFoodIndex = 0;
        }

        /** Moves the snake.
            @param direction - 'U' = Up, 'L' = Left, 'R' = Right, 'D' = Down 
            @return The game's score after the move. Return -1 if game over. 
            Game over when snake crosses the screen boundary or bites its body. */
        public int Move(string direction)
        {
            if (direction == "U")
            {
                _r = _r - 1;
            }
            else if (direction == "D")
            {
                _r = _r + 1;
            }
            else if (direction == "R")
            {
                _c = _c + 1;
            }
            else
            {
                _c = _c - 1;
            }
            return CheckProgress(_r, _c);
        }

        private int CheckProgress(int row, int col)
        {
            Console.WriteLine("Row: " + row + " " + "Col: " + col);
            Console.WriteLine("Next Food: " + _food[_nextFoodIndex, 0] + ", " + _food[_nextFoodIndex, 1]);
            if (IsGameOver(row, col))
            {
                return -1;
            }

            if (_food[_nextFoodIndex, 0] == row && _food[_nextFoodIndex, 1] == col)
            {
                _score++;
                _board[row, col] = 'S';
                _nextFoodIndex++;
                return _score;
            }
            _board[row, col] = 'S';
            var oldTailX = _snakeTail.Item1;
            var oldTailY = _snakeTail.Item2;
            _board[oldTailX, oldTailY] = default(char);
            return _score;
        }

        private bool IsGameOver(int row, int col)
        {
            return (row >= _h) || (col >= _w) || (col < 0) || (row < 0) || IsBodyBitten(row, col);
        }

        private bool IsBodyBitten(int row, int col)
        {
            return _board[row, col] == 'S';
        }
    }
}

/**
 * Your SnakeGame object will be instantiated and called as such:
 * SnakeGame obj = new SnakeGame(width, height, food);
 * int param_1 = obj.Move(direction);
 */
