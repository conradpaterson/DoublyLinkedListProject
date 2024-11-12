using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListWithErrors
{
   public class DLList
    {
        public DLLNode head; // pointer to the head of the list
        public DLLNode tail; // pointer to the tail of the list
       public DLList() { head = null;  tail = null; } // constructor
        /*-------------------------------------------------------------------
        * The methods below includes several errors. Your  task is to write
        * unit test to discover these errors. During delivery the tutor may
        * add or remove errors to adjust the scale of the effort required by
        */
        public void addToTail(DLLNode p)
        {

            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                tail.next = p;
                p.previous = tail;//Fix: Set p.previous before changing tail.
                tail = p;
            }
        } // end of addToTail

        public void addToHead(DLLNode p)
        {
            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                p.next = this.head;
                this.head.previous = p;
                p.previous = null;//Fix:Set p.previous to null because it's the new head.
                head = p;
            }
        } // end of addToHead

        public void removeHead()
        {
            if (this.head == null) return;
            this.head = this.head.next;
            this.head.previous = null;
        } // removeHead

        public void removeTail()
        {
            if (this.tail == null) return;
            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
                return;
            }
            this.tail = this.tail.previous;
            this.tail.next = null;//Fix:Set the new tail's next pointer to null.
        } 

        public DLLNode search(int num)
        {
            DLLNode p = head;
            while (p != null)
            {
                if (p.num == num) break;//Fix:Check before moving to the next node.
                p = p.next;
            }
            return (p);
        } // end of search (return pionter to the node);

        public void removeNode(DLLNode p)
        { // removing the node p.

            if (p == null) return;
            
            //If removing the head.
            if (p.previous == null)
            {
                this.head = p.next;
                if(this.head != null)//Fix:If the new head exists, set it's previous to null.
                this.head.previous = null;
                return;
            }
            //If removing the tail.
            else if(p.next == null)
            {
                this.tail = p.previous;
                if(this.tail != null)//Fix:If the new tail exists, set it's next to null.
                    this.tail.next=null;
                return;
            }
            //If removing the middle node.
            else
            {
                p.previous.next = p.next;
                p.next.previous = p.previous;
            }
           //Clean up the node.
            p.next = null;
            p.previous = null;
        } // end of remove a node

        public int total()
        {
            DLLNode p = head;
            int tot = 0;
            while (p != null)
            {
                tot += p.num;
                p = p.next;//Fix:Move to next node one at a time.
            }
            return (tot);
        } // end of total
    } // end of DLList class
}
