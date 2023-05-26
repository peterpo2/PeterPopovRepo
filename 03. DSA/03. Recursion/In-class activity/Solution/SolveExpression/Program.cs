using System;

namespace SolveExpression
{
	class Program
	{
		static void Main()
		{
			string expr1 = "45+(55)";
			Console.WriteLine($"{expr1} = {Solve(expr1, 0)}");
			
			string expr2 = "45+(24*(12+(3)))";
			Console.WriteLine($"{expr2} = {Solve(expr2, 0)}");
			
			string expr3 = "12*(35-(46*(5+(15))))";
			Console.WriteLine($"{expr3} = {Solve(expr3, 0)}");
		}

		static readonly char[] operators = new char[] { '+', '-', '*' };

		static int Solve(string expr, int currentIndex)
		{
			int nextOperatorIndex = expr.IndexOfAny(operators, currentIndex);

			if (nextOperatorIndex == -1) // no more operators, no more calculations, return the number in the innermost brackets
			{
				int closingBracketIndex = expr.IndexOf(')', currentIndex);
				return int.Parse(expr[currentIndex..closingBracketIndex]); // C#8 'Range' operator .. can be used to get substring 
			}

			int calculatedSoFar = Solve(expr, nextOperatorIndex + 2); // +2 to jump over the '('. There always is an '(' after operator
			int currentNumber = int.Parse(expr[currentIndex..nextOperatorIndex]); // get the number to the left of the operator

			// calculate & return the result of this sub-expression
			return (expr[nextOperatorIndex]) switch // C#8 switch expression
			{
				'+' => currentNumber + calculatedSoFar,
				'-' => currentNumber - calculatedSoFar,
				'*' => currentNumber * calculatedSoFar,

				_ => throw new Exception("dont ever get here") // '_' is the default case in C#8 switches
			};
		}
	}
}
