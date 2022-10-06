using System;

namespace _05_generics
{
    class MyArray<ItemType>
    {
        int count;
        ItemType[] arr;

        public MyArray(int count)
        {
            this.count = count;
            arr = new ItemType[count];
        }

        public void Show()
        {
            foreach (ItemType item in arr)
            {
                Console.Write(item + " ");
            }
        }

        public override string ToString()
        {
            return $"Array with count: {count}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyArray<float> arr = new MyArray<float>(10);

            arr.Show();
            arr.ToString(); // default: _05_generics.MyArray<ItemType>
        }
    }
}

