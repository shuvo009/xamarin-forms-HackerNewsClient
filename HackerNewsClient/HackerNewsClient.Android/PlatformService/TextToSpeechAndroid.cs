using System.Diagnostics;
using HackerNewsClient.Core.Interface;
using HackerNewsClient.Droid.PlatformService;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechAndroid))]
namespace HackerNewsClient.Droid.PlatformService
{
    public class TextToSpeechAndroid : ITextToSpeech
    {
        public void Speak()
        {
            Debug.WriteLine("Speak");
        }
    }
}