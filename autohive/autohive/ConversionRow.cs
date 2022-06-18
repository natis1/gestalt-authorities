namespace autohive;

public struct ConversionElement
{
    // This will go to ScanPattern and remove anything in scanRemove it finds among the children
    // then it will add anything in scanAdd in order.
    // The last element in scan pattern is a leaf value
    // scan pattern matches the key with that leaf value
    public string[] ScanPattern;
    public string[] ScanRemove;
    public string[] ScanAdd;
    // If only match is set, it will only act on root keys that match OnlyMatch
    public string[] OnlyMatch;

    public ConversionElement(string[] scanPattern, string[] scanRemove, string[] scanAdd, string[] onlyMatch)
    {
        ScanAdd = scanAdd;
        ScanPattern = scanPattern;
        ScanRemove = scanRemove;
        OnlyMatch = onlyMatch;
    }
}

public struct ConversionRow
{
    public string CanonicalPath;
    public bool IsCommon;
    public ConversionElement[] Elements;
    

    public ConversionRow(string canonicalPath, ConversionElement[] elements, bool isCommon = true)
    {
        CanonicalPath = canonicalPath;
        Elements = elements;
        IsCommon = isCommon;
    }
}