using System.Numerics;
using System.Text;
using CWTools.CSharp;
using CWTools.Parser;
using CWTools.Process;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using QuickGraph;

namespace autohive;

public class Generate
{
    private string StellarisPath;
    private string ModPath;

    public Generate(string stellarisPath, string modPath)
    {
        StellarisPath = stellarisPath;
        ModPath = modPath;
    }

    public int gen()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        foreach (var row in ConversionTable.Table)
        {
            if (row.IsCommon)
            {
                int i = ParseCommon(row);

                if (i != 0)
                {
                    Console.WriteLine("Error parsing row: " + row);
                    return 1;
                }
            }
        }

        return 0;
    }

    // Handle all the stuff in the "common" folder
    private int ParseCommon(ConversionRow row)
    {
        string fullPath = StellarisPath + "/common/" + row.CanonicalPath;
        string[] files = Directory.GetFiles(fullPath, "*.txt");
        Console.WriteLine("Parsing files: ");
        foreach (var VARIABLE in files)
        {
            Console.WriteLine(VARIABLE);
        }

        for (int i = 0; i < files.Length; i++)
        {
            var parsed = CKParser.parseFile(files[i]);
            if (parsed.IsFailure)
            {
                return 1;
            }
            FSharpList<Types.Statement> parsedResult = parsed.GetResult();
            var v = LanguagePrimitives.IntrinsicFunctions.UnboxGeneric<Node>((object) FSharpFunc<string, CWTools.Utilities.Position.range>.InvokeFast<FSharpList<Types.Statement>, Node>(CK2Process.ck2Process.ProcessNode(), "", CWTools.Utilities.Position.range.Zero, parsedResult));
            
            Console.WriteLine("Extracted " + v.Children.Length + " children from v");
            foreach (var child in v.Children)
            {
                if (child == null)
                    continue;
                //ScanNode(child, row.Elements[0].ScanPattern);
                Console.WriteLine(child.Key);
                RecursivePrint(child);
                
                
            }
            

        }
        
        return 0;
    }

    private void RecursivePrint(Node n, string spacing = "")
    {
        Console.WriteLine(spacing + "Key: " + n.Key);
        foreach(var i in n.Values)
        {
            Console.WriteLine(spacing + "----Val: " + i.Key + ", " + i.Value);
        }
        foreach (var child in n.Children)
        {
            RecursivePrint(child, spacing + "    ");
        }
    }

    private bool ScanNode(Node n, string[] keyPattern)
    {
        


        return false;
    }
}