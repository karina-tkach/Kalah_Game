using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalah_Game
{
    public class ComputerMoveCalculator
    {
        private readonly Board board;
        private int slotsPerSide = 6;
        Random rnd = new Random();

        public ComputerMoveCalculator(Board board)
        {
            this.board = board;
        }

        public int CalculateMove()
        {
            int move = StrategicMove();

            if (move == -1 || board.PlayerTwoSlots[move] == 0)
            {
                move = DefensiveMove();
            }

            if (move == -1 || board.PlayerTwoSlots[move] == 0)
            {
                move = ChooseNotEmptySlot();
            }
            return move;
        }
        private int StrategicMove()
        {

            bool moveFound = false;
            int move = slotsPerSide - 1;

            while (!moveFound && move >= 0)
            {

                int stonesInSlot = board.PlayerTwoSlots[move];

                if (stonesInSlot == (slotsPerSide - move))
                {

                    moveFound = true;
                }
                else
                {
                    move--;
                }
            }

            return move;
        }
        private int DefensiveMove()
        {
            var move = (savedStones:-1,moveIndex: -1);

            int[] opponentSlots = board.PlayerOneSlots;
            int[] currentSlots = board.PlayerTwoSlots;

            for (int index = 0; index < opponentSlots.Length; index++)
            {
                if (opponentSlots[index] == 0)
                {
                    for (int currentIndex = 0; currentIndex < slotsPerSide; currentIndex++)
                    {
                        int numOfstonesToCoverEmptySlot = slotsPerSide - currentIndex + 1 - index;
                        int stones = currentSlots[currentIndex];

                        if (stones >= numOfstonesToCoverEmptySlot)
                        {
                            move = (currentSlots[5-index] > move.savedStones) ? (currentSlots[5-index], currentIndex) : move;

                        }
                    }
                }
            }

            if (move == (-1, -1))
            {

                return -1;
            }
            else
            {
                return move.moveIndex;
            }
        }
        private int ChooseNotEmptySlot()
        {
            List<int> indicesOfNotEmptySlots = new List<int>();
            for (int i = 0; i < board.PlayerTwoSlots.Length; i++)
            {
                if (board.PlayerTwoSlots[i] > 0)
                {
                    indicesOfNotEmptySlots.Add(i);
                }
            }
            if (indicesOfNotEmptySlots.Count > 0)
            {
                int index = rnd.Next(0, indicesOfNotEmptySlots.Count + 1);
                return indicesOfNotEmptySlots[index];
            }
            else
            {
                return 0;
            }
            
        }
    }
}
