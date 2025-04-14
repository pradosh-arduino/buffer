# ⚡️ Better Input for C# with `buffer`

![Buffer package in action](https://raw.githubusercontent.com/pradosh-arduino/buffer/ac911024b63e8a7f5b245be591859991fe23aec4/buffer.gif)

[![NuGet Downloads](https://img.shields.io/nuget/dt/buffer?style=flat-square&logo=nuget&logoColor=ffffff&logoSize=auto&label=Downloads&labelColor=323ca8&color=545454)](https://www.nuget.org/stats/packages/buffer?groupby=Version)
[![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/pradosh-arduino/buffer/dotnet.yml?style=flat-square&logo=github&logoColor=ffffff&logoSize=auto&label=Build)](https://github.com/pradosh-arduino/buffer/actions/workflows/dotnet.yml)
[![NuGet Version](https://img.shields.io/nuget/vpre/buffer?style=flat-square&logo=hackthebox&logoColor=ffffff&logoSize=auto&label=Latest%20Version)](https://www.nuget.org/packages/buffer)



Ever wished `Console.ReadLine()` could give you real-time input? Want full control over what the user types *as they type it*?

Introducing **`buffer`** — a lightweight NuGet package that gives you real-time input handling and total buffer control in C#. Perfect for building interactive CLI tools, REPLs, or anything where `ReadLine()` just doesn’t cut it.

---

## ✨ Features

- `✅` **Real-time updates while users type**
- `📜` **Real-time Syntax highlighting.**
- `🧠` **Manual control over the input buffer**
- `🧵` Thread-safe & supports multithreading
- `🔠` Access buffer as `char[]` or `string`
- `💻` Compatible with a wide range of .NET Frameworks
- `🎉` Emoji support for fun prompts
- `🔒` Secure input handling
- `🛠️` Easy to use and integrate
- `📦` Lightweight and fast
- `🔧` Customizable buffer size

---

## 🚀 Quick Start

### 🧩 Installation

Add it via CLI:

```bash
dotnet add package buffer
```

Or visit the [NuGet page →](https://www.nuget.org/packages/buffer)

---

## 🔧 How It Works

1. Initialize the input buffer
    - With a buffer size
    - Without a buffer size
2. Start listening for input
3. Read the buffer manually as `char[]` or `string`
4. Clear the buffer when you’re done

### 🧪 Example

```cpp
using Prad.Buffer;

...
PradBuffer InputBuffer = new PradBuffer();

// Start capturing input (does NOT return value)
InputBuffer.GetInput();

// Read it manually
string value = InputBuffer.GetBufferAsString();

// Clear when done
InputBuffer.ClearBuffer();
```

### 🧩 Manual Buffer Size Example

```cpp
using Prad.Buffer;

...
PradBuffer InputBuffer = new PradBuffer(10);

// Start capturing input (does NOT return value)
InputBuffer.GetInput(); // Only 10 characters can be stored. (0 to 9)

// Read it manually
string value = InputBuffer.GetBufferAsString();

// Clear when done
InputBuffer.ClearBuffer();
```

### Here is a demo of Limited Buffer Size of 10 characters
![buffer-limit](https://github.com/user-attachments/assets/3f459e05-65dc-4ce7-8f8a-20c09f660702)

### 🧩 Syntax Highlighting in Real-time
```cpp
PradBuffer Buffer = new PradBuffer();

string s = "";

Buffer.SyntaxHighlights.Add("prad", ConsoleColor.Red);
Buffer.SyntaxHighlights.Add("static", ConsoleColor.Blue);
Buffer.SyntaxHighlights.Add("public", ConsoleColor.Green);
Buffer.SyntaxHighlights.Add("=", ConsoleColor.Yellow);

Buffer.EnableSyntaxHighlighting = true;

while(true){
    Buffer.GetInput("> ");

    s = Buffer.GetBufferAsString();

    Buffer.ClearBuffer();

    if(s == "exit") break;

    Console.WriteLine($"Value Entered : \"{s}\"");
}
```

#### Demo of Syntax Highlighting



### 🚀 Using its maximum potential

Here is a code example which uses Multithreading to get the input buffer in real-time.

```cpp
using Prad.Buffer;

class sample_program {
    static PradBuffer buffer = new PradBuffer();

    static void Main(string[] args) {
        Thread thread = new Thread(invoker);
        thread.Start();

        buffer.GetInput("command > ");

        string value = buffer.GetBufferAsString();

        buffer.ClearBuffer();

        Console.WriteLine(value);
    }

    static void invoker(){
        if(buffer.Length > 0)
            Console.WriteLine(buffer.GetBufferAsString());

        Thread.Sleep(1000);
        invoker();
    }
}
```

🛠️ Unlock the full power of `buffer` by using multi-threading to get realtime data even before the user has completed typing.

---

## 🛠 Overloaded Input Methods

### Option 1 – No prompt
```cpp
InputBuffer.GetInput();
```
```txt
<waits here for input>
```

### Option 2 – With custom prompt
```cpp
InputBuffer.GetInput("command > ");
```
```txt
command > <waits here for input>
```

---

## 🤝 Contributing

Contributions are always welcome!

### Steps
```bash
# 1. Fork the repo
# 2. Create a branch
git checkout -b feature-name

# 3. Make changes & commit
git commit -m "Add feature-name"

# 4. Push and open PR
git push origin feature-name
```

### Please:
- Stick to the existing code style
- Write helpful commit messages
- Document new features
- Add tests when possible ✅

---

## 🔗 Links

- 📦 [NuGet Package](https://www.nuget.org/packages/buffer)
- 🧑‍💻 [GitHub Source](https://github.com/pradosh-arduino/buffer)
- 📝 [Blog Post](https://dev.to/pradcode/better-input-method-for-c-4hnb)

---

Give it a ⭐ if you like it and share it with your fellow devs!
