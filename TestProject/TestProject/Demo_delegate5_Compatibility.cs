
D1 d1 = Method;
//D2 d2 = d1;
D2 d2 = new D2(d1);

D1 d3 = Method;
Console.WriteLine(d1 == d3);

D1 d4 = Method;
d1 += d4;
Console.WriteLine(d1 == d3);
d3 += d4;
Console.WriteLine(d1 == d3);
void Method() { }

delegate void D1();
delegate void D2();