using System;

namespace Class
{
    class Program

    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yoda`s Games");
            Console.WriteLine("The Force: In this card game, Yoda will draw a card ");
            Console.WriteLine("and the user will then guess if the next card is higher or lower");
            Console.WriteLine("10 in a row = 3x Credits Bet");
            Console.WriteLine("7 in a row = 2x Credits Bet");
            Console.WriteLine("5 in a row = break even");
            Console.WriteLine("Blasters: Yoda is shooting lasers at you!");
            Console.WriteLine("You must decide to deflect or dodge");
            Console.WriteLine("Dodging is more likely to work but deflecting is worth more points");
            Console.WriteLine("You start with 15 points, 40 points will win the game but if you drop to 0 you lose");
            Console.WriteLine("Must bet at least 20 credits to play Blasters");
            System.Console.WriteLine("Spaceships is a 2 player game where each user has 5 ships");
            System.Console.WriteLine("The ships have 50, 40, 30, 20, and 10 health, respectively");
            System.Console.WriteLine("Players will take turns selecting a number to hit each other`s ship");
            System.Console.WriteLine("The higher health a ship starts with, the better the chances of landing a hit");
            System.Console.WriteLine("A hit always takes away 10 health");
            System.Console.WriteLine("The first player to eliminate all the opponents ship wins");
            System.Console.WriteLine("Credits will not be involved since it is a user vs user game");
            
        }
        int userCredits =50;

        static void Menu(ref int userCredits, ref int userGuess, ref int creditsBet)
        {
           DisplayMenu();
           int userChoice = GetMenuChoice(ref userCredits);
           while(userChoice != 5)
           {
               if(userChoice == 1)
               {
                  TheForce(ref userCredits, ref userGuess, ref creditsBet);
               }
               else if (userChoice == 2)
               {
                   Blasters(ref userCredits);
               }
               else if (userChoice == 3)
               {
                   Scoreboard(ref userCredits);
               }
               else if (userChoice==4)
               {
                   Spaceships();
               }
            
           }

        }
        
        static void DisplayMenu()
        {
           Console.WriteLine("1. The Force");
           Console.WriteLine("2. Blasters");
           Console.WriteLine("3. View Scoreboard");
           System.Console.WriteLine("4. Spaceships");
           Console.WriteLine("5. Exit Game");
        }
        static int GetMenuChoice(ref int userCredits)
        {
            int menuChoice=0;
            while(userCredits>0&& userCredits<300)
            {
                Console.WriteLine("Enter Your Choice:  ");
             menuChoice = int.Parse(Console.ReadLine());
            while(menuChoice < 1 || menuChoice > 5)
            {
                Console.WriteLine("Invalid Choice");
                Console.WriteLine("Enter Your Choice: ");
                 menuChoice=int.Parse(Console.ReadLine());
            
            }
            
        
            }
            return menuChoice;
        }
         const int NUM_OF_CARDS = 52;
         public enum SUIT
         {
             HEARTS,
             SPADES,
             DIAMONDS,
             CLUBS
         }
         public enum VALUE
         {
             ACE = 1, TWO=2, THREE =3, FOUR=4, FIVE=5, SIX=6, SEVEN=7, EIGHT=8, NINE=9, TEN=10, JACK=11, QUEEN=12, KING=13
         }
         public SUIT MySuit {get; set;}
         public VALUE MyValue {get; set;}
          private Card[] deck;

        public void DeckOfCards()
        {
          deck = new Card[NUM_OF_CARDS];
        }

        public Card[] getDeck {get { return deck;}}
        public void setUpDeck()
        {
            int i =0;
            foreach(SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach(VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    deck[i] = new Card {MySuit = s, MyValue = v};
                    i++;
                }
            }
            ShuffleCards();
        }
        public void ShuffleCards()
        {
           Random rand = new Random(); 
           Card temp;
           for(int shuffleTimes = 0; shuffleTimes<100;shuffleTimes++)
           {
               for(int i =0; i < NUM_OF_CARDS; i++)
               {
                   int secondCardIndex = rand.Next(13);
                   temp = deck[i];
                   deck[i]= deck[secondCardIndex];
                   deck[secondCardIndex]= temp;
               }
           }
        }
        public void TheForce(ref int userCredits, ref int userGuess, ref int creditsBet)
        {
            System.Console.WriteLine("How many credits would you like to bet?");
             creditsBet = int.Parse(Console.ReadLine());
            int correctGuesses=0;
            int incorrectGuesses=0;
            if (userCredits!< creditsBet)
            {
                ShuffleCards();
                System.Console.WriteLine("Enter 1 for Higher, 2 for Lower");
                 userGuess= int.Parse(Console.ReadLine());
                if(userGuess != 1 && userGuess !=2)
                {
                   System.Console.WriteLine("Invalid choice, Enter 1 for Higher, 2 for Lower");
                   userGuess= int.Parse(Console.ReadLine());
                }
                if(userGuess==1||userGuess==2)
                for(int i =0; i<10; i++)
                {
                    System.Console.WriteLine("Enter 1 for Higher, 2 for Lower");
                 userGuess= int.Parse(Console.ReadLine());
                }
                if(i =10)
                {
                  System.Console.WriteLine("You Win!");
                  System.Console.WriteLine("Enter 1 to play again, Enter 2 to exit");
                    int userChoice= int.Parse(Console.ReadLine());
                    if(userChoice==1)
                    {
                        TheForce(ref userCredits, ref userGuess, ref creditsBet);
                    }
                    if(userChoice >2 || userChoice<1)
                    {
                        System.Console.WriteLine("Invalid input, Enter 1 to keep playing, 2 to exit");
                    }
                  
                }
                if (correctGuesses ==10)
                {
                    creditsBet=creditsBet*3;
                }
                if(correctGuesses>10&& correctGuesses>6)
                {
                   creditsBet= creditsBet*2;
                }
                if(correctGuesses<7 && correctGuesses> 4)
                {
                    creditsBet=creditsBet*1;
                }
                else
                {
                    creditsBet=creditsBet*0;
                }
                 
                if(userGuess==false)
                for (int j =0; j<1; j++)
                {
                    System.Console.WriteLine("You Lose");
                    System.Console.WriteLine("Enter 1 to play again, Enter 2 to exit");
                    int userChoice= int.Parse(Console.ReadLine());
                    if(userChoice==1)
                    {
                        TheForce(ref userCredits, ref userGuess, ref creditsBet);
                    }
                    if(userChoice >2 || userChoice<1)
                    {
                        System.Console.WriteLine("Invalid input, Enter 1 to keep playing, 2 to exit");
                         userChoice= int.Parse(Console.ReadLine());
                    }
                }
                
               
            }
            else
            {
                System.Console.WriteLine("Invalid Bet, Please enter your bet");
                 creditsBet= int.Parse(Console.ReadLine());
            }
            
        }
        public void Blasters(ref int userCredits)
        {
            System.Console.WriteLine("How many credits would you like to bet?");
            int creditsBet= int.Parse(Console.ReadLine());
            if(creditsBet<20 || creditsBet> userCredits )
            {
                System.Console.WriteLine("Invalid bet, please enter a valid bet");
                 creditsBet= int.Parse(Console.ReadLine());
            }
            int userPoints=15;
            while(creditsBet>20&&creditsBet<=userCredits)
            while(userPoints>0 && userPoints<40)
            {
                System.Console.WriteLine("Enter 1 to dodge, 2 to deflect");
                int userChoice = int.Parse(Console.ReadLine());
                if(userChoice<1||userChoice>2)
                {
                    System.Console.WriteLine("Invalid choice, select 1 to dodge, 2 to deflect");
                     userChoice = int.Parse(Console.ReadLine());
                }
                if(userChoice==1)
                {
                    Random rand = new Random();
                    int dodgeNumber = rand.Next(0, 101);
                    if(dodgeNumber<=50)
                    {
                        System.Console.WriteLine("Success!");
                        userPoints=userPoints +5;
                    }
                    if(dodgeNumber>50)
                    {
                        System.Console.WriteLine("You`ve been hit");
                        userPoints=userPoints -5;
                    }
                }
                if(userChoice==2)
                {
                     Random rand = new Random();
                    int deflectNumber = rand.Next(0, 101);
                    if(deflectNumber<=30)
                    {
                        System.Console.WriteLine("Success!");
                        userPoints=userPoints +10;
                    }
                    if(deflectNumber>30)
                    {
                        System.Console.WriteLine("You`ve been hit");
                        userPoints=userPoints -5;
                    }
                }
            }
            if (userPoints>=40)
            {
                System.Console.WriteLine("You Win!");
                creditsBet=creditsBet*2;
            }
            if (userPoints==0)
            {
                System.Console.WriteLine("You Lose");
                creditsBet=creditsBet*0;
            }
            
        }
        public void Scoreboard(ref int userCredits)
        {
           Console.Write("Credit Balance: ");
           System.Console.WriteLine(userCredits);
        }
            
        public void Spaceships()
        {
            int userShip1 =10;
            int userShip2= 20;
            int userShip3 =30;
            int userShip4 =40;
            int userShip5= 50;
            while(userShip1>0 || userShip2>0||userShip3>0||userShip4>0||userShip5>0) 
            {
                System.Console.WriteLine("Enter 1 to shoot at Ship 1, 2 to shoot at Ship 2, and so on");
            int userChoice=int.Parse(Console.ReadLine());
            if (userChoice >5 || userChoice <1)
            {
                System.Console.WriteLine("Invalid Input, please enter a number 1-5");
                 userChoice=int.Parse(Console.ReadLine());
            }
            if(userChoice==1)
            {
               Random rand = new Random();
               int chanceOfHit = rand.Next(0, 101);
               if(chanceOfHit<10)
               {
                   System.Console.WriteLine("Hit!");
                    userShip1 = userShip1 -10;
               }
               if(chanceOfHit>10)
               {
                   System.Console.WriteLine("Miss!");
               }
            }
            if (userChoice==2)
            {
                Random rand = new Random();
               int chanceOfHit = rand.Next(0, 101);
               if(chanceOfHit<20)
               {
                   System.Console.WriteLine("Hit!");
                    userShip2 = userShip2 -10;
               }
               if(chanceOfHit>20)
               {
                   System.Console.WriteLine("Miss!");
               }
            }
            if (userChoice==3)
            {
                Random rand = new Random();
               int chanceOfHit = rand.Next(0, 101);
               if(chanceOfHit<30)
               {
                   System.Console.WriteLine("Hit!");
                    userShip3 = userShip3 -10;
               }
               if(chanceOfHit>30)
               {
                   System.Console.WriteLine("Miss!");
               }
            }
            if (userChoice==4)
            {
                Random rand = new Random();
               int chanceOfHit = rand.Next(0, 101);
               if(chanceOfHit<40)
               {
                   System.Console.WriteLine("Hit!");
                    userShip4 = userShip4 -10;
               }
               if(chanceOfHit>40)
               {
                   System.Console.WriteLine("Miss!");
               }
            }
            if (userChoice==5)
            {
                Random rand = new Random();
               int chanceOfHit = rand.Next(0, 101);
               if(chanceOfHit<50)
               {
                   System.Console.WriteLine("Hit!");
                    userShip5 = userShip5 -10;
               }
               if(chanceOfHit>50)
               {
                   System.Console.WriteLine("Miss!");
               }
            }

            }
            
        
        
        
            int user2Ship1 =10;
            int user2Ship2= 20;
            int user2Ship3 =30;
            int user2Ship4 =40;
            int user2Ship5= 50;
            while(user2Ship1>0 || user2Ship2>0||user2Ship3>0||user2Ship4>0||user2Ship5>0) 
            {
                System.Console.WriteLine("Enter 1 to shoot at Ship 1, 2 to shoot at Ship 2, and so on");
            int userChoice=int.Parse(Console.ReadLine());
            if (userChoice >5 || userChoice <1)
            {
                System.Console.WriteLine("Invalid Input, please enter a number 1-5");
                 userChoice=int.Parse(Console.ReadLine());
            }
            if(userChoice==1)
            {
               Random rand = new Random();
               int chanceOfHit = rand.Next(0, 101);
               if(chanceOfHit<10)
               {
                   System.Console.WriteLine("Hit!");
                    user2Ship1 = user2Ship1 -10;
               }
               if(chanceOfHit>10)
               {
                   System.Console.WriteLine("Miss!");
               }
            }
            if (userChoice==2)
            {
                Random rand = new Random();
               int chanceOfHit = rand.Next(0, 101);
               if(chanceOfHit<20)
               {
                   System.Console.WriteLine("Hit!");
                    user2Ship2 = user2Ship2 -10;
               }
               if(chanceOfHit>20)
               {
                   System.Console.WriteLine("Miss!");
               }
            }
            if (userChoice==3)
            {
                Random rand = new Random();
               int chanceOfHit = rand.Next(0, 101);
               if(chanceOfHit<30)
               {
                   System.Console.WriteLine("Hit!");
                   user2Ship3 = user2Ship3 -10;
               }
               if(chanceOfHit>30)
               {
                   System.Console.WriteLine("Miss!");
               }
            }
            if (userChoice==4)
            {
                Random rand = new Random();
               int chanceOfHit = rand.Next(0, 101);
               if(chanceOfHit<40)
               {
                   System.Console.WriteLine("Hit!");
                    user2Ship4 = user2Ship4 -10;
               }
               if(chanceOfHit>40)
               {
                   System.Console.WriteLine("Miss!");
               }
            }
            if (userChoice==5)
            {
                Random rand = new Random();
               int chanceOfHit = rand.Next(0, 101);
               if(chanceOfHit<50)
               {
                   System.Console.WriteLine("Hit!");
                    user2Ship5 = user2Ship5 -10;
               }
               if(chanceOfHit>50)
               {
                   System.Console.WriteLine("Miss!");
               }
            }

            }
            if(userShip1==0&&userShip2==0&&userShip3==0&&userShip4==0&&userShip5==0)
            {
                System.Console.WriteLine("Player 1 Wins!");
            }
            if(user2Ship1==0&&user2Ship2==0&&user2Ship3==0&&user2Ship4==0&&user2Ship5==0)
            {
                System.Console.WriteLine("Player 2 Wins!");
            }
            
        }
        
             


        
        

        



        
    }
}

