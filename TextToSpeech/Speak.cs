using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace TextToSpeech
{
    public class Speak
    {
        public static async Task SpeakNow(SpeechConfig config, string text)
        {
            using (var synthesizer = new SpeechSynthesizer(config))
            {
                var result = await synthesizer.SpeakTextAsync(text);
                // save to wav file
                if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                {
                    Console.WriteLine("Audio synthesized.");
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");
                }
            }
        }

        public static async void SpeakSave(SpeechConfig config, string text, string filename)
        {
            using (var fileOutput = AudioConfig.FromWavFileOutput(filename))
            using (var synthesizer = new SpeechSynthesizer(config, fileOutput))
            {
                if (string.IsNullOrEmpty(text))
                    return;

                using (var result = await synthesizer.SpeakTextAsync(text))
                {
                    if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        Console.WriteLine($"Speech synthesized for text [{text}], and the audio was saved to [{filename}]");
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                        Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");                       
                    }
                }
            }

        }       
    }
}