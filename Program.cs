using Game;

using System.Threading.Channels;

Random random = new Random();

List<string> names = new List<string> {
"Святослав","Мирослав","МясникИзУжгорода","Инвокер","Ящер","ПоганыйЯщер","ДимаСеров","Валерийдзиё"
};

Console.WriteLine("Введи кол-во игроков");
int bots = int.Parse(Console.ReadLine());

metods[] gaymer = new metods[bots];

for (int i = 0; i < gaymer.Length; i++)
{
    gaymer[i] = new metods();
}


for (int i = 0; i < gaymer.Length; i++)
{
    bool friend = false;
    int ForRandomName = random.Next(0, 8);
    int ForRandomFriend = random.Next(0, 2);
    if (ForRandomFriend == 0)
    {
        friend = false;
    }
    else { friend = true; }
    int lives = 100;


    gaymer[i].Info(names[ForRandomName], random.Next(1, 100), random.Next(1, 100), friend, lives, random.Next(10, 20));
}
Console.Clear();
for (int i = 0; i < gaymer.Length; i++)
{
    Console.Write(i + 1 + " ");
    gaymer[i].Print();
}

Console.Write("Выбери своего героя: ");
int hero = int.Parse(Console.ReadLine()) - 1;

while (true)
{
    Console.WriteLine("\n0 - Информация о всех героях.\n1 - Поменять героя.\n2 - Движение.\n3 - УНИЧТОЖЕНИЕ.\n4 - Битва.\n5 - Лечение.\n6 - Полное восстановление здоровья.\n7 - Смена лагеря.\n8 - Информация о соём герое.");
    Console.Write("Ввод: ");
    int active = int.Parse(Console.ReadLine());
    Console.WriteLine();


    int xp = gaymer[hero].getxp();
    if (xp < 1)
    {
        Console.Clear();
        for (int i = 0; i < gaymer.Length; i++)
        {
            Console.Write(i + 1 + " ");
            gaymer[i].Print();
        }
        Console.WriteLine("Ваш герой отправился на фонтан, давай меняй героя");
        Console.Write("Выбери нового героя: ");
        hero = int.Parse(Console.ReadLine()) - 1;
    }

    if (active == 8)
    {
        Console.Clear();
        gaymer[hero].Print();
        Console.WriteLine();
    }

    if (active == 0)
    {
        Console.Clear();
        for (int i = 0; i < gaymer.Length; i++)
        {
            gaymer[i].Print();
        }
    }

    if (active == 1)
    {
        for (int i = 0; i < gaymer.Length; i++)
        {
            Console.Write(i + 1 + " ");
            gaymer[i].Print();
        }
        Console.Clear();
        Console.WriteLine("Выбери своего героя: ");
        hero = int.Parse(Console.ReadLine()) - 1;
    }

    if (active == 2)
    {
        Console.Clear();
        for (int i = 0; i < gaymer.Length; i++)
        {
            Console.Write(i + 1 + " ");
            gaymer[i].Print();
        }
        Console.WriteLine("Перемещение героя.");
        Console.Write("Введи координаты x: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Введи координаты y: ");
        int y = int.Parse(Console.ReadLine());
        gaymer[hero].MoveX(x);
        gaymer[hero].MoveY(y);
    }

    if (active == 3)
    {

        Console.Clear();
        Console.WriteLine("Режим ваншот");

        for (int i = 0; i < gaymer.Length; i++)
        {
            Console.Write(i + 1 + " ");
            gaymer[i].Print();
        }

        Console.WriteLine("Введи номер игрока, которого ваншотнем: ");
        int anigilate = int.Parse(Console.ReadLine()) - 1;

        if (gaymer[hero].getl() == gaymer[anigilate].getl())
        {
            Console.WriteLine("Не стреляй по своим!\n");
        }

        else if (gaymer[hero].getx() == gaymer[anigilate].getx() && gaymer[hero].gety() == gaymer[anigilate].gety())
        {
            gaymer[anigilate].Del(anigilate);


        }
        else
        {
            Console.WriteLine("Ты не на нужных кордах.");
        }


    }
    if (active == 4)
    {
        Console.Clear();
        for (int i = 0; i < gaymer.Length; i++)
        {
            Console.Write(i + 1 + " ");
            gaymer[i].Print();
        }
        Console.WriteLine("Введи номер игрока с которым хотим пообщаться: ");
        int anigilate = int.Parse(Console.ReadLine()) - 1;

        if (gaymer[hero].getl() == gaymer[anigilate].getl())
        {
            Console.WriteLine("Не стреляй по своим.\n");
        }

        else if (gaymer[hero].getx() == gaymer[anigilate].getx() && gaymer[hero].gety() == gaymer[anigilate].gety())
        {
            int du = gaymer[hero].getdu();
            gaymer[anigilate].Uron(du);

            du = gaymer[anigilate].getdu();
            gaymer[hero].Uron(du);

            gaymer[hero].Print();
            gaymer[anigilate].Print();

        }
        else if (gaymer[hero].getx() != gaymer[anigilate].getx() && gaymer[hero].gety() == gaymer[anigilate].gety())
        {
            Console.WriteLine("Ты не на нужных кордах.");
        }

    }

    if (active == 5)
    {
        Console.Write("Лечение.");
        int du = random.Next(5, 20);
        gaymer[hero].Doc(du);
    }

    if (active == 6)
    {
        Console.WriteLine("Полное восстановление здоровья.");
        gaymer[hero].Vost();
    }

    if (active == 7)
    {
        Console.WriteLine("Смена лагеря.");
        gaymer[hero].Lager();
    }

}
