using DSharpPlus;
using DSharpPlus.EventArgs;

namespace CoffeeFriend
{
    internal class Program
    {
        static CoffeeQueue coffee = new CoffeeQueue();
        static List<Person> listOfPerson = new List<Person>();
        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            //============================================================
            var discordClient = new DiscordClient(new DiscordConfiguration
            {
                Token = "",
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All
            });

            discordClient.MessageCreated += OnMessageCreated;
            await discordClient.ConnectAsync();
            await Task.Delay(-1) ;


            Console.ReadKey();
        }


        private static async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs msg)
        {
            if(string .Equals(msg.Message.Content, "!add", StringComparison.OrdinalIgnoreCase))
            {
                string name = msg.Author.Username;
                Person person = new Person(name);
                coffee.Enqueue(person);
                await msg.Message.RespondAsync($"{name} has been added to the queue");
            }

            if(string.Equals(msg.Message.Content, "!check", StringComparison.OrdinalIgnoreCase))
            {
                await msg.Message.RespondAsync(coffee.ToString());
            }

            if(string.Equals(msg.Message.Content, "!rotate", StringComparison.OrdinalIgnoreCase))
            {
                coffee.Rotate();
                await msg.Message.RespondAsync(coffee.ToString());
            }










            //if(string.Equals(msg.Message.Content, "!add", StringComparison.OrdinalIgnoreCase))
            //{
            //    Person person = new Person(msg.Author.Username);
            //    listOfPerson.Add(person);   
            //    await msg.Message.RespondAsync(person.Name);
            //}

            //if(string.Equals(msg.Message.Content, "!check", StringComparison.OrdinalIgnoreCase))
            //{
            //    foreach(Person person in listOfPerson)
            //    {
            //        await msg.Message.RespondAsync(person.Name);
            //    }
            //}





















            if (string.Equals(msg.Message.Content, "Amir", StringComparison.OrdinalIgnoreCase))
            {
                await msg.Message.RespondAsync("Amir spelar PUBG");
            }
        }
    }
}