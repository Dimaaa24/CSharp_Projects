namespace Custom_Hashtables
{
    internal class Nod<T>
    {
        public Nod<T> Next { get; set; }
        public string Key { get; set; }
        public T Value { get; set; }
    }
}
