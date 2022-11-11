using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Data.OleDb;
using System.Data;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static Program;
using System.Reflection.PortableExecutable;

public partial class Program
{
    public static void Main()
    {
        // Read, parse, and generate bill report
        var report = new BillReport("BillFile.xml").GenerateReport();
        Console.WriteLine(report);
        // Export bill report into a .rpt file
        File.WriteAllText($"BillFile-{DateTime.Now.ToString("MMddyyyy")}.rpt", report);
    }

}