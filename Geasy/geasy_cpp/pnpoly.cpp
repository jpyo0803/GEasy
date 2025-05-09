#pragma once

#include "pnpoly.h"

namespace geasy {

void PNPoly::set_strategy(std::unique_ptr<IPNPolyStrategy> strategy) {
  strategy_ = std::move(strategy);
}

bool PNPoly::Test(Point2dFloat point, const std::vector<Point2dFloat>& polygon) {
  return strategy_->Test(point, polygon);
}

}  // namespace geasy