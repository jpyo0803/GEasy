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

GEASY_API bool PNPolyFloat(float point_x, float point_y, float* polygon_x_arr, float* polygon_y_arr,
                           int size);

#ifdef __cplusplus
}
#endif
