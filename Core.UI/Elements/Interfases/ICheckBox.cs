﻿using Core.UI.WebElements.Interfaces;

namespace Core.UI.Elements.Interfases
{
    /// <summary>
    /// The checkBox interface.
    /// </summary>
    public interface ICheckBox : IBaseElement
    {
        /// <summary>
        /// Gets a value indicating whether selected.
        /// </summary>
        bool Selected { get; }

        /// <summary>
        /// The set.
        /// </summary>
        /// <param name= "value">
        /// The value.
        /// </param>
        /// <param name="value"></param>
        void Set(bool value);

        /// <summary>
        /// The Click
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <typeparam name="TWebObject">
        /// The desired type of page object to be created
        /// </typeparam>
        /// <returns>
        /// The <see cref="ICreatablePageObject"/>
        /// </returns>
        TWebObject Set<TWebObject>(bool value)
            where TWebObject : ICreatablePageObject;

    }
}
