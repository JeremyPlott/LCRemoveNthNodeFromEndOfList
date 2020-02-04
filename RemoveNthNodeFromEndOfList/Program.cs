public class Solution
{
	public ListNode RemoveNthFromEnd(ListNode head, int n)
	{

		//adding this is a safety net to get us around a testcase
		var startNode = new ListNode(0);

		//appending head onto our new node so the entire list is there
		startNode.next = head;

		//these are our two pointers. They need to start at the same place
		var frontNode = startNode;
		var backNode = startNode;

		//here is where the logic starts. Say you have a three foot container and need to make a 
		//mark two feet from the right side. If you had a two foot plank, started it
		//on the left side, and pushed it until it hit the right side, the left end of the plank would
		//be where you need it, two feet from the right side. 
		//This is the same idea, but with pointers and a list instead of a plank and a container.

		//this is going to iterate through until it is distance (n) from the left side.
		//In the analogy it correlates to the right end of the plank.
		for (int currentNode = 0; currentNode <= n; currentNode++)
		{
			frontNode = frontNode.next;
		}

		//now that our plank is the correct length we will iterate through until 
		//the front pointer hits the end of the list
		while (frontNode != null)
		{
			backNode = backNode.next;
			frontNode = frontNode.next;
		}

		//the next node on the left is the one that needs to be skipped, so we add the node after the next node.
		//think of this line as rewriting the link information rather than deleting a node.

		//[a]->[b]->[c].

		//[a].next looks at the link information of [a], which is currently routed to [b]. 
		//If I set [a].next == [a].next.next, I am rewriting that route location.

		//    [b]
		//[a]---->[c]->

		//think of it like changing an address. Instead of going here, go there.
		backNode.next = backNode.next.next;

		//return the now altered list
		return startNode.next;
	}
}