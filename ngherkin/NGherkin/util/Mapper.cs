namespace gherkin.util
{
    public interface Mapper<T, R>
    {
        R map(T o);
    }
}