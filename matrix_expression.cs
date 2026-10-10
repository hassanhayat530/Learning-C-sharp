using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO.Compression;
using System.Net.Http;
using System.Xml.XPath;
using static System.Console;

class matrix_stack {
    Matrix[] a;
    int n;

    public matrix_stack(int limit) {
        a = new Matrix[limit];
    }

    public int count => n;

    public void push(Matrix i) {
        a[n++] = i;
    }

    public Matrix pop() => a[--n];

    public Matrix this[int i] => a[n - 1 - i];

    public static bool operator ! (matrix_stack s) =>
        s.count == 0;
}

class Matrix {
    public int N;
    public int[,] matrix;

    public Matrix(int n) {
        this.N = n;
        this.matrix = new int[n, n];
    }

    public void read() {
        for (int i = 0 ; i < N ; ++i) {
            string[] row = ReadLine()!.Split(' ');
            for (int j = 0 ; j < N ; ++j) {
                matrix[i, j] = int.Parse(row[j]);
            }
        }
    }

    public static Matrix operator + (Matrix x, Matrix y) {
        int n = x.N;
        Matrix z = new Matrix(n);

        for (int i = 0; i < n ; ++i) {
            for (int j = 0; j < n ; ++j) {
                z.matrix[i, j] = x.matrix[i, j] + y.matrix[i, j];
            }
        }

        return z;
    }

    public static Matrix operator - (Matrix x, Matrix y) {
        int n = x.N;
        Matrix z = new Matrix(n);

        for (int i = 0; i < n ; ++i) {
            for (int j = 0; j < n ; ++j) {
                z.matrix[i, j] = x.matrix[i, j] - y.matrix[i, j];
            }
        }

        return z;
    }

    public static Matrix operator * (Matrix x, Matrix y) {
        int n = x.N;
        Matrix z = new Matrix(n);

        for (int i = 0; i < n ; ++i) {
            for (int j = 0; j < n ; ++j) {
                for (int k = 0; k < n ; ++k) {
                    z.matrix[i, j] += x.matrix[i, k] * y.matrix[k, j];
                }
            }
        }

        return z;
    }

    public void print() {
        for (int i = 0; i < this.N ; ++i) {
            for (int j = 0; j < this.N; ++j) {
                Write(this.matrix[i,j]);
                if (j != this.N - 1) {
                    Write(' ');
                }
            }
            WriteLine();
        }
    }
}

class TopLevel {

    static Matrix? postfix_eval(string op, Matrix x, Matrix y) {
        switch (op) {
            case "+":
                return x + y;
            case "-":
                return x - y;
            case "*":
                return x * y;
            default:
                return null;
        }
    }

    static void Main() {
        string[] first_line = ReadLine()!.Split(' ');

        int N = int.Parse(first_line[0]);
        int M = int.Parse(first_line[1]);

        Matrix[] matrices = new Matrix[M];

        for (int i = 0; i < M ; ++i) {
            matrices[i] = new Matrix(N);
            matrices[i].read();
            ReadLine();
        }

        string[] postfix = ReadLine()!.Split(' ');
        matrix_stack postfix_stack = new matrix_stack(postfix.Length);

        for (int i = 0; i < postfix.Length; ++i) {
            if (postfix[i] == "+" || postfix[i] == "-" || postfix[i] == "*") {
                string op = postfix[i];
                Matrix y = postfix_stack.pop();
                Matrix x = postfix_stack.pop();
                Matrix z = postfix_eval(op, x, y)!;
                postfix_stack.push(z);
            }
            else {
                postfix_stack.push(matrices[int.Parse(postfix[i]) - 1]);
            }
        }

        Matrix result = postfix_stack.pop();
        result.print();
    }
}
