using System;
using System.Runtime.InteropServices;

namespace ScreenLogger
{
    public struct CursorInfo
    {
        public uint cbSize;
        public uint flags;
        public IntPtr hCursor;
        public PointStruct ptScreenPos;

        public void Initialize()
        {
            cbSize = (uint)Marshal.SizeOf(typeof(CursorInfo));
        }
    }
}
