using AttributedCarLibrary;
/*
 * 提前繫結 (Early Binding)
 * 成員必須是公開的
 */
Console.WriteLine("***** Value of VehicleDescriptionAttribute *****\n");
ReflectOnAttributesUsingEarlyBinding();
// Console.ReadLine();
static void ReflectOnAttributesUsingEarlyBinding()
{
    // 取得代表 Winnebago 的 Type。
    Type t = typeof(Winnebago);
    // 取得 Winnebago 上所有的屬性。
    object[] customAtts = t.GetCustomAttributes(false);
    // 印出描述。
    foreach (VehicleDescriptionAttribute v in customAtts)
    {
        Console.WriteLine("-> {0}\n", v.Description);
    }
}