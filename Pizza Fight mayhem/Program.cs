using System;
using System.Threading;
class Program
{
    static void Main()
    {

        Console.WriteLine("\n\n THIS INSTRUCTIONS  WILL STAY FOR 5 MINUTES PLEASE READ");
        game startgame = new game();

        Thread.Sleep(12000);
        Console.Clear();
        startgame.spawncharacters();
        Thread.Sleep(12000);
        Console.Clear();
        startgame.processgameloop();
        
       
    }
}

class player
{
    private int health = 100;
    private int max_health = 100;
    private int attackdamage = 20;
    private int healing_capacity = 10;
    private Random rand = new Random();

    public  int CalculateTotalDamage()
    {
        int additionalDamage = generateRandomNumberInRange(5, 15);
        int totalDamage = attackdamage + additionalDamage;

        return totalDamage;
    }


    public void TakeDamage(int damageRecieved) => Health -= damageRecieved;

    public int generateRandomNumberInRange(int min, int max)
    {
        return rand.Next(min, max + 1); 
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
        DisplayPlayerStats(); 
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


    public int CalculateTotalHeal()
    {
        int additionalHeal = generateRandomNumberInRange(10, 20);
        int totalHeal =  healing_capacity + additionalHeal;

        return totalHeal;
    }

    public void Heal(int healAmount) => Health += healAmount;

    public void ShowHeal(int healAmount)
    {
        if (Health >= max_health)
        {
            Console.WriteLine("             🍕 PIZZA BATTLE 🍕                   ");
            Console.WriteLine("============================================");
            Console.WriteLine("     Dough Master is bursting with energy! 🚀    ");
            Console.WriteLine("--------------------------------------------");
        }
        else
        {
            Console.WriteLine("             🍕 PIZZA BATTLE 🍕                   ");
            Console.WriteLine("============================================");
            Console.WriteLine("Dough Master's heal restored " + healAmount + " hp! ☕");
            Console.WriteLine("--------------------------------------------");
        }
    }


    public void DisplayPlayerStats()
    {
        Console.WriteLine("\n---------------------------------------------------");
        Console.WriteLine("              DOUGH MASTER'S STATS                ");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Health: " + Health + "/" + max_health);
        Console.WriteLine("Dough Slapper: " + attackdamage);
        Console.WriteLine("Espresso Shot ☕: " + healing_capacity);
        Console.WriteLine("Dough Slapper Boost 🌪️: 5 to 15");
        Console.WriteLine("Espresso Shot Boost ☕: 10 to 20");
    }


}

class Enemy
{
    private int health = 150;
    private int attack_damage = 15;
    private int max_health = 150;
    private Random rand = new Random();
    public Enemy()
    {
        spawnenemy();
        DisplayPlayerStats();
    }

    private int generaterandomnumberinrange(int max, int min)
    {
        return rand.Next(min, max + 1);
    }


    public int  CalculateTotalaDamage()
    {
        int total_damage = attack_damage + generaterandomnumberinrange(10, 5);
        return total_damage;
    }

    public void ShowAttackDamage(int totalDamage)
    {
        Console.WriteLine("             🍕 PIZZA BATTLE 🍕                   ");
        Console.WriteLine("============================================");
        Console.WriteLine("Crust Bandit's attack dealt " + totalDamage + " damage! 🥊");
        Console.WriteLine("--------------------------------------------");
    }

    public void  TakeDamage(int damage_taken) => Health -= damage_taken;



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


