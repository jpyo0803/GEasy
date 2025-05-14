#include "convex_hull.h"

namespace geasy {

void ConvexHull::set_strategy(std::unique_ptr<IConvexHullStrategy> strategy) {
  strategy_ = std::move(strategy);
}

std::vector<Point2dFloat> ConvexHull::Build(const std::vector<Point2dFloat>& points) {
  return strategy_->Build(points);
}

}  // namespace geasy