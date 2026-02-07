using System.Text;
using static Game;
using System;
using System.Text.Json;

[Serializable]
public class GameState
{
    public int Coin { get; set; }
    public int Heart { get; set; }
    public int Energy { get; set; }
}
/// <summary>
/// Клас Player начальний клас в якому записано імя гравця та видає інформацію по грі
/// </summary>
class Player
{
    string name;
    private DrawLabirint lab;
    private Statistic statistic;
    public Player(DrawLabirint lab, Statistic statistic)
    {
        this.lab = lab;
        this.statistic = statistic;
    }
    /// <summary>
    /// Метод SetName він потрібен для дізнаваня імя гравця
    /// </summary>
    public void SetName()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        Console.WriteLine("Як тебе звати?");
        name = Console.ReadLine();
        Console.WriteLine("Натисни будь-яку клавішу, щоб продовжити");
        Console.ReadKey();
        Console.Clear();
    }
    /// <summary>
    /// Метод GetName повертає імя гравця
    /// </summary>
    public string GetName()
    {
        return name;
    }
    /// <summary>
    /// Метод Print привітає гравця та або перекидає на гру або дає інформацію по грі а вже поті перекидає на гру
    /// </summary>
    public void Print()
    {

        Console.WriteLine($"Привіт {name}");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Введіть 1 якщо хочеш почати гру та 2 якщо хочет подивитися інформацію по грі");
        string input = Console.ReadLine();
        int num = 0;
        int.TryParse(input, out num);
        Console.Clear();
        if (num == 1)
        {
        }
        else if (num == 2)
        {


            MoneyEnemy moneyEnemy = new MoneyEnemy();
            moneyEnemy.SetMoneyEnemy();
            moneyEnemy.GetMoneyEnemy();

            StandartEnemy standartEnemy = new StandartEnemy();
            standartEnemy.SetEnemy();
            standartEnemy.GetEnemy();


            EnergyEnemy energyEnemy = new EnergyEnemy();
            energyEnemy.SetEnergyEnemy();
            energyEnemy.GetEnergyEnemy();

            Wall wall = new Wall();
            wall.SetWall();
            wall.GetWall();

            Coin coin = new Coin();
            coin.SetCoin();
            coin.GetCoin();

            Heart heart = new Heart();
            heart.SetHeart();
            heart.GetHeart();

            Console.ReadKey();
            Console.Clear();


        }
        else
        {
            Console.WriteLine("Ви ввели невірне число. Будь ласка, введіть 1 або 2.");
            Environment.Exit(0);
            Console.ReadKey();
        }
    }
}
/// <summary>
/// Клас Game в якому записані кнопки
/// </summary>
class Game
{
    public enum Key
    {

        Left = 'a',
        Right = 'd',
        Up = 'w',
        Down = 's',
        E = 'e',
        H = 'h',

    }
}

/// <summary>
/// Клас Enemy головний клас в якому записані злодії на карті
/// </summary>
class Enemy
{
    protected string name;
    protected string skill;


}

class StandartEnemy : Enemy
{
    public void SetEnemy()

    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("О");
        Console.ResetColor();
        name = "Ворог";
        skill = "Стандартний ворог який забирає 1 серце.";
    }

    public void GetEnemy()
    {
        Console.WriteLine(name);
        Console.WriteLine(skill);
    }
}

/// <summary>
/// Клас MoneyEnemy забирає з вашего кормана 10 монет якщо у вас буде меньш 10 то может попасти в борги
/// </summary>
class MoneyEnemy : Enemy
{
    public void SetMoneyEnemy()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("О");
        Console.ResetColor();
        name = "Монетний ворог";
        skill = "Забирає 10 монет. Якщо буде менше – борги.";
    }

    public void GetMoneyEnemy()
    {
        Console.WriteLine(name);
        Console.WriteLine(skill);

    }
}

