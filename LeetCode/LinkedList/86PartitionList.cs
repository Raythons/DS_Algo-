/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode Partition(ListNode head, int x)
    {
        ListNode lessThanList = new ListNode(0);
        ListNode moreThanList = new ListNode(0);

        ListNode lessThanListHolder = lessThanList;
        ListNode moreThanListHolder = moreThanList;

        while (head is not null)
        {
            if (head.val < x)
            {
                lessThanList.next = head;
                lessThanList = lessThanList.next;
            }
            else
            {
                moreThanList.next = head;
                moreThanList = moreThanList.next;
            }
            head = head.next;
        }

        moreThanList.next = null;
        lessThanList.next = moreThanListHolder.next;

        head = lessThanListHolder.next;

        return head;
    }
}