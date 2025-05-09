#include "geasy.h"

namespace geasy {

float TestSum(float* arr, int size) {
  float sum = 0;
  for (int i = 0; i < size; ++i) sum += arr[i];
  return sum;
}

}  // namespace geasy