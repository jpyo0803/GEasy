WINDOWS
MINGW version: 6.3.0

MINGW64 installation
1. $ Install MSYS2
2. $ pacman -S mingw-w64-x86_64-gcc

how to build (CMD 터미널 사용) 

1. $ set PATH=C:\msys64\mingw64\bin;%PATH% (만약 gcc가 C:\msys64\mingw64\bin\gcc.exe에 있다면)
2. go to "geasy_cpp" directory
3. $ mkdir build
4. $ cd build
5. $ cmake .. -G "MinGW Makefiles"
6. $ mingw32-makemake
7. libgeasy.dll을 <사용 프로젝트>\bin\debug에 넣으면됨