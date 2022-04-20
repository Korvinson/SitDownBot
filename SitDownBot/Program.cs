using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;

namespace TelegramBotExperiments
{

    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5350180632:AAGKZqvVqEbZoW0ySXCWeAhp4SxnZPvyw4Y");
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, киса фантазерка!/br есть три команды 'привет', 'пока' и 'Гардемарины вперед'");
                    return;
                }
                if (message.Text.ToLower() == "привет")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Привет-привет мандаринка, я больше пока ничего не умею");
                }
                if (message.Text.ToLower() == "пока")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Пока-пока, не очкуй там сильно");
                }
                if (message.Text.ToLower() == "гардемарины вперёд")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "За моего отца");
                }
                if (message.Text.ToLower() == "гардемарины вперед")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "За моего отца!");
                }
                //await botClient.SendTextMessageAsync(message.Chat, "Привет-привет мандаринка, я больше пока ничего не умею");
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
              Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}