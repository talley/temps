
static class Program
{
    static  async Task<int> Main(string[] args)
    {
        var arguments = args;
        while (true)
        {
            WriteLine("Add a new pair of source and destination folders;");
            WriteLine("Exit.");
            var choice=ReadLine();
            switch (choice)
            {
                case "Exit":
                    WriteLine("Add a new pair of source and destination folders;");
                    WriteLine("Exit.");
                    Console.ReadLine();
                    break;

                default:
                    await Task.Run(async () =>
                    {

                        var serviceProvider = ServiceProviderDI.GetProvider();
                        var transferService = serviceProvider.GetService<ITransfer>();


                        if (arguments.len() < 5)
                        {
                            WriteLine(@"Please input source and destination folder");
                        }
                        else
                        {
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

                            rootCommand.SetHandler(async (string source, string destination) =>
                            {
                                WriteLine($"The value for -s is: {source}");
                                WriteLine($"The value for -d is: {destination}");


                                var folderPaths = new List<string> { source, destination };
                                // await transferService.TransferFilesAsync(folderPaths).ConfigureAwait(false);

                            }, sourceOption, destinationOption);

                            await rootCommand.InvokeAsync(args).ConfigureAwait(false);
                        }
                    }).ConfigureAwait(false);
                    WriteLine("Add a new pair of source and destination folders;");
                    WriteLine("Exit.");
                    break;
            }

        }
    }

}
