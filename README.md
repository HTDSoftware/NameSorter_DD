# NameSorter

A simple yet SOLID, testable, and maintainable console application for sorting names.  
Developed for the Dye & Durham coding challenge to demonstrate thoughtful design, code clarity, and team empathy.

---

## 💡 Problem

Given a list of names (each consisting of a surname followed by up to three given names), the application sorts the names:

- Primarily by **surname**
- Secondarily by the concatenated **given names**

---

## 🧠 Purpose of the Challenge

The goal is not to write a trivial sorting algorithm, but to:

- Write code that communicates its purpose clearly and empathetically
- Apply SOLID principles appropriately, without over-engineering
- Design for readability, clarity, and future maintainability
- Demonstrate effective and meaningful test coverage

---

## 🏗️ Project Structure

```NameSorter.sln │ ├── NameSorter.Core # Domain models and services │ ├── Models/ # Person model │ ├── Services/ # Parser, Sorter, Processor │ └── IO/ # Output writers (file, console, composite) │ ├── NameSorter.Console # Entry point (AppRunner + Program) │ └── NameSorter.Tests # xUnit + NSubstitute test project```

## 📥 Getting Started

1. **Clone the repository**:

    ```bash
    git clone https://github.com/your-username/NameSorter.git
    cd NameSorter
    ```

2. **Restore dependencies**:

    ```bash
    dotnet restore
    ```

3. **Build the solution**:

    ```bash
    dotnet build
    ```

4. **Run the application** (see below for usage):
---

## 🚀 How to Run

### 🛠 Prerequisites

- [.NET 6 SDK or later](https://dotnet.microsoft.com/en-us/download)

### ▶️ Running the App

1. Create a text file, e.g. `unsorted-names-list.txt`:

    ```
     Janet Parsons
     Vaughn Lewis
     Adonis Julius Archer
     Shelby Nathan Yoder
     Marin Alvarez
     London Lindsey
     Beau Tristan Bentley
     Leo Gardner
     Hunter Uriah Mathew Clarke
     Mikayla Lopez
     Frankie Conner Ritter
    ```

2. From the solution root 
(I acknowledge here that the remit says executing the program in the following way; name-sorter ./unsorted-names-list.txt):

    ```bash
    ./NameSorter_DD.Console.exe ./unsorted-names-list.txt
    ```

3. Output will be written to:

    - The **console**
    - A file called `sorted-names-list.txt`

---

## ✅ Example Input

    ```
     Janet Parsons
     Vaughn Lewis
     Adonis Julius Archer
     Shelby Nathan Yoder
     Marin Alvarez
     London Lindsey
     Beau Tristan Bentley
     Leo Gardner
     Hunter Uriah Mathew Clarke
     Mikayla Lopez
     Frankie Conner Ritter
    ```


### 📤 Output (console + sorted-names-list.txt)

    ```
     Marin Alvarez
     Adonis Julius Archer
     Beau Tristan Bentley
     Hunter Uriah Mathew Clarke
     Leo Gardner
     Vaughn Lewis
     London Lindsey
     Mikayla Lopez
     Janet Parsons
     Frankie Conner Ritter
     Shelby Nathan Yoder
     ```
---

## 🔍 Design Principles

This solution emphasizes:

- **Single Responsibility**: each class does one clear thing
- **Open/Closed Principle**: easy to extend (e.g., new output format)
- **Minimal, appropriate abstraction**: DI used only where it adds clarity
- **Empathy**: code is clean, self-explanatory, and easy to modify

---

## 🧪 Tests

Tests are written using [xUnit](https://xunit.net/) and [NSubstitute](https://nsubstitute.github.io/).

### 🔬 Test Coverage Includes:

| Test Type | What it Validates |
|-----------|-------------------|
| Unit tests | `NameParser`, `NameSorter`, `NameProcessor` |
| End-to-End tests | Full app run via `AppRunner` with real file I/O |

### ▶️ Run tests:

```bash
dotnet test

🧼 Example: End-to-End Test Validates Full Pipeline
Writes to sorted-names-list.txt

Runs the app with AppRunner

Asserts that sorted-names-list.txt is created with expected content

Cleans up all files after execution

🙌 Final Thoughts
This solution reflects how I'd write production-ready code with clarity, empathy, and testability in mind — all while staying lean and focused.

Thanks for the opportunity!