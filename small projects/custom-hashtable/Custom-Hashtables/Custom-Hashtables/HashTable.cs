namespace Custom_Hashtables
{
    internal class HashTable<T>
    {
        private readonly Nod<T>[] buckets;

        private int size { get; set; }

        public HashTable()
        {
            buckets = new Nod<T>[100];
        }

        public HashTable(int size)
        {
            if (size > 0)
            {
                this.size = 0;
                buckets = new Nod<T>[size];
            }
            else
            {
                throw new ArgumentException(nameof(size));
            }    
        }

        public void Put(string key,T value)
        {
            if(key == null) throw new ArgumentNullException(nameof(key));

            var newNod = new Nod<T> { Key=key, Value=value, Next=null };

            int pos = HashFunctionKey(key);

            Nod<T> listNods = buckets[pos];

            if(listNods == null) 
            {
                buckets[pos] = newNod;
                size++;
            }
            else
            {
                while(listNods.Next != null)
                {
                    listNods=listNods.Next;
                }
                listNods.Next = newNod;
                size++;
            }
        }

        public T Get(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            int pos = HashFunctionKey(key);

            Nod<T> listNods = buckets[pos];

            while(listNods != null)
            {
                if (listNods.Key == key)
                {
                    return listNods.Value;
                }

                listNods=listNods.Next;
            }

            return default(T);
        }

        public void Remove(string key)
        {
            if(key == null)
            {
                throw new ArgumentNullException();
            }

            int pos = HashFunctionKey(key);

            Nod<T> listNods = buckets[pos];

            if(listNods == null)
            {
                return;
            }

            Nod<T> previousNod = null;

            while (listNods != null)
            {
                if (listNods.Key == key)
                {
                    break;
                }

                previousNod = listNods;
                listNods = listNods.Next;
            }

            if (previousNod == null)
            {
                size--;
                buckets[pos] = null;
            }
            else
            {
                size--;
                previousNod.Next = listNods.Next;
            }

        }

        public bool ContainsKey(string key)
        {
            if( key == null)
            {
                throw new ArgumentNullException();
            }

            int pos = HashFunctionKey(key);

            Nod<T> listNods = buckets[pos];

            while (listNods != null)
            {
                if (listNods.Key == key)
                    return true;

                listNods = listNods.Next;
            }

            return false;
        }

        public int Count()
        {
            return size;
        }

        public List<T> Indexer()
        {
            int nrOfBuckets = buckets.Length;
            List<T> genericsList = new List<T>();

            for (int i = 0; i < nrOfBuckets; i++)
            {

                Nod<T> listNods = buckets[i];

                while (listNods != null)
                {
                    genericsList.Add(listNods.Value);

                    listNods = listNods.Next;
                }

            }
            return genericsList;
        }

        protected int HashFunctionKey(string key)
        {
            return Math.Abs(key.GetHashCode()) % buckets.Length;
        }
    }
}
