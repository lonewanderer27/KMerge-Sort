namespace Merge_Sort_AAC
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] unsortedArray = { 7, 3, 8, 5, 10, 6, 4, 2, 3, 1 };
      ShowArray("Unsorted Array", unsortedArray);

      int[] sortedArray = CheckArray(unsortedArray);
      ShowArray("Sorted Array", sortedArray);
      
      Console.WriteLine("===== END =====");
      Console.ReadLine();
    }

    static void ShowArray(string prefix, int[] array)
    {
      Console.Write(prefix + ": ");

      int counter = 0;
      foreach (int i in array)
      {
        if (counter < array.Length)
          Console.Write(i + ", ");
        else
          Console.Write(i);
        
        counter++;
      }
      Console.WriteLine("\n");
    }

    static int[] CheckArray(int[] array)
    {
      Console.WriteLine("--- Check ---");
      if (array.Length > 1)
      {
        int half = array.Length / 2;

        int[] leftArray = GetHalfArray(array, 0, half, "Left");
        int[] rightArray = GetHalfArray(array, half, array.Length, "Right");

        leftArray = CheckArray(leftArray);
        rightArray = CheckArray(rightArray);

        return MergeArray(leftArray, rightArray);
      }
      
      return array;
    }

    static int[] GetHalfArray(int[] oldArray, int from, int to, string side)
    {
      Console.WriteLine("--- Half Array ---");
      int[] newArray = new int[to - from];
      Console.WriteLine("New Size[" + side + "]:" + newArray.Length);
      int counter = 0;
      for (int i = from; i < to; i++)
      {
        newArray[counter] = oldArray[i];
        counter++;
      }

      ShowArray("newArray[" + side + "]", newArray);
      return newArray;
    }

    static int[] MergeArray(int[] leftArray, int[] rightArray) {
      Console.WriteLine("--- Merge ---");

      int[] mergedArray = new int[leftArray.Length + rightArray.Length];

      int mergeIndex = 0;
      int leftIndex = 0;
      int rightIndex = 0;

      while (leftIndex < leftArray.Length & rightIndex < rightArray.Length)
      {
        Console.Write(leftArray[leftIndex] + " > " + rightArray[rightIndex]);
        
        // replace > with < so it'll become descending
        if (leftArray[leftIndex] > rightArray[rightIndex])
        {
          mergedArray[mergeIndex] = rightArray[rightIndex];
          Console.WriteLine(" is true, so insert " + rightArray[rightIndex]);

          rightIndex++;
          mergeIndex++;
        }
        else
        {
          mergedArray[mergeIndex] = leftArray[leftIndex];
          Console.WriteLine(" is false, so insert " + leftArray[leftIndex]);

          leftIndex++;
          mergeIndex++;
        }
      }

      while (leftIndex < leftArray.Length)
      {
        mergedArray[mergeIndex] = leftArray[leftIndex];
        Console.WriteLine("insert: "+ leftArray[leftIndex]);

        leftIndex++;
        mergeIndex++;
      }

      while (rightIndex < rightArray.Length)
      {
        mergedArray[mergeIndex] = rightArray[rightIndex];
        Console.WriteLine("insert: "+ rightArray[rightIndex]);
        
        rightIndex++;
        mergeIndex++;
      }
      
      ShowArray("MergeArray", mergedArray);
      return mergedArray;
    }
  }
}