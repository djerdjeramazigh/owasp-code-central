using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Xml;


namespace Owasp.VulnReport.ascx
{
	/// <summary>
	/// Summary description for ascxTargets.
	/// </summary>
	public class ascxTargets : System.Windows.Forms.UserControl
	{		
		private string strCurrentProject;
		private string strFullPathToCurrentProject;
		private string strPathToProjectFiles;
		private string strFullPathToSelectedTarget;	
		private string strPathToTempFileFolder;
        private string strPathToTargetXmlFile;

        private utils.authentic authUtils = new utils.authentic();
		private System.Windows.Forms.ListBox lbTargetsInCurrentProject;
		private System.Windows.Forms.Label lbCurrentProject;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btAddNewTarget;
		private System.Windows.Forms.TextBox txtNewTargetName;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btSaveTarget;
		private System.Windows.Forms.Button btDeleteSelectedTarget;
		private System.Windows.Forms.Label lbUnsavedData;
		private AxXMLSPYPLUGINLib.AxAuthentic axAuthentic_Targets;
		private System.Windows.Forms.Label lblTargetsSaved;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btRenameTarget;
        private System.Windows.Forms.TextBox txtRenameTarget;
        private Button btnTargetImport;
        private ToolTip targetToolTips = new ToolTip();
        private bool unsavedDataExists = false;
        private WebBrowser axWebBrowserContentsOfProjectFolder;
        private GroupBox groupBox4;
        private Label label4;
        private TextBox txtTargetsSearchResults;
        private TextBox txtTargetsSearchQuery;
        private Label label5;
        private CheckBox cbIgnoreStatusFlag;
        private TextBox txtDefaultTargetType;
        private Label label6;
        private CheckBox cbShowContentOfProjectFolder;
        private GroupBox groupBox5;
        private Label lbXmlBreaksXsdSchema;
        private ToolTip toolTip1;
        private IContainer components;
        private SplitContainer splitContainer1;

        private OrgBasePaths obpPaths = OrgBasePaths.GetPaths();

