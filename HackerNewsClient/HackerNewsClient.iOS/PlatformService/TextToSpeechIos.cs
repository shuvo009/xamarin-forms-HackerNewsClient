using System.Diagnostics;
using HackerNewsClient.Core.Interface;
using HackerNewsClient.iOS.PlatformService;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechIos))]
namespace HackerNewsClient.iOS.PlatformService
{
    public class TextToSpeechIos: ITextToSpeech
    {
        public void Speak()
        {
            Debug.WriteLine("Speak");
        }
    }
}