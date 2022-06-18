// See https://aka.ms/new-console-template for more information

using autohive;

Console.WriteLine("Hello, World!");

if (args.Length < 2)
{
    Console.WriteLine("ERROR: autohive requires two arguments to run");
    Console.WriteLine("./autohive <Stellaris Path> <Output Path>");
    return 1;
}

Generate g = new Generate(args[0], args[1]);

return g.gen();