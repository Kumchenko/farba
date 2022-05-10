
namespace Lab5
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHistoryClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuHistoryItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHistoryItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.editorPanel = new System.Windows.Forms.Panel();
            this.pictureEditor = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.currcolor1Panel = new System.Windows.Forms.Panel();
            this.currcolorLabel = new System.Windows.Forms.Label();
            this.thickLabel = new System.Windows.Forms.Label();
            this.thickSelector = new System.Windows.Forms.ComboBox();
            this.currcolor2Panel = new System.Windows.Forms.Panel();
            this.lineBox = new System.Windows.Forms.PictureBox();
            this.penBox = new System.Windows.Forms.PictureBox();
            this.squareBox = new System.Windows.Forms.PictureBox();
            this.circleBox = new System.Windows.Forms.PictureBox();
            this.eraserBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.scaleLabel = new System.Windows.Forms.Label();
            this.scale_p_button = new System.Windows.Forms.Button();
            this.scale_m_button = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.editorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.penBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.squareBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circleBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eraserBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.Control;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuHistory,
            this.MenuClipboard});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(722, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.BackColor = System.Drawing.SystemColors.Control;
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCreate,
            this.MenuOpen,
            this.toolStripSeparator1,
            this.MenuSave,
            this.MenuSaveAs,
            this.toolStripSeparator2,
            this.MenuClose,
            this.MenuExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(48, 20);
            this.MenuFile.Text = "Файл";
            // 
            // MenuCreate
            // 
            this.MenuCreate.BackColor = System.Drawing.SystemColors.Control;
            this.MenuCreate.Name = "MenuCreate";
            this.MenuCreate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.MenuCreate.Size = new System.Drawing.Size(173, 22);
            this.MenuCreate.Text = "Создать";
            this.MenuCreate.Click += new System.EventHandler(this.toolStripMenuCreate_Click);
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuOpen.Size = new System.Drawing.Size(173, 22);
            this.MenuOpen.Text = "Открыть";
            this.MenuOpen.Click += new System.EventHandler(this.toolStripMenuOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // MenuSave
            // 
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuSave.Size = new System.Drawing.Size(173, 22);
            this.MenuSave.Text = "Сохранить";
            this.MenuSave.Click += new System.EventHandler(this.toolStripMenuSave_Click);
            // 
            // MenuSaveAs
            // 
            this.MenuSaveAs.Name = "MenuSaveAs";
            this.MenuSaveAs.Size = new System.Drawing.Size(173, 22);
            this.MenuSaveAs.Text = "Сохранить как";
            this.MenuSaveAs.Click += new System.EventHandler(this.toolStripMenuSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // MenuClose
            // 
            this.MenuClose.Name = "MenuClose";
            this.MenuClose.Size = new System.Drawing.Size(173, 22);
            this.MenuClose.Text = "Закрыть";
            this.MenuClose.Click += new System.EventHandler(this.toolStripMenuClose_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.MenuExit.Size = new System.Drawing.Size(173, 22);
            this.MenuExit.Text = "Выход";
            this.MenuExit.Click += new System.EventHandler(this.toolStripMenuExit_Click);
            // 
            // MenuHistory
            // 
            this.MenuHistory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHistoryClear,
            this.toolStripSeparator3,
            this.MenuHistoryItem1,
            this.MenuHistoryItem2});
            this.MenuHistory.Enabled = false;
            this.MenuHistory.Name = "MenuHistory";
            this.MenuHistory.Size = new System.Drawing.Size(66, 20);
            this.MenuHistory.Text = "История";
            // 
            // MenuHistoryClear
            // 
            this.MenuHistoryClear.Enabled = false;
            this.MenuHistoryClear.Name = "MenuHistoryClear";
            this.MenuHistoryClear.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.MenuHistoryClear.Size = new System.Drawing.Size(323, 22);
            this.MenuHistoryClear.Text = "Изображение открыто(Отменить всё)";
            this.MenuHistoryClear.Click += new System.EventHandler(this.MenuHistoryClear_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(320, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // MenuHistoryItem1
            // 
            this.MenuHistoryItem1.Enabled = false;
            this.MenuHistoryItem1.Name = "MenuHistoryItem1";
            this.MenuHistoryItem1.Size = new System.Drawing.Size(323, 22);
            this.MenuHistoryItem1.Text = "Действие назад";
            this.MenuHistoryItem1.Click += new System.EventHandler(this.MenuHistoryItem1_Click);
            // 
            // MenuHistoryItem2
            // 
            this.MenuHistoryItem2.Enabled = false;
            this.MenuHistoryItem2.Name = "MenuHistoryItem2";
            this.MenuHistoryItem2.Size = new System.Drawing.Size(323, 22);
            this.MenuHistoryItem2.Text = "Действие вперед";
            this.MenuHistoryItem2.Click += new System.EventHandler(this.MenuHistoryItem2_Click);
            // 
            // MenuClipboard
            // 
            this.MenuClipboard.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPaste,
            this.MenuCopy});
            this.MenuClipboard.Name = "MenuClipboard";
            this.MenuClipboard.Size = new System.Drawing.Size(101, 20);
            this.MenuClipboard.Text = "Буфер Обмена";
            // 
            // MenuPaste
            // 
            this.MenuPaste.Name = "MenuPaste";
            this.MenuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.MenuPaste.Size = new System.Drawing.Size(216, 22);
            this.MenuPaste.Text = "Вставить из БО";
            this.MenuPaste.Click += new System.EventHandler(this.toolStripMenuPaste_Click);
            // 
            // MenuCopy
            // 
            this.MenuCopy.Name = "MenuCopy";
            this.MenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MenuCopy.Size = new System.Drawing.Size(216, 22);
            this.MenuCopy.Text = "Скопировать в БО";
            this.MenuCopy.Click += new System.EventHandler(this.toolStripMenuCopy_Click);
            // 
            // editorPanel
            // 
            this.editorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorPanel.AutoScroll = true;
            this.editorPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editorPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.editorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editorPanel.Controls.Add(this.pictureEditor);
            this.editorPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.editorPanel.Location = new System.Drawing.Point(68, 30);
            this.editorPanel.Name = "editorPanel";
            this.editorPanel.Size = new System.Drawing.Size(647, 396);
            this.editorPanel.TabIndex = 1;
            this.editorPanel.Click += new System.EventHandler(this.panel1_Click);
            // 
            // pictureEditor
            // 
            this.pictureEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureEditor.Location = new System.Drawing.Point(0, 0);
            this.pictureEditor.Name = "pictureEditor";
            this.pictureEditor.Size = new System.Drawing.Size(0, 0);
            this.pictureEditor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureEditor.TabIndex = 0;
            this.pictureEditor.TabStop = false;
            this.pictureEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // currcolor1Panel
            // 
            this.currcolor1Panel.BackColor = System.Drawing.SystemColors.Desktop;
            this.currcolor1Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currcolor1Panel.Location = new System.Drawing.Point(2, 58);
            this.currcolor1Panel.Name = "currcolor1Panel";
            this.currcolor1Panel.Size = new System.Drawing.Size(27, 27);
            this.currcolor1Panel.TabIndex = 3;
            this.toolTip1.SetToolTip(this.currcolor1Panel, "Основной цвет");
            this.currcolor1Panel.Click += new System.EventHandler(this.currcolorpanel_Click);
            // 
            // currcolorLabel
            // 
            this.currcolorLabel.AutoSize = true;
            this.currcolorLabel.Location = new System.Drawing.Point(7, 24);
            this.currcolorLabel.Name = "currcolorLabel";
            this.currcolorLabel.Size = new System.Drawing.Size(52, 26);
            this.currcolorLabel.TabIndex = 4;
            this.currcolorLabel.Text = "Текущая\r\nпалитра";
            this.currcolorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // thickLabel
            // 
            this.thickLabel.AutoSize = true;
            this.thickLabel.Location = new System.Drawing.Point(7, 97);
            this.thickLabel.Name = "thickLabel";
            this.thickLabel.Size = new System.Drawing.Size(53, 26);
            this.thickLabel.TabIndex = 5;
            this.thickLabel.Text = "Толщина\r\nконтура";
            this.thickLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // thickSelector
            // 
            this.thickSelector.FormattingEnabled = true;
            this.thickSelector.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "6",
            "8",
            "10",
            "12",
            "14",
            "16",
            "20",
            "22",
            "48",
            "60"});
            this.thickSelector.Location = new System.Drawing.Point(2, 126);
            this.thickSelector.Name = "thickSelector";
            this.thickSelector.Size = new System.Drawing.Size(64, 21);
            this.thickSelector.TabIndex = 6;
            this.thickSelector.Text = "4";
            this.thickSelector.TextChanged += new System.EventHandler(this.thickSelector_TextChanged);
            this.thickSelector.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.thickSelector_KeyPress);
            // 
            // currcolor2Panel
            // 
            this.currcolor2Panel.BackColor = System.Drawing.Color.White;
            this.currcolor2Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currcolor2Panel.Location = new System.Drawing.Point(39, 58);
            this.currcolor2Panel.Name = "currcolor2Panel";
            this.currcolor2Panel.Size = new System.Drawing.Size(27, 27);
            this.currcolor2Panel.TabIndex = 7;
            this.toolTip1.SetToolTip(this.currcolor2Panel, "Дополнительный\r\n(Закрашивает)");
            this.currcolor2Panel.Click += new System.EventHandler(this.currcolor2Panel_Click);
            // 
            // lineBox
            // 
            this.lineBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineBox.Location = new System.Drawing.Point(39, 153);
            this.lineBox.Name = "lineBox";
            this.lineBox.Size = new System.Drawing.Size(27, 27);
            this.lineBox.TabIndex = 8;
            this.lineBox.TabStop = false;
            this.toolTip1.SetToolTip(this.lineBox, "Линия");
            this.lineBox.Click += new System.EventHandler(this.lineBox_Click);
            this.lineBox.Paint += new System.Windows.Forms.PaintEventHandler(this.lineBox_Paint);
            this.lineBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lineBox_MouseDown);
            this.lineBox.MouseLeave += new System.EventHandler(this.lineBox_MouseLeave);
            this.lineBox.MouseHover += new System.EventHandler(this.lineBox_MouseHover);
            this.lineBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lineBox_MouseUp);
            // 
            // penBox
            // 
            this.penBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.penBox.Location = new System.Drawing.Point(2, 153);
            this.penBox.Name = "penBox";
            this.penBox.Size = new System.Drawing.Size(27, 27);
            this.penBox.TabIndex = 8;
            this.penBox.TabStop = false;
            this.toolTip1.SetToolTip(this.penBox, "Карандаш");
            this.penBox.Click += new System.EventHandler(this.penBox_Click);
            this.penBox.Paint += new System.Windows.Forms.PaintEventHandler(this.penBox_Paint);
            this.penBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.penBox_MouseDown);
            this.penBox.MouseLeave += new System.EventHandler(this.penBox_MouseLeave);
            this.penBox.MouseHover += new System.EventHandler(this.penBox_MouseHover);
            this.penBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.penBox_MouseUp);
            // 
            // squareBox
            // 
            this.squareBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.squareBox.Location = new System.Drawing.Point(2, 186);
            this.squareBox.Name = "squareBox";
            this.squareBox.Size = new System.Drawing.Size(27, 27);
            this.squareBox.TabIndex = 9;
            this.squareBox.TabStop = false;
            this.toolTip1.SetToolTip(this.squareBox, "Квадрат");
            this.squareBox.Click += new System.EventHandler(this.squareBox_Click);
            this.squareBox.Paint += new System.Windows.Forms.PaintEventHandler(this.squareBox_Paint);
            this.squareBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.squareBox_MouseDown);
            this.squareBox.MouseLeave += new System.EventHandler(this.squareBox_MouseLeave);
            this.squareBox.MouseHover += new System.EventHandler(this.squareBox_MouseHover);
            this.squareBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.squareBox_MouseUp);
            // 
            // circleBox
            // 
            this.circleBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.circleBox.Location = new System.Drawing.Point(39, 186);
            this.circleBox.Name = "circleBox";
            this.circleBox.Size = new System.Drawing.Size(27, 27);
            this.circleBox.TabIndex = 9;
            this.circleBox.TabStop = false;
            this.toolTip1.SetToolTip(this.circleBox, "Круг");
            this.circleBox.Click += new System.EventHandler(this.circleBox_Click);
            this.circleBox.Paint += new System.Windows.Forms.PaintEventHandler(this.circleBox_Paint);
            this.circleBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.circleBox_MouseDown);
            this.circleBox.MouseLeave += new System.EventHandler(this.circleBox_MouseLeave);
            this.circleBox.MouseHover += new System.EventHandler(this.circleBox_MouseHover);
            this.circleBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.circleBox_MouseUp);
            // 
            // eraserBox
            // 
            this.eraserBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eraserBox.Location = new System.Drawing.Point(2, 219);
            this.eraserBox.Name = "eraserBox";
            this.eraserBox.Size = new System.Drawing.Size(27, 27);
            this.eraserBox.TabIndex = 10;
            this.eraserBox.TabStop = false;
            this.toolTip1.SetToolTip(this.eraserBox, "Ластик");
            this.eraserBox.Click += new System.EventHandler(this.eraserBox_Click);
            this.eraserBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.eraserBox_MouseDown);
            this.eraserBox.MouseLeave += new System.EventHandler(this.eraserBox_MouseLeave);
            this.eraserBox.MouseHover += new System.EventHandler(this.eraserBox_MouseHover);
            this.eraserBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.eraserBox_MouseUp);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.ReshowDelay = 100;
            // 
            // scaleLabel
            // 
            this.scaleLabel.AutoSize = true;
            this.scaleLabel.Location = new System.Drawing.Point(6, 259);
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(53, 26);
            this.scaleLabel.TabIndex = 5;
            this.scaleLabel.Text = "Масштаб\r\n100%";
            this.scaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scale_p_button
            // 
            this.scale_p_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scale_p_button.Location = new System.Drawing.Point(2, 288);
            this.scale_p_button.Name = "scale_p_button";
            this.scale_p_button.Size = new System.Drawing.Size(27, 27);
            this.scale_p_button.TabIndex = 11;
            this.scale_p_button.Text = "+";
            this.scale_p_button.UseVisualStyleBackColor = true;
            this.scale_p_button.Click += new System.EventHandler(this.scale_p_button_Click);
            // 
            // scale_m_button
            // 
            this.scale_m_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scale_m_button.Location = new System.Drawing.Point(39, 288);
            this.scale_m_button.Name = "scale_m_button";
            this.scale_m_button.Size = new System.Drawing.Size(27, 27);
            this.scale_m_button.TabIndex = 11;
            this.scale_m_button.Text = "-";
            this.scale_m_button.UseVisualStyleBackColor = true;
            this.scale_m_button.Click += new System.EventHandler(this.scale_m_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(722, 433);
            this.Controls.Add(this.scale_m_button);
            this.Controls.Add(this.scale_p_button);
            this.Controls.Add(this.eraserBox);
            this.Controls.Add(this.circleBox);
            this.Controls.Add(this.squareBox);
            this.Controls.Add(this.penBox);
            this.Controls.Add(this.lineBox);
            this.Controls.Add(this.currcolor2Panel);
            this.Controls.Add(this.thickSelector);
            this.Controls.Add(this.scaleLabel);
            this.Controls.Add(this.thickLabel);
            this.Controls.Add(this.currcolorLabel);
            this.Controls.Add(this.currcolor1Panel);
            this.Controls.Add(this.editorPanel);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Farba";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.editorPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.penBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.squareBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circleBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eraserBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuClipboard;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel editorPanel;
        private System.Windows.Forms.ToolStripMenuItem MenuCreate;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel currcolor1Panel;
        private System.Windows.Forms.Label currcolorLabel;
        private System.Windows.Forms.Label thickLabel;
        private System.Windows.Forms.ComboBox thickSelector;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PictureBox pictureEditor;
        private System.Windows.Forms.ToolStripMenuItem MenuPaste;
        private System.Windows.Forms.ToolStripMenuItem MenuCopy;
        private System.Windows.Forms.ToolStripMenuItem MenuClose;
        private System.Windows.Forms.ToolStripMenuItem MenuHistory;
        private System.Windows.Forms.ToolStripMenuItem MenuHistoryClear;
        private System.Windows.Forms.ToolStripMenuItem MenuHistoryItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuHistoryItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel currcolor2Panel;
        private System.Windows.Forms.PictureBox lineBox;
        private System.Windows.Forms.PictureBox penBox;
        private System.Windows.Forms.PictureBox squareBox;
        private System.Windows.Forms.PictureBox circleBox;
        private System.Windows.Forms.PictureBox eraserBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label scaleLabel;
        private System.Windows.Forms.Button scale_p_button;
        private System.Windows.Forms.Button scale_m_button;
    }
}

