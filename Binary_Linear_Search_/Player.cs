using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Binary_Linear_Search_
{
    public class Player : IComparable<Player>
    {
        string name;
        int score;

        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public int CompareTo(Player other)
        {
            return (this.score == other.score) ? 0 : (this.score > other.score) ? 1 : -1;
        }
    }
}
