namespace ParserName
{
    public interface INameParser
    {
        NameComponents ParseFullName(string fullName);
    }
}