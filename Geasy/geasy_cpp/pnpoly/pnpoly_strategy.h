#pragma once

#include <vector>
#include "ipnpoly_strategy.h"

namespace geasy {
class WindingNumberMethod : public IPNPolyStrategy {
 public:
  bool Test(Point2dFloat point, const std::vector<Point2dFloat>& polygon) override;
};

}  // namespace geasy