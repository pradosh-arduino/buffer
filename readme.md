![Buffer package in action](./buffer.gif)

## Better Input for C#

Have you ever wondered if you could get the values of what users are typing in real time with `Console.ReadLine()` function? or do you want full control of input?

Well don't worry! This `buffer` nuget package aims to solve the issues of `ReadLine()` and gives more control to the user!

### Features
- Data updates in real time.
- Control of buffer when to clear and when to call next time.
- Directly get the buffer as a character array.
- Supports multithreading to have extra control.
- Supports a wide range of .NET Frameworks.

### Usage

#### Process
```md
1. Initialize the object
2. Get the input from the user (does **not** return the value)
3. Read the buffer to get the values by using two methods
    1. Get the buffer as char[] itself.
    2. Get the buffer as a string.
4. Clear the buffer (you have to do it **manually** by invoking a method)
```

#### Example Usage
```cpp
PradBuffer InputBuffer = new PradBuffer();

InputBuffer.GetInput();

string value = InputBuffer.GetBufferAsString();

InputBuffer.ClearBuffer();
```

### Input process
The input function is overloaded so there are two different ways to use it.

#### Method 1
`code.cs`
```cpp
InputBuffer.GetInput();
```

`output:`
```
<waits here for input>
```

#### Method 2
`code.cs`
```cpp
InputBuffer.GetInput("command > ");
```

`output:`
```
command > <waits here for input>
```

### Importing the package
You can check out the [nuget.org](https://www.nuget.org/packages/buffer) site for extra detailed installation.

For simply just dotnet :
```bash
dotnet add package buffer
```

### Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch:
    ```bash
    git checkout -b feature-name
    ```
3. Commit your changes:
    ```bash
    git commit -m "Add feature-name"
    ```
4. Push to your branch:
    ```bash
    git push origin feature-name
    ```
5. Open a pull request.

### Contribution guidelines
- Follow the existing code style.
- Write clear and concise commit messages.
- Ensure that your code is well-documented.
- Write tests for new features and ensure all tests pass before submitting a pull request.