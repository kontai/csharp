using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Serialization;
using _06enumDemo;
using FunWithBitwiseOperations;

EmpTypeRnum e = EmpTypeRnum.Manager;
//funEnum(e);

bitWiseOperator b = new bitWiseOperator();
b.FunWithBitwise();
ContactPreferenceEnum emailAndPhone =
    ContactPreferenceEnum.Email | ContactPreferenceEnum.Phone;
Console.WriteLine("None? {0}", (emailAndPhone | ContactPreferenceEnum.None) == emailAndPhone);
Console.WriteLine("Email? {0}", (emailAndPhone | ContactPreferenceEnum.Email) == emailAndPhone);
Console.WriteLine("Email? {0}", (emailAndPhone & ContactPreferenceEnum.Email) != ContactPreferenceEnum.None);
Console.WriteLine(emailAndPhone);   //Flag Attributes toString Display Name(Without Flags,just show 6)


static void funEnum(System.Enum e1)
{
    EmpTypeRnum e = (EmpTypeRnum)e1;
    //get enum type 
    Console.WriteLine(typeof(EmpTypeRnum));
    Console.WriteLine(e.GetType());

    //get enum type
    Console.WriteLine(EmpTypeRnum.GetValuesAsUnderlyingType(typeof(EmpTypeRnum)));

    Console.WriteLine(e);
    Type enumType = e.GetType();
    Console.WriteLine((byte)e);
    Console.WriteLine(e.GetType().Name);

    Array enumData = Enum.GetValues(e.GetType());
    foreach (var o in e.GetType().GetEnumValues())
    {
        Console.WriteLine(o);
    }

    Console.WriteLine("This enum has {0} members", enumData.Length);
    Console.WriteLine("{0},{0:D}", enumData.GetValue(0));
}


enum EmpTypeRnum : byte
{
    Manager = 10,
    Grunt = 1,
    Contractor = 100,
    //VicePresident = 999 //too big for a byte!
}