namespace CaesarCypher;
using System;

public static class CaesarCipher
{
    private static int shiftAmount;

    private static string ShiftLetters(char[] msgToEncode)
    {
        for (int i = 0; i < msgToEncode.Length; i++)
        {
            if (!char.IsWhiteSpace(msgToEncode[i]) && !char.IsDigit(msgToEncode[i]))
            {
                WrapAround(shiftAmount, msgToEncode, i);
            }
        }

        return new string(msgToEncode);
    }
    
    private static string UnShiftLetters(char[] msgToDecode, int unShift)
    {
        for (int i = 0; i < msgToDecode.Length; i++)
        {
            if (!char.IsWhiteSpace(msgToDecode[i]) && !char.IsDigit(msgToDecode[i]))
            {
                WrapAround(unShift, msgToDecode, i);
            }
        }

        return new string(msgToDecode);
    }

    private static void WrapAround(int shift, char[] msgToEncode, int i)
    {
        if (char.IsUpper(msgToEncode[i])) // For uppercase letters
        {
            msgToEncode[i] = (char)((msgToEncode[i] - 'A' + shift + 26) % 26 + 'A');
        }
        else if (char.IsLower(msgToEncode[i])) // For lowercase letters
        {
            msgToEncode[i] = (char)((msgToEncode[i] - 'a' + shift + 26) % 26 + 'a');
        }
    }
    
    public static string Encode(string message, int shift)
    {
        if (shift == 26)
        {
            shift += 1;
        }

        char[] msgToEncode = message.ToCharArray();
        shiftAmount = shift % 26;

        return ShiftLetters(msgToEncode);
    }

    public static string Decode(string message)
    {
        char[] msgToDecode = message.ToCharArray();
        int unShift = -shiftAmount % 26;

        return UnShiftLetters(msgToDecode, unShift);
    }

    
    public static string Crack(string encodedMessage)
    {
        // Implement code cracking logic here
        throw new NotImplementedException();
    }

}


class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Enter a string to encode (or type 'quit' to exit): ");
            string input = Console.ReadLine();

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            int shift;
            while (true)
            {
                Console.Write("Enter a shift number (integer): ");
                string shiftInput = Console.ReadLine();

                if (int.TryParse(shiftInput, out shift))
                    break;
                else
                    Console.WriteLine("Please enter a valid integer.");
            }

            string encoded = CaesarCipher.Encode(input, shift);
            Console.WriteLine($"Encoded string: {encoded}");
            string decoded = CaesarCipher.Decode(encoded);
            Console.WriteLine($"Decoded string: {decoded}");
        }
    }
}