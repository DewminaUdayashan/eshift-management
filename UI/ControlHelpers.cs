using eshift_management.Models;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace eshift_management.UI
{
    public static class ControlHelpers
    {
        /// <summary>
        /// Draws a rounded rectangle status chip inside a DataGridView cell.
        /// </summary>
        public static void DrawStatusChip(Graphics g, Rectangle bounds, JobStatus status)
        {
            // Determine colors based on status
            Color backgroundColor = GetStatusColor(status);
            Color foregroundColor = Color.White;

            // Use high-quality drawing settings
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Define the chip's rectangle, with a small margin
            RectangleF chipBounds = new RectangleF(bounds.X + 4, bounds.Y + 8, 100, bounds.Height - 16);

            // Create a rounded rectangle path
            using (GraphicsPath path = GetRoundedRect(chipBounds, 12))
            using (SolidBrush brush = new SolidBrush(backgroundColor))
            {
                // Draw the chip background
                g.FillPath(brush, path);

                // Draw the status text
                using (Font font = new Font("Segoe UI", 8F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(foregroundColor))
                {
                    TextRenderer.DrawText(g, status.ToString(), font, Rectangle.Round(chipBounds), foregroundColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            }
        }

        private static Color GetStatusColor(JobStatus status)
        {
            switch (status)
            {
                case JobStatus.Pending:
                    return Color.Goldenrod;
                case JobStatus.Approved:
                case JobStatus.Scheduled:
                    return Color.FromArgb(0, 123, 255); // Blue
                case JobStatus.OnGoing:
                    return Color.Teal;
                case JobStatus.Completed:
                    return Color.SeaGreen;
                case JobStatus.Canceled:
                case JobStatus.Rejected:
                    return Color.IndianRed;
                default:
                    return Color.Gray;
            }
        }

        private static GraphicsPath GetRoundedRect(RectangleF baseRect, float radius)
        {
            var path = new GraphicsPath();
            path.AddArc(baseRect.X, baseRect.Y, radius, radius, 180, 90);
            path.AddArc(baseRect.Right - radius, baseRect.Y, radius, radius, 270, 90);
            path.AddArc(baseRect.Right - radius, baseRect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(baseRect.X, baseRect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}