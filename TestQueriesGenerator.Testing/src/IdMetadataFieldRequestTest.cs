//-----------------------------------------------------------------------
// <copyright file="IdMetadataFieldRequestTest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestQueriesGenerator.Testing;

using TestQueriesGenerator.Library.Domains;
using TestQueriesGenerator.Library.Entities;

/// <summary>
/// Contains unit tests for both IdGetFieldRequest and IdSetFieldRequest classes.
/// </summary>
public class IdMetadataFieldRequestTest
{
    private const string RequestIdName = "RequestID";

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.Agency"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_Agency_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.Agency).Compile(true),
            expression: Is.EqualTo("get_field Agency RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.Description"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_Description_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.Description).Compile(true),
            expression: Is.EqualTo("get_field Description RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.Department"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_Department_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.Department).Compile(true),
            expression: Is.EqualTo("get_field Department RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.Title"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_Title_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.Title).Compile(true),
            expression: Is.EqualTo("get_field Title RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.Type"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_Type_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.Type).Compile(true),
            expression: Is.EqualTo("get_field Type RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.UserField1"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_UserField1_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.UserField1).Compile(true),
            expression: Is.EqualTo("get_field UserField1 RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.UserField2"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_UserField2_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.UserField2).Compile(true),
            expression: Is.EqualTo("get_field UserField2 RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.UserField3"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_UserField3_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.UserField3).Compile(true),
            expression: Is.EqualTo("get_field UserField3 RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.UserField4"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_UserField4_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.UserField4).Compile(true),
            expression: Is.EqualTo("get_field UserField4 RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.RecordTime"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_RecordTime_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.RecordTime).Compile(true),
            expression: Is.EqualTo("get_field RecordTime RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.ModifiedTime"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_ModifiedTime_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.ModifiedTime).Compile(true),
            expression: Is.EqualTo("get_field ModifiedTime RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.KillDate"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_KillDate_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.KillDate).Compile(true),
            expression: Is.EqualTo("get_field KillDate RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.SOM"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_SOM_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.SOM).Compile(true),
            expression: Is.EqualTo("get_field SOM RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.DAR"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_DAR_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.DAR).Compile(true),
            expression: Is.EqualTo("get_field DAR RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.GOP"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_GOP_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.GOP).Compile(true),
            expression: Is.EqualTo("get_field GOP RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.FileSize"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_FileSize_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.FileSize).Compile(true),
            expression: Is.EqualTo("get_field FileSize RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.Resolution"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_Resolution_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.Resolution).Compile(true),
            expression: Is.EqualTo("get_field Resolution RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.VideoFormat"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_VideoFormat_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.VideoFormat).Compile(true),
            expression: Is.EqualTo("get_field VideoFormat RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.BitRate"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_BitRate_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.BitRate).Compile(true),
            expression: Is.EqualTo("get_field BitRate RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.Handle"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_Handle_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.Handle).Compile(true),
            expression: Is.EqualTo("get_field Handle RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.Link"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_Link_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.Link).Compile(true),
            expression: Is.EqualTo("get_field Link RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.MachineName"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_MachineName_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.MachineName).Compile(true),
            expression: Is.EqualTo("get_field MachineName RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.UserName"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_UserName_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.UserName).Compile(true),
            expression: Is.EqualTo("get_field UserName RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.AudioBits"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_AudioBits_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.AudioBits).Compile(true),
            expression: Is.EqualTo("get_field AudioBits RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled GET-request for the <see cref="Metadata.AudioChannels"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldGetRequest_AudioChannels_TestCase()
    {
        Assert.That(
            actual: new IdGetFieldRequest(idName: RequestIdName, metadataField: Metadata.AudioChannels).Compile(true),
            expression: Is.EqualTo("get_field AudioChannels RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled SET-request for the <see cref="Metadata.Agency"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldSetRequest_Agency_TestCase()
    {
        Assert.That(
            actual: new IdSetFieldRequest(idName: RequestIdName, metadataField: Metadata.Agency, metadataValue: "TestAgencyValue").Compile(true),
            expression: Is.EqualTo("set_field Agency TestAgencyValue RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled SET-request for the <see cref="Metadata.Description"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldSetRequest_Description_TestCase()
    {
        Assert.That(
            actual: new IdSetFieldRequest(idName: RequestIdName, metadataField: Metadata.Description, metadataValue: "TestDescriptionValue").Compile(true),
            expression: Is.EqualTo("set_field Description TestDescriptionValue RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled SET-request for the <see cref="Metadata.Department"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldSetRequest_Department_TestCase()
    {
        Assert.That(
            actual: new IdSetFieldRequest(idName: RequestIdName, metadataField: Metadata.Department, metadataValue: "TestDepartmentValue").Compile(true),
            expression: Is.EqualTo("set_field Department TestDepartmentValue RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled SET-request for the <see cref="Metadata.Title"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldSetRequest_Title_TestCase()
    {
        Assert.That(
            actual: new IdSetFieldRequest(idName: RequestIdName, metadataField: Metadata.Title, metadataValue: "TestTitleValue").Compile(true),
            expression: Is.EqualTo("set_field Title TestTitleValue RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled SET-request for the <see cref="Metadata.Type"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldSetRequest_Type_TestCase()
    {
        Assert.That(
            actual: new IdSetFieldRequest(idName: RequestIdName, metadataField: Metadata.Type, metadataValue: "TestTypeValue").Compile(true),
            expression: Is.EqualTo("set_field Type TestTypeValue RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled SET-request for the <see cref="Metadata.UserField1"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldSetRequest_UserField1_TestCase()
    {
        Assert.That(
            actual: new IdSetFieldRequest(idName: RequestIdName, metadataField: Metadata.UserField1, metadataValue: "TestUserField1Value").Compile(true),
            expression: Is.EqualTo("set_field UserField1 TestUserField1Value RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled SET-request for the <see cref="Metadata.UserField2"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldSetRequest_UserField2_TestCase()
    {
        Assert.That(
            actual: new IdSetFieldRequest(idName: RequestIdName, metadataField: Metadata.UserField2, metadataValue: "TestUserField2Value").Compile(true),
            expression: Is.EqualTo("set_field UserField2 TestUserField2Value RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled SET-request for the <see cref="Metadata.UserField3"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldSetRequest_UserField3_TestCase()
    {
        Assert.That(
            actual: new IdSetFieldRequest(idName: RequestIdName, metadataField: Metadata.UserField3, metadataValue: "TestUserField3Value").Compile(true),
            expression: Is.EqualTo("set_field UserField3 TestUserField3Value RequestID"));
    }

    /// <summary>
    /// Tests creating a compiled SET-request for the <see cref="Metadata.UserField4"/> metadata field.
    /// </summary>
    [Test]
    public void CompileIdFieldSetRequest_UserField4_TestCase()
    {
        Assert.That(
            actual: new IdSetFieldRequest(idName: RequestIdName, metadataField: Metadata.UserField4, metadataValue: "TestUserField4Value").Compile(true),
            expression: Is.EqualTo("set_field UserField4 TestUserField4Value RequestID"));
    }
}
