using System;
using System.Collections.Generic;
using static System.Console;
static class List_extensions {
    public static bool all<T>(this List<T> list, Func<T, bool> predicate) {
        foreach (T i in list) {
            if (predicate(i))
                continue;
            else return false;
        }
        return true;
    }

    public static bool any<T>(this List<T> list, Func<T, bool> predicate) {
        foreach (T i in list) {
            if (predicate(i))
                return true;
        }
        return false;
    }

    public static bool find<T>(this List<T> list, Func<T, bool> predicate, out string? found) {
        foreach (T i in list) {
            if (predicate(i)) {
                found = i!.ToString();
                return true;
            }
        }
        found = "not found";
        return false;
    }

    public static List<T> filter<T>(this List<T> list, Func<T, bool> predicate) {
        List<T> found_list = new();

        foreach (T i in list) {
            if (predicate(i)) {
                found_list.Add(i);
            }
        }
        return found_list;
    }
}

class Top {
    static bool compare(int a, string comp_op, int b) {
        switch (comp_op) {
            case "<":
                return a < b;
            case "<=":
                return a <= b;
            case "==":
                return a == b;
            case "!=":
                return a != b;
            case ">":
                return a > b;
            case ">=":
                return a >= b;
            default:
                throw new ArgumentException("Operator is invalid");
        }
    }

    static void use_method(List<int> list, string cmd, string op, string arg) {
        int comp_num = int.Parse(arg); 
        string found;

        switch (cmd) {
            case "all":
                WriteLine(list.all(i => compare(i, op, comp_num)));
                return;
            case "any":
                WriteLine(list.any(i => compare(i, op, comp_num)));
                return;
            case "find":
                list.find(i => compare(i, op, comp_num), out found!);
                WriteLine(found);
                return;
            case "filter":
                List<int> filter_list = list.filter(i => compare(i, op, comp_num));
                for (int i = 0 ; i < filter_list.Count ; ++i) {
                    Write(filter_list[i]);
                    Write(' ');
                }
                WriteLine();
                return;
            default: 
                WriteLine("Command is Invalid");
                return;
        }
    }

    static void Main() {
        // Turning first line into a list
        string first_line = ReadLine()!;
        string[] numbers = first_line.Split();
        List<int> list = new();
        foreach (string i in numbers) {
            list.Add(int.Parse(i));
        }

        string line;
        while ((line = ReadLine()!) != null && line != "") {
            WriteLine(line);
            string[] formatted_line = line.Split();

            use_method(list, formatted_line[0], formatted_line[1], formatted_line[2]);
        }
    }
}
