#pragma once

#include <vector>
#include "point2d_float.h"

namespace geasy {
class IPNPolyStrategy {
 public:
  virtual bool Test(Point2dFloat point, const std::vector<Point2dFloat>& polygon) = 0;

  virtual ~IPNPolyStrategy() = default;
};
}  // namespace geasy