namespace ch.wuerth.tobias.mux.Core.events
{
    public interface ICallback<in T>
    {
        void Push(T arg);
    }
}