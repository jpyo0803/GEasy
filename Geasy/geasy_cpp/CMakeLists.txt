cmake_minimum_required(VERSION 3.10)
project(geasy_cpp)

# 라이브러리 대상 파일들
add_library(geasy_cpp SHARED
    geasy_api.cpp     # C API 인터페이스
    geasy.cpp         # 핵심 구현부
    point2d_float.cpp
    vector2d_float.cpp
    segment2d_float.cpp
)

# C++17 사용
target_compile_features(geasy_cpp PUBLIC cxx_std_17)

# Windows DLL symbol export
target_compile_definitions(geasy_cpp PRIVATE GEASY_EXPORTS)

# 헤더 포함 경로 설정
target_include_directories(geasy_cpp PUBLIC ${CMAKE_CURRENT_SOURCE_DIR})

add_custom_command(TARGET geasy_cpp POST_BUILD
  COMMAND ${CMAKE_COMMAND} -E copy_if_different
    $<TARGET_FILE:geasy_cpp>
    ${CMAKE_SOURCE_DIR}/../../GeasyRunner/bin/Debug/net8.0/
  COMMAND ${CMAKE_COMMAND} -E copy_if_different
    $<TARGET_FILE:geasy_cpp>
    ${CMAKE_SOURCE_DIR}/../../Geasy.Tests/bin/Debug/net8.0/
)

add_executable(geasy_tests
    unittests.cpp
    geasy.cpp         # 핵심 구현부
    point2d_float.cpp
    vector2d_float.cpp
    segment2d_float.cpp
)

target_link_libraries(geasy_tests PRIVATE geasy_cpp)
target_include_directories(geasy_tests PRIVATE ${CMAKE_CURRENT_SOURCE_DIR})