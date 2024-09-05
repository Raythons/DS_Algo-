using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithims.BFS._1129ShortestAlternatingPaths;

namespace Algorithims.BFS
{
    public class _365WaterAndJug
    {
        public static int MaxJug1 { get; set; }
        public  static int MaxJug2 { get; set; }

        public class WaterClass 
        {
            public int Jug1 { get; set; }
            public int Jug2 { get; set; }
            public WaterClass(int jug1, int jug2) {
                Jug1 = jug1;
                Jug2 = jug2;
            }

            public (int Jug1NewVal, int Jug2NewVal) FillJug1 ()
            {
                int newJugValue = Jug1;
                if (Jug1 == 0)
                    newJugValue = MaxJug1;
                else if (Jug1 < MaxJug1)
                    newJugValue = Jug1 + (MaxJug1 - Jug1) ;

                return (newJugValue, Jug2);
            }
            public (int Jug1NewVal, int Jug2NewVal) FillJug2()
            {
                int newJugValue = Jug2;
                if (Jug2 == 0)
                    newJugValue = MaxJug2;
                else if (Jug2 < MaxJug2)
                    newJugValue = Jug2 + (MaxJug2 - Jug2);
                return (Jug1, newJugValue);
            }
            public (int Jug1NewVal, int Jug2NewVal) PourJug1()
            {
                if (Jug2 == MaxJug2)
                    return (Jug1, Jug2);

                int Jug1NewVal = Jug1;

                int Jug2NewVal = Jug2 + Jug1;

                if (Jug2NewVal > MaxJug2)
                {
                    Jug1NewVal = Jug2NewVal - MaxJug2;
                    Jug2NewVal = MaxJug2;
                }
                else
                    Jug1NewVal = 0;

                return (Jug1NewVal , Jug2NewVal);
            }
            public (int Jug1NewVal, int Jug2NewVal) PourJug2()
            {
                if (Jug1 == MaxJug1)
                    return (Jug1, Jug2);

                int Jug2NewVal = Jug2;

                int Jug1NewVal = Jug2 + Jug1;

                if (Jug1NewVal > MaxJug1)
                {
                    Jug2NewVal = Jug1NewVal - MaxJug1;
                    Jug1NewVal = MaxJug2;
                }
                else
                    Jug2NewVal = 0;

                return (Jug2NewVal, Jug2NewVal);
            }
            public (int Jug1NewVal, int Jug2NewVal) EmptyJug1 ()
            {
                return (0, Jug2);
            }
            public (int Jug1NewVal, int Jug2NewVal) EmptyJug2()
            {
                return (Jug1, 0);
            }
        
            public int Sum ()
            {
                return Jug1 + Jug2;
            }
        }

        public static bool CanMeasureWater(int x, int y, int target)
        {
            Queue<(int Jug1Val, int Jug2Val)> q = new Queue<(int Jug1Val, int Jug2Val)>();
            Dictionary<(int Jug1Val, int Jug2Val), bool> visited = new();
            MaxJug1 = x;
            MaxJug2 = y;
            visited.Add((0, 0), true);
            q.Enqueue((0, 0));
            if( x + y  < target)
                 return false;


            for (int level = 0, sz = q.Count; q.Count > 0; ++level, sz = q.Count)
            {
                while (sz-- > 0)
                {
                    var cur = q.Dequeue();
                    var water = new WaterClass(cur.Jug1Val, cur.Jug2Val);


                    if (water.Sum() == target)
                        return true;

                    //visited.Add((cur.Jug1Val, cur.Jug2Val), true);

                    (int Jug1NewVal, int Jug2NewVal) newPoints = water.FillJug1();
                    //water = new(newPoints.Jug1NewVal, newPoints.Jug2NewVal);

                    if (!visited.ContainsKey(newPoints))
                    {
                        water = new(newPoints.Jug1NewVal, newPoints.Jug2NewVal);
                        visited.Add((newPoints.Jug1NewVal, newPoints.Jug2NewVal), true);
                        water.Jug1 = cur.Jug1Val;
                        water.Jug2  = cur.Jug2Val;
                        q.Enqueue(newPoints);
                    }

                    newPoints = water.FillJug2();


                    if (!visited.ContainsKey(newPoints))
                    {
                        water = new(newPoints.Jug1NewVal, newPoints.Jug2NewVal);
                        visited.Add((newPoints.Jug1NewVal, newPoints.Jug2NewVal), true);
                        water.Jug1 = cur.Jug1Val;
                        water.Jug2 = cur.Jug2Val;
                        q.Enqueue(newPoints);
                    }


                    newPoints = water.PourJug1();

                    if (!visited.ContainsKey(newPoints))
                    {
                        water = new(newPoints.Jug1NewVal, newPoints.Jug2NewVal);
                        visited.Add((newPoints.Jug1NewVal, newPoints.Jug2NewVal), true);
                        water.Jug1 = cur.Jug1Val;
                        water.Jug2 = cur.Jug2Val;
                        q.Enqueue(newPoints);
                    }

                    newPoints = water.PourJug2();


                    if (!visited.ContainsKey(newPoints))
                    {
                        water = new(newPoints.Jug1NewVal, newPoints.Jug2NewVal);
                        visited.Add((newPoints.Jug1NewVal, newPoints.Jug2NewVal), true);
                        water.Jug1 = cur.Jug1Val;
                        water.Jug2 = cur.Jug2Val;
                        q.Enqueue(newPoints);
                    }
                    newPoints = water.EmptyJug1();

                    if (!visited.ContainsKey(newPoints))
                    {
                        water = new(newPoints.Jug1NewVal, newPoints.Jug2NewVal);
                        visited.Add((newPoints.Jug1NewVal, newPoints.Jug2NewVal), true);
                        water.Jug1 = cur.Jug1Val;
                        water.Jug2 = cur.Jug2Val;
                        q.Enqueue(newPoints);
                    }

                    newPoints = water.EmptyJug2();


                    if (!visited.ContainsKey(newPoints))
                    {
                        water = new(newPoints.Jug1NewVal, newPoints.Jug2NewVal);
                        visited.Add((newPoints.Jug1NewVal, newPoints.Jug2NewVal), true);
                        water.Jug1 = cur.Jug1Val;
                        water.Jug2 = cur.Jug2Val;
                        q.Enqueue(newPoints);
                    }

                }  
            }
            return false;
        }

        public  static void Run ()
        {
            Console.WriteLine(CanMeasureWater(15, 20, 100));
        }
    }   
}
