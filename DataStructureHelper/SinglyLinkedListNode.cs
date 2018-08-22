namespace DataStructureHelper
{
    public class SinglyLinkedListNode<T>
    {
        private T _data;
        private SinglyLinkedListNode<T> _next;

        public T Data { get => _data; set => _data = value; }

        public SinglyLinkedListNode<T> Next { get => _next; set => _next = value; }

        public SinglyLinkedListNode(T data)
        {
            _data = data;
            _next = null;
        }

        public void CreateAddNodeAfter(T data, SinglyLinkedListNode<T> currentNode) 
        {
            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(data);
            SinglyLinkedListNode<T> nextCopy = currentNode.Next;
            currentNode.Next = newNode;
            newNode.Next = nextCopy;
        }

        public override string ToString()
        {
            return _data.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else
            {
                SinglyLinkedListNode<T> node = (SinglyLinkedListNode<T>)obj;
                return Data.Equals(node.Data);
            }
        }

        public override int GetHashCode()
        {
            int hash = 97;
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