    public void DisplayPlayerStats()
    {
        Console.WriteLine("\n---------------------------------------------------");
        Console.WriteLine("              CRUST BADNIT'S STATS                ");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Health: " + Health + "/" + max_health);
        Console.WriteLine("Crust Bandit's shot : " + attack_damage);

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

    

    private void gameoptions()
    {

        Console.WriteLine("==================================================");
        Console.WriteLine("             🍕 PIZZA BATTLE OPTIONS 🍕             ");
        Console.WriteLine("==================================================");
        Console.WriteLine("  Choose your action:");
        Console.WriteLine("    [A] Attack the Crust Bandit 🥊");
        Console.WriteLine("    [H] Gulp an Espresso Shot ☕");
        Console.WriteLine("==================================================");
        Console.Write("  Your choice: ");
    }





    public void processgameloop()
    {

        do
        {
            showbattleoptions();
            processgameinput();
        } while (AreCharactersAlive());

    }


    player doughMaster = new player();
    Enemy crustbandit = new Enemy();
    

    private void showbattleoptions()
    {
        Console.WriteLine("PRESS A FOR ATTACK");
        Console.WriteLine("PRESS H FOR HEAL");
    }
    private void processgameinput()
    {
        string player_choice = getinput();
        Console.Clear();
        switch (player_choice)
        {
            case "A":

                PlayerAttack();
                if (CheckGameOver())
                    break;

                EnemyAttack();
                if (CheckGameOver())
                    break;

                DisplayCharacterStats();
                break;
            case "H":
                PlayerHeal();
                EnemyAttack();
                if (CheckGameOver())
                    break;

                DisplayCharacterStats();
                break;
            default:
                InvalidInput();
                break;

        }

    }

    private void PlayerAttack()
    {
        
        int total_damage = doughMaster.CalculateTotalDamage();
        crustbandit.TakeDamage(total_damage);
        doughMaster.ShowAttackDamage(total_damage);
    }

    private void PlayerHeal()
    {
        int totalHeal = doughMaster.CalculateTotalHeal();
        doughMaster.Heal(totalHeal);
        doughMaster.ShowHeal(totalHeal);
    }

    private string getinput()
    {
        string input = Console.ReadLine();
        return input.ToUpper();
    }


    private void EnemyAttack()
    {
        int total_damage= crustbandit.CalculateTotalaDamage();
        crustbandit.TakeDamage(total_damage);
        crustbandit.ShowAttackDamage(total_damage);
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

    private void DisplayCharacterStats()
    {
        doughMaster.DisplayPlayerStats();
        crustbandit.DisplayPlayerStats();
    }


    private bool CheckGameOver()
    {
        if (crustbandit.Health <= 0)
        {
            ShowGameWin();
            return true;
        }
        if (doughMaster.Health <= 0)
        {
            ShowGameLose();
            return true;
        }
        return false;
    }

    private void ShowGameWin()
    {
        Console.Clear();
         
        Console.WriteLine("==================================================");
        Console.WriteLine("           🎉 PIZZA JUSTICE SERVED! 🎉              ");
        Console.WriteLine("==================================================");
        Console.WriteLine("The Dough Master has defeated the Crust Bandit!");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("The perfect pizza has been reclaimed 🍕           ");
        Console.WriteLine("The honor of Italian cuisine is restored!         ");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("    Bon appétit, and thanks for playing! 👨‍🍳        ");
        Console.WriteLine("==================================================");

    }


    private void ShowGameLose()

    {

        Console.Clear();

        Console.WriteLine("==================================================");
        Console.WriteLine("              😭 PIZZA TRAGEDY! 😭                ");
        Console.WriteLine("==================================================");
        Console.WriteLine("The Dough Master has been outmaneuvered!           ");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("The Crust Bandit escapes with your masterpiece 🏃‍♂️");
        Console.WriteLine("Your pizzeria's reputation is in shambles 📉      ");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("        Thanks for your valiant effort! 🎖️         ");
        Console.WriteLine("   Perhaps it's time to switch to calzones... 🥟   ");
        Console.WriteLine("==================================================");


    }

    private void InvalidInput() => Console.WriteLine("Invalid Input! , please give a valid input");
    private bool AreCharactersAlive() => doughMaster.Health > 0 && crustbandit.Health > 0;

    public void spawncharacters()
    {
        player doughMaster = new player();
        Enemy crustbandit = new Enemy();

       
    }
}
