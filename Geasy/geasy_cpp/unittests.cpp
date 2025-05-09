#include <cassert>
#include <iostream>
#include "custom_assert.h"
#include "point2d_float.h"
#include "segment2d_float.h"
#include "vector2d_float.h"

using namespace std;
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

  Vector2dFloat v7(-5, 7);
  double v7_length = v7.Length();
  ASSERT_NEAR(v7_length, 8.6023252, kEpsilon);
}

void TestSegment2dFloat() {
  Segment2dFloat s1({0, 0}, {5, 5});

  Point2dFloat p1(0, 0);  // true
  Point2dFloat p2(3, 3);  // true
  Point2dFloat p3(5, 5);  // true
  Point2dFloat p4(5, 4);  // false
  Point2dFloat p5(5, 6);  // false

  ASSERT_EQUAL(s1.CCWOfPointAboutMe(p1), 0);
  ASSERT_EQUAL(s1.CCWOfPointAboutMe(p2), 0);
  ASSERT_EQUAL(s1.CCWOfPointAboutMe(p3), 0);
  ASSERT_EQUAL(s1.CCWOfPointAboutMe(p4), -1);
  ASSERT_EQUAL(s1.CCWOfPointAboutMe(p5), 1);

  ASSERT_TRUE(s1.IsPointOnMe(p1));
  ASSERT_TRUE(s1.IsPointOnMe(p2));
  ASSERT_TRUE(s1.IsPointOnMe(p3));
  ASSERT_FALSE(s1.IsPointOnMe(p4));
  ASSERT_FALSE(s1.IsPointOnMe(p5));
}

void TestSegment2dFloat2() {
  Segment2dFloat s1({-5, 0}, {5, 0});

  Segment2dFloat s2({0, -5}, {0, 5});
  ASSERT_TRUE(Segment2dFloat::IsIntersect(s1, s2));

  Segment2dFloat s3({6, -5}, {6, 5});
  ASSERT_FALSE(Segment2dFloat::IsIntersect(s1, s3));

  Segment2dFloat s4({5, -5}, {5, 5});
  ASSERT_TRUE(Segment2dFloat::IsIntersect(s1, s4));

  Segment2dFloat s5({5, 0}, {5, 9});
  ASSERT_TRUE(Segment2dFloat::IsIntersect(s1, s5));

  Segment2dFloat s6({0, 0.5}, {0, 10});
  ASSERT_FALSE(Segment2dFloat::IsIntersect(s1, s6));
}

void RunTests() {
  TestVector2dFloat();
  TestSegment2dFloat();
  TestSegment2dFloat2();
}

int main(int argc, char** argv) {
  RunTests();
  return 0;
}