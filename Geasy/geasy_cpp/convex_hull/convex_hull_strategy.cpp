#include "convex_hull_strategy.h"
#include <algorithm>
#include <cassert>
#include "segment2d_float.h"

namespace geasy {

std::vector<Point2dFloat> MonotoneChainMethod::Build(const std::vector<Point2dFloat>& points) {
  std::vector<Point2dFloat> copied_points = points;

  sort(copied_points.begin(), copied_points.end(),
       [](const Point2dFloat& p1, const Point2dFloat& p2) {
         if (p1.x() == p2.x()) {
           return p1.y() < p2.y();
         }
         return p1.x() < p2.x();
       });

  // Remove duplicates
  copied_points.erase(std::unique(copied_points.begin(), copied_points.end()), copied_points.end());

  std::vector<Point2dFloat> lower, upper;

  int n = copied_points.size();
  for (int i = 0; i < n; ++i) {
    while (lower.size() >= 2 &&
           Segment2dFloat(lower.at(lower.size() - 2), lower.at(lower.size() - 1))
                   .CCWOfPointAboutMe(copied_points.at(i)) <= 0) {
      lower.pop_back();
    }
    lower.push_back(copied_points[i]);
  }

  for (int i = n - 1; i >= 0; --i) {
    while (upper.size() >= 2 &&
           Segment2dFloat(upper.at(upper.size() - 2), upper.at(upper.size() - 1))
                   .CCWOfPointAboutMe(copied_points.at(i)) <= 0) {
      upper.pop_back();
    }
    upper.push_back(copied_points[i]);
  }

  lower.pop_back();
  upper.pop_back();

  lower.insert(lower.end(), upper.begin(), upper.end());
  return lower;
}

}  // namespace geasy