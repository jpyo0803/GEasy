WINDOWS

MINGW64 installation
$ [https://visualstudio.microsoft.com/ko/visual-cpp-build-tools/]에서 Install MSVC build tool 설치

how to build (CMD 터미널 사용) 

1. $ set PATH=C:\msys64\mingw64\bin;%PATH% (만약 gcc가 C:\msys64\mingw64\bin\gcc.exe에 있다면)
2. go to "geasy_cpp" directory
3. $ mkdir build
4. $ cmake -B build -G "Visual Studio 17 2022" -A x64
5. $ cmake --build build --config Release


MACOS / LINUX
1. go to "geasy_cpp" directory
2. $ mkdir build
3. $ cd build
3. $ cmake .. 
4. $ make