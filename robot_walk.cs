using System.Collections.Generic;
using static System.Console;
using System;

class Maze {
    List<List<char>> maze = new List<List<char>>();
    public void read_maze() {
        string line;
        while ((line = ReadLine()!) != null && line != "") {
            char[] row_arr = line.ToCharArray();
            List<char> row = new List<char>();

            for (int i = 0 ; i < row_arr.Length ; ++i) {
                row.Add(row_arr[i]);
            }
            maze.Add(row);
        }
    }

    public List<List<char>> get_maze() {
        return maze;
    }

    public double[,] init_probs() {
        int rows = maze.Count;
        int cols = maze[0].Count;

        double[,] probs = new double[rows, cols];

        for (int i = 0 ; i < rows ; ++i) {
            for (int j = 0 ; j < cols ; ++j) {
                if (maze[i][j] == 'h') {
                    probs[i,j] = 0;
                }

                if (maze[i][j] == 'g') {
                    probs[i,j] = 1;
                }

                if (maze[i][j] == '.') {
                    probs[i,j] = 0;
                }
            }
        }

        return probs;
    }

    public void print_maze() {
        for (int i = 0; i < maze.Count ; ++i) {
            for (int j = 0; j < maze[i].Count ; ++j) {
                Write(maze[i][j]);
            }
            WriteLine();
        }
    }
}

class Top_Level_Code {

    static void Main() {

        double avg(double[,] probs, (int x, int y) p) {
            int rows = probs.GetLength(0);
            int cols = probs.GetLength(1);

            double sum = 0;
            double count = 0;

            if (p.x > 0) { sum += probs[p.x - 1, p.y]; ++count; }
            if (p.x < rows - 1) { sum += probs[p.x + 1, p.y]; ++count; }
            if (p.y > 0) { sum += probs[p.x, p.y - 1]; ++count; }
            if (p.y < cols - 1) { sum += probs[p.x, p.y + 1]; ++count; }

            return sum / count;
        }


        Maze labyrinth = new Maze();
        labyrinth.read_maze();
        List<List<char>> maze = labyrinth.get_maze();

        double[,] probs = labyrinth.init_probs();
        int rows = probs.GetLength(0);
        int cols = probs.GetLength(1);

        double espilon = 0.000001;
        bool diff_low = false;

        while (diff_low != true) {
            double max_diff = 0;
            for (int i = 0 ; i < rows ; ++i) {
                for (int j = 0 ; j < cols ; ++j) {
                    if (maze[i][j] != 'g' && maze[i][j] != 'h') {
                        double point = probs[i,j];
                        double n_avg = avg(probs, (i, j));

                        double diff = Math.Abs(n_avg - probs[i, j]);

                        if (diff > max_diff) {
                            max_diff = diff;
                        }

                        probs[i,j] = n_avg;
                    }
                }
            }

            if (max_diff < espilon) {
                diff_low = true;
            }
        }
        WriteLine(Math.Round(probs[0,0], 3));
    }
}
