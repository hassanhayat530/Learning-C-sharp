using static System.Console;
using System.Collections.Generic;

class type_setting {

    static void print_word(List<char> word) {

        for (int i = 0; i < word.Count; i++) {
            Write(word[i]);
        }
    }
    static void Main() {

        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        List<char> curr_word = new();
        int num_chars = 0;
        int max_chars = 30;

        while (ReadLine() is string line) {
            line = line + '\n';

            foreach (char c in line) {

                if (alphabet.Contains(c)) {
                    curr_word.Add(c);
                    num_chars++;
                }
                else {
                    print_word(curr_word);
                    if (curr_word.Count > max_chars) {
                        WriteLine();
                        num_chars = 0;
                        curr_word.Clear();
                    }
                    if (curr_word.Count != 0) {
                        Write(" ");
                        num_chars++;
                    }
                    curr_word.Clear();
                    continue;
                }

                if (num_chars > max_chars && curr_word.Count <= max_chars) {
                    WriteLine();
                    num_chars = curr_word.Count;
                }
            }
        }    
    }
}


