namespace ConsoleApp1
{

 public class Node<T> : IDisposable  where T : IComparable<T> 
   {
       public T? Data { get; set; } 
      public Node<T>? Next { get; set; } 
        private bool _Disposed = false;

      public Node(T data) {
          Data = data;
      }
      // Pointer to SAME type
      //Node(int data) : data(data) { }
       ~Node()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            // If Its Dispossed Already Dont Do Anything

            if (_Disposed) return;

            // logic of Dispose Here
            if (disposing)
            {
                Data = default;
                Next = null;
                
                // Dispose manged Code 
                
            }
            // Here I Dont Have Any  In Future It May be used

            _Disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    };

  
}
