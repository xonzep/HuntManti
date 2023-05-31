
/*
 * We're making a guessing game. Each guess has an outcome. If the guess is wrong the player in the form of the 'city' takes damage.
 * The first thing to do is setup the state of the game. For that we need a few variables to hold our starting points.
 * Next we need to get info from the first player and store that. We create a function to get the number which we can reuse for the
 * second player's input as well. 
 */


int cityHealth = 15; 
int cityHealthCurrent = 15;
 
int manticoreHealth = 10;
int manticoreHealthCurret = 10;
int round = 1;

//Our input function to make sure we're getting numbers back and they are in range.
 static int ParseIntInputInRange(string prompt, int start, int end)
 {
     Console.WriteLine(prompt);
     bool isInRange = false;
     int userInput = 0;
     
     while (!isInRange)
     {
         string uInput = Console.ReadLine() ?? string.Empty;

         if (int.TryParse(uInput, out userInput))
         {
             if (userInput <= end && userInput >= start)
             {
                 isInRange = true;
             }
         }

         if (!isInRange)
         {
             Console.WriteLine($"The number you put in is either not a valid number or is not in range. Please input a valid integer between {start} and {end}.");
         }
     }

     return userInput;
 }
 
 int playerOneInput;
 playerOneInput = ParseIntInputInRange("Please input a number between 1 and 100 for position of the Manticore.", 1,100 );

 Console.Clear();


static void gameLoop()
{
    bool play = true;
    while (play)
    {
        
    }
}


     


 
 