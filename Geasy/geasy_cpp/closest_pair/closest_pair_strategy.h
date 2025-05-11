#pragma once

#include <vector>
#include "iclosest_pair_strategy.h"

namespace geasy {

class Point2dFloatWithTag : public Point2dFloat {
 public:
  Point2dFloatWithTag(float x, float y, int tag);

  int tag() const;

  void set_tag(int tag);

 private:
  int tag_;
};

class DivideAndConquerMethod : public IClosestPairStrategy {
 public:
  std::pair<std::pair<Point2dFloat, Point2dFloat>, double> Solve(
      const std::vector<Point2dFloat>& points) override;

 private:
  std::pair<std::pair<Point2dFloatWithTag, Point2dFloatWithTag>, double> SolveRec(
      const std::vector<Point2dFloatWithTag>& sorted_x,
      const std::vector<Point2dFloatWithTag>& sorted_y);
};

}  // namespace geasy