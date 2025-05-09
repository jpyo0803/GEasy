#include "geasy_api.h"
#include "geasy.h"

float TestSum(float* arr, int size) {
  return geasy::TestSum(arr, size);
}

bool PNPolyFloat(float point_x, float point_y, float* polygon_x_arr, float* polygon_y_arr,
                 int size) {
  return geasy::PNPolyFloat(point_x, point_y, polygon_x_arr, polygon_y_arr, size);
}