using System;

FunWithBitwiseOperations();

FunWithEMailPhone();
FileParmissionTest();
static void FunWithBitwiseOperations()
{
    Console.WriteLine("===== Fun wih Bitwise Operations");
    Console.WriteLine("6: {0}", Convert.ToString(6, 2).PadLeft(8, '0'));
    Console.WriteLine("6: {0}", Convert.ToString(4, 2).PadLeft(8, '0'));
    Console.WriteLine("6 & 4 = {0} | {1}", 6 & 4, Convert.ToString((6 & 4), 2));
    Console.WriteLine("6 | 4 = {0} | {1}", 6 | 4, Convert.ToString((6 | 4), 2));
    Console.WriteLine("6 ^ 4 = {0} | {1}", 6 ^ 4, Convert.ToString((6 ^ 4), 2));
    Console.WriteLine("6 << 1  = {0} | {1}", 6 << 1, Convert.ToString((6 << 1), 2));
    Console.WriteLine("6 >> 1 = {0} | {1}", 6 >> 1, Convert.ToString((6 >> 1), 2));
    Console.WriteLine("~6 = {0} | {1}", ~6, Convert.ToString(~((short)6), 2));
    Console.WriteLine("Int.MaxValue {0}", Convert.ToString((int.MaxValue), 2));
}

static void FunWithEMailPhone()
{
    ContactPreferenceEnum emailAndPhone = ContactPreferenceEnum.Email | ContactPreferenceEnum.Phone;
    Console.WriteLine("has phone? {0}",emailAndPhone.HasFlag(ContactPreferenceEnum.Phone));
    Console.WriteLine("None? {0}", (emailAndPhone | ContactPreferenceEnum.None) == emailAndPhone);
Console.WriteLine("Email? {0}", (emailAndPhone | ContactPreferenceEnum.Email) == emailAndPhone);
Console.WriteLine("Phone? {0}", (emailAndPhone | ContactPreferenceEnum.Phone) == emailAndPhone);
Console.WriteLine("Text? {0}", (emailAndPhone | ContactPreferenceEnum.Text) == emailAndPhone);
}

static void FileParmissionTest()
{
FilePermissions permissions = FilePermissions.Read | FilePermissions.Write;

bool canRead = (permissions & FilePermissions.Read) == FilePermissions.Read;
Console.WriteLine($"can read? {canRead}");

    //無flags,輸出3;有flags,輸出Read,Write
Console.WriteLine(permissions);
}

[Flags]
public enum ContactPreferenceEnum
{
    None = 1,
    Email = 2,
    Phone = 4,
    Text = 6
}


