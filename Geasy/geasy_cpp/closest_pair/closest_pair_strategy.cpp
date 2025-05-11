#include "closest_pair_strategy.h"
#include <algorithm>
#include <cassert>
#include <iostream>
#include <limits>

namespace geasy {

Point2dFloatWithTag::Point2dFloatWithTag(float x, float y, int tag) :
    Point2dFloat(x, y), tag_(tag) {}

int Point2dFloatWithTag::tag() const {
  return tag_;
}

void Point2dFloatWithTag::set_tag(int tag) {
  tag_ = tag;
}

std::pair<std::pair<Point2dFloat, Point2dFloat>, double> DivideAndConquerMethod::Solve(
    const std::vector<Point2dFloat>& points) {
  int n = points.size();
  assert(n >= 2);

  std::vector<Point2dFloatWithTag> sorted_x;
  sorted_x.reserve(n);

  for (int i = 0; i < n; ++i) {
    sorted_x.emplace_back(points[i].x(), points[i].y(), -1);
  }

  std::sort(
      sorted_x.begin(), sorted_x.end(),
      [](const Point2dFloatWithTag& p1, const Point2dFloatWithTag& p2) { return p1.x() < p2.x(); });

  for (int i = 0; i < n; ++i) {
    sorted_x[i].set_tag(i);
  }

  auto sorted_y = sorted_x;
  std::sort(
      sorted_y.begin(), sorted_y.end(),
      [](const Point2dFloatWithTag& p1, const Point2dFloatWithTag& p2) { return p1.y() < p2.y(); });

  // Due to slicing, conversion from 'Point2dFloatWithTag' -> 'Point2dFloat'
  return SolveRec(sorted_x, sorted_y);
}

std::pair<std::pair<Point2dFloatWithTag, Point2dFloatWithTag>, double>
DivideAndConquerMethod::SolveRec(const std::vector<Point2dFloatWithTag>& sorted_x,
                                 const std::vector<Point2dFloatWithTag>& sorted_y) {
  constexpr float kEpsilon = 1e-6f;

  assert(sorted_x.size() == sorted_y.size());

  int n = sorted_x.size();

  double min_dist = std::numeric_limits<double>::max();
  Point2dFloatWithTag closest_p1(0, 0, -1);
  Point2dFloatWithTag closest_p2(0, 0, -1);

  if (n <= 3) {
    // bruteforce search for 3 points or less
    for (int i = 0; i < n - 1; ++i) {
      for (int j = i + 1; j < n; ++j) {
        double dist = Point2dFloat::Distance(sorted_x[i], sorted_x[j]);
        if (dist < min_dist) {
          min_dist = dist;
          closest_p1 = sorted_x[i];
          closest_p2 = sorted_x[j];
        }
      }
    }
    return {{closest_p1, closest_p2}, min_dist};
  }

  int mid = n / 2;
  Point2dFloatWithTag mid_point = sorted_x[mid];

  std::vector<Point2dFloatWithTag> lh_sorted_x(sorted_x.begin(), sorted_x.begin() + mid);
  std::vector<Point2dFloatWithTag> rh_sorted_x(sorted_x.begin() + mid, sorted_x.end());

  std::vector<Point2dFloatWithTag> lh_sorted_y, rh_sorted_y;
  lh_sorted_y.reserve(lh_sorted_x.size());
  rh_sorted_y.reserve(rh_sorted_x.size());

  for (int i = 0; i < n; ++i) {
    auto y_point = sorted_y[i];
    if (y_point.x() < mid_point.x() - kEpsilon) {
      lh_sorted_y.push_back(y_point);
    } else if (y_point.x() > mid_point.x() + kEpsilon) {
      rh_sorted_y.push_back(y_point);
    } else {
      if (y_point.tag() < mid_point.tag()) {
        lh_sorted_y.push_back(y_point);
      } else {
        rh_sorted_y.push_back(y_point);
      }
    }
  }

  auto left_result = SolveRec(lh_sorted_x, lh_sorted_y);
  auto right_result = SolveRec(rh_sorted_x, rh_sorted_y);

  double left_min_dist = left_result.second;
  double right_min_dist = right_result.second;

  min_dist = std::min(left_min_dist, right_min_dist);
  if (left_min_dist < right_min_dist) {
    closest_p1 = left_result.first.first;
    closest_p2 = left_result.first.second;
  } else {
    closest_p1 = right_result.first.first;
    closest_p2 = right_result.first.second;
  }

  std::vector<Point2dFloatWithTag> strip;
  for (const auto& point : sorted_y) {
    if (fabs(point.x() - mid_point.x()) < min_dist) {
      strip.push_back(point);
    }
  }

  int strip_len = strip.size();
  for (int i = 0; i < strip_len - 1; ++i) {
    for (int j = i + 1; j < strip_len && (strip[j].y() - strip[i].y() < min_dist); ++j) {
      double dist = Point2dFloat::Distance(strip[i], strip[j]);

      if (dist < min_dist) {
        min_dist = dist;
        closest_p1 = strip[i];
        closest_p2 = strip[j];
      }
    }
  }

  return {{closest_p1, closest_p2}, min_dist};
}

}  // namespace geasy