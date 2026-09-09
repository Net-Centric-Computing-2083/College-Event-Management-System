using System.Drawing;
using System.Windows.Forms;

namespace CollegeEventManagementSystem.UI
{
    /// <summary>
    /// All colours and control styling of the application are kept in this one class,
    /// so every screen uses the same "Orchid Purple" look.
    /// Change a colour here and the whole application changes.
    /// </summary>
    public static class Theme
    {
        public static readonly Color PrimaryDark = Color.FromArgb(74, 20, 140);
        public static readonly Color Primary = Color.FromArgb(106, 27, 154);
        public static readonly Color PrimaryLight = Color.FromArgb(156, 77, 204);
        public static readonly Color Lavender = Color.FromArgb(237, 231, 246);
        public static readonly Color Background = Color.FromArgb(247, 245, 251);
        public static readonly Color Border = Color.FromArgb(214, 202, 232);
        public static readonly Color TextDark = Color.FromArgb(46, 42, 53);
        public static readonly Color TextMuted = Color.FromArgb(110, 100, 125);
        public static readonly Color Danger = Color.FromArgb(176, 42, 55);

        public static void StyleForm(Form form)
        {
            form.BackColor = Background;
            form.ForeColor = TextDark;
        }

        public static void StylePrimaryButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Primary;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button.FlatAppearance.MouseOverBackColor = PrimaryLight;
            button.FlatAppearance.MouseDownBackColor = PrimaryDark;
            button.Cursor = Cursors.Hand;
        }

        public static void StyleSecondaryButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Primary;
            button.BackColor = Lavender;
            button.ForeColor = PrimaryDark;
            button.Font = new Font("Segoe UI", 9.75F);
            button.FlatAppearance.MouseOverBackColor = Border;
            button.FlatAppearance.MouseDownBackColor = PrimaryLight;
            button.Cursor = Cursors.Hand;
        }

        public static void StyleDangerButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Danger;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9.75F);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 60, 72);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(140, 30, 42);
            button.Cursor = Cursors.Hand;
        }

        /// <summary>Style used by the sidebar navigation buttons of MainForm.</summary>
        public static void StyleNavButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Primary;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 10F);
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(24, 0, 0, 0);
            button.FlatAppearance.MouseOverBackColor = PrimaryLight;
            button.FlatAppearance.MouseDownBackColor = PrimaryDark;
            button.Cursor = Cursors.Hand;
        }

        /// <summary>Common DataGridView appearance: read-only, full row select, alternating rows.</summary>
        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.GridColor = Border;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grid.ColumnHeadersHeight = 34;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = TextDark;
            grid.DefaultCellStyle.SelectionBackColor = PrimaryLight;
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.DefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Lavender;
            grid.RowTemplate.Height = 28;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>Style used by the four summary cards of the dashboard.</summary>
        public static void StyleCard(Panel card)
        {
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
