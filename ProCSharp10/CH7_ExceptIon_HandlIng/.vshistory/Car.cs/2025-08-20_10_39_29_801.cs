namespace SimpleException;
class Car
{
  // Constant for maximum speed.
  public const int MaxSpeed = 100;
  // Car properties.
  public int CurrentSpeed {get; set;} = 0;
  public string PetName {get; set;} = "";
  // Is the car still operational?
  private bool _carIsDead;
  // A car has-a radio.
  private readonly Radio _theMusicBox = new Radio();
  // Constructors.
  public Car() {}
  public Car(string name, int speed)
  {
    CurrentSpeed = speed;
    PetName = name;
  }
  public void CrankTunes(bool state)
  {
    // Delegate request to inner object.
    _theMusicBox.TurnOn(state);
  }
  // See if Car has overheated.




    public void Accelerate(int delta)
{
    if (_carIsDead)
    {
        Console.WriteLine("{0} is out of order...", PetName);
    }
    else
    {
        CurrentSpeed += delta;
        if (CurrentSpeed >= MaxSpeed)
        {
            CurrentSpeed = 0;
            _carIsDead = true;
            // 用 throw 丟出例外
            throw new Exception($"{PetName} has overheated!");
        }
        Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
    }
}

}