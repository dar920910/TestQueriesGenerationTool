//-----------------------------------------------------------------------
// <copyright file="IdFullMetadataRequestTest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Testing;

using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Entities;

/// <summary>
/// Contains unit tests for both IdFullGetMetadataRequest and IdFullSetMetadataRequest classes.
/// </summary>
public class IdFullMetadataRequestTest
{
    private const string RequestIdName = "RequestID";
    private const string TestMetadataFieldValue = "TestMetadataFieldValue";

    /// <summary>
    /// Tests creating a compiled full metadata GET-request.
    /// </summary>
    [Test]
    public void CompileIdFullGetMetadataRequestTest()
    {
        string actualFullGetRequest = new IdFullGetMetadataRequest(
            new List<IdGetFieldRequest>()
            {
                new (idName: RequestIdName, metadataField: Metadata.Agency),
                new (idName: RequestIdName, metadataField: Metadata.Description),
                new (idName: RequestIdName, metadataField: Metadata.Department),
                new (idName: RequestIdName, metadataField: Metadata.Title),
                new (idName: RequestIdName, metadataField: Metadata.Type),
                new (idName: RequestIdName, metadataField: Metadata.UserField1),
                new (idName: RequestIdName, metadataField: Metadata.UserField2),
                new (idName: RequestIdName, metadataField: Metadata.UserField3),
                new (idName: RequestIdName, metadataField: Metadata.UserField4),
                new (idName: RequestIdName, metadataField: Metadata.RecordTime),
                new (idName: RequestIdName, metadataField: Metadata.ModifiedTime),
                new (idName: RequestIdName, metadataField: Metadata.KillDate),
                new (idName: RequestIdName, metadataField: Metadata.SOM),
                new (idName: RequestIdName, metadataField: Metadata.DAR),
                new (idName: RequestIdName, metadataField: Metadata.GOP),
                new (idName: RequestIdName, metadataField: Metadata.FileSize),
                new (idName: RequestIdName, metadataField: Metadata.Resolution),
                new (idName: RequestIdName, metadataField: Metadata.VideoFormat),
                new (idName: RequestIdName, metadataField: Metadata.BitRate),
                new (idName: RequestIdName, metadataField: Metadata.Handle),
                new (idName: RequestIdName, metadataField: Metadata.Link),
                new (idName: RequestIdName, metadataField: Metadata.MachineName),
                new (idName: RequestIdName, metadataField: Metadata.UserName),
                new (idName: RequestIdName, metadataField: Metadata.AudioBits),
                new (idName: RequestIdName, metadataField: Metadata.AudioChannels),
            }).Compile(true);

        string expectedFullGetRequest =
            $"get_field {Metadata.Agency} {RequestIdName}\n" +
            $"get_field {Metadata.Description} {RequestIdName}\n" +
            $"get_field {Metadata.Department} {RequestIdName}\n" +
            $"get_field {Metadata.Title} {RequestIdName}\n" +
            $"get_field {Metadata.Type} {RequestIdName}\n" +
            $"get_field {Metadata.UserField1} {RequestIdName}\n" +
            $"get_field {Metadata.UserField2} {RequestIdName}\n" +
            $"get_field {Metadata.UserField3} {RequestIdName}\n" +
            $"get_field {Metadata.UserField4} {RequestIdName}\n" +
            $"get_field {Metadata.RecordTime} {RequestIdName}\n" +
            $"get_field {Metadata.ModifiedTime} {RequestIdName}\n" +
            $"get_field {Metadata.KillDate} {RequestIdName}\n" +
            $"get_field {Metadata.SOM} {RequestIdName}\n" +
            $"get_field {Metadata.DAR} {RequestIdName}\n" +
            $"get_field {Metadata.GOP} {RequestIdName}\n" +
            $"get_field {Metadata.FileSize} {RequestIdName}\n" +
            $"get_field {Metadata.Resolution} {RequestIdName}\n" +
            $"get_field {Metadata.VideoFormat} {RequestIdName}\n" +
            $"get_field {Metadata.BitRate} {RequestIdName}\n" +
            $"get_field {Metadata.Handle} {RequestIdName}\n" +
            $"get_field {Metadata.Link} {RequestIdName}\n" +
            $"get_field {Metadata.MachineName} {RequestIdName}\n" +
            $"get_field {Metadata.UserName} {RequestIdName}\n" +
            $"get_field {Metadata.AudioBits} {RequestIdName}\n" +
            $"get_field {Metadata.AudioChannels} {RequestIdName}\n";

        Assert.That(actual: actualFullGetRequest, expression: Is.EqualTo(expectedFullGetRequest));
    }

    /// <summary>
    /// Tests creating a compiled full metadata SET-request.
    /// </summary>
    [Test]
    public void CompileIdFullSetMetadataRequestTest()
    {
        string actualFullSetRequest = new IdFullSetMetadataRequest(
            new List<IdSetFieldRequest>()
            {
                new (idName: RequestIdName, metadataField: Metadata.Agency, metadataValue: TestMetadataFieldValue),
                new (idName: RequestIdName, metadataField: Metadata.Description, metadataValue: TestMetadataFieldValue),
                new (idName: RequestIdName, metadataField: Metadata.Department, metadataValue: TestMetadataFieldValue),
                new (idName: RequestIdName, metadataField: Metadata.Title, metadataValue: TestMetadataFieldValue),
                new (idName: RequestIdName, metadataField: Metadata.Type, metadataValue: TestMetadataFieldValue),
                new (idName: RequestIdName, metadataField: Metadata.UserField1, metadataValue: TestMetadataFieldValue),
                new (idName: RequestIdName, metadataField: Metadata.UserField2, metadataValue: TestMetadataFieldValue),
                new (idName: RequestIdName, metadataField: Metadata.UserField3, metadataValue: TestMetadataFieldValue),
                new (idName: RequestIdName, metadataField: Metadata.UserField4, metadataValue: TestMetadataFieldValue),
            }).Compile(true);

        string expectedFullSetRequest =
            $"set_field {Metadata.Agency} {TestMetadataFieldValue} {RequestIdName}\n" +
            $"set_field {Metadata.Description} {TestMetadataFieldValue} {RequestIdName}\n" +
            $"set_field {Metadata.Department} {TestMetadataFieldValue} {RequestIdName}\n" +
            $"set_field {Metadata.Title} {TestMetadataFieldValue} {RequestIdName}\n" +
            $"set_field {Metadata.Type} {TestMetadataFieldValue} {RequestIdName}\n" +
            $"set_field {Metadata.UserField1} {TestMetadataFieldValue} {RequestIdName}\n" +
            $"set_field {Metadata.UserField2} {TestMetadataFieldValue} {RequestIdName}\n" +
            $"set_field {Metadata.UserField3} {TestMetadataFieldValue} {RequestIdName}\n" +
            $"set_field {Metadata.UserField4} {TestMetadataFieldValue} {RequestIdName}\n";

        Assert.That(actual: actualFullSetRequest, expression: Is.EqualTo(expectedFullSetRequest));
    }
}
