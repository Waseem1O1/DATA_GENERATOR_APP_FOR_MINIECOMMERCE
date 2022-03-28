namespace DATA_GENERATOR_APP_FOR_MINIECOMMERCE.ViewModels
{
    public class DataGeneratorService<T> : IDataGenerator<T>
        where T : class, new()
    {
        public List<T> Collection() => GenFu.GenFu.ListOf<T>();
        public List<T> Collection(int length) => GenFu.GenFu.ListOf<T>(length);
        public T Instance() => GenFu.GenFu.New<T>();
    }
}
