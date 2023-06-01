
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
 * We need to take in the user's guess, compare it to the position and if higher or lower we report back.
 * We also need to up the damage the manticore does each round.
*/


int cityHealth = 15; 
int cityHealthCurrent = 15;
 
int manticoreHealth = 10;
int manticoreHealthCurrent = 10;
int round = 0;



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

int playerOneInput = ParseIntInputInRange("Please input a number between 1 and 100 for the position of the Manticore.", 1,100 );
Console.Clear();



//Create a function that causes damage based on if it's a multi of 3, 5, or 3 and 5.
//We need to figure out if the guess is correct, too far or too short.
static string AccofGuess(int mantiloc, int userGuess)
{
    string accuracy = "";
    if (mantiloc > userGuess)
    {
        accuracy = "That round OVERSHOT the target!";
    }
    else if (mantiloc < userGuess)
    {
        accuracy = "That round fell SHORT of the target!";
    }
    else
    {
        accuracy = "That was a DIRECT HIT!";

    }

    return accuracy;
}

int RoundDamage(int currentRound)
{
    int damageAmount = 1;

    if (currentRound == currentRound % 3 || currentRound == currentRound % 5)
    {
        damageAmount = 3;
    }
    else if (currentRound == currentRound % 3 && currentRound == currentRound % 5)
    {
        damageAmount = 10;
    }
    else damageAmount = 1;
    
    return damageAmount;
}

int doDamage(int target, int currentR)
{
    if (target == cityHealth)
    {
        return cityHealthCurrent--;
    }

    if (target == manticoreHealth)
    {
        int damage = RoundDamage(currentR);
        return manticoreHealthCurrent - damage;
    }
    else
    {
        return 0;
    }
}

    
void Status(int cRound, int cCityHealth, int cMantiHealth)
{
    Console.WriteLine($"Round:{cRound}");
    Console.WriteLine($"City:{cCityHealth}");
    Console.WriteLine($"Manticore:{cMantiHealth}");
    

}

void gameLoop()
{
    while (cityHealthCurrent > 0 || manticoreHealthCurrent > 0)
    {
        int playerTwoInput = ParseIntInputInRange("Tell the defenses where to aim, pick a number between 1 and 100.", 1, 100);
        string result = AccofGuess(playerOneInput, playerTwoInput);
        doDamage()
        Status(round, cityHealthCurrent, manticoreHealthCurrent);
        Console.WriteLine(result);
        round++;
    }
}


     


 
 