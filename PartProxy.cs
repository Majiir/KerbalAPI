
namespace KerbalAPI
{
    public abstract partial class Part<T> where T : Part<T>, new()
    {
        public abstract class Proxy : global::Part
        {

            #region Proxy Mechanism

            private Part<T> part;

            public Proxy() : base()
            {
                part = Part<T>.Create(this);
            }

            #endregion

            #region Events

            protected override void onPartStart()
            {
                base.onPartStart();
                part.OnStart();
            }

            protected override void onActiveUpdate()
            {
                base.onActiveUpdate();
                part.OnActiveUpdate();
            }

            #endregion

        }
    }
}
