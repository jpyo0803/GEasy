#pragma once

#include <vector>
#include "point2d_float.h"

namespace geasy {
class IClosestPairStrategy {
 public:
  virtual std::pair<std::pair<Point2dFloat, Point2dFloat>, double> Solve(
      const std::vector<Point2dFloat>& points) = 0;

  virtual ~IClosestPairStrategy() = default;
};
}  // namespace geasy