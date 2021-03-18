namespace Sorting
{
    public class SinglyLinkedListNode<T> where T : struct
    {
        public T data;
        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode(T data)
        {
            this.data = data;
        }
    }
}
