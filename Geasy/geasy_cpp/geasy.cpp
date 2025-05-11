#include "geasy.h"
#include <memory>
#include "pnpoly/pnpoly.h"
#include "pnpoly/pnpoly_strategy.h"

#include "closest_pair/closest_pair.h"
#include "closest_pair/closest_pair_strategy.h"

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

void ClosestPairFloat(float* point_x_arr, float* point_y_arr, int size, float* out_x1,
                      float* out_y1, float* out_x2, float* out_y2, double* out_min_dist) {
  ClosestPair obj;
  obj.set_strategy(std::make_unique<DivideAndConquerMethod>());

  std::vector<Point2dFloat> points;
  points.reserve(size);

  for (int i = 0; i < size; ++i) {
    points.emplace_back(point_x_arr[i], point_y_arr[i]);
  }

  auto result = obj.Solve(points);

  *out_x1 = result.first.first.x();
  *out_y1 = result.first.first.y();
  *out_x2 = result.first.second.x();
  *out_y2 = result.first.second.y();
  *out_min_dist = result.second;
}

}  // namespace geasy