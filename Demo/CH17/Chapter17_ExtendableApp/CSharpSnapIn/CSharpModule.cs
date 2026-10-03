using System;
using System.Collections.Generic;
using System.Text;
using CommonSnappableTypes;

namespace CSharpSnapIn;

[CompanyInfo(CompanyName = "FooBar", CompanyUrl = "Www.FooBar.com")]
internal class CSharpModule : IAppFunctionality
{
    public void Doit()
    {
        Console.WriteLine("You have just used the C# shap-in!");
    }
}
