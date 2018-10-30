namespace Sorting
{
    public class SinglyLinkedListNode<T> where T : struct
    {
        public T Data;
        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode(T data)
        {
            Data = data;
        }
    }
}
