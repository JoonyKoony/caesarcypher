using CaesarCypher;

namespace CypherTest;

public class CaesarCipherTests
{
    [Fact]
    public void Encode_ShouldEncodeMessageWithShift()
    {
        // Arrange
        string input = "Hello World";
        int shift = 3;
        string expected = "Khoor Zruog"; // Shift each character by 3

        // Act
        string actual = CaesarCipher.Encode(input, shift);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Encode_ShouldHandleEmptyString()
    {
        // Arrange
        string input = "";
        int shift = 3;
        string expected = ""; // No characters to encode

        // Act
        string actual = CaesarCipher.Encode(input, shift);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Encode_ShouldHandleNegativeShift()
    {
        // Arrange
        string input = "Khoor";
        int shift = -3;
        string expected = "Hello"; // Shift backwards

        // Act
        string actual = CaesarCipher.Encode(input, shift);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Encode_ShouldWrapAroundAlphabet()
    {
        // Arrange
        string input = "Zebra";
        int shift = 3;
        string expected = "Cheud"; // Wraps around at 'Z'

        // Act
        string actual = CaesarCipher.Encode(input, shift);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Decode_ShouldDecodeMessageWithShift()
    {
        // Arrange
        string input = "world";
        int shift = -5;
        string expected = "rjmgy";

        // Act
        string actual = CaesarCipher.Encode(input, shift);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("ABC", 3, "DEF")]
    [InlineData("XYZ", 1, "YZA")]
    [InlineData("hello", 5, "mjqqt")]
    [InlineData("world", -5, "rjmgy")]
    [InlineData("", 10, "")] // Empty string
    public void Encode_WithVariousInputs_ShouldReturnExpectedResults(string input, int shift, string expected)
    {
        // Act
        string actual = CaesarCipher.Encode(input, shift);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Uifsf jt b tfdsfu nfttbhf", 1, "There is a secret message")]
    [InlineData("Wklv lv d whvw phvvdjh", 3, "This is a test message")]
    [InlineData("Khoor Zruog", 3, "Hello World")]
    public void Decode_ShouldReturnOriginalMessage_WhenGivenEncodedMessageAndShift(string encodedMessage, int shift, string expected)
    {
        // Arrange
        CaesarCipher.Encode(expected, shift); // Set the shiftAmount

        // Act
        string decodedMessage = CaesarCipher.Decode(encodedMessage);

        // Assert
        Assert.Equal(expected, decodedMessage);
    }
}