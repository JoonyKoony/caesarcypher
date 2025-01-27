﻿namespace CaesarCypher;
using System;

public static class CaesarCipher
{
    //private string encodedCypher;

    //private string decodedCypher;

    // private string uncodedCyhper;

    // Public Methods
    public static string Encode(string message, int shift)
    {
        char[] msgToEncode = message.ToCharArray();

        for (int i = 0; i < msgToEncode.Length; i++)
        {
            if (msgToEncode[i] == 'A' || msgToEncode[i] == 'a' || msgToEncode[i] == 'Z' || msgToEncode[i] == 'z')
            {
                msgToEncode[i] = WrapAround(msgToEncode[i], shift);
            }
            else if (!char.IsWhiteSpace(msgToEncode[i]) && !char.IsDigit(msgToEncode[i]))
            {
                NewMethod(shift, msgToEncode, i);
            }

        }
        return new string(msgToEncode);
    }

    private static void NewMethod(int shift, char[] msgToEncode, int i)
    {
        if ((msgToEncode[i] + shift < 'A' && msgToEncode[i] + shift > 'z') || (msgToEncode[i] + shift > 'Z' && msgToEncode[i] + shift < 'a'))
        {
            msgToEncode[i] = WrapAround(msgToEncode[i], shift);
        }
        else
        {
            msgToEncode[i] = (char)((char)msgToEncode[i] + shift);
        }
    }


    public static char WrapAround(char message, int shift)
    {
        if (char.IsUpper(message)) // For uppercase letters
        {
            return (char)((message - 'A' + shift + 26) % 26 + 'A');
        }
        else if (char.IsLower(message)) // For lowercase letters
        {
            return (char)((message - 'a' + shift + 26) % 26 + 'a');
        }
        else
        {
            // Non-alphabetic characters are not shifted
            return message;
        }
    }

    public static string Decode(string message, int shift)
    {
        // Implement decoding logic here
        throw new NotImplementedException();
    }

    public static string Crack(string encodedMessage)
    {
        // Implement code cracking logic here
        throw new NotImplementedException();
    }

    // Optional: Add helper methods here (e.g., for handling edge cases)
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
            string decoded = CaesarCipher.Decode(encoded, shift);
            Console.WriteLine($"Decoded string: {decoded}");
        }
    }
}