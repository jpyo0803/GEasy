#include "geasy.h"
#include <memory>
#include "pnpoly/pnpoly.h"
#include "pnpoly/pnpoly_strategy.h"

namespace geasy {

float TestSum(float* arr, int size) {
  float sum = 0;
  for (int i = 0; i < size; ++i) sum += arr[i];
  return sum;
}

bool PNPolyFloat(float point_x, float point_y, float* polygon_x_arr, float* polygon_y_arr,
                 int size) {
  PNPoly obj;
  obj.set_strategy(std::make_unique<WindingNumberMethod>());

  Point2dFloat point(point_x, point_y);

  std::vector<Point2dFloat> polygon;
  polygon.reserve(size);

  for (int i = 0; i < size; ++i) {
    polygon.emplace_back(polygon_x_arr[i], polygon_y_arr[i]);
  }

  return obj.Test(point, polygon);
}

}  // namespace geasy