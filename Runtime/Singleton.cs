using JetBrains.Annotations;

namespace Singletons
{
    /// <summary>
    /// Base class for singletons
    /// </summary>
    /// <typeparam name="T">Type inheriting from <see cref="Singleton{T}"/></typeparam>
    [PublicAPI]
    public class Singleton<T> where T: new()
    {
        /// <summary>
        /// Lazily instantiated single instance of type <typeparamref name="T"/>
        /// </summary>
        [NotNull] public static T Instance => instance ??= new T();
        
        private static T instance;
    }
}