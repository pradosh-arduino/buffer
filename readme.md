## Better Input for C#
Have you ever wondered if you could get the values of what users are typing in real time with `Console.ReadLine()` function? or do you want full control of input?

Well don't worry! This `buffer` nuget package aims to solve the issues of `ReadLine()` and gives more control to the user!

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

#### Example Syntax
```cs
PradBuffer InputBuffer = new PradBuffer();

InputBuffer.GetInput();

string value = InputBuffer.GetBufferAsString();

InputBuffer.ClearBuffer();
```

### Input process
The input function is overloaded so there are two different ways to use it.

#### Method 1
`code.cs`
```cs
InputBuffer.GetInput();
```

`output:`
```
<waits here for input>
```

#### Method 2
`code.cs`
```cs
InputBuffer.GetInput("command > ");
```

`output:`
```
command > <waits here for input>
```