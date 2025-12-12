namespace Common.Physics
{
    public interface IAction
    {
        void Invoke();
    }

    public interface IAction<in TArg>
    {
        void Invoke(TArg arg);
    }

    public interface IAction<in TArg1, in TArg2>
    {
        void Invoke(TArg1 args1, TArg2 args2);
    }
    
    public interface IAction<in TArg1, in TArg2, in TArg3>
    {
        void Invoke(TArg1 args1, TArg2 args2, TArg3 args3);
    }
}