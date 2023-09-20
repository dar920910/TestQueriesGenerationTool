using TestQueriesGenerator.Library.Services;

namespace TestQueriesGenerator.Testing;

public class GeneratorTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetIdNumber_WhenValueLevel1()
    {
        string idNumber = GeneratorService.GetIdNumber(500_000);
        Assert.That(actual: idNumber, Is.EqualTo("0500000"));
    }

    [Test]
    public void GetIdNumber_WhenValueLevel2()
    {
        string idNumber = GeneratorService.GetIdNumber(50_000);
        Assert.That(actual: idNumber, Is.EqualTo("0050000"));
    }

    [Test]
    public void GetIdNumber_WhenValueLevel3()
    {
        string idNumber = GeneratorService.GetIdNumber(5_000);
        Assert.That(actual: idNumber, Is.EqualTo("0005000"));
    }

    [Test]
    public void GetIdNumber_WhenValueLevel4()
    {
        string idNumber = GeneratorService.GetIdNumber(500);
        Assert.That(actual: idNumber, Is.EqualTo("0000500"));
    }

    [Test]
    public void GetIdNumber_WhenValueLevel5()
    {
        string idNumber = GeneratorService.GetIdNumber(50);
        Assert.That(actual: idNumber, Is.EqualTo("0000050"));
    }

    [Test]
    public void GetIdNumber_WhenValueLevel6()
    {
        string idNumber = GeneratorService.GetIdNumber(5);
        Assert.That(actual: idNumber, Is.EqualTo("0000005"));
    }

    [Test]
    public void GetIdNumber_WhenMaximumAvailableValue()
    {
        string idNumber = GeneratorService.GetIdNumber(999_999);
        Assert.That(actual: idNumber, Is.EqualTo("0999999"));
    }

    [Test]
    public void GetIdNumber_WhenMinimumAvailableValue()
    {
        string idNumber = GeneratorService.GetIdNumber(0);
        Assert.That(actual: idNumber, Is.EqualTo("0000000"));
    }
}