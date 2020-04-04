using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Two_Sum
{
    public class Solution
    {
        //Hash Set - O(n) Complexity
        public int[] TwoSum_Hash(int[] nums, int target)
        {
            Hashtable iteratedValues = new Hashtable(); 

            //For each item in the array...
            for(int i = 0; i < nums.Length; i++)
            {
                //Find the complement (The number that adds to the current item to get the target)
                int complement = target - nums[i];

                //If the complement is already a key in the hash table...
                if(iteratedValues.ContainsKey(complement))
                {
                    //Return the index of the complement in the hashtable and the index of the current item
                    return new int[] { (int)iteratedValues[complement], i };
                }
                else if(!iteratedValues.ContainsKey(nums[i]))
                {
                    //If the complement is not in the hash table, make sure the current item is not either.
                    //(A number can be encountered more than once in the starting array before the desired complement)
                    //If the current item is not yet in the hash table, add it.
                    iteratedValues.Add(nums[i], i);
                }
            }

            //If we got here, no two values in the array add to the target, so throw an exception
            throw new ArgumentException("No two numbers in the provided array add up to the target number");
        }


        //Nested Loop - O(n^2) Complexity
        public int[] TwoSum_Nested(int[] nums, int target)
        {
            //For each item in the array
            for (int i = 0; i < nums.Length; i++)
            {
                //Determine the number that adds to the current item to get the target
                int complement = target - nums[i];

                //Find the next item in the array that matches the complement
                int matchIndex = Array.IndexOf(nums, complement, i + 1);

                //If a match for the target's complement was found, return the two indices 
                //(index of the current and index of the match)
                if(matchIndex > 0)
                {
                    return new int[] { i, matchIndex };
                }
            }

            //If we got here, no match was found, so throw an exception
            throw new ArgumentException("No two numbers in the provided array add up to the target number");
        }



        #region Failed Attempts
        //Time complexity is too great for large inputs
        public int[] TwoSum_Linq(int[] nums, int target)
        {
            (int sum, int index1, int index2) match =
                nums
                    .Join
                    (
                        //Perform a cross join between the items in the array and themselves
                        nums,
                        n1 => true,
                        n2 => true,
                        (n1, n2) => (sum: n1 + n2, index1: Array.IndexOf(nums, n1), index2: Array.LastIndexOf(nums, n2))
                    )
                    .Where
                    (
                        //Exclude records where the two items are the same
                        tuple => tuple.index1 != tuple.index2
                    )
                    .First
                    (
                        //Find the first result (there should only be one) 
                        //where the sum of the joined items equals the target
                        tuple => tuple.sum == target
                    );

            return new int[] { match.index1, match.index2 };
        }
        #endregion
    }
}
