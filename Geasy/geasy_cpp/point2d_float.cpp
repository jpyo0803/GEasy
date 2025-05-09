#include "point2d_float.h"

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

}  // namespace geasy