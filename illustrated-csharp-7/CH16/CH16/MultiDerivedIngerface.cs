namespace CH16;
/*
 * 不同類實現一個接口的示例
 * 
 * 
 */
public class Animal
{
}

interface ILiveBirth
{
    string BabyCalled();
}

class Cat : Animal, ILiveBirth //聲明Cat類
{
    public string BabyCalled() => "kitten";
}

class Dog : Animal, ILiveBirth //聲明Dog類
{
    public string BabyCalled() => "puppy";
}

class Bird : Animal //聲明Bird類
{
}

public class MultiDerivedIngerface
{
    static void Main(string[] args)
    {
        Animal[] animals = new Animal[3]; //創建ANIMAL數組 animals[0] = new Cat();
        animals[0] = new Cat(); //捶人Cat類對象
        animals[1] = new Dog(); //捶人Cat類對象
        animals[2] = new Bird(); //捶人Dog類對象

        foreach (Animal animal in animals) //在數組中循環
        {
            ILiveBirth ib = animal as ILiveBirth; //如果實現IliveBirth......
            if (null != ib)
            {
                Console.WriteLine($"Baby is called {ib.BabyCalled()}");
            }
        }
    }
}