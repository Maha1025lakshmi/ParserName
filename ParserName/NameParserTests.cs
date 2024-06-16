using ParserName;
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
    public void ParseFullName_MissingForenameOrSurname_ThrowsArgumentException()
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
    public void ParseFullName_NoForename_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _nameParser.ParseFullName("Doe"));
        Assert.Throws<ArgumentException>(() => _nameParser.ParseFullName("Dr. Doe"));
    }

    [Fact]
    public void ParseFullName_NoSurname_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _nameParser.ParseFullName("John"));
        Assert.Throws<ArgumentException>(() => _nameParser.ParseFullName("Dr. John"));
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

    [Fact]
    public void ParseFullName_FullNameWithoutSpaces_ShouldThrowArgumentException()
    {
        
        var fullName = "Dr.JohnDoe";        
        var exception = Assert.Throws<ArgumentException>(() => _nameParser.ParseFullName(fullName));
        Assert.Equal("Full name must include spaces between the title, forename, middle name, and surname.", exception.Message);
    }
}