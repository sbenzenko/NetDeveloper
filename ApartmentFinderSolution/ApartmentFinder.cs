using System;
using System.Collections.Generic;

namespace ApartmentFinder
{
  public class ApartmentFinder
  {
    const int BIGGEST_DISTANCE = 999999;
    private int[,] distances;

    private enum Position
    {
      Previous = -1,
      Current = 0,
      Next = 1
    }

    public int Find(Dictionary<string, bool>[] blocks)
    {
      distances = new int[blocks.Length, blocks[0].Count];
      int blocksCount = distances.GetLength(0);
      var maxDistances = new int[blocksCount];

      PopulateBlockDistances(blocks[0],
  0, Position.Current, true);

      for (int block = 1; block < blocksCount; block++)
      {
        PopulateBlockDistances(blocks[block],
          block, Position.Previous, true);
      }

      maxDistances[blocksCount - 1] = MaxServiceDistance(blocksCount - 1);

      for (int block = blocksCount - 2; block >= 0; block--)
      {
        PopulateBlockDistances(blocks[block],
          block, Position.Next);
        maxDistances[block] = MaxServiceDistance(block);
      }

      return FindMinBlock(maxDistances);
    }

    private int PopulateBlockDistances(Dictionary<string, bool> services,
      int currentBlock, Position compareToBlock, bool initialize = false)
    {
      int i = 0;
      foreach (var service in services.Values)
      {
        if (initialize)
          distances[currentBlock, i] = BIGGEST_DISTANCE;

        distances[currentBlock, i] = service ? 0 :
            Math.Min(distances[currentBlock, i], distances[currentBlock + (int)compareToBlock, i] + 1);
        i++;
      }

      return i;
    }

    private int FindMinBlock(int[] serviceDistances)
    {
      int min = BIGGEST_DISTANCE;
      int index = -1;
      for (int i = 0; i < serviceDistances.Length; i++)
      {
        if (serviceDistances[i] < min)
        {
          min = serviceDistances[i];
          index = i;
        }
      }
      return index;
    }

    private int MaxServiceDistance(int index)
    {
      int max = 0;
      for (int i = 0; i < distances.GetLength(1); i++)
      {
        if (distances[index, i] > max) max = distances[index, i];
      }

      return max;
    }
  }
}
