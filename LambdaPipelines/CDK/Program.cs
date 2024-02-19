using System.Diagnostics.CodeAnalysis;
using Amazon.CDK;
using CDK.Stacks;

namespace CDK;

[ExcludeFromCodeCoverage]
public static class Program
{
    public static void Main()
    {
        IEnvironment environment = new Amazon.CDK.Environment
        {
            Account = "",
            Region = "us-east-1"
        };
        var app = new App();
        _ = new LambdaPipelinesStack(app, "LambdaPipelinesStack", new StackProps { Env = environment });

        app.Synth();
    }
}