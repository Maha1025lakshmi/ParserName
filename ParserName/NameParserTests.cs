﻿using ParserName;
using Xunit;


public class NameParserTests
{
    private readonly INameParser _nameParser;

    public NameParserTests()
    {
        _nameParser = new NameParser();
    }

    [Fact]
    public void ParseFullName_ValidNameWithTitle_ReturnsCorrectComponents()
    {
        var result = _nameParser.ParseFullName("Dr. John Michael Doe");

        Assert.Equal("Dr.", result.Title);
        Assert.Equal("John", result.Forename);
        Assert.Equal("Michael", result.MiddleName);
        Assert.Equal("Doe", result.Surname);
    }

    [Fact]
    public void ParseFullName_ValidNameWithoutTitle_ReturnsCorrectComponents()
    {
        var result = _nameParser.ParseFullName("John Michael Doe");

        Assert.Null(result.Title);
        Assert.Equal("John", result.Forename);
        Assert.Equal("Michael", result.MiddleName);
        Assert.Equal("Doe", result.Surname);
    }

    [Fact]
    public void ParseFullName_MissingForenameandSurname_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _nameParser.ParseFullName("John"));
        Assert.Throws<ArgumentException>(() => _nameParser.ParseFullName("Doe"));
    }

    [Fact]
    public void ParseFullName_EmptyOrWhitespace_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _nameParser.ParseFullName(""));
        Assert.Throws<ArgumentException>(() => _nameParser.ParseFullName("    "));
    }

    [Fact]
    public void ParseFullName_TitleOnly_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _nameParser.ParseFullName("Dr."));
        Assert.Throws<ArgumentException>(() => _nameParser.ParseFullName("Mr."));
    }    

    [Fact]
    public void ParseFullName_NonNameCharacters_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _nameParser.ParseFullName("@#$%^&*()"));
    }

    [Fact]
    public void ParseFullName_ExtraSpaces_ReturnsCorrectComponents()
    {
        var result = _nameParser.ParseFullName("  John   Michael   Doe  ");

        Assert.Null(result.Title);
        Assert.Equal("John", result.Forename);
        Assert.Equal("Michael", result.MiddleName);
        Assert.Equal("Doe", result.Surname);
    }

    [Fact]
    public void ParseFullName_ValidFullNameWithMultipleMiddleNames_ShouldReturnCorrectNameComponents()
    {
        
        var fullName = "Dr. John Michael David Smith";
        var result = _nameParser.ParseFullName(fullName);        
        Assert.Equal("Dr.", result.Title);
        Assert.Equal("John", result.Forename);
        Assert.Equal("Michael David", result.MiddleName);
        Assert.Equal("Smith", result.Surname);
    }   
}
