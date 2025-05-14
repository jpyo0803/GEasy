#include "geasy_api.h"
#include "geasy.h"

float TestSum(float* arr, int size) {
  return geasy::TestSum(arr, size);
}

bool PNPolyFloat(float point_x, float point_y, float* polygon_x_arr, float* polygon_y_arr,
                 int size) {
  return geasy::PNPolyFloat(point_x, point_y, polygon_x_arr, polygon_y_arr, size);
}

void ClosestPairFloat(float* point_x_arr, float* point_y_arr, int size, float* out_x1,
                      float* out_y1, float* out_x2, float* out_y2, double* out_min_dist) {
  geasy::ClosestPairFloat(point_x_arr, point_y_arr, size, out_x1, out_y1, out_x2, out_y2,
                          out_min_dist);
}

void ConvexHullFloat(float* point_x_arr, float* point_y_arr, int size, float* out_point_x_arr,
                     float* out_point_y_arr, int* out_size) {
  geasy::ConvexHullFloat(point_x_arr, point_y_arr, size, out_point_x_arr, out_point_y_arr,
                         out_size);
}