namespace CVBuilder.Model
{
    public class IdGenerator
    {
            int next = 1;

            public int Next => System.Threading.Interlocked.Increment(ref next);

            public void Reset(int value) { System.Threading.Interlocked.Exchange(ref next, value); }
    }
}