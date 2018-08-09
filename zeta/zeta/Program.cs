using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeta
{
    class Program
    {
        
            static void Main(string[] args)
            {
            int number;
            BinaryGame objGame = new BinaryGame();

            
            Console.Write("Enter the number to play : ");
            number = Convert.ToInt32(Console.ReadLine());
            objGame.NumberByZita = number;
            
            char[] numberInbinary = objGame.convertToBinary(number);

            Console.WriteLine(numberInbinary);

             objGame.gameOn(numberInbinary);

            Console.WriteLine(objGame.Winner);

        

            Console.ReadLine();

            
            }
    }
}
