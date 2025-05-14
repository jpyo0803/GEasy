#pragma once

#include <vector>
#include "iconvex_hull_strategy.h"

namespace geasy {
class MonotoneChainMethod : public IConvexHullStrategy {
 public:
  std::vector<Point2dFloat> Build(const std::vector<Point2dFloat>& points) override;
};

}  // namespace geasy