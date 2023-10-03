//-----------------------------------------------------------------------
// <copyright file="RequestCompilerTest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Testing;

using TestQueriesGenerator.Library;

/// <summary>
/// Contains unit tests for the MetadataService class.
/// </summary>
public class RequestCompilerTest
{
    private const string MetadataPrefix = "TEST";

    /// <summary>
    /// Tests creating a ID name when using a number from the Level #1.
    /// This range contains integers more than 100_000 and less than 1_000_000.
    /// </summary>
    [Test]
    public void GetIdName_WhenValueLevel1()
    {
        string idNumber = RequestCompiler.CreateIdName(MetadataPrefix, 500_000);
        Assert.That(actual: idNumber, Is.EqualTo("TEST_0500000"));
    }

    /// <summary>
    /// Tests creating a ID name when using a number from the Level #2.
    /// This range contains integers more than 10_000 and less than 100_000.
    /// </summary>
    [Test]
    public void GetIdName_WhenValueLevel2()
    {
        string idNumber = RequestCompiler.CreateIdName(MetadataPrefix, 50_000);
        Assert.That(actual: idNumber, Is.EqualTo("TEST_0050000"));
    }

    /// <summary>
    /// Tests creating a ID name when using a number from the Level #3.
    /// This range contains integers more than 1000 and less than 10_000.
    /// </summary>
    [Test]
    public void GetIdName_WhenValueLevel3()
    {
        string idNumber = RequestCompiler.CreateIdName(MetadataPrefix, 5_000);
        Assert.That(actual: idNumber, Is.EqualTo("TEST_0005000"));
    }

    /// <summary>
    /// Tests creating a ID name when using a number from the Level #4.
    /// This range contains integers more than 100 and less than 1000.
    /// </summary>
    [Test]
    public void GetIdName_WhenValueLevel4()
    {
        string idNumber = RequestCompiler.CreateIdName(MetadataPrefix, 500);
        Assert.That(actual: idNumber, Is.EqualTo("TEST_0000500"));
    }

    /// <summary>
    /// Tests creating a ID name when using a number from the Level #5.
    /// This range contains integers more than 10 and less than 100.
    /// </summary>
    [Test]
    public void GetIdName_WhenValueLevel5()
    {
        string idNumber = RequestCompiler.CreateIdName(MetadataPrefix, 50);
        Assert.That(actual: idNumber, Is.EqualTo("TEST_0000050"));
    }

    /// <summary>
    /// Tests creating a ID name when using a number from the Level #6.
    /// This range contains integers more than 0 and less than 10.
    /// </summary>
    [Test]
    public void GetIdName_WhenValueLevel6()
    {
        string idNumber = RequestCompiler.CreateIdName(MetadataPrefix, 5);
        Assert.That(actual: idNumber, Is.EqualTo("TEST_0000005"));
    }

    /// <summary>
    /// Tests creating a ID name when using the maximum available number.
    /// </summary>
    [Test]
    public void GetIdName_WhenMaximumAvailableValue()
    {
        string idNumber = RequestCompiler.CreateIdName(MetadataPrefix, 999_999);
        Assert.That(actual: idNumber, Is.EqualTo("TEST_0999999"));
    }

    /// <summary>
    /// Tests creating a ID name when using the minimum available number.
    /// </summary>
    [Test]
    public void GetIdName_WhenMinimumAvailableValue()
    {
        string idNumber = RequestCompiler.CreateIdName(MetadataPrefix, 0);
        Assert.That(actual: idNumber, Is.EqualTo("TEST_0000000"));
    }
}