/// <summary>
/// Клас EnergyEnemy забирає з вашего кормана 19 єнергії якщо у вас буде меньш 19 то ви програйте
/// </summary>
class EnergyEnemy : Enemy
{
    public void SetEnergyEnemy()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("О");
        Console.ResetColor();
        name = "Енергітичний ворог ";
        skill = "Забирає з вашего кормана 19 єнергії якщо у вас буде меньш 19 то ви програйте.";

    }
    public void GetEnergyEnemy()
    {
        Console.WriteLine(name);
        Console.WriteLine(skill);
    }
}
/// <summary>
/// Клас Object головний клас в якому записані обєкти на карті
/// </summary>
class Object
{
    public string name;
    public string information;
}
/// <summary>
/// Клас Wall просто стіна не дає проходу
/// </summary>
class Wall : Object
{
    public void SetWall()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("█");
        Console.ResetColor();
        name = "Стіна ";
        information = "Просто стіна не дає проходу.";

    }
    public void GetWall()
    {
        Console.WriteLine(name);
        Console.WriteLine(information);
    }
}
/// <summary>
/// Клас SetEnergy дає 51 енергію
/// </summary>
class Energy : Object
{
    public void SetEnergy()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("A");
        Console.ResetColor();
        name = "Енергія ";
        information = "Дає 51 енергію.";

    }
    public void GetEnergy()
    {
        Console.WriteLine(name);
        Console.WriteLine(information);
    }
}
/// <summary>
/// Клас Coin дає + 1 монету.
/// </summary>
class Coin : Object
{
    public void SetCoin()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("О");
        Console.ResetColor();
        name = "Монета ";
        information = "Дає + 1 монету.";
    }
    public void GetCoin()
    {
        Console.WriteLine(name);
        Console.WriteLine(information);
    }
}
/// <summary>
/// Клас Heart дає + 1 серце
/// </summary>
class Heart : Object
{
    public void SetHeart()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("♥");
        Console.ResetColor();
        name = "Серце  ";
        information = "Дає + 1 серце.";
    }
    public void GetHeart()
    {
        Console.WriteLine(name);
        Console.WriteLine(information);
    }
}
/// <summary>
/// Клас Statistic в якому записана статистика яка видаєтся після поразки чи вийграша  
/// </summary>
public class Statistic
{
    private DrawLabirint lab;

    public Statistic(DrawLabirint labRef)
    {
        this.lab = labRef;
    }
    public void Statistics()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Кількість монет:" + lab.coin);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Кількість жизнів:" + lab.heart);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Кількість єнергіі:" + lab.energy);
        Console.ResetColor();

    }
}
/// <summary>
/// Клас DrawLabirint який малює випадковий лабірінт
/// </summary>
public class DrawLabirint
{


