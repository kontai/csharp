using LazyObjectInstantiation;
Console.WriteLine("***** Fun with Lazy Instantiation *****\n");
// No allocation of AllTracks object here!
MediaPlayer myPlayer = new MediaPlayer();
myPlayer.Play();
// Allocation of AllTracks happens when you call GetAllTracks().
MediaPlayer yourPlayer = new MediaPlayer();
Lazy<AllTracks> yourMusic = yourPlayer.GetAllTracks();