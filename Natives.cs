using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ElevateHandle
{
    public static unsafe class NT
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern uint NtQuerySystemInformation(uint InfoClass, ulong Info, uint Size, out uint Length);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern ulong LoadLibrary([MarshalAs(UnmanagedType.LPStr)]string lpFileName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern ulong GetProcAddress(ulong hModule, string procName);

        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern uint RtlGetVersion(_OSVERSIONINFOEXW* lpVersionInformation);

        [StructLayout(LayoutKind.Sequential)]
        public struct _RTL_PROCESS_MODULES
        {
            public uint NumberOfModules;
            public _RTL_PROCESS_MODULE_INFORMATION Modules;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct _RTL_PROCESS_MODULE_INFORMATION
        {
            public void* Section;
            public void* MappedBase;
            public void* ImageBase;
            public uint ImageSize;
            public uint Flags;
            public ushort LoadOrderIndex;
            public ushort InitOrderIndex;
            public ushort LoadCount;
            public ushort OffsetToFileName;
            public fixed sbyte FullPathName[256];
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct ProcessContext
        {
            public uint ProcessId;
            public ulong DirectoryBase;
            public ulong KernelEntry;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct _OSVERSIONINFOEXW
        {
            public uint dwOSVersionInfoSize;
            public uint dwMajorVersion;
            public uint dwMinorVersion;
            public uint dwBuildNumber;
            public uint dwPlatformId;
            public fixed byte szCSDVersion[128 * 2/*WCHAR*/];     // Maintenance string for PSS usage
            public ushort wServicePackMajor;
            public ushort wServicePackMinor;
            public ushort wSuiteMask;
            public byte wProductType;
            public byte wReserved;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct _HANDLE_TABLE_ENTRY
        {
            public ulong Object;
            public ulong GrantedAccess;
        }
    }
}
