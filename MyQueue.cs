namespace queues
{
    class MyQueue
    {

        Queue<Data>? data;

        public MyQueue()
        {
            data = new Queue<Data>();
        }

        public int? Count()
        {
            return data?.Count;
        }
        public void Push(int newValue)
        {
            data?.Enqueue(new Data(newValue));
        }

        public int Pop()
        {

            Data? result = data?.Dequeue();

            if (result != null)
                return result.classData;

            return 0;
        }


        public int? Show()
        {
            return data?.Peek().classData;
        }

        public int? Get(int pos)
        {
            for (int i = 0; i < pos; ++i)
                this.Push(this.Pop());

            int? result = this.Show();

            for (int i = pos; i < data?.Count; ++i)
                this.Push(this.Pop());

            return result;
        }

        public void Swap(int pos1, int pos2)
        {
            var temp1 = this.Get(pos1);
            var temp2 = this.Get(pos2);
            if (temp2 != null)
                this.Set(pos1, (int)temp2);
            if (temp1 != null)
                this.Set(pos2, (int)temp1);
        }

        public void Set(int pos, int newValue)
        {
            for (int i = 0; i < pos; ++i)
                this.Push(this.Pop());

            this.Pop();

            this.Push(newValue);

            for (int i = pos; i < data?.Count - 1; ++i)
                this.Push(this.Pop());
        }

        public void Clear()
        {
            data?.Clear();
        }
        public void Print()
        {
            if (data != null)
                foreach (Data item in data)
                    Console.WriteLine(item.classData);
            Console.WriteLine("---------");
        }


    }

    public class Data
    {
        public int classData { get; set; }

        public Data(int input)
        {
            classData = input;
        }
    }
}