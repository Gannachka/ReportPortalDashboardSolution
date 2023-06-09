using Core.UI.WebElements.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Elements.Interfases
{
    /// <summary>
    /// The Label interface
    /// </summary>
    public interface ILabel : IBaseElement
    {
        /// <summary>
        /// Gets the hidden text.
        /// </summary>
        string HiddenText { get; }
    }
}
