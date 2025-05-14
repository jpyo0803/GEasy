#pragma once

#include <vector>
#include "point2d_float.h"

namespace geasy {
class IConvexHullStrategy {
 public:
  virtual std::vector<Point2dFloat> Build(const std::vector<Point2dFloat>& points) = 0;

  virtual ~IConvexHullStrategy() = default;
};
}  // namespace geasy