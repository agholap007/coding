public class LongestSubstring
{
    public string GetLongestSubstring(string str)
    {
        return str;
    }

    [Fact]
    public void Test()
    {
        var expected = "1";
        var actual = GetLongestSubstring(expected);
        Xunit.Assert.Equal(actual, expected);
    }
}