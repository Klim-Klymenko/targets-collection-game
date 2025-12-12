namespace Common.Physics
{
    public interface IFunction<out TR>
    {
        TR Invoke();
    }

    public interface IFunction<in TArg, out TR>
    {
        TR Invoke(TArg args);
    }
    
    public interface IFunction<in TArg1, in TArg2, out TR>
    {
        TR Invoke(TArg1 args1, TArg2 args2);
    }
}