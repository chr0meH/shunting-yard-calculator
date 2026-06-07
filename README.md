# Shunting-Yard Expression Evaluator & Math Parser

A robust, custom-built mathematical expression parser and evaluator developed in C#. This project goes beyond basic calculations by functioning as a lightweight math interpreter, implementing the Shunting-Yard algorithm alongside dynamic variable assignment.

## 🚀 Key Features

* **Algorithmic Parsing:** Utilizes the **Shunting-Yard algorithm** to accurately parse complex mathematical expressions, correctly handling operator precedence (`+`, `-`, `*`, `/`, `^`) and nested parentheses.
* **Variable State Management:** Supports dynamic variable assignment and evaluation (e.g., `x = 10`, `y = x * 2`). The interpreter maintains a custom symbol table that can store and retrieve up to 10 distinct variables during runtime.
* **Custom Data Structures:** Engineered from scratch without relying on standard `.NET` generic collections for the core logic. Features custom, optimized implementations of **Stack**, **Queue**, and **ArrayList** to manage tokenization and evaluate the abstract syntax tree.
* **Robust Error Handling:** Includes built-in exception handling for edge cases such as division by zero, undefined variables, and symbol table overflow, providing clear, color-coded console feedback to the user.

## 🛠️ Tech Stack & Skills Highlighted

* **Language:** C#
* **Core Concepts:** Algorithm Design (Parsing/Evaluation), Custom Data Structures, State Management, Object-Oriented Programming (OOP), Exception Handling.

## 💻 How to Use

Simply run the console application and input your mathematical expressions or variable assignments:
```text
Введіть вираз: x = 15
15
Введіть вираз: y = x * 2
30
Введіть вираз: (y + x) / 5
9
