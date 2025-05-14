#pragma once

#include <memory>
#include "iconvex_hull_strategy.h"

namespace geasy {
class ConvexHull {
 public:
  void set_strategy(std::unique_ptr<IConvexHullStrategy> strategy);

  std::vector<Point2dFloat> Build(const std::vector<Point2dFloat>& points);

 private:
  std::unique_ptr<IConvexHullStrategy> strategy_;
};
}  // namespace geasy