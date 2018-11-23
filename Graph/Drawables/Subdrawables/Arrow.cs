using SFML.Graphics;
using Graph.MathUtils;
using SFML.System;

namespace Graph.Drawables.Subdrawables
{
    public class Arrow : Transformable, Drawable
    {
        #region Constants

        private const float DEFAULT_SIZE = 1f;

        #endregion

        #region Properties

        /// <summary>
        /// Size of the arrow
        /// </summary>
        public float Size { get; set; } = 1;

        /// <summary>
        /// Color of the arrow
        /// </summary>
        public Color Color { get; set; }

        public Vector ParentVector { get; }

        #endregion

        #region Constructors

        public Arrow(Vector parentVector)
        {
            ParentVector = parentVector;
            DeriveFromVector(ParentVector);
            ParentVector.OnChange += (s, e) => DeriveFromVector(ParentVector);
        }

        #endregion

        #region Methods

        private void DeriveFromVector(Vector vector)
        {
            Position = vector.Position;
            Rotation = -SpaceMath.AngleBetween(
                new Vector2f(0, 0),
                vector) - 150;
            Color = vector.Color;
            Size = vector.ArrowSize;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            var triangle = new CircleShape(Size, 3)
            {
                Origin = new Vector2f(Size, Size),
                Position = ParentVector.GetParentWindow().ToWindowCoords(new Vector2f(Position.X, -Position.Y)),
                Rotation = Rotation,
                OutlineColor = Color,
                FillColor = Color
            };

            target.Draw(triangle);
        }

        #endregion
    }
}