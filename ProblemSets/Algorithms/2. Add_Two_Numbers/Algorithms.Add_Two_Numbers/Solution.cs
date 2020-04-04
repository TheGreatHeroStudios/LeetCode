using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Add_Two_Numbers
{
    public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public override bool Equals(object obj)
        {
            return
                obj is ListNode node &&
                node.val == val &&
                (
                    (node.next == null && next == null) ||
                    (node.next?.Equals(next) ?? false)
                );
        }
    }
 


    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //Recursively add each node to get a linked-list of result nodes
            return AddNodes(l1, l2);
        }


        private ListNode AddNodes(ListNode node1, ListNode node2)
        {
            ListNode resultNode = null;

            //If at least one operand node has a value, apply it to the result node
            if (node1 != null || node2 != null)
            {
                int nodeTotal = (node1?.val ?? 0) + (node2?.val ?? 0);

                //If the sum of the two node values is greater than 9, we need to carry the 1 to the next node 
                //To get a sum greater than 9, both nodes must have a value, so either node can be used to carry the 1
                if(nodeTotal >= 10)
                {
                    nodeTotal -= 10;

                    if(node1.next == null)
                    {
                        node1.next = new ListNode(1);
                    }
                    else
                    {
                        node1.next.val += 1;
                    }
                }

                //Apply the value, then recursively build the next result node from the two operands until both are null 
                resultNode = new ListNode(nodeTotal);
                resultNode.next = AddNodes(node1?.next, node2?.next);
            }

            //Once both operand nodes are null, there are no more 'next' nodes to add, so return null
            return resultNode;
        }
    }
}
