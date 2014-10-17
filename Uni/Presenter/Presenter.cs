//-----------------------------------------------------------------------
// <copyright file="Presenter.cs" company="CompanyName">
//     ---
// </copyright>
//-----------------------------------------------------------------------
namespace Uni.Presenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Uni.View;

    /// <summary>
    /// Abstract class for presenter
    /// </summary>
    /// <typeparam name="TView">IView Instance</typeparam>
    public abstract class Presenter<TView> where TView : IView
    {
        /// <summary>
        /// IView field
        /// </summary>
        private TView view;

        /// <summary>
        /// Base constructor for presenter
        /// </summary>
        /// <param name="view">IView instance</param>
        public Presenter(TView view)
        {
            this.view = view;
        }

        /// <summary>
        /// Gets instance of IView
        /// </summary>
        public TView View
        {
            get
            {
                return this.view;
            }
        }
    }
}