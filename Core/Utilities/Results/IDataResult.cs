namespace Core.Utilities.Results;
public interface IDataResult<Type>:IResult
{
    Type Data {get;}
}