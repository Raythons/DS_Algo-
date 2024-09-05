// See https://aka.ms/new-console-template for more information
using Algorithims;
using Algorithims.BFS;
using Algorithims.Dfs;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using Graph = System.Collections.Generic.List<System.Collections.Generic.List<int>>;

Console.WriteLine("Hello, World!");

int[][] grid1 = new int[][]
{
    new int[] { 1, 1, 1, 0, 0 },
    new int[] { 0, 1, 1, 1, 1 },
    new int[] { 0, 0, 0, 0, 0 },
    new int[] { 1, 0, 0, 0, 0 },
    new int[] { 1, 1, 0, 1, 1 }
};

int[][] grid2 = new int[][]
{
    new int[] { 1, 1, 1, 0, 0 },
    new int[] { 0, 0, 1, 1, 1 },
    new int[] { 0, 1, 0, 0, 0 },
    new int[] { 1, 0, 1, 1, 0 },
    new int[] { 0, 1, 0, 1, 0 }
};

//Console.WriteLine(_1905SubIslands.CountSubIslands(grid1, grid2));

//var arr =   new int[] { 3,-1 };

var s = "dcab";

//_752OpenLock.Run();
//_417WaterFlow.Run();
//_1129ShortestAlternatingPaths.Run();
//_365WaterAndJug.Run();
_773SlidingPuzzle.Run();
//_2049MinimumOperations.Run();


//Console.WriteLine(_1202SmallestStringWithSwap.SmallestStringWithSwaps(s, paris));

//Console.WriteLine("####_785IsBipartite$$$$");
//_785IsBipartite.Run();
//Console.WriteLine("####_785IsBipartite$$$$");

//Console.WriteLine("####_1466MinReorder$$$$");
//_1466MinReorder.Run();
//Console.WriteLine("####_1466MinReorder$$$$");

//Console.WriteLine("####_1631MinimumEffortPath$$$$");
//_1631MinimumEffortPath.Run();
//Console.WriteLine("####_1631MinimumEffortPath$$$$");

//var arr = new List<int>() { 3, -1, 0, 2 };

//arr = CountSortWithNegative(arr);
//foreach (int i in arr)
//{
//    Console.WriteLine(i);
//}


//GraphOfEdges.CreateAndAddAndPrint();
//GraphOfHashSet.CreateAndAddAndPrint();
//AirLineGraph.CreateAndAddAndPrint();
//ImageAsGraph.CreateAndAddAndPrint();
var matrix = new int[][] { new int[] { 1, 1 }, new int[] { 1, 2 } };
//Console.WriteLine(MatrixDfs.ColoringBorder(matrix, 0, 0, 3));
var matrix_1559 = new char[][] 
                        {
                            new char[] { 'a', 'b', 'b',  },
                            new char[] { 'b', 'z', 'b',},
                            new char[] { 'b', 'b', 'a',  },
                        };
//new char[] { 'c', 'c', 'c', 'a' }, new char[] { 'c', 'd', 'c', 'c' },
//new char[] { 'c', 'c', 'e', 'c' }, new char[] { 'f', 'c', 'c', 'c' } };
//Console.WriteLine(_1559Cycels.ContainsCycle(matrix_1559));




var arr2 = new int[] { 1,2,3, 4, 4, 4, 4, 4, 4, 5,5, 10 };
//var arr = new List<int>() { 3, -1, 0, 2 };
var idx = BinarySearchFirstOccur(arr2, 4);

var _436intervals = new int[] []{ new int []{ 3, 4 }, new int[] { 2, 3 }, new int[] { 1, 2 }, };



static int MySqrt(int x)
{
    int start = 0;
    int end = x;
    int ans = -1;
    
    while (start <= end)
    {
        ulong mid = (ulong)(start + (end - start) / 2);
        BigInteger holder;
        if ((holder = mid * mid ) <= x)
        {
            ans = (int)mid;
            start = (int)mid + 1;
        }
        else
            end = (int)mid - 1;
    }
    return ans;
}


static int BinarySearchFirstOccur(int[] nums, int target)
{
    int start = 0;
    int end = nums.Length - 1;

    while (start < end)
    {
        int mid = start + (end - start) / 2;

        if (nums[mid] < target)
        {
            start = mid + 1;
        }
        else if (nums[mid] > target)
        {
            end = mid - 1;
        }
        else
        {
            end = mid; 
        }
    }
    if (start < 0 || start >= nums.Length) return - 1;
    return nums[start] == target ? start : -1;
}



static int BinarySearchFirstOccur2(int[] nums, int target)
{
    int start = 0;
    int end = nums.Length - 1;

    int position = -1;
    while (start < end)
    {
        int mid = start + (end - start) / 2;

        if (nums[mid] < target)
        {
            start = mid + 1;
        }
        else if (nums[mid] > target)
        {
            end = mid - 1;
        }
        else
        {
            position = mid;
        }
    }
    return position;
}


