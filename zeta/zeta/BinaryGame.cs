using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeta
{
    class BinaryGame
    {
        int numberByZita;
        int numberByZitaOnePlus;
        int numberByZitaOneMinus;
        int numOfRounds;
        char winner;
        char[] numberInbinary;
        public char[] binaryNumberBeforechange;

     
        public char Winner
        {
            get{
                return winner;
            }
            set{
                winner = value;
            }
        }

        public int NumberByZita
        {
            get
            {
                return numberByZita;
            }
            set
            {
                numberByZita = value;
            }
        }

        public char[] convertToBinary(int numByZeta)
        {
            int quot;
            string rem = "";
            while (numByZeta >= 1)
            {
                quot = numByZeta / 2;
                rem += (numByZeta % 2).ToString();
                numByZeta = quot;
            }

            string bin = "";
            for (int i = rem.Length - 1; i >= 0; i--)
            {
                bin = bin + rem[i];
            }

            char[] numberInbinary = new char[bin.Length];
            numOfRounds = bin.Length;
            numberInbinary = bin.ToArray();
            binaryNumberBeforechange = bin.ToArray();
            return numberInbinary;
        }

        public int convertToDecimal(char[] num)
        {

            int rem;
            int decimal_val = 0, base_val = 1;

            for (int i = (num.Length-1); i >= 0; i--)
            {
                rem = Convert.ToInt32(new string(num[i], 1));
              
                decimal_val = decimal_val + rem * base_val;

                base_val = base_val * 2;
            }

            return decimal_val;
        }

        public char[] checkNChgLeftBit(char[] binaryNumber, int move)
        {
            if (binaryNumber[move] == binaryNumber[move - 1])
            {
                if (binaryNumber[move - 1] == '1')
                    binaryNumber[move - 1] = '0';
                else
                    binaryNumber[move - 1] = '1';
            }

            return binaryNumber;
        }

        public char[] checkNChgRightBit(char[] binaryNumber, int move)
        {
            if (binaryNumber[move] == binaryNumber[move + 1])
            {
                if (binaryNumber[move + 1] == '1')
                    binaryNumber[move + 1] = '0';
                else
                    binaryNumber[move + 1] = '1';
            }

            return binaryNumber;
        }

        public char[] toggleMBit(char[] binaryNumber, int move)
        {
            if (binaryNumber[move] == '1')
                binaryNumber[move] = '0';
            else
                binaryNumber[move] = '1';

            return binaryNumber;
        }

        public char checkForWinner(string player, char[] binaryNumber)
        {
            bool flag = false;
            int decimalValue;

            for (int chkBit = 0; chkBit < numOfRounds; chkBit++)
            {
                if (binaryNumberBeforechange[chkBit] == binaryNumber[chkBit])
                    flag = true;
                else
                    flag = false;
            }

            decimalValue = convertToDecimal(binaryNumber);
            numberByZitaOnePlus = decimalValue + 1;
            numberByZitaOneMinus = decimalValue - 1;

            if (flag || NumberByZita + 1 == numberByZitaOnePlus || NumberByZita - 1 == numberByZitaOneMinus)
            {
                if (player == "Xavier")
                    Winner = 'X';
                else
                    Winner = 'Y';
            }
            else
            {
                if (player == "Xavier")
                    Winner = 'Y';
                else
                    Winner = 'X';
            }

            return winner;
        }

        public char gameOn(char[] binaryNumber)
        {
            string player = "Xavier";

            for (int move = 0; move < numOfRounds; move++)
            {
                if (move == 0)
                {
                    binaryNumber = checkNChgRightBit(binaryNumber, move);
                    binaryNumber = toggleMBit(binaryNumber, move);
                }
                else if (move == numOfRounds - 1)
                {
                    binaryNumber = checkNChgLeftBit(binaryNumber, move);
                    binaryNumber = toggleMBit(binaryNumber, move);
                   
                    break;
                }
                else
                {
                    binaryNumber = checkNChgLeftBit(binaryNumber, move);
                    binaryNumber = checkNChgRightBit(binaryNumber, move);

                    binaryNumber = toggleMBit(binaryNumber, move);                    
                }

                if (player == "Xavier")
                    player = "Yale";
                else
                    player = "Xavier";
            }
            
            char winner = checkForWinner(player, binaryNumber);

            return winner;
        }
            
    }      
}
