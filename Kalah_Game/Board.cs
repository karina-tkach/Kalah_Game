using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalah_Game
{
    public class Board
    {
        private const int stonesPerSlot = 4;
        private const int slotsPerSide = 6;
        private string moveStatus = "Make a move!";
        private string playerTwoName;

        public string PlayerTwoName
        {
            get { return playerTwoName; }
            set { playerTwoName = value; }
        }


        public string MoveStatus
        {
            get { return moveStatus; }
        }


        private int[] playerOneSlots;
        public int[] PlayerOneSlots
        {
            get { return (int[])playerOneSlots.Clone(); }
        }


        private int[] playerTwoSlots;
        public int[] PlayerTwoSlots
        {
            get { return (int[])playerTwoSlots.Clone(); }
        }


        private int playerOneStore = 0;
        public int PlayerOneStore
        {
            get { return playerOneStore; }
        }


        private int playerTwoStore = 0;
        public int PlayerTwoStore
        {
            get { return playerTwoStore; }
        }


        private bool isPlayerOneTurn = true;
        public bool IsPlayerOneTurn
        {
            get { return isPlayerOneTurn; }
        }


        private bool isGameEnded = false;
        public bool IsGameEnded
        {
            get { return isGameEnded; }
        }


        public Board(string playerTwoName)
        {
            playerOneSlots = new int[slotsPerSide];
            playerTwoSlots = new int[slotsPerSide];
            Array.Fill(playerOneSlots, stonesPerSlot);
            Array.Fill(playerTwoSlots, stonesPerSlot);
            this.playerTwoName = playerTwoName;
        }

        public void MakeMove(int slotIndex)
        {
            if (isGameEnded)
            {
                return;
            }

            bool isOnPlayerOneSide = isPlayerOneTurn;
            int numOfStones = GetStonesInSlot(slotIndex);

            if (numOfStones == 0)
            {
                moveStatus = "Invalid move!!!";
                return;
            }


            int nextSlotIndex = slotIndex + 1;

            MoveStones(ref numOfStones, ref nextSlotIndex, ref isOnPlayerOneSide);

            int lastSlotIndex = nextSlotIndex - 1;

            StonesGrabChecker(lastSlotIndex, isOnPlayerOneSide);

            GameOverChecker();

            CheckTurn(nextSlotIndex, isOnPlayerOneSide);
        }
        private int GetStonesInSlot(int slotIndex)
        {
            int numOfStones;
            if (isPlayerOneTurn)
            {
                numOfStones = playerOneSlots[slotIndex];
                playerOneSlots[slotIndex] = 0;
            }
            else
            {
                numOfStones = playerTwoSlots[slotIndex];
                playerTwoSlots[slotIndex] = 0;
            }
            return numOfStones;
        }
        private void MoveStones(ref int numOfStones, ref int nextSlotIndex, ref bool isOnPlayerOneSide)
        {
            for (; numOfStones > 0; numOfStones--)
            {
                if (nextSlotIndex == slotsPerSide)
                {
                    if (isPlayerOneTurn == isOnPlayerOneSide)
                    {
                        if (isOnPlayerOneSide)
                        {
                            playerOneStore++;
                        }
                        else
                        {
                            playerTwoStore++;
                        }
                        nextSlotIndex = 0;
                        isOnPlayerOneSide = !isOnPlayerOneSide;
                    }
                    else
                    {
                        nextSlotIndex = 0;
                        isOnPlayerOneSide = !isOnPlayerOneSide;
                        if (isOnPlayerOneSide)
                        {
                            playerOneSlots[nextSlotIndex] += 1;
                        }
                        else
                        {
                            playerTwoSlots[nextSlotIndex] += 1;
                        }
                        nextSlotIndex++;
                    }
                }
                else
                {
                    if (isOnPlayerOneSide)
                    {
                        playerOneSlots[nextSlotIndex] += 1;
                    }
                    else
                    {
                        playerTwoSlots[nextSlotIndex] += 1;
                    }
                    nextSlotIndex++;
                }
            }
        } 
        private void StonesGrabChecker(int lastSlotIndex, bool isOnPlayerOneSide)
        {
            bool isWithinRange = (lastSlotIndex >= 0 && lastSlotIndex < slotsPerSide);
            if (isWithinRange)
            {
                bool onCurrentPlayerSide = (isOnPlayerOneSide == isPlayerOneTurn);
                int[] currentPlayerSlots;
                int[] opponentSlots;
                if (isPlayerOneTurn)
                {
                    currentPlayerSlots = playerOneSlots;
                    opponentSlots = playerTwoSlots;
                }
                else
                {
                    currentPlayerSlots = playerTwoSlots;
                    opponentSlots = playerOneSlots;
                }
                

                bool lastSlotWasEmpty = currentPlayerSlots[lastSlotIndex] == 1;

                if (onCurrentPlayerSide && lastSlotWasEmpty)
                {
                    int takeSlotIndex = slotsPerSide - 1 - lastSlotIndex;

                    if (opponentSlots[takeSlotIndex] > 0)
                    {
                        currentPlayerSlots[lastSlotIndex] = 0;

                        if (isOnPlayerOneSide)
                        {
                            playerOneStore += 1 + opponentSlots[takeSlotIndex];
                        }
                        else
                        {
                            playerTwoStore += 1 + opponentSlots[takeSlotIndex];
                        }
                        opponentSlots[takeSlotIndex] = 0;
                    }

                }
            }
        }
        private void GameOverChecker()
        {
            if (IsOneSideEmpty())
            {
                playerOneStore += playerOneSlots.Sum();
                Array.Fill(playerOneSlots, 0);
                playerTwoStore += playerTwoSlots.Sum();
                Array.Fill(playerTwoSlots, 0);
                isGameEnded = true;
            }
        }
        private bool IsOneSideEmpty()
        {
            bool isPlayerSideEmpty = true;
            foreach (int slot in playerOneSlots)
            {
                if (slot != 0)
                {
                    isPlayerSideEmpty = false;
                }
            }

            if (!isPlayerSideEmpty)
            {
                foreach (int slot in playerTwoSlots)
                {
                    if (slot != 0)
                    {
                        return false;
                    }
                }

            }

            return true;
        }
        private void CheckTurn(int nextSlotIndex, bool isOnPlayerOneSide)
        {
            bool landedInMancala = (nextSlotIndex == 0 && (isPlayerOneTurn != isOnPlayerOneSide));

            if (!landedInMancala)
            {
                isPlayerOneTurn = !isPlayerOneTurn;
                moveStatus = "Make a move!";
            }
            else
            {
                if (playerTwoName == "Computer")
                {
                    moveStatus = "Free turn for " + (isPlayerOneTurn ? "Player!" : "Computer!");
                }
                else
                {
                    moveStatus = "Free turn for " + (isPlayerOneTurn ? "Player One!" : "Player Two!");
                }
            }
        }
    }
}
