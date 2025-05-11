#pragma once

#include "closest_pair.h"

namespace geasy {

void ClosestPair::set_strategy(std::unique_ptr<IClosestPairStrategy> strategy) {
  strategy_ = std::move(strategy);
}

std::pair<std::pair<Point2dFloat, Point2dFloat>, double> ClosestPair::Solve(
    const std::vector<Point2dFloat>& points) {
  return strategy_->Solve(points);
}

}  // namespace geasy