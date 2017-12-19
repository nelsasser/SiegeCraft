namespace SiegeCraft_Fixed_.Utility {
	public class CircularBuffer<T> {

		private T[] buffer;
		private int next = 0;

		public CircularBuffer(int size) {
			buffer = new T[size];
		}

		public T get(int index) {
			if(index < buffer.Length && index >= 0) {
				return buffer[index];
			} else {
				throw new CircularBufferException("Attempted to access index outside of buffer.");
			}
		}

		public void add(T obj) {
			buffer[next] = obj;
			next = (next + 1) % buffer.Length;
		}
	}
}
