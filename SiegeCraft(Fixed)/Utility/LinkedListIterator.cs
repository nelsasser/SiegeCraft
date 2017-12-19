using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeCraft_Fixed_.Utility {
	class LinkedListIterator<T> {

		LinkedList<T> list;
		LinkedListNode<T> currentNode;
		LinkedListNode<T> prevNode = null;

		public LinkedListIterator(LinkedList<T> list) {
			this.list = list;
			currentNode = list.First;
		}

		public T next() {
			LinkedListNode<T> r = currentNode;

			prevNode = currentNode;
			currentNode = currentNode.Next;

			return r.Value;
        }

		public bool hasNext() {
			if(currentNode == null || currentNode.Next == null) {
				return false;
			}
			return true;
		}

		public T remove() {
			LinkedListNode<T> r = prevNode;

			list.Remove(prevNode);

			return r.Value;
		}

		public void add(T obj) {
			if(prevNode == null) {
				list.AddFirst(obj);
			} else {
				list.AddAfter(prevNode, obj);
			}
		}
	}
}
