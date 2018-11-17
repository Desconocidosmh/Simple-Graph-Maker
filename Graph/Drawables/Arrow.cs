using SFML.Graphics;
using Graph.MathUtils;
using SFML.System;


namespace Graph.Drawables
{
    public class Arrow : Transformable, Drawable
    {
        private const float DEFAULT_SIZE = 1f;

        #region Properties

        /// <summary>
        /// Size of the arrow
        /// </summary>
        public float Size { get; set; }

        /// <summary>
        /// Color of the arrow
        /// </summary>
        public Color Color { get; set; }

        #endregion

        #region Constructors

        public Arrow() : this(new Vector2f()) { }
        public Arrow(Vector2f position) : this(position, 0) { }
        public Arrow(Vector2f position, float rotation) : this(position, rotation, DEFAULT_SIZE) { }
        public Arrow(Vector2f position, float rotation, float size)
        {
            Position = position;
            Rotation = rotation;
            Size = size;

            Color = Color.Black;
        }

        #endregion

        public void ApplyCorrectRotationForVector(Vector vector)
        {
            float rotation = SpaceMath.AngleBetween(
                new Vector2f(0, 0),
                vector) - 30;
            Rotation = rotation;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            var triangle = new CircleShape(Size, 3);

            triangle.Origin = new Vector2f(Size, Size);
            triangle.Position = Position;
            triangle.Rotation = Rotation;
            triangle.OutlineColor = Color;
            triangle.FillColor = Color;


            target.Draw(triangle);
        }
    }
}