#include <cmath>

#define ASSERT_TRUE(cond)                            \
  do {                                               \
    if (!(cond)) {                                   \
      std::cerr << "❌ ASSERT_TRUE failed:\n"       \
                << "  Condition: " << #cond << "\n"; \
      std::exit(1);                                  \
    }                                                \
  } while (0)

#define ASSERT_FALSE(cond)                           \
  do {                                               \
    if (cond) {                                      \
      std::cerr << "❌ ASSERT_FALSE failed:\n"      \
                << "  Condition: " << #cond << "\n"; \
      std::exit(1);                                  \
    }                                                \
  } while (0)

#define ASSERT_EQUAL(actual, expected)                      \
  do {                                                      \
    if ((actual) != (expected)) {                           \
      std::cerr << "❌ ASSERT_EQUAL failed:\n"             \
                << "  Expected: " << (expected) << "\n"     \
                << "  Actual  : " << (actual) << std::endl; \
      std::exit(1);                                         \
    }                                                       \
  } while (0)

#define ASSERT_NEAR(actual, expected, epsilon)               \
  do {                                                       \
    if (std::fabs((actual) - (expected)) > (epsilon)) {      \
      std::cerr << "❌ ASSERT_NEAR failed:\n"               \
                << "  Expected: " << (expected) << "\n"      \
                << "  Actual  : " << (actual) << "\n"        \
                << "  Epsilon : " << (epsilon) << std::endl; \
      std::exit(1);                                          \
    }                                                        \
  } while (0)