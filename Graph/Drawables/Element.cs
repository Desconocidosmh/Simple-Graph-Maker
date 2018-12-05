using SFML.Graphics;
using Graph.Window;

namespace Graph.Drawables
{
    public abstract class Element : Drawable
    {
        #region Properies

        public virtual Color Color { get; protected set; }

        private GraphWindow parentWindow;

        #endregion

        #region Methods

        public virtual GraphWindow GetParentWindow() =>
            parentWindow;
        
        public virtual void SetParentWindow(GraphWindow value)
        {
            if (parentWindow != null)
            {
                parentWindow.CoordinateSystem.OnChange -= (s, e) => DeriveFromCoordinateSystem(parentWindow.CoordinateSystem);
                parentWindow.RemoveElement(this);
            }

            parentWindow = value;

            if (parentWindow != null)
            {
                DeriveFromCoordinateSystem(parentWindow.CoordinateSystem);
                parentWindow.CoordinateSystem.OnChange += (s, e) => DeriveFromCoordinateSystem(parentWindow.CoordinateSystem);
            }
        }

        protected virtual void DeriveFromCoordinateSystem(CoordinateSystem coordinateSystem)
        {
            Color = coordinateSystem.Color;
        }

        public abstract void Draw(RenderTarget target, RenderStates states);

        #endregion
    }
}