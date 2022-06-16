using CommandLine;
using MediatR;

namespace GenericCli;

public class SomeApplication
{
    private readonly IMediator _mediator;

    public SomeApplication(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Run(string[] args)
    {
        var options = typeof(SomeApplication).Assembly
            .GetTypes()
            .Where(p =>
                p.IsAssignableTo(typeof(BaseOptions)) &&
                p.IsClass &&
                !p.IsAbstract)
            .ToArray();

        await Parser
            .Default
            .ParseArguments(args, options)
            .WithParsedAsync(async p =>
                await _mediator.Publish(p)
            );
    }
}