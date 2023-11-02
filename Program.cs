namespace KMerge_Sort_AAC
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] prevArray = { 7, 3, 8, 5, 10, 6, 4, 2, 3, 1 };
      DisplayArray("prevArray", prevArray);
      
      Console.WriteLine("======== START SORTING ========");

      int[] nextArray = CheckArray(prevArray);
      DisplayArray("nextArray", nextArray);
      
      Console.WriteLine("======== SORTING END ========");
      Console.ReadLine();
    }

    static void DisplayArray(string text, int[] array)
    {
      Console.Write(text + ": ");
      
      foreach (int i in array)
      {
        Console.Write(i + ", ");
      }
      Console.WriteLine("\n");
    }

    static int[] CheckArray(int[] array)
    {
      Console.WriteLine("==== Check ====");
      if (array.Length > 1)
      {
        int half = array.Length / 2;

        int[] leftArray = SplitArray(array, 0, half, "Left");
        int[] rightArray = SplitArray(array, half, array.Length, "Right");

        leftArray = CheckArray(leftArray);
        rightArray = CheckArray(rightArray);

        return MergeArray(leftArray, rightArray);
      }
      
      return array;
    }

    static int[] SplitArray(int[] oldArray, int from, int to, string side)
    {
      Console.WriteLine("--- Split Array ---");
      int[] newArray = new int[to - from];
      Console.WriteLine("New Size [" + side + "] :" + newArray.Length);
      int counter = 0;
      for (int i = from; i < to; i++)
      {
        newArray[counter] = oldArray[i];
        counter++;
      }

      DisplayArray("newArray [" + side + "] ", newArray);
      return newArray;
    }

    static int[] MergeArray(int[] leftArray, int[] rightArray) {
      Console.WriteLine("==== Merge ====");

      int[] mergedArray = new int[leftArray.Length + rightArray.Length];

      int mergeIndex = 0;
      int leftIndex = 0;
      int rightIndex = 0;

      while (leftIndex < leftArray.Length & rightIndex < rightArray.Length)
      {
        Console.Write(leftArray[leftIndex] + " > " + rightArray[rightIndex]);
        
        if (leftArray[leftIndex] > rightArray[rightIndex])
        {
          mergedArray[mergeIndex] = rightArray[rightIndex];
          Console.WriteLine(" is True, so insert " + rightArray[rightIndex]);

          rightIndex++;
          mergeIndex++;
        }
        else
        {
          mergedArray[mergeIndex] = leftArray[leftIndex];
          Console.WriteLine(" is False, so insert " + leftArray[leftIndex]);

          leftIndex++;
          mergeIndex++;
        }
      }

      while (leftIndex < leftArray.Length)
      {
        mergedArray[mergeIndex] = leftArray[leftIndex];
        Console.WriteLine("Insert: "+ leftArray[leftIndex]);

        leftIndex++;
        mergeIndex++;
      }

      while (rightIndex < rightArray.Length)
      {
        mergedArray[mergeIndex] = rightArray[rightIndex];
        Console.WriteLine("Insert: "+ rightArray[rightIndex]);
        
        rightIndex++;
        mergeIndex++;
      }
      
      DisplayArray("MergeArray", mergedArray);
      return mergedArray;
    }
  }
}