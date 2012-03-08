using System;

namespace KerbalAPI
{
    public abstract partial class Part<T> where T : Part<T>, new()
    {

        #region Proxy Mechanism

        private Proxy _proxy;

        private Proxy proxy
        {
            get
            {
                if (_proxy == null)
                {
                    throw new Exception("Part proxy not assigned! (Are you trying to construct a Part manually?)");
                }
                return _proxy;
            }
            set { _proxy = value; }
        }

        private static Part<T> Create(Proxy proxy)
        {
            Part<T> part = new T();
            part.proxy = proxy;
            return part;
        }

        #endregion

        #region Methods

        public void Explode()
        {
            proxy.explode();
        }

        #endregion

        #region Events

        public event EventHandler ActiveUpdate;

        protected virtual void OnActiveUpdate()
        {
            EventHandler handler = ActiveUpdate;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler Start;

        protected virtual void OnStart()
        {
            EventHandler handler = Start;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion

    }
}
