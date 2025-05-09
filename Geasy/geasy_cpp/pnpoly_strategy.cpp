#pragma once

#include "pnpoly_strategy.h"
#include <algorithm>
#include "segment2d_float.h"

namespace geasy {

bool WindingNumberMethod::Test(Point2dFloat point, const std::vector<Point2dFloat>& polygon) {
  int n = polygon.size();

  int winding_count = 0;
  for (int i = 0; i < n; ++i) {
    Segment2dFloat segment(polygon[i], polygon[(i + 1) % n]);
    if (segment.IsPointOnMe(point)) {
      return true;
    }

    float y1 = segment.start().y();
    float y2 = segment.end().y();

    if (std::min(y1, y2) <= point.y() && point.y() <= std::max(y1, y2)) {
      int ccw = segment.CCWOfPointAboutMe(point);
      if (y1 < y2 && ccw > 0) {
        winding_count++;
      } else if (y1 > y2 && ccw < 0) {
        winding_count--;
      }
    }
  }
  // winding count == 0, then outside
  // winding count != 0, then inside
  return winding_count != 0;
}

}  // namespace geasy