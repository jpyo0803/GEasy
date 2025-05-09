#include "vector2d_float.h"

namespace geasy {

Vector2dFloat::Vector2dFloat(float x, float y) : x_(x), y_(y) {}

float Vector2dFloat::x() const {
  return x_;
}
float Vector2dFloat::y() const {
  return y_;
}

void Vector2dFloat::set_x(float x) {
  x_ = x;
}
void Vector2dFloat::set_y(float y) {
  y_ = y;
}

double Vector2dFloat::Cross(const Vector2dFloat& v1, const Vector2dFloat& v2) {
  double v1x = static_cast<double>(v1.x_);
  double v1y = static_cast<double>(v1.y_);
  double v2x = static_cast<double>(v2.x_);
  double v2y = static_cast<double>(v2.y_);
  return v1x * v2y - v1y * v2x;
}

double Vector2dFloat::Dot(const Vector2dFloat& v1, const Vector2dFloat& v2) {
  double v1x = static_cast<double>(v1.x_);
  double v1y = static_cast<double>(v1.y_);
  double v2x = static_cast<double>(v2.x_);
  double v2y = static_cast<double>(v2.y_);
  return v1x * v2x + v1y * v2y;
}

}  // namespace geasy