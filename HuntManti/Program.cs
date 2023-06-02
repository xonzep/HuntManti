
/*
 * We're making a guessing game. Each guess has an outcome. If the guess is wrong the player in the form of the 'city' takes damage.
 * The first thing to do is setup the state of the game. For that we need a few variables to hold our starting points.
 * Next we need to get info from the first player and store that. We create a function to get the number which we can reuse for the
 * second player's input as well.
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


     


 
 