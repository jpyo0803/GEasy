#include <cassert>
#include <iostream>
#include "custom_assert.h"
#include "vector2d_float.h"

using namespace geasy;

void TestVector2dFloat() {
  constexpr double kEpsilon = 1e-6;
  Vector2dFloat v1(2.2342, 1.5346);
  Vector2dFloat v2(3.3453, 7.3434);

  double cross_result = Vector2dFloat::Cross(v1, v2);
  ASSERT_NEAR(cross_result, 11.2729269, kEpsilon);

  double dot_result = Vector2dFloat::Dot(v1, v2);
  ASSERT_NEAR(dot_result, 18.7432509, kEpsilon);

  Vector2dFloat v3(1, 0);
  Vector2dFloat v4(1, 1);
  int ccw_result1 = Vector2dFloat::CCW(v3, v4);
  assert(ccw_result1 == 1);

  Vector2dFloat v5(1, 0);
  int ccw_result2 = Vector2dFloat::CCW(v3, v5);
  assert(ccw_result2 == 0);

  Vector2dFloat v6(1, -1);
  int ccw_result3 = Vector2dFloat::CCW(v3, v6);
  assert(ccw_result2 == -1);
}

void RunTests() {
  TestVector2dFloat();
}

int main(int argc, char** argv) {
  RunTests();
  return 0;
}