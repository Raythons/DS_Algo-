public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        var minHeap = new PriorityQueue<(int x, int y), Double>();
        var s = new SortedSet<(int x, int y)>();

        var minHeaps = new PriorityQueue<int,int>();
        minHeaps.Enqueue(1,2);

        for (int i = 0; i < points.Length; i++)
        {
            var x = points[i][0];
            var y = points[i][1];
            var val = Math.Sqrt(x * x + y * y);
            minHeap.Enqueue((x, y), -val);
            if (minHeap.Count > k)
                minHeap.Dequeue();
        }
  
        var answer = new List<int[]>();
        var gg = new SortedSet<int>();
        while (minHeap.Count > 0)
        {
            (int x, int y) = minHeap.Dequeue();
            answer.Add(new int[] { x, y });
        }
        return answer.ToArray();
    }
}