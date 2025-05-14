#include "point2d_float.h"
#include <cmath>

namespace geasy {

Point2dFloat::Point2dFloat(float x, float y) : x_(x), y_(y) {}

float Point2dFloat::x() const {
  return x_;
}
float Point2dFloat::y() const {
  return y_;
}

void Point2dFloat::set_x(float x) {
  x_ = x;
}
void Point2dFloat::set_y(float y) {
  y_ = y;
}

bool Point2dFloat::operator==(const Point2dFloat& other) const {
  return x_ == other.x_ && y_ == other.y_;
}

double Point2dFloat::Distance(const Point2dFloat& p1, const Point2dFloat& p2) {
  double p1x = static_cast<double>(p1.x_), p1y = static_cast<double>(p1.y_);
  double p2x = static_cast<double>(p2.x_), p2y = static_cast<double>(p2.y_);
  double dx = p2x - p1x;
  double dy = p2y - p1y;
  return std::sqrt(dx * dx + dy * dy);
}

}  // namespace geasy