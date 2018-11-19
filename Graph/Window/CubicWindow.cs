using SFML.Graphics;
using Graph.Drawables;

namespace Graph.Window
{
    public class CubicWindow : GraphWindow
    {
        #region Properties

        public SquareFunction Function { get; }

        #endregion

        #region Constructors

        public CubicWindow(uint width, uint heigth, string name, Color backgroundColor,
            Color coordinateSystemColor, int initialScale, float a, float b, float c)
            : base(width, heigth, name, backgroundColor, coordinateSystemColor, initialScale)
        {
            Function = new SquareFunction(this, a, b ,c);
        }

        #endregion

        #region Methods

        protected override void DrawElements(RenderTarget target) => target.Draw(Function);

        #endregion
    }
}
