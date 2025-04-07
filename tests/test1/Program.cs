using prad;

class test1 {
    public static void Main(){
        prad_buffer buffer = new prad_buffer();

        buffer.get_input();

        string value = buffer.get_buffer_as_string();

        buffer.clear_buffer();

        Console.WriteLine("Entered Value : " + value);
        Console.WriteLine("Value Length  : " + value.Length);
    }
}