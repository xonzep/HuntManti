
/*
 * We're making a guessing game. Each guess has an outcome. If the guess is wrong the player in the form of the 'city' takes damage.
 * The first thing to do is setup the state of the game. For that we need a few variables to hold our starting points.
 * Next we need to get info from the first player and store that. We create a function to get the number which we can reuse for the
 * second player's input as well.
 *
 * The first user begins by secretly establishing how far the Manticore is from the city, in the range 0 to 100.
 * The program then allows a second player to repeatedly attempt to destroy the airship by picking the
 * range to target until either the city of Consolas or the Manticore is destroyed. In each attempt, the player
 * is told if they overshot (too far), fell short (not far enough), or hit the Manticore. The damage dealt to the
 * Manticore depends on the turn number. For most turns, 1 point of damage is dealt. But if the turn number
 * is a multiple of 3, a fire blast deals 3 points of damage; a multiple of 5, an electric blast deals 3 points of
 * damage, and if it is a multiple of both 3 and 5, a mighty fire-electric blast deals 10 points of damage. The
 * Manticore is destroyed after taking 10 points of damage.
 * However, if the Manticore survives a turn, it will deal a guaranteed 1 point of damage to the city of
 * Consolas. The city can only take 15 points of damage before being annihilated.
 * Before a round begins, the user should see the current status: the current round number, the city’s health,
 * and the Manticore’s health.
 *
 * STATUS: Round: 1 City: 15/15 Manticore: 10/10
 *The cannon is expected to deal 1 damage this round.
 *
 *--------------------------------------
 *
 * 
 *Enter desired cannon range: 50
 *That round OVERSHOT the target.
 *
 * We to take in the user's guess, compare it to the position and if higher or lower we report back.
 * We also need to up the damage the manticore does each round.
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
    Console.Clear();
     return userInput;
 }
 
 int playerOneInput;
 playerOneInput = ParseIntInputInRange("Please input a number between 1 and 100 for position of the Manticore.", 1,100 );


//Create a function that causes damage based on if it's a multi of 3, 5, or 3 and 5.
//We need to figure out if the guess is correct, too far or too short.
static void AccuofGuess(int mantiloc, int userGuess)
{
    if (mantiloc > userGuess)
    {
        Console.WriteLine("That round OVERSHOT the target!");
    }
    else if (mantiloc < userGuess)
    {
        Console.WriteLine("That round fell SHORT of the target.");
    }
    else
    {
        Console.WriteLine("That was a DIRECT HIT!");
        
    }
}
    
static string Status(int round, int cdamage, int mdamage)
{
    
}

void gameLoop()
{
    while (cityHealthCurrent > 0 || manticoreHealthCurret > 0)
    {
        
    }
}


     


 
 