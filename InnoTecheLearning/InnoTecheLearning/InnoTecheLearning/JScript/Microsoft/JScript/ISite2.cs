﻿namespace Microsoft.JScript
{
    using System;
    using System.Runtime.InteropServices;

    [ComVisible(true), Guid("BFF6C980-0705-4394-88B8-A03A4B8B4CD7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISite2
    {
        object[] GetParentChain(object obj);
    }
}

