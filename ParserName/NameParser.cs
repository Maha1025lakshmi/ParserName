using ParserName;
using System.Collections.Generic;
using System.Text.RegularExpressions;
public class NameParser : INameParser
{
    public NameComponents ParseFullName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("Full name cannot be empty or whitespace.");
        }

        if (!IsValidName(fullName))
        {
            throw new ArgumentException("Full name must contain valid characters.");
        }

        string[] titles = { "Mr.", "Mrs.", "Ms.", "Dr." , "Prof." };
        string? title = null, forename = null, middleName = null, surname = null;      

        string[] name = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int index = 0;

        // Check if the first part is a title
        if (name.Length > 0 && titles.Contains(name[0]))
        {
            title = name[0];
            index++;
        }

        // Assign forename
        if (name.Length > index)
        {
            forename = name[index];
            index++;
        }

        // Assign surname and handle middle names
        if (name.Length > index)
        {
            surname = name[^1];
            if (index < name.Length - 1)
            {
                middleName = string.Join(' ', name[index..^1]);
            }
        }

        if (string.IsNullOrEmpty(forename) && string.IsNullOrEmpty(surname))
        {
            throw new ArgumentException("Full name must include at least a forename and a surname.");
        }
        

        return new NameComponents
        {
            Title = title,
            Forename = forename,
            MiddleName = middleName,
            Surname = surname
        };
    }

    private bool IsValidName(string fullName)
    {
        // Regex to check for invalid characters
        var regex = new Regex(@"^[a-zA-Z\s\.]*$");
        return regex.IsMatch(fullName);
    }
}