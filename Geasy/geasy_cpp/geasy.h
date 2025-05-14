#pragma once

namespace geasy {

float TestSum(float* arr, int size);

bool PNPolyFloat(float point_x, float point_y, float* polygon_x_arr, float* polygon_y_arr,
                 int size);

void ClosestPairFloat(float* point_x_arr, float* point_y_arr, int size, float* out_x1,
                      float* out_y1, float* out_x2, float* out_y2, double* out_min_dist);

void ConvexHullFloat(float* point_x_arr, float* point_y_arr, int size, float* out_point_x_arr,
                     float* out_point_y_arr, int* out_size);
}  // namespace geasy