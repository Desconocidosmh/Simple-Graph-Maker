using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using Graph.Window;

namespace Graph.Drawables.Subdrawables
{
    public class SpacingLineCollection : Drawable
    {
        private static Font font = new Font(@"Resources\Fonts\Roboto-Medium.ttf");

        private readonly SpacingLine[] lines;

        public SpacingLineCollection(GraphWindow parentWindow, float size)
        {
            var localLines = new List<SpacingLine>();

            float spacing = parentWindow.CoordinateSystem.Spacing;
            float scale = parentWindow.CoordinateSystem.Scale;

            for (float i = spacing; i < scale; i += spacing)
            {
                // Draw spacing lines on vertical line for both sides
                localLines.Add(new SpacingLine(parentWindow, new Vector2f(0, i), size, Orientation.Horizontal, font));
                localLines.Add(new SpacingLine(parentWindow, new Vector2f(0, -i), size, Orientation.Horizontal, font));

                // Add spacing lines on horizontal line for both sides
                localLines.Add(new SpacingLine(parentWindow, new Vector2f(i, 0), size, Orientation.Vertical, font));
                localLines.Add(new SpacingLine(parentWindow, new Vector2f(-i, 0), size, Orientation.Vertical, font));
            }

            lines = localLines.ToArray();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var line in lines)
            {
                target.Draw(line);
            }
        }
    }
}
