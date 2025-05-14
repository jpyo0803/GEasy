#pragma once

#include "ipoint2d.h"

namespace geasy {

class Point2dFloat : public IPoint2d<float> {
 public:
  Point2dFloat(float x, float y);

  float x() const override;
  float y() const override;

  void set_x(float x) override;
  void set_y(float y) override;

  bool operator==(const Point2dFloat& other) const;

  static double Distance(const Point2dFloat& p1, const Point2dFloat& p2);

 private:
  float x_, y_;
};

}  // namespace geasy