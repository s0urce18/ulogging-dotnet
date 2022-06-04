# ulogging-dotnet

.NET library for logging

## Installation:

Download `.dll` files from `DLLs` folder or download `DLLs.zip`

## Importing:

1. Add `.dll` files to your project

2. Add to your document:
    ```cs
    using Ulogging;
    ```

## Using:

`LogItLowImportance<T1, T2, ... TAnsw>(Func<T1, T2, ... TAnsw>)` — function low importance logging

`LogItLowImportance<T1, T2, ... T16>(Action<T1, T2, ... T16>)` — void low importance logging

`LogItHighImportance<T1, T2, ... TAnsw>(Func<T1, T2, ... TAnsw>)` — function high importance logging

`LogItHighImportance<T1, T2, ... T16>(Action<T1, T2, ... T16>)` — void high importance logging

`LogHere(string)` — method for log where you put this method

`File.Close();` — closing output file (DON'T FORGET ABOUT PUTTING IT TO END OF A FILE)

And other documentation in `Ulogging/Ulogging.cs` and examples in `Example/Example.cs`