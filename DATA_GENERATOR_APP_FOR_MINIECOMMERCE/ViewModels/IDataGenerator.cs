namespace DATA_GENERATOR_APP_FOR_MINIECOMMERCE.ViewModels
{
    public interface IDataGenerator<T> where T : class
    {
        List<T> Collection();
        List<T> Collection(int length);
        T Instance();
    }
}
