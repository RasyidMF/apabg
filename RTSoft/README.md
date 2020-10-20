# RTSoft Library
Created By : <a href="https://www.facebook.com/RasyidMFS"><b>RasyidMF</b></a><br>
Youtube Channel : <b><a href="https://www.youtube.com/channel/UC4pMFaK2xg1NVlmo3I6Kvkw?view_as=subscriber">Click Here</a></b><br>
Version : <b>1.0<code>(Release)</code></b><br>
Country : <b>Indonesia</b> (+62) <br>
Dev : <b>RTSoft</b><br>

# What is RTSoft Library
a function that is often used by our community and that we release is only some / not all functions. Of course we release this function for free and easy to use. We want to see how you can develop our Function for Growtopia.

# Documentation
to use our function it is expected to pay attention to Uppercase, Parameters because it is sensitive. this programming language that we demonstrated is C#.

#### Added this into your top code
```csharp
using System.Runtime.InteropServices;
```
#### DLL Import
Always added this before added the function
```csharp
[DllImport(@"RTSoft.dll")]
```
Example :
```csharp
[DllImport(@"RTSoft.dll")]
public static extern bool GT_INIT();
```
#### Initialize Growtopia
Allowed your Privilege
```csharp
public static extern bool GT_INIT();
```
#### Accessing Growtopia
Access Growtopia to allowed READ and WRITE memory
```csharp
public static extern int GET_GT(out IntPtr res);
```
#### Hook Ban Bypass Address Growtopia
Reading Location BanBypass Address of Growtopia
```csharp
public static extern IntPtr GET_BAN_BYPASS_ADDR(IntPtr proc);
```
#### Get Address Growtopia
Scanning signature for getting specific Address
```csharp
public static extern IntPtr GET_ADDR(IntPtr proc, string ptr, string msk, out IntPtr resaddr);
```
#### Get Address Growtopia Increment
Scanning signature for getting specific Address, But you can increment the address
```csharp
public static extern IntPtr GET_ADDR_INC(IntPtr proc, string ptr, string msk, int inc, out IntPtr resaddr);
```
#### Read Memory Growtopia
Read Specific Memory Address
```csharp
public static extern IntPtr READ_MEM_ADDR(IntPtr proc, IntPtr addr);
```
#### Write Memory Growtopia
Write Specific Memory Address
```csharp
public static extern bool WRITE_MEM_ADDR(IntPtr proc, string val, int size, IntPtr addr);
```
#### Nop (0x90) Growtopia
Patching Memory as 0x90 (NOP)
```csharp
public static extern bool NOP(IntPtr proc, IntPtr addr, int size);
```
#### Patch Growtopia
Patching Memory
```csharp
public static extern bool PATCH(IntPtr proc, IntPtr addr, byte[] mem, int size);
```
## Information
Some functions return a string but the data type is IntPtr. How to change it using this code.
```csharp
public string CPtoString(IntPtr pointer)
{
    return Marshal.PtrToStringAnsi(pointer);
}
```
And this is the function was supported returns string
```csharp
public static extern IntPtr GET_BAN_BYPASS_ADDR(IntPtr proc);
public static extern IntPtr GET_ADDR(IntPtr proc, string ptr, string msk, out IntPtr resaddr);
public static extern IntPtr GET_ADDR_INC(IntPtr proc, string ptr, string msk, int inc, out IntPtr resaddr);
public static extern IntPtr READ_MEM_ADDR(IntPtr proc, IntPtr addr);
```
Example
```csharp
string v = CPtoString(GET_BAN_BYPASS_ADDR(proc));
```
## Some unique Error / Success Code
```csharp
public static extern int GET_GT(out IntPtr res);
// Status Code :
// 0 = Growtopia Not Found
// 1 = Access Denied
// 2 = Success

public static extern IntPtr GET_BAN_BYPASS_ADDR(IntPtr proc);
public static extern IntPtr GET_ADDR(IntPtr proc, string ptr, string msk, out IntPtr resaddr);
public static extern IntPtr GET_ADDR_INC(IntPtr proc, string ptr, string msk, int inc, out IntPtr resaddr);
// Status Code :
// 0 = Address Not Found
// 5 = Access Denied
// 299 = Check your Computer BIT, 32 / 64 Bit
// Full of System Error code you can found in here https://docs.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-
```
## DLLImport
```csharp
[DllImport(@"RTSoft.dll")]
public static extern bool GT_INIT();
[DllImport(@"RTSoft.dll")]
public static extern int GET_GT(out IntPtr res);
[DllImport(@"RTSoft.dll")]
public static extern IntPtr GET_BAN_BYPASS_ADDR(IntPtr proc);
[DllImport(@"RTSoft.dll")]
public static extern IntPtr GET_ADDR(IntPtr proc, string ptr, string msk, out IntPtr resaddr);
[DllImport(@"RTSoft.dll")]
public static extern IntPtr GET_ADDR_INC(IntPtr proc, string ptr, string msk, int inc, out IntPtr resaddr);
[DllImport(@"RTSoft.dll")]
public static extern IntPtr READ_MEM_ADDR(IntPtr proc, IntPtr addr);
[DllImport(@"RTSoft.dll")]
public static extern bool WRITE_MEM_ADDR(IntPtr proc, string val, int size, IntPtr addr);
[DllImport(@"RTSoft.dll")]
public static extern bool NOP(IntPtr proc, IntPtr addr, int size);
[DllImport(@"RTSoft.dll")]
public static extern bool PATCH(IntPtr proc, IntPtr addr, byte[] mem, int size);
```


