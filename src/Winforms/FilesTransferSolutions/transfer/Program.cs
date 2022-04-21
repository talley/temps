
using Microsoft.Extensions.Logging;

static class Program
{
    private static ITransfer _transfer;
    static Program()
    {

    }
    static  async Task<int> Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
           .AddLogging()
           .AddSingleton<ITransfer, TransferRepository>()
           .BuildServiceProvider();
        var transferService = serviceProvider.GetService<ITransfer>();


        WriteLine("Add a new pair of source and destination folders;");
        WriteLine("Exit.");
        var result = 0;
        var arguments = args;
        WriteLine($"arguments:{JsonConvert.SerializeObject(arguments)}");
        WriteLine($"arguments length:{arguments.len()}");
        if (arguments.len()<5)
        {
            WriteLine(@"Please input source and destination folder");
        }
        else
        {
            var mapper = MapHelper.GetMapper();
            var sourceOption = new Option<string>(
             "-s",
             getDefaultValue: () => "",
             description: "please enter source path"
            );
            var destinationOption = new Option<string>(
                "-d",
                getDefaultValue: () => "",
                description: "please enter source path"
               );

            var rootCommand = new RootCommand { sourceOption, destinationOption };

            rootCommand.Aliases.Append("transfer");

            rootCommand.SetHandler((string source, string destination) =>
            {
                Console.WriteLine($"The value for -s is: {source}");
                Console.WriteLine($"The value for -d is: {destination}");
            }, sourceOption, destinationOption);

            result = await rootCommand.InvokeAsync(args).ConfigureAwait(false);
        }

        return result;
    }


}
