namespace GeometrySteps.Logic.Interfaces
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
