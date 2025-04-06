namespace prad
{
    /// <summary>
    /// This is an custom made input buffer so that we can get the output even if the user have not completed typing.
    /// coded by @pradosh-arduino (github) 
    /// </summary>
    class prad_buffer {
        private char[] buffer = new char[1024];

        /// <summary>
        /// Stores the current index of the input buffer.
        /// </summary>
        public int buffer_index = 0;

        /// <summary>
        /// Stores the total length of the input buffer.
        /// </summary>
        public int length = 0;

        /// <summary>
        /// Function to add a character to the buffer.
        /// </summary>
        /// <param name="c">The character to be added.</param>
        public void add_char(char c){
            if(buffer_index >= buffer.Length)
                return;

            buffer[buffer_index] = c;
            buffer_index++;
            length++;
        }

        /// <summary>
        /// Clears the buffer for next usage, This function will not be automatically called, you have to call by yourself.
        /// </summary>
        public void clear_buffer(){
            for(int i = 0; i < buffer.Length; i++){
                buffer[i] = '\0';
            }

            buffer_index = 0;
            length = 0;
        }

        /// <summary>
        /// Gets the input and stores it in the input buffer array cleanly. It does not return the buffer.
        /// </summary>
        public void get_input(){
            ConsoleKeyInfo current;

            while (true)
            {
                if(!Console.KeyAvailable) continue;

                current = Console.ReadKey(true);

                if (current.Key == ConsoleKey.Enter)
                {
                    if(length != 0)
                        Console.WriteLine();

                    for(int i=0; i<length;i++){
                        if(buffer[i] == '\0'){
                            length = i;
                            break;
                        }
                    }
                    
                    break;
                }
                else if (current.Key == ConsoleKey.Backspace)
                {
                    if (buffer_index > 0)
                    {
                        buffer_index--;
                        length--;
                        Console.Write("\b \b");
                    }
                }
                else if(current.Key == ConsoleKey.LeftArrow){
                    if(Console.CursorLeft > 0){
                        Console.CursorLeft--;
                        buffer_index--;
                    }
                }
                else if(current.Key == ConsoleKey.RightArrow){
                    if(Console.CursorLeft < length){
                        Console.CursorLeft++;
                        buffer_index++;
                    }
                }
                else if(current.Key == ConsoleKey.Home){
                    Console.Write("\r");
                    buffer_index = 0;
                }
                else if(current.Key == ConsoleKey.End){
                    Console.CursorLeft = length;
                    buffer_index = length;
                }
                else
                {
                    add_char(current.KeyChar);
                    Console.Write(current.KeyChar);
                }
            }
        }

        /// <summary>
        /// Gets the input and stores it in the input buffer array cleanly. It does not return the buffer. We can add a prefix to the input.
        /// </summary>
        /// <param name="prefix">The actual prefix needed to be displayed</param>
        public void get_input(string prefix){
            ConsoleKeyInfo current;

            Console.Write(prefix);

            while (true)
            {
                if(!Console.KeyAvailable) continue;

                current = Console.ReadKey(true);

                if (current.Key == ConsoleKey.Enter)
                {
                    if(length != 0)
                        Console.WriteLine();

                    for(int i=0; i<length;i++){
                        if(buffer[i] == '\0'){
                            length = i;
                            break;
                        }
                    }
                    
                    break;
                }
                else if (current.Key == ConsoleKey.Backspace)
                {
                    if (buffer_index > 0)
                    {
                        buffer_index--;
                        length--;
                        Console.Write("\b \b");
                    }
                }
                else if(current.Key == ConsoleKey.LeftArrow){
                    if(Console.CursorLeft > prefix.Length){
                        Console.CursorLeft--;
                        buffer_index--;
                    }
                }
                else if(current.Key == ConsoleKey.RightArrow){
                    if(Console.CursorLeft < length + prefix.Length){
                        Console.CursorLeft++;
                        buffer_index++;
                    }
                }
                else if(current.Key == ConsoleKey.Home){
                    Console.Write("\r");
                    Console.CursorLeft += prefix.Length;
                    buffer_index = 0;
                }
                else if(current.Key == ConsoleKey.End){
                    Console.CursorLeft = length + prefix.Length;
                    buffer_index = length;
                }
                else
                {
                    add_char(current.KeyChar);
                    Console.Write(current.KeyChar);
                }
            }
        }

        /// <summary>
        /// Function to get the buffer values.
        /// </summary>
        /// <returns>It returns the buffer as an character array.</returns>
        public char[] get_buffer(){
            return buffer;
        }

        /// <summary>
        /// Function to get the buffer array as a string.
        /// </summary>
        /// <returns>A proper string with buffer values.</returns>
        public string get_buffer_as_string(){
            return new string(buffer, 0, length);
        }
    }
}