WINDOWS

MINGW64 installation
$ [https://visualstudio.microsoft.com/ko/visual-cpp-build-tools/]에서 Install MSVC build tool 설치

how to build (CMD 터미널 사용) 

1. $ set PATH=C:\msys64\mingw64\bin;%PATH% (만약 gcc가 C:\msys64\mingw64\bin\gcc.exe에 있다면)
2. go to "geasy_cpp" directory
3. $ mkdir build
4. $ cmake -B build -G "Visual Studio 17 2022" -A x64
5. $ cmake --build build --config Release
6. build/Release/geasy_cpp.dll을 <사용 프로젝트>\bin\debug에 넣으면됨