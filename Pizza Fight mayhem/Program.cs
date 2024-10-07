using System;

class Program
{
    static void Main()
    {
        game startgame = new game();
       
    }
}

class player
{
    private int health = 100;
    private int max_health = 100;
    private int attackdamage = 20;
    private int healing_capacity = 10;
    private Random rand = new Random(); // Moved the Random instance here

    public int CalculateTotalDamage()
    {
        int additionalDamage = generateRandomNumberInRange(5, 15);
        int totalDamage = attackdamage + additionalDamage;

        return totalDamage;
    }

    public int generateRandomNumberInRange(int min, int max)
    {
        return rand.Next(min, max + 1); // Use the instance variable
    }

    public void ShowAttackDamage(int totalDamage)
    {
        Console.WriteLine("             🍕 PIZZA BATTLE 🍕                   ");
        Console.WriteLine("============================================");
        Console.WriteLine("Dough Master's attack dealt " + totalDamage + " damage! 🥊");
        Console.WriteLine("--------------------------------------------");
    }

    public player()
    {
        spawn_player();
    }

    private void spawn_player()
    {
        Console.WriteLine("\n==================================================");
        Console.WriteLine(" 🍕 DOUGH MASTER: GUARDIAN OF THE GOLDEN CRUST 🍕 ");
        Console.WriteLine("==================================================\n");
        Console.WriteLine("\nDough Master: That scoundrel won't escape with my creation!\n");
    }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            if (value < 0)
            {
                health = 0;
            }
            else if (value >= max_health)
            {
                health = max_health;
            }
            else
            {
                health = value;
            }
        }
    }
}

class Enemy
{
    private int health = 150;
    private int attack_damage = 15;
    private int max_health = 150;

    public Enemy()
    {
        spawnenemy();
    }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            if (health < 0)
            {
                health = 0;
            }
            else if (health >= max_health)
            {
                health = max_health;
            }
            else
            {
                health = value;
            }
        }
    }

    private void spawnenemy()
    {
        Console.WriteLine("\n==================================================");
        Console.WriteLine("  CRUST BANDIT: MEMESIS OF ITALIAN CUSINE");
        Console.WriteLine("\n==================================================\n\n");
        Console.WriteLine("Crust Bandit: This delectable pizza is mine now! You'll never catch me, flour face!");
    }
}

class game
{
    public game()
    {
        displaygamestory();
        spawncharacters();
    }

    private void displaygamestory()
    {
        Console.WriteLine("\n# # # # # # # # # # # # # # # # # # # # # # # #");
        Console.WriteLine("\t🍕  MIDNIGHT PIZZA FIGHT 🍕");
        Console.WriteLine("# # # # # # # # # # # # # # # # # # # # # # # #\n");
        Console.WriteLine("In a busting pizzeria on a busy Friday night");
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
        Console.WriteLine("You, the Dough Master, created your magnum opus \nthe perfect pizza. Suddenly, sneaky Crust Bandit snatches your masterpiece!");
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
        Console.WriteLine("Fueled by passion for your craft, you give chase...");
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
        Console.WriteLine("Through winding alleys and crowded streets\nyou pursue the pizza pilferer. Finally, the thief is cornered in a dead-end alley\nIt's time to recover your stolen slice!");
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
        Console.WriteLine("                         FIGHT!");
    }

    private void spawncharacters()
    {
        player doughMaster = new player();
        Enemy crustbandit = new Enemy();

        // Calculate and show attack damage
        int totalDamage = doughMaster.CalculateTotalDamage();
        doughMaster.ShowAttackDamage(totalDamage);
    }
}
