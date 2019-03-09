using System;

namespace CompositionRoot
{
    /// <summary>
    /// Composition root.
    /// </summary>
    public interface ICompositionRoot
    {
        /// <summary>
        /// Зарегистрировать зависимости.
        /// </summary>
        void RegisterDependencies();
    }
}
