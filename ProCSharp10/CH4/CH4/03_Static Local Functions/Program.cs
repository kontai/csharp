using System;

AddWrapperWithSideEffect(5,10);
static int AddWrapperWithSideEffect(int x, int y)
{

  Console.WriteLine($"x={x}, y={y}");
  //Do some validation here
  //return Add();
  Add();
  Console.WriteLine($"x={x}, y={y}");
  int Add() //增加static,防止本地變量被修改
  {
    x += 1;
    return x + y;
  }

  return 0;
}