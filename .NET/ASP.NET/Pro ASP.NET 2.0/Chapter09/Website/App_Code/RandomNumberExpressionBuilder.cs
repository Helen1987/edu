using System;
using System.Web.UI;
using System.Web.Compilation;
using System.CodeDom;
using System.ComponentModel;

public class RandomNumberExpressionBuilder : ExpressionBuilder
{
	public static string GetRandomNumber(int lowerLimit, int upperLimit)
	{
		Random rand = new Random();
		int randValue = rand.Next(lowerLimit, upperLimit + 1);
		return randValue.ToString();
	}

	public override CodeExpression GetCodeExpression(
		BoundPropertyEntry entry, object parsedData,
		ExpressionBuilderContext context)
	{
		// entry.Expression is the number string
		// (minus the RandomNumber: prefix).
		if (!entry.Expression.Contains(","))
		{
			throw new ArgumentException("Must include two numbers separated by a comma.");
		}
		else
		{
			// Get the two numbers.
			string[] numbers = entry.Expression.Split(',');

			if (numbers.Length != 2)
			{
				throw new ArgumentException("Only include two numbers.");
			}
			else
			{
				int lowerLimit, upperLimit;
				if (Int32.TryParse(numbers[0], out lowerLimit) &&
					Int32.TryParse(numbers[1], out upperLimit))
				{

					// So far all the operations have been performed in
					// normal code. That's because the two numbers are
					// specified in the expression, and so they won't
					// change each time the page is requested.
					// However, the random number should be allowed to
					// change each time, so you need to switch to CodeDOM.
					Type type = entry.DeclaringType;
					PropertyDescriptor descriptor = TypeDescriptor.GetProperties(type)[entry.PropertyInfo.Name];
					CodeExpression[] expressionArray = new CodeExpression[2];
					expressionArray[0] = new CodePrimitiveExpression(lowerLimit);
					expressionArray[1] = new CodePrimitiveExpression(upperLimit); 
					return new CodeCastExpression(descriptor.PropertyType, new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(base.GetType()), "GetRandomNumber", expressionArray));
				}
				else
				{
					throw new ArgumentException("Use valid integers.");
				}

			}
		}
		
	}
}


