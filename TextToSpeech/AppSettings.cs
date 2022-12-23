using Microsoft.Extensions.Configuration;

namespace TextToSpeech
{
    public class AppSettings
    {
        public string? Key { get; set; }
        public string? Region { get; set; }
        public string? Voice { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool Speak { get; set; }
        public bool Save { get; set; }

        public AppSettings SetAppSettings(IConfiguration config)
        {
            this.Key = config["key"] ?? throw new System.ArgumentNullException(nameof(config));
            this.Region = config["region"] ?? throw new System.ArgumentNullException(nameof(config));
            this.Voice = config["voice"] ?? throw new System.ArgumentNullException(nameof(config));
            this.Text = config["text"] ?? throw new System.ArgumentNullException(nameof(config));
            this.Speak = Convert.ToBoolean(config["speak"]);
            this.Save = Convert.ToBoolean(config["save"]);

            return this;
        }
    }
}