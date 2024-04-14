using System;

public static class SimpleCalculator
{

	public static string Calculate(int operand1, int operand2, string operation)
		=>operation switch
			{
				"+" => $"{operand1} {operation} {operand2} = {operand1+operand2}",
				"*" => $"{operand1} {operation} {operand2} = {operand1*operand2}",
				"/" => operand2 !=0 ? $"{operand1} {operation} {operand2} = {operand1/operand2}" : "Division by zero is not allowed.",
				"" => throw new ArgumentException("Operation cannot be empty."),
				null => throw new ArgumentNullException(operation, "Operation cannot be null."),
				_ => throw new ArgumentOutOfRangeException(operation, "Operation not allowed. Only use (+ , * , /)")
			};

}