// leetCode
static List<(int,int)> MinimumAbsoluteDifference (List<int> list)
{
    list.Sort();

    var MinDifrrence = int.MaxValue;

    for (int i = 1; i < list.Count; i++)
    {
        MinDifrrence = int.Min(list.ElementAt(i) - list.ElementAt(i - 1), MinDifrrence);  
    }



    var listOfPairs = new List<(int,int)> ();
    for (int i = 1; i < list.Count; i++)
    {
        if (list.ElementAt(i) -  list.ElementAt(i - 1)   == MinDifrrence)
        {
            listOfPairs.Add((list.ElementAt(i - 1), list.ElementAt(i)));
        }
    }
    return listOfPairs;
}


// // leetCode Array Partition I
static int ArrayPartition(List<int> array)
{
    array.Sort();

    int MaxSum = 0;
    for (int i = 0; i < array.Count; i += 2)
        MaxSum += array.ElementAt(i);
    return MaxSum;
}

static void WiggleSort (List<int> list )
{
    List<int> newList = new List<int>();

    int Left = 0;
    int Right = list.Count - 1 ;

    while ( Left <= Right )
    {
        newList.Add( Left );
        if (Left != Right)
            newList.Add(Right);
        Left += 1;
        Right += 1; 
    }

    list = newList;

}


// wrong
static int MaximizeSuOfArrayAfterKNegations(int[] list, int k)
{
    Array.Sort(list);
    int zeroIndex = -1;
    for (int i = 0; i < list.Length; i++)
    {
        if (list[i] == 0)
        {
            k = 0;
            zeroIndex = i;
            break;
        }

        if (list[i] < 0 && k > 0)
        {
            list[i] = list[i] * (-1);
            k--;
        }
    }

    if (k > 0 && zeroIndex != -1)
    {
        while (k > 0) {
            list[zeroIndex] = list[zeroIndex] * (-1);
        }
    }
    else if (k > 0)
    {
        while (k > 0)
        {
            list[0] = list[0] * (-1);
            k--;
        }
    }

    var LargestSum = 0;
    foreach (int i in list)
        LargestSum += i;
    return LargestSum;  

}

static  int[] CountSort(int[] arry)
{
    int size = arry.Length;
    int maxVal = arry[0];
    for (int i = 0;  i < size;  i++)
    {
        if (arry[i] > maxVal)
            maxVal = arry[i];
    }

    List<int> count = new List<int>( new int [maxVal + 1]) ;
    for (int i = 0; i < size; i++)
        count[arry[i]] += 1;

    int idx = 0;
    for (int i = 0; i <=  maxVal; i++) {
        for (int j = 0; j < count[i]; ++j , ++idx)   
            arry[idx] = i;     
    }
    return arry;
}

static int[] CountSortWithNegative(int[] arry)
{
    int size = arry.Length;
    int shift = 50000;

    for (int i = 0; i < size; i++)
    {
        arry[i] += shift;
    }

    int maxVal = arry[0];
    for (int i = 0; i < size; i++)
    {
        if (arry[i] > maxVal)
            maxVal = arry[i];
    }

    List<int> count = new List<int>(new int[maxVal + 1]);
    for (int i = 0; i < size; i++)
        count[arry[i]] += 1;

    int idx = 0;
    for (int i = 0; i <= maxVal; i++)
    {
        for (int j = 0; j < count[i]; ++j, ++idx)
            arry[idx] = i - shift;
    }
    return arry;
}
static int Maximizesuofarrayafterknegations2(int[] nums, int k)
{
    Array.Sort(nums);


    int MinVal = int.MaxValue;
    int Sum = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] <  0 &&  k > 0)
        {
            k -= 1;
            nums[i] *= -1;   
        }
        Sum += i;
        MinVal = int.Min(MinVal, nums[i]);
    }

    if(k % 2 != 0)
        Sum -=  2* MinVal;
    return Sum;
}





//vector<int> sortArray(vector<int> &array)
//{
//    // Find the largest element of the array
//    int size = array.size();
//    const int SHIFT = 50000;

//    for (int i = 0; i < size; ++i)
//        array[i] += SHIFT;


//    int max = array[0];
//    for (int i = 1; i < size; ++i)
//        if (array[i] > max)
//            max = array[i];

//    vector<int> count(max+1);   // zeros

//    // Compute Frequency
//    for (int i = 0; i < size; ++i)
//        count[array[i]] += 1;

//    int idx = 0;
//    for (int i = 0; i <= max; ++i)
//    {
//        for (int j = 0; j < count[i]; ++j, ++idx)
//            array[idx] = i - SHIFT;
//    }


//    return array;
//}