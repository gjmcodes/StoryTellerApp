namespace StoryTeller.Domain.Xamarin.Core.Entities
{
    public abstract class BaseEntity<T> where T : new()
    {
        public string Id { get; private set; }
        public T entity { get; private set; }
    }
}
