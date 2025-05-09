cmake_minimum_required(VERSION 3.10)
project(geasy)

add_library(geasy SHARED geasy.cpp)

target_compile_features(geasy PUBLIC cxx_std_17)

# Windows DLL export symbol
target_compile_definitions(geasy PRIVATE GEASY_EXPORTS)