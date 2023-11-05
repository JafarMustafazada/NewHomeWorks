
namespace Task_Generics.Models;

public class EndergMadeList<T1>
{
    T1[] _array;

    public int RealSize { get => this._array.Length; }
    public int Capacity { get; }
    public int Length { get; private set; } //Count
    public T1 this[int i]
    {
        get
        {
            if (i < this.Length && i >= 0)
            {
                return this._array[i];
            }
            else throw new ArgumentOutOfRangeException();
        }
        set
        {
            if (i < this.Length && i >= 0)
            {
                this._array[i] = value;
            }
            else throw new ArgumentOutOfRangeException();
        }
    }


    public EndergMadeList(int capacity = 0)
    {
        if (capacity < 2) capacity = 6;
        this.Capacity = capacity;
        this.Length = 0;
        this._array = new T1[0];
    }
    public EndergMadeList(in T1[] array, int capacity = 0) : this(capacity)
    {
        this.Length = array.Length;
        this._array = new T1[(array.Length / this.Capacity + 1) * this.Capacity];

        for (int i = 0; i < array.Length; i++)
        {
            this._array[i] = array[i];
        }
    }


    public void Add(T1 element)
    {
        if (this.Length == this._array.Length)
        {
            Array.Resize(ref this._array, this.Length + this.Capacity);
        }
        this._array[this.Length++] = element;
    }
    public void Clear()
    {
        this.Length = 0;
        this._array = new T1[0];
    }
    public bool Contains(T1 element)
    {
        if (this.IndexOf(element) >= 0)
        {
            return true;
        }
        return false;
    }

    public bool Remove(int index, bool WithException = false)
    {
        if (index >= this.Length || index < 0)
        {
            // actual purpose of bool variable is to differ "Remove(int index)" from "Remove(int element)".
            if (WithException) throw new ArgumentOutOfRangeException();
            return false;
        }
        T1[] newArray = new T1[this._array.Length];

        for (int i = 0; i < index;)
        {
            newArray[i] = this._array[i++];
        }
        this.Length--;

        for (int i = index; i < this.Length;)
        {
            newArray[i] = this._array[++i];
        }
        this._array = newArray;

        return true;
    }
    public bool Remove(T1 element)
    {
        int index = this.IndexOf(element);
        if (index >= 0)
        {
            this.Remove(index, false);
            return true;
        }
        return false;
    }

    public T1[] Reverse()
    {
        T1[] newArray = new T1[this.Length];
        for (int i = 0; i < this.Length; i++)
        {
            newArray[this.Length - i - 1] = this._array[i];
        }

        return newArray;
    }

    public int IndexOf(T1 element)
    {
        for (int i = 0; i < this.Length; i++)
        {
            if (this._array[i].Equals(element))
            {
                return i;
            }
        }
        return -1;
    }
    public int LastIndexOf(T1 element)
    {
        for (int i = this.Length - 1; i >= 0; i--)
        {
            if (this._array[i].Equals(element))
            {
                return i;
            }
        }
        return -1;
    }
}
