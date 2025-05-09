#pragma once

namespace geasy {

template <typename T>
class IVector2d {
 public:
  virtual ~IVector2d() = default;

  virtual T x() const = 0;
  virtual T y() const = 0;

  virtual void set_x(T x) = 0;
  virtual void set_y(T y) = 0;
};

}  // namespace geasy