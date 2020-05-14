﻿namespace ThirdLaboratory
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
            this.bSerialize = new System.Windows.Forms.Button();
            this.bDeserialize = new System.Windows.Forms.Button();
            this.lbClothes = new System.Windows.Forms.ListBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.bDelete = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.cbFuncPlugins = new System.Windows.Forms.ComboBox();
            this.bChooseFunc = new System.Windows.Forms.Button();
            this.laPlugins = new System.Windows.Forms.Label();
            this.laClothes = new System.Windows.Forms.Label();
            this.laMain = new System.Windows.Forms.Label();
            this.laSerializePlugins = new System.Windows.Forms.Label();
            this.cbSerializePlugins = new System.Windows.Forms.ComboBox();
            this.bChooseSerializer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bSerialize
            // 
            this.bSerialize.Location = new System.Drawing.Point(12, 40);
            this.bSerialize.Name = "bSerialize";
            this.bSerialize.Size = new System.Drawing.Size(152, 31);
            this.bSerialize.TabIndex = 0;
            this.bSerialize.Text = "Serialize";
            this.bSerialize.UseVisualStyleBackColor = true;
            this.bSerialize.Click += new System.EventHandler(this.bSerialize_Click);
            // 
            // bDeserialize
            // 
            this.bDeserialize.Location = new System.Drawing.Point(12, 77);
            this.bDeserialize.Name = "bDeserialize";
            this.bDeserialize.Size = new System.Drawing.Size(152, 31);
            this.bDeserialize.TabIndex = 1;
            this.bDeserialize.Text = "Deserialize";
            this.bDeserialize.UseVisualStyleBackColor = true;
            this.bDeserialize.Click += new System.EventHandler(this.bDeserialize_Click);
            // 
            // lbClothes
            // 
            this.lbClothes.ItemHeight = 16;
            this.lbClothes.Location = new System.Drawing.Point(186, 12);
            this.lbClothes.Name = "lbClothes";
            this.lbClothes.Size = new System.Drawing.Size(226, 516);
            this.lbClothes.TabIndex = 2;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(12, 495);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(152, 31);
            this.bAdd.TabIndex = 3;
            this.bAdd.Text = "Add";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // cbTypes
            // 
            this.cbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypes.FormattingEnabled = true;
            this.cbTypes.Location = new System.Drawing.Point(12, 465);
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(152, 24);
            this.cbTypes.TabIndex = 4;
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(12, 114);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(152, 31);
            this.bDelete.TabIndex = 5;
            this.bDelete.Text = "Delete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bEdit
            // 
            this.bEdit.Location = new System.Drawing.Point(12, 151);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(152, 31);
            this.bEdit.TabIndex = 6;
            this.bEdit.Text = "Edit/View";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // cbFuncPlugins
            // 
            this.cbFuncPlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuncPlugins.FormattingEnabled = true;
            this.cbFuncPlugins.Location = new System.Drawing.Point(12, 233);
            this.cbFuncPlugins.Name = "cbFuncPlugins";
            this.cbFuncPlugins.Size = new System.Drawing.Size(152, 24);
            this.cbFuncPlugins.TabIndex = 8;
            // 
            // bChooseFunc
            // 
            this.bChooseFunc.Location = new System.Drawing.Point(12, 263);
            this.bChooseFunc.Name = "bChooseFunc";
            this.bChooseFunc.Size = new System.Drawing.Size(152, 31);
            this.bChooseFunc.TabIndex = 7;
            this.bChooseFunc.Text = "Make current";
            this.bChooseFunc.UseVisualStyleBackColor = true;
            this.bChooseFunc.Click += new System.EventHandler(this.bChooseFunc_Click);
            // 
            // laPlugins
            // 
            this.laPlugins.AutoSize = true;
            this.laPlugins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.laPlugins.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laPlugins.Location = new System.Drawing.Point(12, 203);
            this.laPlugins.MinimumSize = new System.Drawing.Size(152, 2);
            this.laPlugins.Name = "laPlugins";
            this.laPlugins.Size = new System.Drawing.Size(152, 19);
            this.laPlugins.TabIndex = 9;
            this.laPlugins.Text = "Functional Plugins";
            this.laPlugins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // laClothes
            // 
            this.laClothes.AutoSize = true;
            this.laClothes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.laClothes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laClothes.Location = new System.Drawing.Point(12, 434);
            this.laClothes.MinimumSize = new System.Drawing.Size(152, 2);
            this.laClothes.Name = "laClothes";
            this.laClothes.Size = new System.Drawing.Size(153, 19);
            this.laClothes.TabIndex = 10;
            this.laClothes.Text = "Clothes Constructor";
            this.laClothes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // laMain
            // 
            this.laMain.AutoSize = true;
            this.laMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.laMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laMain.Location = new System.Drawing.Point(12, 12);
            this.laMain.MinimumSize = new System.Drawing.Size(152, 2);
            this.laMain.Name = "laMain";
            this.laMain.Size = new System.Drawing.Size(152, 19);
            this.laMain.TabIndex = 11;
            this.laMain.Text = "Main";
            this.laMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // laSerializePlugins
            // 
            this.laSerializePlugins.AutoSize = true;
            this.laSerializePlugins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.laSerializePlugins.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laSerializePlugins.Location = new System.Drawing.Point(12, 316);
            this.laSerializePlugins.MinimumSize = new System.Drawing.Size(152, 2);
            this.laSerializePlugins.Name = "laSerializePlugins";
            this.laSerializePlugins.Size = new System.Drawing.Size(152, 19);
            this.laSerializePlugins.TabIndex = 12;
            this.laSerializePlugins.Text = "Serialize Plugins";
            this.laSerializePlugins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbSerializePlugins
            // 
            this.cbSerializePlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerializePlugins.FormattingEnabled = true;
            this.cbSerializePlugins.Location = new System.Drawing.Point(12, 347);
            this.cbSerializePlugins.Name = "cbSerializePlugins";
            this.cbSerializePlugins.Size = new System.Drawing.Size(152, 24);
            this.cbSerializePlugins.TabIndex = 14;
            // 
            // bChooseSerializer
            // 
            this.bChooseSerializer.Location = new System.Drawing.Point(12, 377);
            this.bChooseSerializer.Name = "bChooseSerializer";
            this.bChooseSerializer.Size = new System.Drawing.Size(152, 31);
            this.bChooseSerializer.TabIndex = 13;
            this.bChooseSerializer.Text = "Make current";
            this.bChooseSerializer.UseVisualStyleBackColor = true;
            this.bChooseSerializer.Click += new System.EventHandler(this.bChooseSerializer_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 536);
            this.Controls.Add(this.cbSerializePlugins);
            this.Controls.Add(this.bChooseSerializer);
            this.Controls.Add(this.laSerializePlugins);
            this.Controls.Add(this.laMain);
            this.Controls.Add(this.laClothes);
            this.Controls.Add(this.laPlugins);
            this.Controls.Add(this.cbFuncPlugins);
            this.Controls.Add(this.bChooseFunc);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.cbTypes);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.lbClothes);
            this.Controls.Add(this.bDeserialize);
            this.Controls.Add(this.bSerialize);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Third Laboratory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSerialize;
        private System.Windows.Forms.Button bDeserialize;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.ComboBox cbTypes;
        private System.Windows.Forms.ListBox lbClothes;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ComboBox cbFuncPlugins;
        private System.Windows.Forms.Button bChooseFunc;
        private System.Windows.Forms.Label laPlugins;
        private System.Windows.Forms.Label laClothes;
        private System.Windows.Forms.Label laMain;
        private System.Windows.Forms.Label laSerializePlugins;
        private System.Windows.Forms.ComboBox cbSerializePlugins;
        private System.Windows.Forms.Button bChooseSerializer;
    }
}

