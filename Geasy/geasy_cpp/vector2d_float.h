#pragma once

#include "ivector2d.h"

namespace geasy {

class Vector2dFloat : public IVector2d<float> {
 public:
  Vector2dFloat(float x, float y);

  float x() const override;
  float y() const override;

  void set_x(float x) override;
  void set_y(float y) override;

  double Length() const;

  static double Cross(const Vector2dFloat& v1, const Vector2dFloat& v2);

  static double Dot(const Vector2dFloat& v1, const Vector2dFloat& v2);

  static int CCW(const Vector2dFloat& v1, const Vector2dFloat& v2);

 private:
  float x_, y_;
};

}  // namespace geasy