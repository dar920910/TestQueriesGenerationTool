//-----------------------------------------------------------------------
// <copyright file="ScaleMetadataRequestTest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Testing;

using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Entities;

/// <summary>
/// Contains unit tests for both ScaleGetMetaRequest and ScaleSetMetaRequest classes.
/// </summary>
public class ScaleMetadataRequestTest
{
    private const string RequestIdName1 = "RequestID1";
    private const string RequestIdName2 = "RequestID2";
    private const string RequestIdName3 = "RequestID3";
    private const string TestMetadataFieldValue = "TestMetadataFieldValue";

    /// <summary>
    /// Tests creating a compiled scalable GET-request.
    /// </summary>
    [Test]
    public void CompileScaleGetMetadataRequestTest()
    {
        string actualScaleGetRequest = new ScaleGetMetaRequest(
            new List<IdFullGetMetadataRequest>()
            {
                new IdFullGetMetadataRequest(new List<IdGetFieldRequest>()
                {
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.Agency),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.Description),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.Department),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.Title),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.Type),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.UserField1),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.UserField2),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.UserField3),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.UserField4),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.RecordTime),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.ModifiedTime),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.KillDate),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.SOM),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.DAR),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.GOP),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.FileSize),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.Resolution),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.VideoFormat),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.BitRate),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.Handle),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.Link),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.MachineName),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.UserName),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.AudioBits),
                    new IdGetFieldRequest(idName: RequestIdName1, metadataField: Metadata.AudioChannels),
                }),
                new IdFullGetMetadataRequest(new List<IdGetFieldRequest>()
                {
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.Agency),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.Description),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.Department),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.Title),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.Type),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.UserField1),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.UserField2),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.UserField3),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.UserField4),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.RecordTime),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.ModifiedTime),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.KillDate),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.SOM),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.DAR),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.GOP),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.FileSize),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.Resolution),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.VideoFormat),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.BitRate),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.Handle),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.Link),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.MachineName),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.UserName),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.AudioBits),
                    new IdGetFieldRequest(idName: RequestIdName2, metadataField: Metadata.AudioChannels),
                }),
                new IdFullGetMetadataRequest(new List<IdGetFieldRequest>()
                {
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.Agency),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.Description),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.Department),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.Title),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.Type),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.UserField1),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.UserField2),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.UserField3),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.UserField4),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.RecordTime),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.ModifiedTime),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.KillDate),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.SOM),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.DAR),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.GOP),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.FileSize),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.Resolution),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.VideoFormat),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.BitRate),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.Handle),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.Link),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.MachineName),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.UserName),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.AudioBits),
                    new IdGetFieldRequest(idName: RequestIdName3, metadataField: Metadata.AudioChannels),
                }),
            }).Compile(true);

        string expectedScaleGetRequest =
            $"get_field {Metadata.Agency} {RequestIdName1}\n" +
            $"get_field {Metadata.Description} {RequestIdName1}\n" +
            $"get_field {Metadata.Department} {RequestIdName1}\n" +
            $"get_field {Metadata.Title} {RequestIdName1}\n" +
            $"get_field {Metadata.Type} {RequestIdName1}\n" +
            $"get_field {Metadata.UserField1} {RequestIdName1}\n" +
            $"get_field {Metadata.UserField2} {RequestIdName1}\n" +
            $"get_field {Metadata.UserField3} {RequestIdName1}\n" +
            $"get_field {Metadata.UserField4} {RequestIdName1}\n" +
            $"get_field {Metadata.RecordTime} {RequestIdName1}\n" +
            $"get_field {Metadata.ModifiedTime} {RequestIdName1}\n" +
            $"get_field {Metadata.KillDate} {RequestIdName1}\n" +
            $"get_field {Metadata.SOM} {RequestIdName1}\n" +
            $"get_field {Metadata.DAR} {RequestIdName1}\n" +
            $"get_field {Metadata.GOP} {RequestIdName1}\n" +
            $"get_field {Metadata.FileSize} {RequestIdName1}\n" +
            $"get_field {Metadata.Resolution} {RequestIdName1}\n" +
            $"get_field {Metadata.VideoFormat} {RequestIdName1}\n" +
            $"get_field {Metadata.BitRate} {RequestIdName1}\n" +
            $"get_field {Metadata.Handle} {RequestIdName1}\n" +
            $"get_field {Metadata.Link} {RequestIdName1}\n" +
            $"get_field {Metadata.MachineName} {RequestIdName1}\n" +
            $"get_field {Metadata.UserName} {RequestIdName1}\n" +
            $"get_field {Metadata.AudioBits} {RequestIdName1}\n" +
            $"get_field {Metadata.AudioChannels} {RequestIdName1}\n" +

            $"get_field {Metadata.Agency} {RequestIdName2}\n" +
            $"get_field {Metadata.Description} {RequestIdName2}\n" +
            $"get_field {Metadata.Department} {RequestIdName2}\n" +
            $"get_field {Metadata.Title} {RequestIdName2}\n" +
            $"get_field {Metadata.Type} {RequestIdName2}\n" +
            $"get_field {Metadata.UserField1} {RequestIdName2}\n" +
            $"get_field {Metadata.UserField2} {RequestIdName2}\n" +
            $"get_field {Metadata.UserField3} {RequestIdName2}\n" +
            $"get_field {Metadata.UserField4} {RequestIdName2}\n" +
            $"get_field {Metadata.RecordTime} {RequestIdName2}\n" +
            $"get_field {Metadata.ModifiedTime} {RequestIdName2}\n" +
            $"get_field {Metadata.KillDate} {RequestIdName2}\n" +
            $"get_field {Metadata.SOM} {RequestIdName2}\n" +
            $"get_field {Metadata.DAR} {RequestIdName2}\n" +
            $"get_field {Metadata.GOP} {RequestIdName2}\n" +
            $"get_field {Metadata.FileSize} {RequestIdName2}\n" +
            $"get_field {Metadata.Resolution} {RequestIdName2}\n" +
            $"get_field {Metadata.VideoFormat} {RequestIdName2}\n" +
            $"get_field {Metadata.BitRate} {RequestIdName2}\n" +
            $"get_field {Metadata.Handle} {RequestIdName2}\n" +
            $"get_field {Metadata.Link} {RequestIdName2}\n" +
            $"get_field {Metadata.MachineName} {RequestIdName2}\n" +
            $"get_field {Metadata.UserName} {RequestIdName2}\n" +
            $"get_field {Metadata.AudioBits} {RequestIdName2}\n" +
            $"get_field {Metadata.AudioChannels} {RequestIdName2}\n" +

            $"get_field {Metadata.Agency} {RequestIdName3}\n" +
            $"get_field {Metadata.Description} {RequestIdName3}\n" +
            $"get_field {Metadata.Department} {RequestIdName3}\n" +
            $"get_field {Metadata.Title} {RequestIdName3}\n" +
            $"get_field {Metadata.Type} {RequestIdName3}\n" +
            $"get_field {Metadata.UserField1} {RequestIdName3}\n" +
            $"get_field {Metadata.UserField2} {RequestIdName3}\n" +
            $"get_field {Metadata.UserField3} {RequestIdName3}\n" +
            $"get_field {Metadata.UserField4} {RequestIdName3}\n" +
            $"get_field {Metadata.RecordTime} {RequestIdName3}\n" +
            $"get_field {Metadata.ModifiedTime} {RequestIdName3}\n" +
            $"get_field {Metadata.KillDate} {RequestIdName3}\n" +
            $"get_field {Metadata.SOM} {RequestIdName3}\n" +
            $"get_field {Metadata.DAR} {RequestIdName3}\n" +
            $"get_field {Metadata.GOP} {RequestIdName3}\n" +
            $"get_field {Metadata.FileSize} {RequestIdName3}\n" +
            $"get_field {Metadata.Resolution} {RequestIdName3}\n" +
            $"get_field {Metadata.VideoFormat} {RequestIdName3}\n" +
            $"get_field {Metadata.BitRate} {RequestIdName3}\n" +
            $"get_field {Metadata.Handle} {RequestIdName3}\n" +
            $"get_field {Metadata.Link} {RequestIdName3}\n" +
            $"get_field {Metadata.MachineName} {RequestIdName3}\n" +
            $"get_field {Metadata.UserName} {RequestIdName3}\n" +
            $"get_field {Metadata.AudioBits} {RequestIdName3}\n" +
            $"get_field {Metadata.AudioChannels} {RequestIdName3}\n";

        Assert.That(actual: actualScaleGetRequest, expression: Is.EqualTo(expectedScaleGetRequest));
    }

    /// <summary>
    /// Tests creating a compiled scalable SET-request.
    /// </summary>
    [Test]
    public void CompileScaleSetMetadataRequestTest()
    {
        string actualScaleSetRequest = new ScaleSetMetaRequest(
            new List<IdFullSetMetadataRequest>()
            {
                new IdFullSetMetadataRequest(new List<IdSetFieldRequest>()
                {
                    new IdSetFieldRequest(idName: RequestIdName1, metadataField: Metadata.Agency, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName1, metadataField: Metadata.Description, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName1, metadataField: Metadata.Department, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName1, metadataField: Metadata.Title, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName1, metadataField: Metadata.Type, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName1, metadataField: Metadata.UserField1, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName1, metadataField: Metadata.UserField2, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName1, metadataField: Metadata.UserField3, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName1, metadataField: Metadata.UserField4, metadataValue: TestMetadataFieldValue),
                }),
                new IdFullSetMetadataRequest(new List<IdSetFieldRequest>()
                {
                    new IdSetFieldRequest(idName: RequestIdName2, metadataField: Metadata.Agency, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName2, metadataField: Metadata.Description, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName2, metadataField: Metadata.Department, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName2, metadataField: Metadata.Title, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName2, metadataField: Metadata.Type, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName2, metadataField: Metadata.UserField1, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName2, metadataField: Metadata.UserField2, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName2, metadataField: Metadata.UserField3, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName2, metadataField: Metadata.UserField4, metadataValue: TestMetadataFieldValue),
                }),
                new IdFullSetMetadataRequest(new List<IdSetFieldRequest>()
                {
                    new IdSetFieldRequest(idName: RequestIdName3, metadataField: Metadata.Agency, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName3, metadataField: Metadata.Description, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName3, metadataField: Metadata.Department, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName3, metadataField: Metadata.Title, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName3, metadataField: Metadata.Type, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName3, metadataField: Metadata.UserField1, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName3, metadataField: Metadata.UserField2, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName3, metadataField: Metadata.UserField3, metadataValue: TestMetadataFieldValue),
                    new IdSetFieldRequest(idName: RequestIdName3, metadataField: Metadata.UserField4, metadataValue: TestMetadataFieldValue),
                }),
            }).Compile(true);

        string expectedScaleSetRequest =
            $"set_field {Metadata.Agency} {TestMetadataFieldValue} {RequestIdName1}\n" +
            $"set_field {Metadata.Description} {TestMetadataFieldValue} {RequestIdName1}\n" +
            $"set_field {Metadata.Department} {TestMetadataFieldValue} {RequestIdName1}\n" +
            $"set_field {Metadata.Title} {TestMetadataFieldValue} {RequestIdName1}\n" +
            $"set_field {Metadata.Type} {TestMetadataFieldValue} {RequestIdName1}\n" +
            $"set_field {Metadata.UserField1} {TestMetadataFieldValue} {RequestIdName1}\n" +
            $"set_field {Metadata.UserField2} {TestMetadataFieldValue} {RequestIdName1}\n" +
            $"set_field {Metadata.UserField3} {TestMetadataFieldValue} {RequestIdName1}\n" +
            $"set_field {Metadata.UserField4} {TestMetadataFieldValue} {RequestIdName1}\n" +

            $"set_field {Metadata.Agency} {TestMetadataFieldValue} {RequestIdName2}\n" +
            $"set_field {Metadata.Description} {TestMetadataFieldValue} {RequestIdName2}\n" +
            $"set_field {Metadata.Department} {TestMetadataFieldValue} {RequestIdName2}\n" +
            $"set_field {Metadata.Title} {TestMetadataFieldValue} {RequestIdName2}\n" +
            $"set_field {Metadata.Type} {TestMetadataFieldValue} {RequestIdName2}\n" +
            $"set_field {Metadata.UserField1} {TestMetadataFieldValue} {RequestIdName2}\n" +
            $"set_field {Metadata.UserField2} {TestMetadataFieldValue} {RequestIdName2}\n" +
            $"set_field {Metadata.UserField3} {TestMetadataFieldValue} {RequestIdName2}\n" +
            $"set_field {Metadata.UserField4} {TestMetadataFieldValue} {RequestIdName2}\n" +

            $"set_field {Metadata.Agency} {TestMetadataFieldValue} {RequestIdName3}\n" +
            $"set_field {Metadata.Description} {TestMetadataFieldValue} {RequestIdName3}\n" +
            $"set_field {Metadata.Department} {TestMetadataFieldValue} {RequestIdName3}\n" +
            $"set_field {Metadata.Title} {TestMetadataFieldValue} {RequestIdName3}\n" +
            $"set_field {Metadata.Type} {TestMetadataFieldValue} {RequestIdName3}\n" +
            $"set_field {Metadata.UserField1} {TestMetadataFieldValue} {RequestIdName3}\n" +
            $"set_field {Metadata.UserField2} {TestMetadataFieldValue} {RequestIdName3}\n" +
            $"set_field {Metadata.UserField3} {TestMetadataFieldValue} {RequestIdName3}\n" +
            $"set_field {Metadata.UserField4} {TestMetadataFieldValue} {RequestIdName3}\n";

        Assert.That(actual: actualScaleSetRequest, expression: Is.EqualTo(expectedScaleSetRequest));
    }
}
