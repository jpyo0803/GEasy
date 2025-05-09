#include "segment2d_float.h"
#include <algorithm>

namespace {
constexpr double kEpsilon = 1e-6;
}

namespace geasy {

Segment2dFloat::Segment2dFloat(Point2dFloat start, Point2dFloat end) : start_(start), end_(end) {}

Point2dFloat Segment2dFloat::start() const {
  return start_;
}
Point2dFloat Segment2dFloat::end() const {
  return end_;
}

void Segment2dFloat::set_start(Point2dFloat start) {
  start_ = start;
}
void Segment2dFloat::set_end(Point2dFloat end) {
  end_ = end;
}

double Segment2dFloat::Length() const {
  return ToVector().Length();
}

Vector2dFloat Segment2dFloat::ToVector() const {
  return Vector2dFloat(end_.x() - start_.x(), end_.y() - start_.y());
}

int Segment2dFloat::CCWOfPointAboutMe(Point2dFloat p) const {
  return CCWofPointAboutSegment(p, *this);
}

bool Segment2dFloat::IsPointOnMe(Point2dFloat p) const {
  return IsPointOnSegment(p, *this);
}

bool Segment2dFloat::IsIntersect(Segment2dFloat s1, Segment2dFloat s2) {
  int a = CCWofPointAboutSegment(s2.start_, s1) * CCWofPointAboutSegment(s2.end_, s1);
  int b = CCWofPointAboutSegment(s1.start_, s2) * CCWofPointAboutSegment(s1.end_, s2);

  if (a < 0 && b < 0)
    return true;
  else if (a == 0 && b < 0)
    return true;
  else if (a < 0 && b == 0)
    return true;
  else if (a == 0 && b == 0) {
    return IsPointOnSegment(s2.start_, s1) || IsPointOnSegment(s2.end_, s1) ||
           IsPointOnSegment(s1.start_, s2) || IsPointOnSegment(s1.end_, s2);
  }
  return false;
}

int Segment2dFloat::CCWofPointAboutSegment(Point2dFloat p, Segment2dFloat s) {
  Vector2dFloat v1 = s.ToVector();
  Vector2dFloat v2(p.x() - s.start_.x(), p.y() - s.start_.y());
  return Vector2dFloat::CCW(v1, v2);
}

bool Segment2dFloat::IsPointOnSegment(Point2dFloat p, Segment2dFloat s) {
  int ccw = CCWofPointAboutSegment(p, s);
  if (ccw != 0) return false;

  float start_x = s.start_.x();
  float start_y = s.start_.y();
  float end_x = s.end_.x();
  float end_y = s.end_.y();

  float min_x = std::min(start_x, end_x) - kEpsilon;
  float max_x = std::max(start_x, end_x) + kEpsilon;
  float min_y = std::min(start_y, end_y) - kEpsilon;
  float max_y = std::max(start_y, end_y) + kEpsilon;

  return (min_x <= p.x() && p.x() <= max_x) && (min_y <= p.y() && p.y() <= max_y);
}

}  // namespace geasy