    public const int HEIGHT = 25;
    public const int WIDTH = 65;
    public int coin = 0;
    public int heart = 3;
    public int energy = 50;
    public int[,] map = new int[HEIGHT, WIDTH];
    /// <summary>
    /// Концтруктор DrawLabirint малює лабірінт
    /// </summary>
    public DrawLabirint()
    {

        Random rand = new Random(); // створюємо генератор випадкових чисел

        for (int y = 0; y < HEIGHT; y++)
        {
            for (int x = 0; x < WIDTH; x++)
            {

                // По краях — завжди стіна
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                {
                    map[y, x] = 1;
                }
                else
                {
                    int roll = rand.Next(0, 100); // 0..99 (усього 100 варіантів)

                    if (roll < 30) map[y, x] = 1; // 30% 
                    else if (roll < 40) map[y, x] = 0; // 10% 
                    else if (roll < 45) map[y, x] = 3; // 5% — Серце 
                    else if (roll < 50) map[y, x] = 4; // 5%  — Енергія 
                    else if (roll < 65) map[y, x] = 5; // 15% — Стандартний ворог 
                    else if (roll < 70) map[y, x] = 6; // 5%  — Енергетичний ворог 
                    else if (roll < 73) map[y, x] = 7; // 3%  — Монетний ворог 
                    else /* roll < 100 */       map[y, x] = 2; // 23% — Монета 



                }
            }
            map[22, 64] = 0;
            map[22, 63] = 0;
            map[22, 62] = 0;
            map[22, 61] = 0;
            map[22, 60] = 0;
            map[2, 2] = 0;
            map[2, 3] = 0;
            map[2, 4] = 0;
            map[2, 5] = 0;
            map[2, 6] = 0;
            map[2, 7] = 0;
            map[2, 8] = 0;
            map[2, 7] = 0;
        }
    }
    /// <summary>
    /// Метод Draw визанчає як вигладає елемент в лабірінті та його колір
    /// </summary>
    public void Draw()
    {
        for (int y = 0; y < HEIGHT; y++)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                if (map[y, x] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("█");
                    Console.ResetColor();
                }
                else if (map[y, x] == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("o");
                    Console.ResetColor();
                }
                else if (map[y, x] == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("♥");
                    Console.ResetColor();
                }
                else if (map[y, x] == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("A");
                    Console.ResetColor();
                }
                else if (map[y, x] == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("O");
                    Console.ResetColor();
                }
                else if (map[y, x] == 6)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("O");
                    Console.ResetColor();
                }
                else if (map[y, x] == 7)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("O");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
    /// <summary>
    /// Метод PlayerItems показує предмети гравця 
    /// </summary>
    public void PlayerItems()
    {


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(67, 0);
        Console.WriteLine("Coin:" + coin);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(67, 1);
        Console.WriteLine("Heart:" + heart);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(67, 2);
        Console.WriteLine("Energy:" + energy);

    }
}
/// <summary>
/// Клас Go відповідає за хотьбу
/// </summary>
class Go
{
    public int X;
    public int Y;
    private int prevX;
    private int prevY;
    private int[,] map;
    public DrawLabirint lab;
    private Statistic statistic;
    public Go(int startX, int startY, int[,] mapRef, DrawLabirint labRef, Statistic stat)
    {
        X = prevX = startX;
        Y = prevY = startY;
        map = mapRef;
        lab = labRef;
        statistic = stat;
    }
    /// <summary>
    /// Метод Move відповідає за кнопки 
    /// </summary>
    public void Move(Key key)
    {
        prevX = X;
        prevY = Y;

        int newX = X;
        int newY = Y;


        switch (key)
        {

            case Key.Left:
                newX--; lab.energy--;
                Console.SetCursorPosition(67, 2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Energy:{lab.energy}   ");
                Console.ResetColor();
                break;
            case Key.Right:
                newX++; lab.energy--;
                Console.SetCursorPosition(67, 2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Energy:{lab.energy}   ");
                Console.ResetColor();
                break;
            case Key.Up:
                newY--; lab.energy--;
                Console.SetCursorPosition(67, 2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Energy:{lab.energy}   ");
                Console.ResetColor();
                break;
            case Key.Down:
                newY++; lab.energy--;
                Console.SetCursorPosition(67, 2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Energy:{lab.energy}   ");
                Console.ResetColor();
                break;
            case Key.E:
                if (lab.coin > 5)
                {
                    lab.energy += 30;
                    lab.coin -= 5;

                    Console.SetCursorPosition(67, 2);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"Energy:{lab.energy}   ");
                    Console.ResetColor();
                    Console.SetCursorPosition(67, 0);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Coin:{lab.coin}   ");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(67, 3);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("У вас не достатньо грошей");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(67, 3);
                    Console.WriteLine("                                ");

                }
                break;

            case Key.H:
                if (lab.coin > 5)
                {
                    lab.heart += 1;
                    lab.coin -= 5;

                    Console.SetCursorPosition(67, 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Heart:{lab.heart}   ");
                    Console.ResetColor();
                    Console.SetCursorPosition(67, 0);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Coin:{lab.coin}   ");
                    Console.ResetColor();
                }

                else
                {
                    Console.SetCursorPosition(67, 3);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("У вас не достатньо грошей");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(67, 3);
                    Console.WriteLine("                                ");

                }

                break;

        }

        if (map[newY, newX] != 1)
        {
            X = newX;
            Y = newY;
        }

        if (lab.energy < 0)
        {
            Console.Clear();
            Console.WriteLine("Ти програв в тебе не має енергіі");
            statistic.Statistics();

        }

        if (newX == 64 && newY == 22)
        {
            Console.Clear();
            Console.WriteLine("Ти виграв");
            statistic.Statistics();
            return;

        }

    }

    /// <summary>
    /// Метод Draw малює гравця та відповідає за те щоб гравець пропадав 
    /// </summary>
    public void Draw()
    {
        if (prevX != X || prevY != Y)
        {
            Console.SetCursorPosition(prevX, prevY);
            Console.Write(' ');
        }
        Console.SetCursorPosition(X, Y);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write('O');
        Console.ResetColor();
    }
}
/// <summary>
/// Клас GameController керує гравцем: його появою, підбором об'єктів та обробкою введення з клавіатури.
/// </summary>
class GameController
{
    public DrawLabirint lab;
    public Statistic statistic;
    public Go player;

    public GameController(DrawLabirint labRef, Statistic statRef)
    {
        lab = labRef;
        statistic = statRef;
    }
    /// <summary>
    /// Метод Gamerule запускає основний цикл гри: створює гравця, обробляє підбір об'єктів і перевіряє умови програшу.
    /// </summary>
    public void Gamerule()
    {
        if (player == null)
        {
            player = new Go(2, 2, lab.map, lab, statistic);
        }
        while (true)
        {
            player.Draw();

            if (lab.map[player.Y, player.X] == 2)
            {
                lab.coin++;
                lab.map[player.Y, player.X] = 0;


                Console.SetCursorPosition(67, 0);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Coin:{lab.coin}   ");
                Console.ResetColor();
            }
            if (lab.map[player.Y, player.X] == 3)
            {
                lab.heart++;
                lab.map[player.Y, player.X] = 0;


                Console.SetCursorPosition(67, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Heart:{lab.heart}   ");
                Console.ResetColor();
            }

            if (lab.map[player.Y, player.X] == 4)
            {
                for (int i = 0; i < 51; i++)
                {
                    lab.energy++;
                }
                lab.map[player.Y, player.X] = 0;


                Console.SetCursorPosition(67, 2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Energy:{lab.energy}   ");
                Console.ResetColor();
            }
            if (lab.map[player.Y, player.X] == 5)
            {
                lab.heart--;

                lab.map[player.Y, player.X] = 0;


                Console.SetCursorPosition(67, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Heart:{lab.heart}   ");
                Console.ResetColor();
            }
            if (lab.map[player.Y, player.X] == 6)
            {
                for (int i = 0; i < 29; i++)
                {
                    lab.energy--;
                }

                lab.map[player.Y, player.X] = 0;


                Console.SetCursorPosition(67, 2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Energy:{lab.energy}   ");
                Console.ResetColor();
            }
            if (lab.map[player.Y, player.X] == 7)
            {
                for (int i = 0; i < 10; i++)
                {
                    lab.coin--;
                }


                lab.map[player.Y, player.X] = 0;


                Console.SetCursorPosition(67, 0);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Coin:{lab.coin}   ");
                Console.ResetColor();
            }
            if (lab.heart < 0)
            {
                Console.Clear();
                Console.WriteLine("Ти програв");
                statistic.Statistics();
                return;

            }

            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);
                char c = char.ToLower(keyInfo.KeyChar);


                if (Enum.IsDefined(typeof(Key), (int)c))
                    player.Move((Key)c);

            }
        }
    }
}
/// <summary>
/// Клас Program відповідає за запуск програми
/// </summary>
class Program
{
    public static void Main()
    {

        Console.Title = "My Labyrinth Game";
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.CursorVisible = false;
        DrawLabirint lab = new DrawLabirint();
        Statistic statistic = new Statistic(lab);
        Player players = new Player(lab, statistic);
        players.SetName();
        players.Print();

        lab.Draw();
        lab.PlayerItems();

        GameController gameController = new GameController(lab, statistic);
        gameController.Gamerule();
        Console.WriteLine("Натисніть будь-яку клавішу, щоб вийти...");
        Console.ReadKey();

        lab.Draw();
        lab.PlayerItems();

        Go player = new Go(2, 2, lab.map, lab, statistic);

    }

}
