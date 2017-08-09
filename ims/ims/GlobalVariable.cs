using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class GlobalVariable
{
    public static string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
    public static string path = (System.IO.Path.GetDirectoryName(executable));
}
