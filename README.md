# Text To Speech

A .NET Project to convert text to speech using Microsoft Azure API.
Um projeto .NET para converter texto em áudio utilizando a API da Microsoft Azure.


## Running the project / Executando o projeto

```bash
cd TextToSpeech
dotnet run
```

## Setting up the project / Configurando o projeto

To use the project, you need to create an account on Microsoft Azure and create an access key for the voice API.
Para utilizar o projeto, é necessário criar uma conta na Microsoft Azure e criar uma chave de acesso para a API de voz.

After creating the access key, you need to configure the file called `appsettings.json` at the root of the project:
Após criar a chave de acesso, é necessário configurar o arquivo chamado `appsettings.json` na raiz do projeto:

```json
{
    "key": "<YOUR_KEY>",
    "region": "<YOUR_REGION>",
    "voice": "<YOUR_VOICE_NAME>",
    "save": true,
    "speak": true,
    "text": "<YOUR_TEXT_TO_SPEECH>"
}
```