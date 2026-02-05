string[] names = ["John", "Peter", "James", "John", "Peter", "James"];
Console.WriteLine("Original sting: {0}", string.Join(',', names));

IEnumerable<string> longName = Enumerable.Where(names, n => n.Length >= 4);
Console.WriteLine("longName: {0}", string.Join(',', longName));

IEnumerable<string> enumerable = names.Where(n => n.Length >= 4);
Console.WriteLine("enumerable: {0}", string.Join(',', enumerable));

/****************************** ordering is matter  **************************************/
int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
//take first 3 elements
IEnumerable<int> take = numbers.Take(3);
Console.WriteLine(string.Join(',', take));

//skip first 3 elements
IEnumerable<int> skip = numbers.Skip(3);
Console.WriteLine(string.Join(',', skip));

//reverse the collection
IEnumerable<int> reverse = numbers.Reverse();
Console.WriteLine(string.Join(",", reverse));

/****************************** Element Operators   **************************************/
// First

numbers = [10, 9, 8, 7, 6];

int first = numbers.First();
Console.WriteLine($"first: {first}");

//Last
int last = numbers.Last();
Console.WriteLine($"last: {last}");

//ElementAt
int elementAt = numbers.ElementAt(2);
Console.WriteLine($"ElementAt(2): {elementAt}");

Console.WriteLine(numbers.OrderBy(i => i).Skip(1).First());

#region Aggregation Operators

/******************************聚合運算子Aggregation Operators   **************************************/

numbers = [10, 9, 8, 7, 6];
//Count
int count = numbers.Count();

//Sum
int sum = numbers.Sum();

//Average
double average = numbers.Average();

//Max
int max = numbers.Max();

//Min
int min = numbers.Min();

#endregion

#region Quantifiers 

/******************************Quantifiers   **************************************/
numbers = [10, 9, 8, 7, 6];
//Contains
bool contains = numbers.Contains(5);
Console.WriteLine($"Contains? {contains}");

//Any
bool any = numbers.Any(n => n > 6);
Console.WriteLine($"any? {any}");

//All
bool all = numbers.All(n => n > 6);
Console.WriteLine($"all? {all}");

#endregion


#region Merge Operators 

/****************************** merge Operators   **************************************/
//Concat
int[] numbers1 = [1, 2, 3, 4, 5];
int[] numbers2 = [6, 7, 8, 9, 10];
IEnumerable<int> concat = numbers1.Concat(numbers2);
Console.WriteLine(string.Join(',', concat));

//Union
int[] numbers3 = [1, 2, 3, 4, 5];
int[] numbers4 = [4, 5, 6, 7, 8];
IEnumerable<int> union = numbers3.Union(numbers4);
Console.WriteLine(string.Join(',', union));

//Intersect
int[] numbers5 = [1, 2, 3, 4, 5];
int[] numbers6 = [4, 5, 6, 7, 8];
IEnumerable<int> intersect = numbers5.Intersect(numbers6);
Console.WriteLine(string.Join(',', intersect));

//Except
int[] numbers7 = [1, 2, 3, 4, 5];
int[] numbers8 = [4, 5, 6, 7, 8];
IEnumerable<int> except = numbers7.Except(numbers8);
Console.WriteLine(string.Join(',', except));

//Zip
int[] numbers9 = [1, 2, 3, 4, 5];
int[] numbers10 = [6, 7, 8, 9, 10];
IEnumerable<int> zip = numbers9.Zip(numbers10, (n1, n2) => n1 + n2); //1+6, 2+7, 3+8, 4+9, 5+10
Console.WriteLine(string.Join(',', zip));

//Distinct
int[] numbers11 = [1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 6];
IEnumerable<int> distinct = numbers11.Distinct();
Console.WriteLine(string.Join(',', distinct));

#endregion

Console.Clear();
