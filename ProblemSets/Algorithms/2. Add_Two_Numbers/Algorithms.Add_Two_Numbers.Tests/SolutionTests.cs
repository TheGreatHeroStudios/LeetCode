using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.Add_Two_Numbers.Tests
{
	public class SolutionTests
	{
		[Theory]
		[InlineData(342, 465, 807)]
		[InlineData(9, 9999999991, 10000000000)]
		public void TestAddTwoNumbers(Int64 val1, Int64 val2, Int64 expectedVal)
		{
			//Arrange
			Solution solution = new Solution();

			ListNode l1 = IntToLinkedList(val1);
			ListNode l2 = IntToLinkedList(val2);
			ListNode expectedResult = IntToLinkedList(expectedVal);

			//Act
			ListNode result = solution.AddTwoNumbers(l1, l2);

			//Assert
			Assert.Equal(expectedResult, result);
		}


		#region Private Helper Methods
		private ListNode IntToLinkedList(Int64 value)
		{
			//Convert the int to a string to easily parse its digits
			IEnumerable<char> digits = value.ToString().Reverse();

			//Recursively build the nodes for the linked list and return it
			return
				DigitsToListNodes
				(
					new ListNode((int)char.GetNumericValue(digits.First())),
					digits.Skip(1)
				);
		}


		private ListNode DigitsToListNodes(ListNode parentNode, IEnumerable<char> remainingDigits)
		{
			//If any digits are remaining...
			if (remainingDigits.Any())
			{
				//Build the next digit into a node which is the child of the current node,
				//remove it from the remaining digits, 
				//and recursively build any nested nodes out of the remaining digits
				parentNode.next =
					DigitsToListNodes
					(
						new ListNode((int)char.GetNumericValue(remainingDigits.First())),
						remainingDigits.Skip(1)
					);
			}

			return parentNode;
		}
		#endregion
	}
}
