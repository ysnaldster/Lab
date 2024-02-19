using Amazon.CDK;
using Amazon.CDK.AWS.ECR;
using Amazon.CDK.AWS.Lambda;
using Constructs;
using TagsManager = Amazon.CDK.Tags;

namespace CDK.Stacks;

public class LambdaPipelinesStack : Stack
{
    private IRepository? _repository;
    private Function? _pipelinesLambda;

    public LambdaPipelinesStack(Construct scope, string id, IStackProps props) :
        base(scope, id, props)
    {
        GenerateEcrRepository();
        GenerateLambda();
    }

    private void GenerateEcrRepository()
    {
        _repository = new Repository(this, "lambda-pipelines-ecr", new RepositoryProps());
    }

    private void GenerateLambda(bool isImageCreated = false)
    {
        if (!isImageCreated) return;
        _pipelinesLambda = new Function(this, "pipelines-lambda", new FunctionProps
        {
            Code = new EcrImageCode(_repository!),
            Handler = Handler.FROM_IMAGE,
            Runtime = Runtime.FROM_IMAGE,
        });
        TagsManager.Of(_pipelinesLambda).Add("Name", "LambdaPipelines");
    }
}