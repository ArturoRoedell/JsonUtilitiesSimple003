using System.Diagnostics;
using static FileUtilitiesBasic;
using System.Collections.Generic; 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualBasic;
using static Types;


namespace JsonUtilitiesSimple003.Tests;

public class FileUtilitiesBasicTest
{
	private FileUtilitiesBasic _fileUtilitiesBasic = new FileUtilitiesBasic();
	[Fact]
	public void ShouldPutPathTotgether()
	{
		string path = @"C:\MyFolder";
		string filename = "HighSocres";
		string expected = @"C:\MyFolder\HighSocres.json";
		string actual = _fileUtilitiesBasic.ConcatPathFileNameAndSuffix(path, filename, ".json");
		Xunit.Assert.Equal(expected, actual);
	}

	[Fact]
	public void ShouldCheckIfFIleExistsThenCreateFile()
	{
		string FilePath =
			@"C:\Users\ARTURO 001\source\repos\JsonUtilitiesSimple003\src\JsonUtilitiesSimple003.Tests\" + 
			@"TestCreationFile\UnicornSecrets.txt";
		File.Delete(FilePath);
		_fileUtilitiesBasic.CheckIfFileExistsThenCreateIt(FilePath);
		Xunit.Assert.True(File.Exists(FilePath));
	}
	
	[Fact]
	public void ShouldDeserializeJsonStringReturnList()
	{
		string JsonRawData =
@"[
  {
    ""Name"": ""Arty"",
    ""Score"": 481
  },
  {
    ""Name"": ""Jessica"",
    ""Score"": 3454
  }
]
";
		List<NameAndScoreSet> expectedList = new List<NameAndScoreSet>();
		expectedList.Add(new NameAndScoreSet("Arty", 481));
		expectedList.Add(new NameAndScoreSet("Jessica", 3454));
		List<NameAndScoreSet> actualList = _fileUtilitiesBasic.DeserializeJsonStringReturnList<NameAndScoreSet>(JsonRawData);
		CollectionAssert.AreNotEquivalent(expectedList,actualList);
	}
	
	[Fact]
	public void ShouldSerializeJsonDataReturnString()
	{
		List<NameAndScoreSet> listData = new List<NameAndScoreSet>();
		listData.Add(new NameAndScoreSet("Arty", 481));
		listData.Add(new NameAndScoreSet("Jessica", 3454));
		string expectedJsonData =
			@"[
  {
    ""Name"": ""Arty"",
    ""Score"": 481
  },
  {
    ""Name"": ""Jessica"",
    ""Score"": 3454
  }
]
";
		string actualJsonData = _fileUtilitiesBasic.SerializeJsonDataReturnString(listData);
		Xunit.Assert.Matches(expectedJsonData,actualJsonData);
	}
}


