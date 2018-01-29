using System.Collections.Concurrent;
using System.Text;

namespace WorkingHour
{
    public class FixedSizedQueue<T>
    {
        readonly ConcurrentQueue<T> _concurrentQueue = new ConcurrentQueue<T>();
        public readonly object LockObject = new object();

        public int Limit { get; set; }
        public void Enqueue(T obj)
        {
            lock (LockObject)
            {
                _concurrentQueue.Enqueue(obj);
            }

            lock (LockObject)
            {
                while (_concurrentQueue.Count > Limit && _concurrentQueue.TryDequeue(out _))
                {
                }
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder("");
            lock (LockObject)
            {
                foreach (var item in _concurrentQueue) stringBuilder.Append(item);
            }
            return stringBuilder.ToString();
        }
    }
}