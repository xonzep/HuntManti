﻿
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


const int city = 15; 
int cityHealthCurrent = city;
 
const int manticore = 10;
int manticoreHealthCurrent = manticore;
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

int playerOneInput = ParseIntInputInRange("Please input a number between 1 and 100 for the position of the Manticore.", 1,100 );
Console.Clear();

void DoDamage(int target, int currentR)
{
    if (target == city)
    {
        cityHealthCurrent--;
    }

    if (cityHealthCurrent < 0)
    {
        cityHealthCurrent = 0;
    }

    if (target == manticore)
    {
        int damage = RoundDamage(currentR);
        manticoreHealthCurrent -= damage;
    }

    if (manticoreHealthCurrent < 0)
    {
        manticoreHealthCurrent = 0;
    }
}

//Create a function that causes damage based on if it's a multi of 3, 5, or 3 and 5.
//We need to figure out if the guess is correct, too far or too short.
string AccofGuess(int mantiloc, int userGuess)
{
    string accuracy;
    if (mantiloc < userGuess)
    {
        DoDamage(city, round);
        accuracy = "That round OVERSHOT the target!";
    }
    else if (mantiloc > userGuess)
    {
        DoDamage(city, round);
        accuracy = "That round fell SHORT of the target!";
    }
    else
    {
        DoDamage(manticore, round);
        accuracy = "That was a DIRECT HIT!";

    }

    return accuracy;
}

int RoundDamage(int currentRound)
{
    int damageAmount;

    if (currentRound % 3 == 0 || currentRound % 5 == 0)
    {
        damageAmount = 3;
    }
    else if (currentRound % 3 == 0 && currentRound % 5 == 0)
    {
        damageAmount = 10;
    }
    else damageAmount = 1;
    
    return damageAmount;
}



    
void Status(int cRound, int cCityHealth, int cMantiHealth)
{
    int cannonDamage = RoundDamage(round);
    Console.WriteLine($"Round: {cRound} City: {cCityHealth}\\{city} Manticore: {cMantiHealth}\\{manticore}");
    Console.WriteLine($"The cannon is expected to do {cannonDamage}");
    
    

}

void GameLoop()
{
    bool play = true;
    //Not ending the loop when health reaches zero. Not sure why. Added bool, that now works.
    while (play)
    {
        int playerTwoInput = ParseIntInputInRange("Tell the defenses where to aim, pick a number between 1 and 100.", 1, 100);
        string result = AccofGuess(playerOneInput, playerTwoInput);
        Status(round, cityHealthCurrent, manticoreHealthCurrent);
        Console.WriteLine();
        Console.WriteLine(result);
        round++;
        if (manticoreHealthCurrent == 0)
        {
            play = false;
            Console.WriteLine();
            Console.WriteLine("The Manticore has been destroyed! The city has been saved!");
        }
        else if(cityHealthCurrent == 0)
        {
            play = false;
            Console.WriteLine();
            Console.WriteLine("The city has been destroyed! The Manticore is victorious!");
        }
        else
        {
            play = true;
        }
    }
}

GameLoop();


     


 
 