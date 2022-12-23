using Microsoft.CognitiveServices.Speech;
using Microsoft.Extensions.Configuration;
using TextToSpeech;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var appSettings = new AppSettings().SetAppSettings(config) ?? throw new System.ArgumentNullException(nameof(config));

var speechConfig = SpeechConfig.FromSubscription(appSettings.Key, appSettings.Region);
speechConfig.SpeechSynthesisVoiceName = appSettings.Voice;
speechConfig.OutputFormat = OutputFormat.Simple;

if (string.IsNullOrEmpty(appSettings.Text))
    return;

if (appSettings.Save)
    Speak.SpeakSave(speechConfig, appSettings.Text, "output.wav");

if (appSettings.Speak)
    await Speak.SpeakNow(speechConfig, appSettings.Text);
