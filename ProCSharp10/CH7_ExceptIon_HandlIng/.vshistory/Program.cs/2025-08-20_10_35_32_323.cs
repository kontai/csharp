using SimpleException;

Car myCar = new Car("Zippy", 20); // 建立一台車，初速 20
myCar.CrankTunes(true);           // 開收音機
for (int i = 0; i < 10; i++)     // 每次加速 10
{
  myCar.Accelerate(10);
}
