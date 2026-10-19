using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BillingSystem.Utils
{
    public static class AppTheme
    {
        public static Color Primary { get; } = Color.FromArgb(30, 76, 150);
        public static Color Secondary { get; } = Color.FromArgb(28, 128, 111);
        public static Color Background { get; } = Color.FromArgb(245, 247, 250);
        public static Color Panel { get; } = Color.FromArgb(255, 255, 255);
        public static Color Accent { get; } = Color.FromArgb(91, 155, 213);
        public static Color Highlight { get; } = Color.FromArgb(194, 224, 255);
        public static Color Success { get; } = Color.FromArgb(40, 167, 69);
        public static Color Warning { get; } = Color.FromArgb(255, 193, 7);
        public static Color Danger { get; } = Color.FromArgb(220, 53, 69);
        public static Color Text { get; } = Color.FromArgb(33, 37, 41);
        public static Color GridRowAlt { get; } = Color.FromArgb(245, 245, 245);
        public static Color InactiveRowColor { get; } = Color.FromArgb(255, 220, 220);
        public static Color ActiveRowColor { get; } = Color.FromArgb(220, 255, 220);

        public static void Apply(Form form)
        {
            if (form == null) return;

            form.BackColor = Background;
            form.ForeColor = Text;

            foreach (Control control in GetAllControls(form))
            {
                if (control is Button button)
                {
                    button.BackColor = Primary;
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font(button.Font, FontStyle.Bold);
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = Color.White;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is DataGridView grid)
                {
                    grid.BackgroundColor = Color.White;
                    grid.BorderStyle = BorderStyle.None;
                    grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                    grid.DefaultCellStyle.SelectionBackColor = Highlight;
                    grid.DefaultCellStyle.SelectionForeColor = Text;
                    grid.ColumnHeadersDefaultCellStyle.BackColor = Primary;
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    grid.ColumnHeadersDefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);
                }
                else if (control is Label label && label.Parent is not null)
                {
                    label.ForeColor = Text;
                }
                else if (control is ToolStrip toolStrip)
                {
                    toolStrip.BackColor = Panel;
                    toolStrip.ForeColor = Text;
                }
            }
        }

        private static IEnumerable<Control> GetAllControls(Control root)
        {
            var stack = new Stack<Control>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var control = stack.Pop();
                yield return control;

                foreach (Control child in control.Controls.Cast<Control>())
                {
                    stack.Push(child);
                }
            }
        }
    }
}
