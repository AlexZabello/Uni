using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uni.View;

namespace Uni.Presenter
{
    public abstract class Presenter<T> where T: IView
    {
        protected T view;

        public T View
        {
            get
            {
                return view;
            }
        }

        public Presenter(T view)
        {
            this.view = view;
        }
    }
}