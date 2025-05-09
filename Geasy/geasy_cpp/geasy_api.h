#pragma once  // header guard

#ifdef _WIN32
#ifdef GEASY_EXPORTS
#define GEASY_API __declspec(dllexport)
#else
#define GEASY_API __declspec(dllimport)
#endif
#endif

#ifdef __cplusplus
extern "C" {
#endif

GEASY_API float TestSum(float* arr, int size);

#ifdef __cplusplus
}
#endif
