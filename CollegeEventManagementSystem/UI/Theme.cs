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
        // ------------------------------------------------------------
        // COLOUR PALETTE
        // ------------------------------------------------------------
        public static readonly Color PrimaryDark = Color.FromArgb(62, 16, 118);
        public static readonly Color Primary = Color.FromArgb(103, 33, 156);
        public static readonly Color PrimaryLight = Color.FromArgb(149, 74, 199);
        public static readonly Color Lavender = Color.FromArgb(243, 238, 250);
        public static readonly Color LavenderDeep = Color.FromArgb(232, 222, 245);
        public static readonly Color Background = Color.FromArgb(246, 243, 250);
        public static readonly Color Border = Color.FromArgb(224, 214, 239);
        public static readonly Color TextDark = Color.FromArgb(42, 37, 51);
        public static readonly Color TextMuted = Color.FromArgb(118, 108, 134);
        public static readonly Color Danger = Color.FromArgb(178, 44, 58);
        public static readonly Color Success = Color.FromArgb(32, 132, 96);

        // ------------------------------------------------------------
        // FONTS
        // ------------------------------------------------------------
        public static Font SectionFont()
        {
            return new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        }

        public static Font BodyFont()
        {
            return new Font("Segoe UI", 9.75F);
        }

        // ------------------------------------------------------------
        // FORM
        // ------------------------------------------------------------

        /// <summary>
        /// Applies the background colour of a screen and then styles every text box,
        /// combo box, date picker, group box and label inside it, so that all the
        /// screens of the application automatically look the same.
        /// </summary>
        public static void StyleForm(Form form)
        {
            form.BackColor = Background;
            form.ForeColor = TextDark;

            StyleChildControls(form);
        }

        /// <summary>Walks through the controls of a container and styles the common ones.</summary>
        private static void StyleChildControls(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox)
                {
                    StyleTextBox((TextBox)control);
                }
                else if (control is ComboBox)
                {
                    StyleComboBox((ComboBox)control);
                }
                else if (control is DateTimePicker)
                {
                    StyleDatePicker((DateTimePicker)control);
                }
                else if (control is GroupBox)
                {
                    StyleGroupBox((GroupBox)control);
                }
                else if (control is Panel && control.Name == "pnlTitle")
                {
                    StyleTitlePanel((Panel)control);
                }

                if (control.HasChildren)
                {
                    StyleChildControls(control);
                }
            }
        }

        public static void StyleTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            textBox.ForeColor = TextDark;
            textBox.Font = BodyFont();
        }

        public static void StyleComboBox(ComboBox comboBox)
        {
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.BackColor = Color.White;
            comboBox.ForeColor = TextDark;
            comboBox.Font = BodyFont();
        }

        public static void StyleDatePicker(DateTimePicker picker)
        {
            picker.CalendarTitleBackColor = Primary;
            picker.CalendarTitleForeColor = Color.White;
            picker.CalendarMonthBackground = Color.White;
            picker.CalendarTrailingForeColor = TextMuted;
            picker.Font = BodyFont();
        }

        public static void StyleGroupBox(GroupBox groupBox)
        {
            groupBox.ForeColor = Primary;
            groupBox.Font = SectionFont();
        }

        /// <summary>The white page-title strip at the top of every screen.</summary>
        public static void StyleTitlePanel(Panel panel)
        {
            panel.BackColor = Color.White;

            // A thin lavender line under the page title separates it from the content.
            Panel bottomLine = new Panel();
            bottomLine.Name = "pnlTitleLine";
            bottomLine.Dock = DockStyle.Bottom;
            bottomLine.Height = 2;
            bottomLine.BackColor = LavenderDeep;
            panel.Controls.Add(bottomLine);
        }

        // ------------------------------------------------------------
        // BUTTONS
        // ------------------------------------------------------------

        public static void StylePrimaryButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Primary;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            button.FlatAppearance.MouseOverBackColor = PrimaryLight;
            button.FlatAppearance.MouseDownBackColor = PrimaryDark;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
        }

        public static void StyleSecondaryButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Border;
            button.BackColor = Color.White;
            button.ForeColor = PrimaryDark;
            button.Font = new Font("Segoe UI", 9.75F);
            button.FlatAppearance.MouseOverBackColor = Lavender;
            button.FlatAppearance.MouseDownBackColor = LavenderDeep;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
        }

        public static void StyleDangerButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Danger;
            button.BackColor = Color.White;
            button.ForeColor = Danger;
            button.Font = new Font("Segoe UI", 9.75F);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(250, 238, 240);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(240, 214, 218);
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
        }

        /// <summary>Style used by the sidebar navigation buttons of MainForm.</summary>
        public static void StyleNavButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(28, 0, 0, 0);
            button.FlatAppearance.MouseOverBackColor = PrimaryLight;
            button.FlatAppearance.MouseDownBackColor = PrimaryDark;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;

            StyleNavButtonInactive(button);
        }

        /// <summary>The sidebar button of the screen that is currently open.</summary>
        public static void StyleNavButtonActive(Button button)
        {
            button.BackColor = PrimaryDark;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
        }

        /// <summary>The sidebar buttons of the screens that are not open.</summary>
        public static void StyleNavButtonInactive(Button button)
        {
            button.BackColor = Primary;
            button.ForeColor = Color.FromArgb(232, 222, 245);
            button.Font = new Font("Segoe UI", 10.5F);
        }

        // ------------------------------------------------------------
        // DATA GRID VIEW
        // ------------------------------------------------------------

        /// <summary>Common DataGridView appearance: read-only, full row select, alternating rows.</summary>
        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.GridColor = Border;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grid.ColumnHeadersHeight = 40;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = TextDark;
            grid.DefaultCellStyle.SelectionBackColor = PrimaryLight;
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            grid.DefaultCellStyle.Font = BodyFont();
            grid.AlternatingRowsDefaultCellStyle.BackColor = Lavender;
            grid.RowTemplate.Height = 32;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ------------------------------------------------------------
        // CARDS
        // ------------------------------------------------------------

        /// <summary>Style used by the four summary cards of the dashboard.</summary>
        public static void StyleCard(Panel card)
        {
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.None;
            AddBorder(card, Border);
        }

        /// <summary>
        /// Draws a thin border around a white area (used for the dashboard cards and
        /// for the panels that hold a DataGridView) so the screen looks organised.
        /// </summary>
        public static void AddBorder(Control control, Color borderColor)
        {
            control.Paint += delegate(object sender, PaintEventArgs e)
            {
                Control target = (Control)sender;

                using (Pen pen = new Pen(borderColor))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, target.Width - 1, target.Height - 1);
                }
            };
        }

        /// <summary>Coloured strip on the left side of a dashboard card.</summary>
        public static void AddCardAccent(Panel card, Color accentColor)
        {
            Panel accent = new Panel();
            accent.Name = "pnlCardAccent";
            accent.Dock = DockStyle.Left;
            accent.Width = 5;
            accent.BackColor = accentColor;
            card.Controls.Add(accent);
        }
    }
}
