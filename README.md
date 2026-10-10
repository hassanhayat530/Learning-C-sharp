# Beginner C# Assignments

A collection of beginner C# assignments. Each file is a standalone script that runs on its own, with no dependencies beyond the .NET standard library and no other files from this repository.

## Programs

| File | Description |
|---|---|
| `number_wheel.cs` | Reads N (0 to 100) and computes the exact probability that a 10-number wheel, spun three times by a random 0 to N positions each, returns to its starting position. The answer is printed as a reduced fraction. |
| `typesetting.cs` | Reads text, extracts the words (runs of Latin letters), and prints them with as many words per line as fit in 30 characters. A word longer than 30 letters gets its own line. |
| `robot_walk.cs` | Reads a maze of empty squares, holes, and goals, and prints the probability that a robot walking randomly from the top-left corner reaches a goal before falling into a hole. Solved iteratively, with the result rounded to 3 decimals. |

## Classes and Generics

| File | Description |
|---|---|
| `rectangle_class.cs` | Defines a `Rectangle` class with integer corner coordinates and methods for perimeter, area, containment, overlap, and intersection. |
| `hands_of_cards.cs` | Defines `Card` and `Hand` classes for 5-card poker hands and a `compare` method that ranks four of a kind, three of a kind, pair, and no pair. |
| `matrix_expression.cs` | Defines a square integer `Matrix` class with overloaded `+`, `-`, and `*`, then uses it to evaluate postfix expressions over matrices read from input. |
| `conditions.cs` | Defines generic extension methods `all`, `any`, `find`, and `filter` on `List<T>`, then uses them to run commands such as `filter < 20` against a list of integers. |

## Running

`number_wheel.cs`, `typesetting.cs`, and `robot_walk.cs` read from standard input and write to standard output. `matrix_expression.cs` and `conditions.cs` do the same for their input-driven tasks.

`rectangle_class.cs` and `hands_of_cards.cs` only define classes. They have no `Main` method (and must not have one), so they need a separate test program to try them out. `hands_of_cards.cs` must also stay in the default namespace.

## Notes

These assignments were written for an automatic grader, so the input scripts read input without printing prompts.
