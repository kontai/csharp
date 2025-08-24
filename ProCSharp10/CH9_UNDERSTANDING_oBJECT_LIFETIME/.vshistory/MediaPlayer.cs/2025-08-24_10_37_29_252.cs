namespace LazyObjectInstantiation;

// The MediaPlayer has-an AllTracks object.
class MediaPlayer
{
    // Assume these methods do something useful.
    public void Play()
    {
        Console.WriteLine("Play a song");
    }


    public void Pause()
    {
        /* Pause the song */
    }

    public void Stop()
    {
        /* Stop playback */
    }

    /// <summary>
    ///  Lazy-延遲初始化
    /// </summary>
    private Lazy<AllTracks> _allSongs = new Lazy<AllTracks>();

    public AllTracks GetAllTracks()
    {
        // Return all of the songs.
        return _allSongs.Value;
    }
}