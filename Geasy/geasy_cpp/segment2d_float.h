#pragma once

#include "point2d_float.h"
#include "vector2d_float.h"

namespace geasy {

class Segment2dFloat {
 public:
  Segment2dFloat(Point2dFloat start, Point2dFloat end);

  Point2dFloat start() const;
  Point2dFloat end() const;

  void set_start(Point2dFloat start);
  void set_end(Point2dFloat end);

  double Length() const;

  Vector2dFloat ToVector() const;

  int CCWOfPointAboutMe(Point2dFloat p) const;

  bool IsPointOnMe(Point2dFloat p) const;

  static bool IsIntersect(Segment2dFloat s1, Segment2dFloat s2);

  static int CCWofPointAboutSegment(Point2dFloat p, Segment2dFloat s);

  static bool IsPointOnSegment(Point2dFloat p, Segment2dFloat s);

 private:
  Point2dFloat start_, end_;
};

}  // namespace geasy