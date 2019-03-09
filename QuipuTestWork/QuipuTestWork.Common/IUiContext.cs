using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuipuTestWork.Common
{
    public interface IUiContext
    {
        /// <summary>
        /// Проверка контекста.
        /// </summary>
        bool IsSynchronized { get; }

        /// <summary>
        /// Синхронное выполнение действия.
        /// </summary>
        /// <param name="action">Действие.</param>
        void Invoke(Action action);

        /// <summary>
        /// Асинхронное выполнение действия.
        /// </summary>
        /// <param name="action">Действие.</param>
        void BeginInvoke(Action action);
    }
}
