public class ClassName
{
    public int MethodName(int param)
    {
        return param;
    }

    [Fact]
    public void Test()
    {
        var expected = 1;
        var actual = MethodName(expected);
        Xunit.Assert.Equal(actual, expected);
    }
}