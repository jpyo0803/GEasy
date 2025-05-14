#pragma once  // header guard

#if defined(_WIN32) || defined(_WIN64)
#ifdef GEASY_EXPORTS
#define GEASY_API __declspec(dllexport)
#else
#define GEASY_API __declspec(dllimport)
#endif
#else
// For non-Windows (Linux, macOS), define it as empty
#define GEASY_API
#endif

#ifdef __cplusplus
extern "C" {
#endif

GEASY_API float TestSum(float* arr, int size);

GEASY_API bool PNPolyFloat(float point_x, float point_y, float* polygon_x_arr, float* polygon_y_arr,
                           int size);

GEASY_API void ClosestPairFloat(float* point_x_arr, float* point_y_arr, int size, float* out_x1,
                                float* out_y1, float* out_x2, float* out_y2, double* out_min_dist);
#ifdef __cplusplus
}
#endif
