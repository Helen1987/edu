#include "StdAfx.h"
#include "Complex.h"

Complex::Complex(double real, double imag)
{
	Real = real;
	Imaginary = imag;
}

double Complex::R::get()
{
	return System::Math::Sqrt(Real*Real + Imaginary*Imaginary);
}

void Complex::R::set(double newR)
{
	double theta = Theta;

	Real = System::Math::Cos(theta) * newR;
	Imaginary = System::Math::Sin(theta) * newR;
}

double Complex::Theta::get()
{
	return System::Math::Atan2(Imaginary, Real);
}

void Complex::Theta::set(double newTheta)
{
	Real = System::Math::Cos(newTheta) * Real;
	Imaginary = System::Math::Sin(newTheta) * Real;
}

System::String^ Complex::ToString()
{
	return System::String::Format("{0} + {1}i", Real, Imaginary);
}