AddWrapperWithSideEffect(1,5);
static int AddWrapperWithSideEffect(int x, int y)
{
  //Do some validation here
  return Add();
  int Add()
  {
    x += 1;
    return x + y;
  }
}

static int AddWrapperWithStatic(int x, int y)
{
  //Do some validation here
  return Add(x,y);
  static int Add(int x, int y)
  {
    return x + y;
  }
}