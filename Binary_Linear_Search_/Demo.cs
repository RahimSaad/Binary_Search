using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Binary_Linear_Search_
{
    class Demo
    {
        static void Main(string[] args)
        {
            Player[] playerArr = {
                new Player("player2", 22),
                new Player("player4", 31),
                new Player("player3", 46),
                new Player("player1", 68),
                new Player("player6", 72),
                new Player("player5", 82),
                new Player("player8", 88),
                new Player("player7", 92)
            };

            Console.WriteLine("------------------Binary Search-------------------\n");
            int idx, NumberOfTris = 0;
            if (BinarySearch.doBinarySearch<Player>(playerArr, playerArr[playerArr.Length - 1], out idx,
                ref NumberOfTris, BinarySearch.LoopBinarySearch<Player>))
            {
                Console.WriteLine("Found at index {0} , Length = {1} , Tries = {2}\n", idx, playerArr.Length, NumberOfTris);
            }
            else
            {
                Console.WriteLine("Not Found");
            }


            Console.WriteLine("------------------Linear Search-------------------\n");
            idx = -1; NumberOfTris = 0;
            if (LinearSearch.doLinearSearch<Player>(playerArr, playerArr[playerArr.Length - 1], out idx))
            {
                Console.WriteLine("Found at index {0} , Length = {1} , Tries = {2}", idx, playerArr.Length, (idx + 1));
            }
            else
            {
                Console.WriteLine("Not Found");
            }
            Console.ReadKey();
        }
    }
}
