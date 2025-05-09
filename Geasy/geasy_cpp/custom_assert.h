#include <cmath>

#define ASSERT_NEAR(actual, expected, epsilon)               \
  do {                                                       \
    if (std::fabs((actual) - (expected)) > (epsilon)) {      \
      std::cerr << "❌ ASSERT_NEAR failed:\n"                \
                << "  Expected: " << (expected) << "\n"      \
                << "  Actual  : " << (actual) << "\n"        \
                << "  Epsilon : " << (epsilon) << std::endl; \
      std::exit(1);                                          \
    }                                                        \
  } while (0)