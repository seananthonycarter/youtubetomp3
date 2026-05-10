using System.IO;
using VideoLibrary;

namespace YouTubeToMP3
{
    class Program
    {
        static void Main(string[] args)
        {
            var youtube = YouTube.Default;
            var vid = youtube.GetVideo(args[0]);
            var mp4path = $"{args[1]}\\{vid.FullName}";
            var mp3path = mp4path.Replace("mp4", "mp3");
            File.WriteAllBytes(mp4path, vid.GetBytes());
            FfmpegWrapper.Convert(mp4path, mp3path);
        }
    }
}
