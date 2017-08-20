using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevateHandle
{
    unsafe class Program
    {
        static void Main(string[] args)
        {
            ElevateHandle.Driver.Load();
            ElevateHandle.UpdateDynamicData();


            ElevateHandle.Elevate(0xDEADBEEF, 0xDEADBEEF);

            //if (.Attach(Convert.ToUInt32(args[0])))
            //    if (!elevator.ElevateHandleAccess((IntPtr)Convert.ToUInt32(args[1]), 0x1fffff))
            //        throw new Exception("ElevateHandleAccess returned false");
            //
            //Console.ReadLine();

            ElevateHandle.Driver.Unload();
        }
    }
}
