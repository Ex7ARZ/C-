#pragma once
#ifdef MYDLL_EXPORTS
#define MyLibrary_API __declspec(dllexport)
#else
#define MyLibrary_API __declspec(dllimport)
#endif


extern "C" {
#include<math.h>
}
extern "C" MyLibrary_API float f1(float a, float b, int i, int n);
extern "C" MyLibrary_API float f1t(float ne,  float a, float b, float e);

extern "C" MyLibrary_API float f2(float a, float b, int i, int n);
extern "C" MyLibrary_API float f2t(float ne,  float a, float b, float e);

extern "C" MyLibrary_API float f3(float a, float b, int i, int n);
extern "C" MyLibrary_API float f3t(float ne,  float a, float b, float e);

extern "C" MyLibrary_API float f4(float a, float b, int i, int n);
extern "C" MyLibrary_API float f4t(float ne,  float a, float b, float e);

