using Core.UI.WebElementWrapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Elements.Interfases
{
    public interface IButton : IBaseElement
    {
        /// <summary>
        /// The Click
        /// </summary>
        void Click();

        /// <summary>
        /// The Click
        /// </summary>
        /// <typeparam name="TWebObject">
        /// The desired type of page object to be created
        /// </typeparam>
        /// <returns>
        /// The <see cref="ICreatablePageObject"/>
        /// </returns>
        TWebObject Click<TWebObject>()
            where TWebObject : ICreatablePageObject;
    }
}
