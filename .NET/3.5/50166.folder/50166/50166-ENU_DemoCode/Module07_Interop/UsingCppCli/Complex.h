#pragma once

value class Complex
{
public:
	Complex(double real, double imag);

	//Automatic properties, similar to C# 3.0 properties with an implicit
	//get and set implementation.
	property double Real;
	property double Imaginary;

	property double R
	{
		double get();
		void set(double newR);
	}

	property double Theta
	{
		double get();
		void set(double newTheta);
	}

	virtual System::String^ ToString() override;
};
