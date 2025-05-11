#pragma once

#include <memory>
#include "iclosest_pair_strategy.h"

namespace geasy {
class ClosestPair {
 public:
  void set_strategy(std::unique_ptr<IClosestPairStrategy> strategy);

  std::pair<std::pair<Point2dFloat, Point2dFloat>, double> Solve(
      const std::vector<Point2dFloat>& points);

 private:
  std::unique_ptr<IClosestPairStrategy> strategy_;
};
}  // namespace geasy