Person p1 = Person.Create("Roman", "Mikula");
Person p2 = Person.Create("Monika");
Person? p3 = null;

Book faust = Book.Create("Doctor faustus", p1);
Book retorika = Book.Create("Retorika", p2);
Book nights = Book.Create("Tisic a jedna noc");

Console.WriteLine(GetBookLabel(faust));
Console.WriteLine(GetBookLabel(retorika));
Console.WriteLine(GetBookLabel(nights));

string GetBookLabel(Book book)
{
    return book
        .Author
        .Map(GetLabel)
        .Map(author => $"{book.Title} by {author}")
        .Reduce(book.Title);
}

string GetLabel(Person person)
{
    return person
        .LastName
        .Map(lastName => $"{person.FirstName} {lastName}")
        .Reduce(person.FirstName);
}


public class Person
{
    public string FirstName { get; }
    public Option<string> LastName { get; }

    private Person(string firstName, Option<string> lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Person Create(string firstName, string lastName) =>
        new Person(firstName, Option<string>.Some(lastName));

    public static Person Create(string firstName) =>
        new Person(firstName, Option<string>.None);
}


public class Book
{
    public string Title { get; }
    public Option<Person> Author { get; }

    private Book(string title, Option<Person> author)
    {
        Title = title;
        Author = author;
    }

    public static Book Create(string title, Person author)
    {
        return new Book(title: title, author: Option<Person>.Some(author));
    }

    public static Book Create(string title)
    {
        return new Book(title: title, author: Option<Person>.None);
    }
}