		public ascxTargets()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            SetupToolTips();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				axAuthentic_Targets.Dispose();
				axAuthentic_Targets.ContainingControl = null;
				if(null != axAuthentic_Targets )
				{
                    axAuthentic_Targets.Dispose();
				}
			}
			base.Dispose( disposing );	
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ascxTargets));
            this.axAuthentic_Targets = new AxXMLSPYPLUGINLib.AxAuthentic();
            this.lbTargetsInCurrentProject = new System.Windows.Forms.ListBox();
            this.lbCurrentProject = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btAddNewTarget = new System.Windows.Forms.Button();
            this.txtNewTargetName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbXmlBreaksXsdSchema = new System.Windows.Forms.Label();
            this.btSaveTarget = new System.Windows.Forms.Button();
            this.lblTargetsSaved = new System.Windows.Forms.Label();
            this.lbUnsavedData = new System.Windows.Forms.Label();
            this.btnTargetImport = new System.Windows.Forms.Button();
            this.btDeleteSelectedTarget = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btRenameTarget = new System.Windows.Forms.Button();
            this.txtRenameTarget = new System.Windows.Forms.TextBox();
            this.axWebBrowserContentsOfProjectFolder = new System.Windows.Forms.WebBrowser();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTargetsSearchResults = new System.Windows.Forms.TextBox();
            this.txtTargetsSearchQuery = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbIgnoreStatusFlag = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDefaultTargetType = new System.Windows.Forms.TextBox();
            this.cbShowContentOfProjectFolder = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Targets)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axAuthentic_Targets
            // 
            this.axAuthentic_Targets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axAuthentic_Targets.Enabled = true;
            this.axAuthentic_Targets.Location = new System.Drawing.Point(-2, -2);
            this.axAuthentic_Targets.Name = "axAuthentic_Targets";
            this.axAuthentic_Targets.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAuthentic_Targets.OcxState")));
            this.axAuthentic_Targets.Size = new System.Drawing.Size(661, 228);
            this.axAuthentic_Targets.TabIndex = 12;
            this.axAuthentic_Targets.SelectionChanged += new System.EventHandler(this.axAuthentic_Targets_SelectionChanged);
            // 
            // lbTargetsInCurrentProject
            // 
            this.lbTargetsInCurrentProject.Location = new System.Drawing.Point(15, 52);
            this.lbTargetsInCurrentProject.Name = "lbTargetsInCurrentProject";
            this.lbTargetsInCurrentProject.Size = new System.Drawing.Size(160, 147);
            this.lbTargetsInCurrentProject.Sorted = true;
            this.lbTargetsInCurrentProject.TabIndex = 11;
            this.lbTargetsInCurrentProject.SelectedIndexChanged += new System.EventHandler(this.lbTargetsInCurrentProject_SelectedIndexChanged);
            // 
            // lbCurrentProject
            // 
            this.lbCurrentProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentProject.Location = new System.Drawing.Point(96, 3);
            this.lbCurrentProject.Name = "lbCurrentProject";
            this.lbCurrentProject.Size = new System.Drawing.Size(280, 16);
            this.lbCurrentProject.TabIndex = 10;
            this.lbCurrentProject.Text = "...";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Current Project";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Targets in Current Project:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btAddNewTarget);
            this.groupBox3.Controls.Add(this.txtNewTargetName);
            this.groupBox3.Location = new System.Drawing.Point(16, 202);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 40);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add Target";
            // 
            // btAddNewTarget
            // 
            this.btAddNewTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAddNewTarget.Location = new System.Drawing.Point(117, 15);
            this.btAddNewTarget.Name = "btAddNewTarget";
            this.btAddNewTarget.Size = new System.Drawing.Size(35, 20);
            this.btAddNewTarget.TabIndex = 1;
            this.btAddNewTarget.Text = "Add";
            this.btAddNewTarget.Click += new System.EventHandler(this.btAddNewTarget_Click);
            // 
            // txtNewTargetName
            // 
            this.txtNewTargetName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNewTargetName.Location = new System.Drawing.Point(8, 15);
            this.txtNewTargetName.Name = "txtNewTargetName";
            this.txtNewTargetName.Size = new System.Drawing.Size(104, 20);
            this.txtNewTargetName.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbXmlBreaksXsdSchema);
            this.groupBox1.Controls.Add(this.btSaveTarget);
            this.groupBox1.Controls.Add(this.lblTargetsSaved);
            this.groupBox1.Controls.Add(this.lbUnsavedData);
            this.groupBox1.Location = new System.Drawing.Point(563, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 59);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // lbXmlBreaksXsdSchema
            // 
            this.lbXmlBreaksXsdSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbXmlBreaksXsdSchema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbXmlBreaksXsdSchema.ForeColor = System.Drawing.Color.Red;
            this.lbXmlBreaksXsdSchema.Location = new System.Drawing.Point(10, 14);
            this.lbXmlBreaksXsdSchema.Name = "lbXmlBreaksXsdSchema";
            this.lbXmlBreaksXsdSchema.Size = new System.Drawing.Size(105, 40);
            this.lbXmlBreaksXsdSchema.TabIndex = 11;
            this.lbXmlBreaksXsdSchema.Text = "Xml breaks XSD schema!!";
            this.lbXmlBreaksXsdSchema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lbXmlBreaksXsdSchema, "Click to view XSD errors");
            this.lbXmlBreaksXsdSchema.Visible = false;
            this.lbXmlBreaksXsdSchema.Click += new System.EventHandler(this.lbXmlBreaksXsdSchema_Click);
            // 
            // btSaveTarget
            // 
            this.btSaveTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveTarget.Location = new System.Drawing.Point(187, 22);
            this.btSaveTarget.Name = "btSaveTarget";
            this.btSaveTarget.Size = new System.Drawing.Size(98, 21);
            this.btSaveTarget.TabIndex = 3;
            this.btSaveTarget.Text = "Save Target";
            this.btSaveTarget.Click += new System.EventHandler(this.btSaveTarget_Click);
            // 
            // lblTargetsSaved
            // 
            this.lblTargetsSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTargetsSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetsSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTargetsSaved.Location = new System.Drawing.Point(125, 14);
            this.lblTargetsSaved.Name = "lblTargetsSaved";
            this.lblTargetsSaved.Size = new System.Drawing.Size(56, 37);
            this.lblTargetsSaved.TabIndex = 9;
            this.lblTargetsSaved.Text = "Targets Saved";
            this.lblTargetsSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTargetsSaved.Visible = false;
            // 
            // lbUnsavedData
            // 
            this.lbUnsavedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnsavedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnsavedData.ForeColor = System.Drawing.Color.Red;
            this.lbUnsavedData.Location = new System.Drawing.Point(119, 20);
            this.lbUnsavedData.Name = "lbUnsavedData";
            this.lbUnsavedData.Size = new System.Drawing.Size(62, 27);
            this.lbUnsavedData.TabIndex = 10;
            this.lbUnsavedData.Text = "Unsaved Data";
            this.lbUnsavedData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUnsavedData.Visible = false;
            // 
            // btnTargetImport
            // 
            this.btnTargetImport.AccessibleDescription = "Imports in targets from nmap Xml output";
            this.btnTargetImport.Location = new System.Drawing.Point(183, 13);
            this.btnTargetImport.Name = "btnTargetImport";
            this.btnTargetImport.Size = new System.Drawing.Size(106, 23);
            this.btnTargetImport.TabIndex = 12;
            this.btnTargetImport.Text = "Import Targets";
            this.btnTargetImport.UseVisualStyleBackColor = true;
            this.btnTargetImport.Click += new System.EventHandler(this.btnTargetImport_Click);
            // 
            // btDeleteSelectedTarget
            // 
            this.btDeleteSelectedTarget.Location = new System.Drawing.Point(16, 322);
            this.btDeleteSelectedTarget.Name = "btDeleteSelectedTarget";
            this.btDeleteSelectedTarget.Size = new System.Drawing.Size(160, 20);
            this.btDeleteSelectedTarget.TabIndex = 15;
            this.btDeleteSelectedTarget.Text = "Delete Selected Target";
            this.btDeleteSelectedTarget.Click += new System.EventHandler(this.btDeleteSelectedTarget_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btRenameTarget);
            this.groupBox2.Controls.Add(this.txtRenameTarget);
            this.groupBox2.Location = new System.Drawing.Point(16, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 64);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rename Target";
            // 
            // btRenameTarget
            // 
            this.btRenameTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRenameTarget.Location = new System.Drawing.Point(96, 40);
            this.btRenameTarget.Name = "btRenameTarget";
            this.btRenameTarget.Size = new System.Drawing.Size(56, 20);
            this.btRenameTarget.TabIndex = 1;
            this.btRenameTarget.Text = "Rename";
            this.btRenameTarget.Click += new System.EventHandler(this.btRenameTarget_Click);
            // 
            // txtRenameTarget
            // 
            this.txtRenameTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRenameTarget.Location = new System.Drawing.Point(8, 16);
            this.txtRenameTarget.Name = "txtRenameTarget";
            this.txtRenameTarget.Size = new System.Drawing.Size(143, 20);
            this.txtRenameTarget.TabIndex = 0;
            // 
            // axWebBrowserContentsOfProjectFolder
            // 
            this.axWebBrowserContentsOfProjectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axWebBrowserContentsOfProjectFolder.Location = new System.Drawing.Point(1, 22);
            this.axWebBrowserContentsOfProjectFolder.MinimumSize = new System.Drawing.Size(20, 20);
            this.axWebBrowserContentsOfProjectFolder.Name = "axWebBrowserContentsOfProjectFolder";
            this.axWebBrowserContentsOfProjectFolder.Size = new System.Drawing.Size(657, 162);
            this.axWebBrowserContentsOfProjectFolder.TabIndex = 16;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.txtTargetsSearchResults);
            this.groupBox4.Controls.Add(this.txtTargetsSearchQuery);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(16, 348);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 145);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search Targets";
            // 
            // txtTargetsSearchResults
            // 
            this.txtTargetsSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTargetsSearchResults.Location = new System.Drawing.Point(10, 76);
            this.txtTargetsSearchResults.Multiline = true;
            this.txtTargetsSearchResults.Name = "txtTargetsSearchResults";
            this.txtTargetsSearchResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTargetsSearchResults.Size = new System.Drawing.Size(144, 63);
            this.txtTargetsSearchResults.TabIndex = 1;
            this.txtTargetsSearchResults.WordWrap = false;
            // 
            // txtTargetsSearchQuery
            // 
            this.txtTargetsSearchQuery.Location = new System.Drawing.Point(10, 37);
            this.txtTargetsSearchQuery.Name = "txtTargetsSearchQuery";
            this.txtTargetsSearchQuery.Size = new System.Drawing.Size(144, 20);
            this.txtTargetsSearchQuery.TabIndex = 1;
            this.txtTargetsSearchQuery.TextChanged += new System.EventHandler(this.txtTargetsSearchQuery_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Results";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "DNS name or IP to search";
            // 
            // cbIgnoreStatusFlag
            // 
            this.cbIgnoreStatusFlag.AutoSize = true;
            this.cbIgnoreStatusFlag.Location = new System.Drawing.Point(185, 39);
            this.cbIgnoreStatusFlag.Name = "cbIgnoreStatusFlag";
            this.cbIgnoreStatusFlag.Size = new System.Drawing.Size(104, 17);
            this.cbIgnoreStatusFlag.TabIndex = 13;
            this.cbIgnoreStatusFlag.Text = "Ignore state=\'up\'";
            this.cbIgnoreStatusFlag.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Default Target Type";
            // 
            // txtDefaultTargetType
            // 
            this.txtDefaultTargetType.Location = new System.Drawing.Point(116, 16);
            this.txtDefaultTargetType.Name = "txtDefaultTargetType";
            this.txtDefaultTargetType.Size = new System.Drawing.Size(61, 20);
            this.txtDefaultTargetType.TabIndex = 15;
            // 
            // cbShowContentOfProjectFolder
            // 
            this.cbShowContentOfProjectFolder.AutoSize = true;
            this.cbShowContentOfProjectFolder.Location = new System.Drawing.Point(3, 4);
            this.cbShowContentOfProjectFolder.Name = "cbShowContentOfProjectFolder";
            this.cbShowContentOfProjectFolder.Size = new System.Drawing.Size(265, 17);
            this.cbShowContentOfProjectFolder.TabIndex = 19;
            this.cbShowContentOfProjectFolder.Text = "Show Contents of Project folder (in Explorer format)";
            this.cbShowContentOfProjectFolder.UseVisualStyleBackColor = true;
            this.cbShowContentOfProjectFolder.CheckedChanged += new System.EventHandler(this.cbShowContentOfProjectFolder_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnTargetImport);
            this.groupBox5.Controls.Add(this.txtDefaultTargetType);
            this.groupBox5.Controls.Add(this.cbIgnoreStatusFlag);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(192, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(300, 59);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Target\'s nMap Import Tool";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(192, 74);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.axAuthentic_Targets);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axWebBrowserContentsOfProjectFolder);
            this.splitContainer1.Panel2.Controls.Add(this.cbShowContentOfProjectFolder);
            this.splitContainer1.Size = new System.Drawing.Size(661, 418);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 20;
            // 
            // ascxTargets
            // 
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btDeleteSelectedTarget);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbTargetsInCurrentProject);
            this.Controls.Add(this.lbCurrentProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ascxTargets";
            this.Size = new System.Drawing.Size(864, 500);
            ((System.ComponentModel.ISupportInitialize)(this.axAuthentic_Targets)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void btAddNewTarget_Click(object sender, System.EventArgs e)
		{
            if (null == strFullPathToCurrentProject || "" == strFullPathToCurrentProject)
            {
                MessageBox.Show("There is no project selected!");
                return;
            }
			if ("" == txtNewTargetName.Text) 
				MessageBox.Show("New Target name cannot be empty!");
			else
			{
				VulnReportHelpers.createNewTargetAndAddItToListBox(lbTargetsInCurrentProject,
                                                                   txtNewTargetName.Text,
                                                                   strFullPathToCurrentProject);
                txtNewTargetName.Clear();
			}
		}

		public void loadProjectData(string strProjectToLoad)
		{
            checkForUnSavedDataAndPromptForSave();

            UserProfile up = UserProfile.GetUserProfile();
			axAuthentic_Targets.Visible = false;
			txtRenameTarget.Text="";
			btRenameTarget.Enabled = false;
			this.strCurrentProject = strProjectToLoad;
            this.strPathToProjectFiles = up.ProjectFilesPath; ;
			this.strPathToTempFileFolder = up.TempDirectoryPath;			
			strFullPathToCurrentProject = Path.GetFullPath(Path.Combine(strPathToProjectFiles, strCurrentProject));
			lbCurrentProject.Text = strCurrentProject ;
			loadTargetsIntoListBox();
            updateWebBrowserContentsOfProjectFolder();            
		}

        public void updateWebBrowserContentsOfProjectFolder()
        {
            if (true == cbShowContentOfProjectFolder.Checked)       // only show this window if this checkBox is selected
                axWebBrowserContentsOfProjectFolder.Navigate(strFullPathToCurrentProject);
        }

		private void loadTargetsIntoListBox()
		{
			utils.windowsForms.loadDirectoriesIntoListBox(lbTargetsInCurrentProject,strFullPathToCurrentProject,"*");
		}

		private void lbTargetsInCurrentProject_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (lbTargetsInCurrentProject.SelectedItem != null)
            {
                axAuthentic_Targets.Visible = true;
                strFullPathToSelectedTarget = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject, lbTargetsInCurrentProject.SelectedItem.ToString()));

                string strSelectedTarget = lbTargetsInCurrentProject.SelectedItem.ToString();
                string strXmlFileToLoad = Path.GetFileNameWithoutExtension(strSelectedTarget) + ".xml";
                this.strPathToTargetXmlFile = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject, Path.Combine(strSelectedTarget, strXmlFileToLoad)));
                utils.authentic.loadXmlFileInTargetAuthenticView(axAuthentic_Targets, strPathToTargetXmlFile, obpPaths.ProjectSchemaPath, obpPaths.SpsTargetTasksPath);
                axAuthentic_Targets.SetUnmodified();
                lbUnsavedData.Visible = false;
                unsavedDataExists = false;
                txtRenameTarget.Text = strSelectedTarget;
                btRenameTarget.Enabled = true;
                // Check if the current file breaks the schema but don't show MessageBox
                new utils.xml.xsdVerification(strPathToTargetXmlFile, obpPaths.ProjectSchemaPath, lbXmlBreaksXsdSchema, false);
            }
		}

		private void btSaveTarget_Click(object sender, System.EventArgs e)
		{
            saveCurrentData();			
			lblTargetsSaved.Visible= true;
			lbUnsavedData.Visible= false;
            unsavedDataExists = false;

            // Check if the current file breaks the schema and show MessageBox
            new utils.xml.xsdVerification(strPathToTargetXmlFile, obpPaths.ProjectSchemaPath, lbXmlBreaksXsdSchema, true);
		}

		private void btDeleteSelectedTarget_Click(object sender, System.EventArgs e)
		{
			if (DialogResult.Yes ==  MessageBox.Show("Are you sure you want to delete the Target '" + lbTargetsInCurrentProject.SelectedItem.ToString() + "'","Delete confirmation Message",MessageBoxButtons.YesNo))
			{
				utils.files.deleteAllFilesInDirectory(strFullPathToSelectedTarget);
				if (Directory.Exists(strFullPathToSelectedTarget))
					Directory.Delete(strFullPathToSelectedTarget);
				loadProjectData(this.strCurrentProject); 
			}
			
		}

		private void axAuthentic_Targets_SelectionChanged(object sender, System.EventArgs e)
		{
			axAuthentic_Targets.Select();
			lblTargetsSaved.Visible = false;
            if (axAuthentic_Targets.Modified)
            {
                lbUnsavedData.Visible = true;
                unsavedDataExists = true;
            }
		}

		private void btRenameTarget_Click(object sender, System.EventArgs e)
		{
			string strFullPathToOriginalTargetName = "";
			string strFullPathToRenamedTargetName = "";
			try
			{
				strFullPathToOriginalTargetName = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject,lbTargetsInCurrentProject.SelectedItem.ToString()));
				strFullPathToRenamedTargetName = Path.GetFullPath(Path.Combine(strFullPathToCurrentProject,txtRenameTarget.Text));
				Directory.Move(strFullPathToOriginalTargetName,strFullPathToRenamedTargetName);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not rename the directory:" +  strFullPathToOriginalTargetName + " : " + ex.Message);
				return;
			}
			string strFullPathToOriginalTargetXmlFileName = "";
			try
			{
				strFullPathToOriginalTargetXmlFileName = Path.Combine(strFullPathToRenamedTargetName, Path.GetFileNameWithoutExtension( lbTargetsInCurrentProject.SelectedItem.ToString()) + ".xml"); 
				string strFullPathToRenamedTargetXmlFileName = Path.Combine(strFullPathToRenamedTargetName, Path.GetFileNameWithoutExtension(txtRenameTarget.Text) + ".xml");
				File.Move(strFullPathToOriginalTargetXmlFileName,strFullPathToRenamedTargetXmlFileName);
			}
			catch (IOException ex)
			{
				MessageBox.Show("Could not rename the file:" +  strFullPathToOriginalTargetXmlFileName + " : " + ex.Message);
				return;
			}
			loadTargetsIntoListBox();
		}

        /// <summary>
        /// This method loads up an xml file to import for the targets list.
        /// 
        /// Precondition: The xml file is in the format of Nmap's xml output file.  
        /// </summary>
        /// <param name="sender">The object that called this method</param>
        /// <param name="e">The data related to the click event</param>
        private void btnTargetImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog odTarget = new OpenFileDialog();
            odTarget.Filter = "XML files(*.xml)|*.xml";
            odTarget.CheckFileExists = true;
            if (DialogResult.OK == odTarget.ShowDialog())
            {
                XmlReader xrTargets = XmlReader.Create(odTarget.FileName);
                XmlDocument xdImport = new XmlDocument();
                xdImport.Load(xrTargets);
                LoadTargetsFromXml(xdImport);
                lbTargetsInCurrentProject_SelectedIndexChanged(sender, e);
            }
        }

        /// <summary>
        /// This method sets up all the tool tips for the targets user control.
        /// </summary>
        private void SetupToolTips()
        {
            // TODO: Add in more tool tips..
            targetToolTips.SetToolTip(btnTargetImport, "This allows targets to be imported from nmap's XML output");
        }

        /// <summary>
        /// This methods loads entries into the targets area based off of status up.  If the value
        /// for the host node is up then all of the hostnames will be added.
        /// </summary>
        /// <param name="xdToImport"></param>
        private void LoadTargetsFromXml(XmlDocument xdToImport)
        {
            int iNumberOfTargetsImported = 0;
            int iNumberOfTargetsIgnored = 0;
            int iNumberOfDuplicatedTargets = 0;
            string strNameOfDuplicateFindings = "";
            XmlNode xnHost;
            XmlNodeList xnlHostList;
            xnlHostList = xdToImport.GetElementsByTagName("host");
            if (xnlHostList.Count == 0)
                MessageBox.Show("Alert: there are no hosts to import in this file");
            else
            {
                for (int i = 0; i < xnlHostList.Count; i++)
                {
                    xnHost = xnlHostList[i];
                    if (xnHost.HasChildNodes)
                    {
                        // Make sure the host was actually up when the scan was ran
                        if (null != xnHost.SelectSingleNode("status[@state='up']") || cbIgnoreStatusFlag.Checked == true)
                        {
                            XmlNodeList xnlAddresses = xnHost.SelectNodes("address");
                            if (xnlAddresses.Count > 0)
                            {
                                for (int j = 0; j < xnlAddresses.Count; j++)
                                {
                                    XmlAttribute xaAddress = (XmlAttribute)xnlAddresses[j].Attributes.GetNamedItem("addr");
                                    if (xaAddress.Value != "")
                                    {
                                        string sanitizedHost = xaAddress.Value.Replace('.', '_');
                                        if (true == lbTargetsInCurrentProject.Items.Contains(sanitizedHost))
                                        {
                                            iNumberOfDuplicatedTargets++;
                                            strNameOfDuplicateFindings += sanitizedHost + ",";
                                        }
                                        else
                                        {
                                            VulnReportHelpers.createNewTargetAndAddItToListBox(lbTargetsInCurrentProject,
                                                                                           sanitizedHost,
                                                                                           strFullPathToCurrentProject);
                                            PopulateTargetInformation(xaAddress.Value, sanitizedHost, xnHost);
                                            iNumberOfTargetsImported++;
                                        }
                                    }
                                }
                            }
                        }
                        else
                            iNumberOfTargetsIgnored++;
                    }
                }
                string strImportReport ="NMAP Import completed." + Environment.NewLine;
                if (iNumberOfTargetsImported > 0)
                    strImportReport += string.Format(Environment.NewLine + "{0} hosts were imported", iNumberOfTargetsImported);
                if (iNumberOfTargetsIgnored > 0)
                    strImportReport += string.Format(Environment.NewLine + "{0} hosts were NOT imported because: null== status[@state='up']", iNumberOfTargetsIgnored);
                if (iNumberOfDuplicatedTargets > 0)
                    strImportReport += string.Format(Environment.NewLine + "{0} hosts were NOT imported because they were duplicate of existing targets. Here is the list of those items: {1}", iNumberOfDuplicatedTargets, strNameOfDuplicateFindings.Substring(0,strNameOfDuplicateFindings.Length -1));

                MessageBox.Show(strImportReport);
            }
        }

        /// <summary>
        /// This method populates the information for a target node from an Nmap Xml results file.  
        /// It will populate the IP address and the host name.
        /// </summary>
        /// <param name="hostName">The value we wish to put in the target.name attribute</param>
        /// <param name="sanitizedHostName">A sanitized version of the host name.  It is considered 
        /// sanitized when there are no periods in the name.</param>
        /// <param name="xnHost">The host node from the nmap import xml file</param>
        /// 
        /// History: 
        /// 26/6/2007 - Mike Woodhead:  Changed the order of the function to Add the ip address before the DNSname 
        ///                             as it was causing schema errors when saving.
        /// 
        private void PopulateTargetInformation(string hostName, string sanitizedHostName, XmlNode xnHost)
        {
            // Load the xml file now and put in the host name and IP Address if available.
            string sTargetXmlPath = Path.Combine(strFullPathToCurrentProject, sanitizedHostName);
            sTargetXmlPath = Path.Combine(sTargetXmlPath, sanitizedHostName + ".xml");
            XmlDocument xdTarget = new XmlDocument();
            xdTarget.Load(sTargetXmlPath);
            // Add name
            XmlNode xnTarget = xdTarget.CreateElement("Target", "vuln_report");
            XmlAttribute xaName = xdTarget.CreateAttribute("name");
            xaName.Value = hostName;
            xnTarget.Attributes.Append(xaName);
            // Add Target type
            if (txtDefaultTargetType.Text != "")
            {
                XmlAttribute xaTestType = xdTarget.CreateAttribute("type");
                xaTestType.Value = txtDefaultTargetType.Text;
                xnTarget.Attributes.Append(xaTestType);
            }

            // Get the IP address
            XmlNode xnIpAddress = xnHost.SelectSingleNode("address[@addrtype='ipv4']");
            if (xnIpAddress != null)
            {
                XmlAttribute xaIpAddress = (XmlAttribute)xnIpAddress.Attributes.GetNamedItem("addr");
                XmlNode xnNewIpAddress = xdTarget.CreateElement("IP", "vuln_report");
                XmlAttribute xaIpValue = xdTarget.CreateAttribute("value");
                xaIpValue.Value = xaIpAddress.Value;
                xnNewIpAddress.Attributes.Append(xaIpValue);
                xnTarget.AppendChild(xnNewIpAddress);
            }

            // Add the DNS name
            XmlNode xnDnsName = xdTarget.CreateElement("DnsName", "vuln_report");
            XmlAttribute xaDnsNameValue = xdTarget.CreateAttribute("value");
            xaDnsNameValue.Value = hostName;
            xnDnsName.Attributes.Append(xaDnsNameValue);
            xnTarget.AppendChild(xnDnsName);

            XmlNodeList xnlTmp = xdTarget.GetElementsByTagName("Targets");
            if (xnlTmp.Count == 0)
            {
                // we need to add in the Targets node
                XmlNode xnTargets = xdTarget.CreateElement("Targets", "vuln_report");
                xnTargets.AppendChild(xnTarget);
                xdTarget.DocumentElement.AppendChild(xnTarget);

            }
            else
            {
                XmlNode xnTargets = xnlTmp[0];
                xnTargets.AppendChild(xnTarget);
            }
            XmlWriter xwTarget = XmlWriter.Create(sTargetXmlPath);
            xdTarget.WriteTo(xwTarget);
            xwTarget.Flush();
            xwTarget.Close();
        }

        /// <summary>
        /// This method asks the user if they wish to save there data if they do then
        /// it saves it for them.  
        /// </summary>
        private void promptUserToSaveData()
        {
            if (MessageBox.Show("Unsaved data exists do you wish to save it?",
                                "Unsaved Data", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                saveCurrentData();
            }
        }

        /// <summary>
        /// This saves the data currently in altova component.
        /// </summary>
        private void saveCurrentData()
        {
            axAuthentic_Targets.Save();
        }

        /// <summary>
        /// This method checks to see if there is any unsaved data for the user and if 
        /// there is then we ask the user if they want the data saved.
        /// </summary>
        public void checkForUnSavedDataAndPromptForSave()
        {
            if (unsavedDataExists)
            {
                promptUserToSaveData();
            }
        }

        private void txtTargetsSearchQuery_TextChanged(object sender, EventArgs e)
        {
            txtTargetsSearchQuery.Enabled = false;
            txtTargetsSearchResults.Text = "";
            foreach (string strDirectory in Directory.GetDirectories(strFullPathToCurrentProject))
            {
                if ("_" != strDirectory.Substring(1, 1)) // ignore targets that start with _
                { 
                    string strTargetXmlFile = Path.Combine(strDirectory,Path.GetFileName(strDirectory)+".xml");
                    if (true == File.Exists(strTargetXmlFile))
                    { 
                        string strFileContents = utils.files.GetFileContents(strTargetXmlFile);
                        if (true == strFileContents.Contains(txtTargetsSearchQuery.Text))
                        {
                            txtTargetsSearchResults.Text = Path.GetFileName(strDirectory) + Environment.NewLine + txtTargetsSearchResults.Text;
                        }
                    }
                    Application.DoEvents();
                }
            }
            txtTargetsSearchQuery.Enabled = true;
        }

        private void cbShowContentOfProjectFolder_CheckedChanged(object sender, EventArgs e)
        {
            axWebBrowserContentsOfProjectFolder.Visible = cbShowContentOfProjectFolder.Checked;
            updateWebBrowserContentsOfProjectFolder();
        }

        private void lbXmlBreaksXsdSchema_Click(object sender, EventArgs e)
        {
            new utils.xml.xsdVerification(strPathToTargetXmlFile, obpPaths.ProjectSchemaPath, lbXmlBreaksXsdSchema, true);
        }

        public void configVariablesForKeyboardHook()
        {
            if ((authUtils.CurrentKeyboardHook == null) || (!authUtils.CurrentKeyboardHook.IsInstalled))
                authUtils.installKeyboardHookInCurrentThread();
            authUtils.AuthenticObject = axAuthentic_Targets;
            authUtils.CurrentControl = (ContainerControl)this;

        }
	}
}
