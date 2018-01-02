using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _222lllll
{
	class ClassArray<T> : IEnumerator<T>, IEnumerable<T>, IComparable<ClassArray<T>>
    {
		private Dictionary<int, T> places;
		private int maxCount;
		private T defaultValue;
		public ClassArray(int size, T defVal) {
			defaultValue = defVal;
		
			places = new Dictionary<int, T>();
			maxCount = size;
	
		}


        public static int operator +(ClassArray<T> p, T car)
        {
            var isCutter = car is Cutter;
            if (p.places.Count == p.maxCount)
            {
                throw new ParkingOverflowException();
            }
            int index = p.places.Count;
            for (int i = 0; i < p.places.Count; ++i)
            {
                if (p.CheckFreePlace(i))
                {
                    index = i;
                }
                if (car.GetType() == p.places[i].GetType())
                {
                    if (isCutter)
                    {
                        if ((car as Cutter).Equals(p.places[i]))
                        {
                            throw new ParkingAlreadyHaveException();
                        }

                    }
                    else if ((car as Lodka).Equals(p.places[i]))
                    {
                        throw new ParkingAlreadyHaveException();
                    }
                }
            }
            if (index != p.places.Count)
            {
                p.places.Add(index, car);
                return index;
            }
            p.places.Add(p.places.Count, car);
            return p.places.Count - 1;
        }
        public static T operator -(ClassArray<T> p, int index) {
			if (p.places.ContainsKey(index)) {
				T car = p.places[index];
				p.places.Remove(index);
				return car;
			}
			throw new ParkingIndexOutOfRangeException();
		}
		private bool CheckFreePlace(int index) {
			return !places.ContainsKey(index); 
		}

		public T this[int ind] {
			get {
				if (places.ContainsKey(ind))
				{
					return places[ind];
				}
				return defaultValue;
			}
		}

        //!!!!!!!!!!!!!!!!!!!!!!!!!!
      private int currentIndex;
      public T Current
      {
          get
          {
              return places[places.Keys.ToList()[currentIndex]];
          }
      }
      object IEnumerator.Current
      {
          get
          {
              return Current;
          }
      }
      public void Dispose() { }
      public bool MoveNext()
      {
          if (currentIndex + 1 >= places.Count)
          {
              Reset();
              return false;
          }
          currentIndex++;
          return true;
      }
      public void Reset()
      {
          currentIndex = -1;
      }
      


        public IEnumerator<T> GetEnumerator()
        {
            return places.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int CompareTo(ClassArray<T> other)
        {
            if (this.Count() > other.Count())
            {
                return -1;
            }
            else if (this.Count() < other.Count())
            {
                return 1;
            }
            else
            {
                var thisKeys = places.Keys.ToList();
                var otherKeys = other.places.Keys.ToList();
                for (int i = 0; i < places.Count; ++i)
                {
                    if (places[thisKeys[i]] is Cutter && other.places[thisKeys[i]] is Lodka)
                    {
                        return 1;
                    }
                    if (places[thisKeys[i]] is Lodka && other.places[thisKeys[i]] is Cutter)
                    {
                        return -1;
                    }
                    if (places[thisKeys[i]] is Cutter && other.places[thisKeys[i]] is Cutter)
                    {
                        return (places[thisKeys[i]] is Cutter).CompareTo(other.places[thisKeys[i]] is Cutter);
                    }
                    if (places[thisKeys[i]] is Lodka && other.places[thisKeys[i]] is Lodka)
                    {
                        return (places[thisKeys[i]] is Lodka).CompareTo(other.places[thisKeys[i]] is Lodka);
                    }
                }
            }
            return 0;
        }
    }

}

