using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int playersValue = 0;
            int dealersValue = 0;
            int tempValue = 0;
            double cash = 500;
            double bets;
            Random random = new Random();
            Console.WriteLine("In order not to get carried away, if your money is doubled, the game will be over");
            Console.WriteLine("Or, if you want to leave early, you will receive a corresponding offer");
            Console.WriteLine("Also, there is a 20 percent commission in our casino");
            Console.WriteLine("*********************************************************************************\n");

            while (true)
            {
                bool check = true;
                bool tie = false;
                Console.WriteLine("You have " + cash + "$");
                Console.WriteLine("Choose your bet");
                while(true)
                {
                    while (!double.TryParse(Console.ReadLine(), out bets))
                    {
                        Console.WriteLine("Choose correct bet!");
                    }
                    if(bets > cash && bets > 0)
                    {
                        Console.WriteLine("You cant bet more than u have");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Your bet is " + bets + "$");
                        break;
                    }    
                }
                playersValue += random.Next(1, 12);
                playersValue += random.Next(1, 12);
                if (playersValue > 21)
                {
                    playersValue -= 10;
                }
                dealersValue += random.Next(1, 12);
                dealersValue += random.Next(1, 12);
                if (dealersValue > 21)
                {
                    dealersValue -= 10;
                }
                string answer;
                while (true)    //players turn
                {
                    if (playersValue == 21)
                    {
                        Console.WriteLine("BlackJack!!!!");
                        break;
                    }
                    Console.WriteLine("Your score is " + playersValue + "\nOne more card?(y - yes n - no)");
                    answer = Console.ReadLine();
                    if (answer == "y")
                    {
                        tempValue = random.Next(1, 12);
                        if(tempValue == 11 && playersValue + 11 > 21)
                        {
                            tempValue -= 10;
                            playersValue += tempValue;
                        }
                        else
                        {
                            playersValue += tempValue;
                        }
                        Console.WriteLine("You new card is " + tempValue);
                        if (playersValue > 21)
                        {
                            Console.WriteLine("******************************");
                            Console.WriteLine("You have more than 21, u lose");
                            check = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (answer == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect answer, try again");
                        continue;
                    }
                }
                Console.WriteLine("******************************");
                Console.WriteLine("Your score is " + playersValue);
                Console.WriteLine("******************************");
                if (playersValue <= 21)     //dealers turn
                {
                    while (dealersValue < 21 && dealersValue < playersValue)
                    {
                        dealersValue += random.Next(1, 12);
                    }
                    if (playersValue == dealersValue)
                    {
                        Console.WriteLine("Tie");
                        Console.WriteLine("******************************");
                        tie = true;
                    }
                    else if (playersValue < dealersValue && dealersValue <= 21)
                    {
                        Console.WriteLine("Dealer has won");
                        Console.WriteLine("******************************");
                        check = false;
                    }
                    else if (dealersValue > 21)
                    {
                        Console.WriteLine("YOU HAVE WON!");
                        Console.WriteLine("******************************");
                        check = true;
                    }
                    else if (dealersValue == 21)
                    {
                        Console.WriteLine("Dealer has won!");
                        Console.WriteLine("******************************");
                        check = false;
                    }
                }
                else
                {
                    Console.WriteLine("The dealer has won");
                    Console.WriteLine("******************************");
                    check = false;
                }
                Console.WriteLine("Dealer's value is " + dealersValue);
                Console.WriteLine("******************************\n");
                if(!tie)
                {
                    if(check)
                    {
                        bets *= 0.8;
                        cash += bets;
                    }
                    else
                    {
                        cash -= bets;
                    }
                }
                Console.WriteLine("Your cash is " + cash + "$");
                if(cash == 0)
                {
                    Console.WriteLine("Game is over! You do not have money!");
                    Console.WriteLine("Press any key to close console");
                    Console.ReadKey();
                    break;
                }
                if(cash >= 1000)
                {
                    Console.WriteLine("Game is over! You have " + cash + "$");
                    Console.WriteLine("Press any key to close console");
                    Console.ReadKey();
                    break;
                }
                Console.WriteLine("Do u want to get more?(y - yes n - no)");
                while(true)
                {
                    answer = Console.ReadLine();
                    if (answer == "y")
                    {
                        playersValue = 0;
                        dealersValue = 0;
                        break;
                    }
                    else if (answer == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect answer, try again");
                        continue;
                    }
                }
                if(answer == "y")
                {
                    continue;
                }
                else 
                {
                    break;
                }
            }
        }
    }
}