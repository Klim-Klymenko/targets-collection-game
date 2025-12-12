namespace Common.Creation
{
    public interface IFactory<out T> where T : class
    {
        T Create();
    }
    
    public interface IFactory<out TR, in TArg> where TR : class
    {
        TR Create(TArg arg);
    }
    
    public interface IFactory<out TR, in TArg1, in TArg2> where TR : class
    {
        TR Create(TArg1 arg1, TArg2 arg2);
    }
    
    public interface IFactory<out TR, in TArg1, in TArg2, in TArg3> where TR : class
    {
        TR Create(TArg1 arg1, TArg2 arg2, TArg3 arg3);
    }
}