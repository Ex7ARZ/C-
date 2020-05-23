#include "pch.h" 
#include <utility>
#include <limits.h>
#include "MyLibrary.h"
//1
float f1(float a, float b, int i, int n)
{
	float x = a, y = 0;
	if (i == n )return 0;
	float h = (-a + b) / n;
	x += (h / 2) + h * i; i++;
	y += (sqrt(0.8 * x * x + 1) / (  x + sqrt(1.5 * x * x + 2))) * h + f1(a, b, i, n);
	return y;
}

float f1t(float ne,  float a, float b, float e)
{
	float s = 0;

	while (abs(f1(a, b, 0, ne + 1) - f1(a, b, 0, ne)) > e);
	{
		ne++;
	}
	s = f1(a, b, 0, ne+1);
	return s;
}
//2
float f2(float a, float b, int i, int n)
{
	float x = a, y = 0;
	if (i == n+1)return 0;
	float h = (-a + b) / n;
	x +=  h * i; i++;
	y += (1 / ( sqrt(2 * pow(x, 2) + 1.3))) * h + f2(a, b, i, n);
	return y;
}
float f2t(float ne1,  float a, float b, float e)
{
	float s = 0;

	while (abs(f2(a, b, 1, ne1 + 1) - f2(a, b, 1, ne1)) > e);
	{
		ne1++;
	}
	s = f2(a, b, 1, ne1 + 1);
	return s;
}
//3
float f3(float a, float b, int i, int n)
{
	float x = a, y = 0;
	if (i == n)return 0;
	float h = (-a + b) / n;
	x += h * i; i++;
	y += (sin(x+1.4) / (0.8+cos(2* pow(x, 2) +0.5))) * h + f3(a, b, i, n);
	return y;
}

float f3t(float ne,  float a, float b, float e)
{
	float s = 0;

	while (abs(f3(a, b, 0, ne + 1) - f3(a, b, 0, ne)) > e);
	{
		ne++;
	}
	s = f3(a, b, 0, ne + 1);
	return s;
}
//4
float f4(float a, float b, int i, int n)
{
	float x = a, y = 0;
	if (i == n+1)return 0;
	float h = (-a + b) / n;
	x += h * i; i++;
	if(i==0 || i==n)y += (sin(pow(x,2)) / (cos(pow(x, 2)) * (pow(x, 2) + 1))) * h/2 + f4(a, b, i, n);
	else y += (sin(pow(x, 2))/ (cos(pow(x, 2))*(pow(x, 2) +1))) * h + f4(a, b, i, n);
	return y;
}

float f4t(float ne, float a, float b, float e)
{
	float s = 0;

	while (abs(f4(a, b, 0, ne + 1) - f4(a, b, 0, ne)) > e);
	{
		ne++;
	}
	s = f4(a, b, 0, ne + 1);
	return s;
}