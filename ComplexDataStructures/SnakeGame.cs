using System;
using System.Collections.Generic;
using System.Linq;

namespace ComplexDataStructures
{

    public class SnakeGame
    {

        /** Initialize your data structure here.
            @param width - screen width
            @param height - screen height 
            @param food - A list of food positions
            E.g food = [[1,1], [1,0]] means the first food is positioned at [1,1], the second is at [1,0]. */
        readonly char[,] board;
        readonly int[,] food;
        int score;
        int nextFoodIndex;
        Tuple<int, int> snakeTail;
        int r;
        int c;
        readonly int w;
        readonly int h;
        public SnakeGame(int width, int height, int[,] food)
        {
            w = width;
            h = height;
            board = new char[h, w];
            score = 0;
            this.food = food;
            board[0, 0] = 'S';
            snakeTail = new Tuple<int, int>(0, 0);
            r = 0;
            c = 0;
            nextFoodIndex = 0;
        }

        /** Moves the snake.
            @param direction - 'U' = Up, 'L' = Left, 'R' = Right, 'D' = Down 
            @return The game's score after the move. Return -1 if game over. 
            Game over when snake crosses the screen boundary or bites its body. */
        public int Move(string direction)
        {
            if (direction == "U")
            {
                r = r - 1;
            }
            else if (direction == "D")
            {
                r = r + 1;
            }
            else if (direction == "R")
            {
                c = c + 1;
            }
            else
            {
                c = c - 1;
            }
            return CheckProgress(r, c);
        }

        private int CheckProgress(int row, int col)
        {
            Console.WriteLine("Row: " + row + " " + "Col: " + col);
            Console.WriteLine("Next Food: " + food[nextFoodIndex, 0] + ", " + food[nextFoodIndex, 1]);
            if (IsGameOver(row, col))
            {
                return -1;
            }
            else if (food[nextFoodIndex, 0] == row && food[nextFoodIndex, 1] == col)
            {
                score++;
                board[row, col] = 'S';
                nextFoodIndex++;
                return score;
            }
            else
            {
                board[row, col] = 'S';
                int oldTailX = snakeTail.Item1;
                int oldTailY = snakeTail.Item2;
                board[oldTailX, oldTailY] = default(char);
                return score;
            }
        }

        private bool IsGameOver(int row, int col)
        {
            return (row >= h) || (col >= w) || (col < 0) || (row < 0) || IsBodyBitten(row, col);
        }

        private bool IsBodyBitten(int row, int col)
        {
            return board[row, col] == 'S';
        }
    }
}

/**
 * Your SnakeGame object will be instantiated and called as such:
 * SnakeGame obj = new SnakeGame(width, height, food);
 * int param_1 = obj.Move(direction);
 */
