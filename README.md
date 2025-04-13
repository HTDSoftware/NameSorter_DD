# NameSorter Dye & Durham

A simple yet SOLID, testable, and maintainable console application for sorting names.  

Developed for the Dye & Durham coding challenge to demonstrate thoughtful design, code clarity, and team empathy.

---

## 💡 Problem

Given a list of names (each consisting of up to three given names followed by a surname), the application sorts the names:

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

```
NameSorter.sln
    ├── NameSorter.Console         # Entry point (AppRunner + Program)
    ├── NameSorter.Core            # Domain models and services
        ├── Models/                # Person model
        ├── Services/              # Parser, Sorter, Processor
        └── IO/                    # Output writers (file, console, composite)
    └── NameSorter.Tests           # xUnit + NSubstitute test project
```

---

## 📥 Getting Started

1. **Clone the repository**:

   ```bash
   git clone https://github.com/HTDSoftware/NameSorter_DD.git
   cd NameSorter_DD
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

- [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download)

### ▶️ Running the App

1. Create a text file, e.g., `unsorted-names-list.txt`:

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

2. From the solution root:

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

## 🛠️ GitHub Actions Workflow
This repository uses GitHub Actions for Continuous Integration (CI). The workflow ensures that the codebase maintains high quality by running automated checks such as building the solution and executing tests.

### Key Features:
Build and Test: Automatically builds the solution and runs all tests on each push or pull request.  
Platform Coverage: Ensures compatibility across supported platforms.  

You can view the workflow file in the repository for more details:  
  
    .github/workflows/NameSorter_DD_BuildTest.yml  

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

| Test Type       | What it Validates                         |
|------------------|-------------------------------------------|
| Unit tests       | `NameParser`, `NameSorter`, `NameProcessor` |
| End-to-End tests | Full app run via `AppRunner` with real file I/O |

### ▶️ Run tests:

```bash
dotnet test
```

Example: End-to-End Test Validates Full Pipeline  
- Writes to `sorted-names-list.txt`  
- Runs the app with `AppRunner`  
- Asserts that `sorted-names-list.txt` is created with expected content  
- Cleans up all files after execution  

---

## 🙌 Final Thoughts

### Below is the section of the remit which determined the majority of my coding decisions:

"Most importantly it is to understand how your code communicates its purpose clearly and with empathy to your potential team members.  
What do we mean by empathy?  
Empathy here is caring about how easy your code is to understand and navigate for the next engineer who touches it.  
Secondly, it is to understand your ability to compose quality code that adheres to SOLID."

### Design considerations:

When I began to design my solution, there was a possibility to abstract some elements to a further degree and to loosely couple further elements, and to use syntax introduced in the latest versions. For example:  
- More Interfaces and Classes  
- More Dependency Injection  
- The use of Primary Constructors  
- The use of Coalescing Expressions  
- The use of more Advanced array access  

---

## ✅ Below is the checklist provided in the remit:

- The solution should be available for review on GitHub — **DONE**
- The names should be sorted correctly — **DONE**
- It should print the sorted list of names to screen — **DONE**
- Write/overwrite the sorted list of names to a file called `sorted-names-list.txt` — **DONE**
- Unit tests should exist — **DONE**
- Minimal, practical documentation should exist — **DONE** (README.md)

---

Thanks for the opportunity!
