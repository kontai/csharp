MediaPlayer player = new MediaPlayer();
//player.GetAllSong();

internal class MediaPlayer
{
    //private MediaPlayer mPlayer=new MediaPlayer();
    //private Lazy<AllSongs> allSong = new Lazy<AllSongs>();
    private AllSongs allSong = new AllSongs();

    public AllSongs GetAllSong()
    {
        return allSong;
        //return allSong.Value;

    }
}

//Huge Size
internal class AllSongs
{
    private string[] songs = new string[1000000];

    public AllSongs()
    {
        //create songs in loop
        for (int i = 0; i < songs.Length; i++)
        {

            Thread.Sleep(1000);
            songs[i] = "Song " + i;
        }
    }
}