//Progressive Queries
string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

IEnumerable<string> query =
    from n in names
    select n.Replace("a", "").Replace("e", "").Replace("i", "")
        .Replace("o", "").Replace("u", "");

query = from n in query
        where n.Length > 2
        orderby n
        select n;


//Wrapping Queries
query = from n1 in
    (
        from n2 in names
        select n2.Replace("a", "").Replace("e", "").Replace("i", "")
            .Replace("o", "").Replace("u", "")
    )
        where n1.Length > 2
        orderby n1
        select n1;