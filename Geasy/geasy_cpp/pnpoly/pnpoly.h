#pragma once

#include <memory>
#include "ipnpoly_strategy.h"

namespace geasy {
class PNPoly {
 public:
  void set_strategy(std::unique_ptr<IPNPolyStrategy> strategy);

  bool Test(Point2dFloat point, const std::vector<Point2dFloat>& polygon);

 private:
  std::unique_ptr<IPNPolyStrategy> strategy_;
};
}  // namespace geasy