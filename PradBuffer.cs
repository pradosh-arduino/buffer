namespace Prad.Buffer;

/// <summary>
/// <para> This is an custom made input buffer though which we can get the output even if the user have not completed typing. (Multi-threading) </para>
/// <para> coded by <a href="https://github.com/pradosh-arduino">@pradosh-arduino (github)</a> </para>
/// 
/// <a href="https://github.com/pradosh-arduino/buffer">Github source</a> • <a href="https://www.nuget.org/packages/buffer">Nuget</a> • <a href="https://dev.to/pradcode/better-input-method-for-c-4hnb">Blog</a>
/// </summary>
public class PradBuffer
{
    private char[] buffer;
    private int BufferSize;

    /// <summary>
    /// <para> Stores the current index of the input buffer. </para>
    /// <para> It is the position of the cursor in the string (buffer array). </para>
    /// <para> It will only be less-than the 'Length' variable. </para>
    /// </summary>
    public int BufferIndex { get; private set; } = 0;

    /// <summary>
    /// Stores the total length of the input buffer.
    /// </summary>
    public int Length { get; private set; } = 0;

    /// <summary>
    /// Constructor to initialize the buffer with its size. Sets to default size of 1024 characters.
    /// </summary>
    public PradBuffer()
    {
        BufferSize = 1024;
        buffer = new char[BufferSize];
    }

    /// <summary>
    /// Constructor to initialize the buffer with your own character limit.
    /// </summary>
    /// <param name="size">The size of the buffer. Or the character limit.</param>
    public PradBuffer(int size)
    {
        BufferSize = size;
        buffer = new char[BufferSize];
    }

    /// <summary>
    /// Function to add a character to the buffer.
    /// </summary>
    /// <param name="c">The character to be added.</param>
    private void AddChar(char c)
    {
        if (BufferIndex >= buffer.Length)
            return;

        buffer[BufferIndex] = c;
        BufferIndex++;
        Length++;
    }

    /// <summary>
    /// Clears the buffer for next usage, This function will not be automatically called, you have to call by yourself.
    /// </summary>
    public void ClearBuffer()
    {
        Array.Clear(buffer, 0, buffer.Length);

        BufferIndex = 0;
        Length = 0;
    }

    /// <summary>
    /// Gets the input and stores it in the input buffer array cleanly. It does <b>NOT</b> return the buffer.
    /// </summary>
    public void GetInput()
    {
        ConsoleKeyInfo current;

        while (true)
        {
            if (!Console.KeyAvailable) continue;

            current = Console.ReadKey(true);

            if (current.Key == ConsoleKey.Enter)
            {
                if (Length != 0)
                    Console.WriteLine();

                for (int i = 0; i < Length; i++)
                {
                    if (buffer[i] == '\0')
                    {
                        Length = i;
                        break;
                    }
                }

                break;
            }
            else if (current.Key == ConsoleKey.Backspace)
            {
                if (BufferIndex > 0)
                {
                    BufferIndex--;
                    Length--;
                    Console.Write("\b \b");
                }
            }
            else if (current.Key == ConsoleKey.LeftArrow)
            {
                if (Console.CursorLeft > 0)
                {
                    Console.CursorLeft--;
                    BufferIndex--;
                }
            }
            else if (current.Key == ConsoleKey.RightArrow)
            {
                if (Console.CursorLeft < Length)
                {
                    Console.CursorLeft++;
                    BufferIndex++;
                }
            }
            else if (current.Key == ConsoleKey.Home)
            {
                Console.Write("\r");
                BufferIndex = 0;
            }
            else if (current.Key == ConsoleKey.End)
            {
                Console.CursorLeft = Length;
                BufferIndex = Length;
            }
            else
            {
                AddChar(current.KeyChar);
                Console.Write(current.KeyChar);
            }
        }
    }

    /// <summary>
    /// Gets the input and stores it in the input buffer array cleanly. It does <b>NOT</b> return the buffer. We can add a prefix to the input.
    /// </summary>
    /// <param name="prefix">The actual prefix needed to be displayed</param>
    public void GetInput(string prefix)
    {
        ConsoleKeyInfo current;

        Console.Write(prefix);

        while (true)
        {
            if (!Console.KeyAvailable) continue;

            current = Console.ReadKey(true);

            if (current.Key == ConsoleKey.Enter)
            {
                if (Length != 0)
                    Console.WriteLine();

                for (int i = 0; i < Length; i++)
                {
                    if (buffer[i] == '\0')
                    {
                        Length = i;
                        break;
                    }
                }

                break;
            }
            else if (current.Key == ConsoleKey.Backspace)
            {
                if (BufferIndex > 0)
                {
                    BufferIndex--;
                    Length--;
                    Console.Write("\b \b");
                }
            }
            else if (current.Key == ConsoleKey.LeftArrow)
            {
                if (Console.CursorLeft > prefix.Length)
                {
                    Console.CursorLeft--;
                    BufferIndex--;
                }
            }
            else if (current.Key == ConsoleKey.RightArrow)
            {
                if (Console.CursorLeft < Length + prefix.Length)
                {
                    Console.CursorLeft++;
                    BufferIndex++;
                }
            }
            else if (current.Key == ConsoleKey.Home)
            {
                Console.Write("\r");
                Console.CursorLeft += prefix.Length;
                BufferIndex = 0;
            }
            else if (current.Key == ConsoleKey.End)
            {
                Console.CursorLeft = Length + prefix.Length;
                BufferIndex = Length;
            }
            else
            {
                AddChar(current.KeyChar);
                Console.Write(current.KeyChar);
            }
        }
    }

    /// <summary>
    /// Function to get the buffer values.
    /// </summary>
    /// <returns>It returns the buffer as an character array.</returns>
    public char[] GetBuffer()
    {
        return buffer;
    }

    /// <summary>
    /// Function to get the buffer array as a string.
    /// </summary>
    /// <returns>A proper string with buffer values.</returns>
    public string GetBufferAsString()
    {
        return new string(buffer, 0, Length);
    }

    /// <summary>
    /// Function to get the allocated buffer size.
    /// </summary>
    /// <returns>The buffer size in integer.</returns>
    public int GetBufferSize()
    {
        return BufferSize;
    }

    /// <summary>
    /// Function to set the buffer size.
    /// This function will <b>CLEAR</b> the buffer and reallocate the buffer with the new size.
    /// </summary>
    /// <param name="size">The size of buffer (default is 1024)</param>
    public void SetBufferSize(int size)
    {
        BufferSize = size;
        buffer = new char[BufferSize];
    }
}
