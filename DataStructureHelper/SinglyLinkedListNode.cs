namespace DataStructureHelper
{
    public class SinglyLinkedListNode<T>
    {
        public T Data { get; set; }

        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }

        public void CreateAddNodeAfter(T data, SinglyLinkedListNode<T> currentNode) 
        {
            var newNode = new SinglyLinkedListNode<T>(data);
            var nextCopy = currentNode.Next;
            currentNode.Next = newNode;
            newNode.Next = nextCopy;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var node = (SinglyLinkedListNode<T>)obj;
            return Data.Equals(node.Data);
        }

        public override int GetHashCode()
        {
            var hash = 97;
            hash = hash * 143 + (Data == null ? 0 : Data.GetHashCode());
            hash = hash * 143 + (Next == null ? 0 : Next.GetHashCode());
            return hash;
        }

        public static bool operator ==(SinglyLinkedListNode<T> obj1, SinglyLinkedListNode<T> obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }

            if (obj1 is null)
            {
                return false;
            }
            if (obj2 is null)
            {
                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(SinglyLinkedListNode<T> obj1, SinglyLinkedListNode<T> obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
