using System.Reflection;
Console.WriteLine("***** Value of VehicleDescriptionAttribute *****\n");
ReflectAttributesUsingLateBinding();
Console.ReadLine();

static void ReflectAttributesUsingLateBinding()
{
    try
    {
        // 載入本機的 AttributedCarLibrary 副本。
        Assembly asm = Assembly.LoadFrom("AttributedCarLibrary");
        // 取得 VehicleDescriptionAttribute 的型別資訊。
        Type vehicleDesc =
            asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");
        // 取得 Description 屬性的型別資訊。
        PropertyInfo? propDesc = vehicleDesc?.GetProperty("Description");
        // 取得組件中所有的型別。
        Type[] types = asm.GetTypes();
        // 走訪每個型別，並取得任何 VehicleDescriptionAttribute。
        foreach (Type t in types)
        {
            object[] objs = t.GetCustomAttributes(vehicleDesc, false);
            // 走訪每個 VehicleDescriptionAttribute，並用延遲繫結
            // 印出描述。
            foreach (object o in objs)
            {
                Console.WriteLine("-> {0}: {1}\n", t.Name,
                    propDesc.GetValue(o, null));
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
