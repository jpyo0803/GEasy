// NativeLibrary.cs
namespace Geasy
{
    internal static class NativeLibrary
    {
#if LINUX
    public const string LIB_NAME = "libgeasy_cpp.so";
#elif OSX
    public const string LIB_NAME = "libgeasy_cpp.dylib";
#else
        public const string LIB_NAME = "geasy_cpp.dll";
#endif
    }
}
