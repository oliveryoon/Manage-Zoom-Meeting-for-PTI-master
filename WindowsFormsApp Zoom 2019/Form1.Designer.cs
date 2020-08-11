namespace WindowsFormsApp_Zoom_2019
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnGetMeetings = new System.Windows.Forms.Button();
            this.btnCreateMeeting = new System.Windows.Forms.Button();
            this.btnUpdateMeetings = new System.Windows.Forms.Button();
            this.btnDeleteMeetings = new System.Windows.Forms.Button();
            this.btnImportUsersToSynergetic = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.lblUpdated = new System.Windows.Forms.Label();
            this.lblProcessed = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dtpPTI = new System.Windows.Forms.DateTimePicker();
            this.chkDeleteExistingMeeting = new System.Windows.Forms.CheckBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtMeetingTopic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBarSimple = new System.Windows.Forms.ProgressBar();
            this.lblJwtToken = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblMeetingDuration = new System.Windows.Forms.Label();
            this.lblMeetingTimeZone = new System.Windows.Forms.Label();
            this.lblMeetingAgenda = new System.Windows.Forms.Label();
            this.lblHostVideo = new System.Windows.Forms.Label();
            this.lblParticipantVideo = new System.Windows.Forms.Label();
            this.lblApprovalType = new System.Windows.Forms.Label();
            this.btnRefreshConfig = new System.Windows.Forms.Button();
            this.txtJWTToken = new System.Windows.Forms.TextBox();
            this.txtMeetingDuration = new System.Windows.Forms.TextBox();
            this.txtTimeZone = new System.Windows.Forms.TextBox();
            this.txtMeetingAgenda = new System.Windows.Forms.TextBox();
            this.rbHostVideoYes = new System.Windows.Forms.RadioButton();
            this.rbHostVideoNo = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfigurationExpand = new System.Windows.Forms.Button();
            this.txtMeetingTopicFromDB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMeetingStartTime = new System.Windows.Forms.TextBox();
            this.lblMeetingType = new System.Windows.Forms.Label();
            this.ddlMeetingType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtScheduleFor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.gbHostVideo = new System.Windows.Forms.GroupBox();
            this.gbParticipantVideo = new System.Windows.Forms.GroupBox();
            this.rbPartticipantVideoYes = new System.Windows.Forms.RadioButton();
            this.rbPartticipantVideoNo = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.rbJoinBeforeHostYes = new System.Windows.Forms.RadioButton();
            this.gbJoinBeforeHost = new System.Windows.Forms.GroupBox();
            this.rbJoinBeforeHostNo = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.rbMuteUponEntryYes = new System.Windows.Forms.RadioButton();
            this.rbMuteUponEntryNo = new System.Windows.Forms.RadioButton();
            this.gbMuteUponEntry = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.rbWaterMarkYes = new System.Windows.Forms.RadioButton();
            this.gbWaterMark = new System.Windows.Forms.GroupBox();
            this.rbWaterMarkNo = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.rbUsePMIYes = new System.Windows.Forms.RadioButton();
            this.gbUsePMI = new System.Windows.Forms.GroupBox();
            this.rbUsePMINo = new System.Windows.Forms.RadioButton();
            this.ddlApprovalType = new System.Windows.Forms.ComboBox();
            this.ddlRegistrationType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.ddlAudio = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.ddlAutoRecording = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtAlternativeHosts = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.gbCloseRegistration = new System.Windows.Forms.GroupBox();
            this.rbCloseRegistrationYes = new System.Windows.Forms.RadioButton();
            this.rbCloseRegistrationNo = new System.Windows.Forms.RadioButton();
            this.label25 = new System.Windows.Forms.Label();
            this.gbWaitingRoom = new System.Windows.Forms.GroupBox();
            this.rbWaitingRoomYes = new System.Windows.Forms.RadioButton();
            this.rbWaitingRoomNo = new System.Windows.Forms.RadioButton();
            this.txtGlobalDialCountries = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtcontactName = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnConfigurationShrink = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.gbMeetingAuthentication = new System.Windows.Forms.GroupBox();
            this.rbMeetingAuthenticationYes = new System.Windows.Forms.RadioButton();
            this.rbMeetingAuthenticationNo = new System.Windows.Forms.RadioButton();
            this.label29 = new System.Windows.Forms.Label();
            this.gbRegistrationEmailNotification = new System.Windows.Forms.GroupBox();
            this.rbRegistrantsEmailNotificationYes = new System.Windows.Forms.RadioButton();
            this.rbRegistrantsEmailNotificationNo = new System.Windows.Forms.RadioButton();
            this.txtAuthenticationDomains = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtAuthenticationOption = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtContactEmail = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.dtpPTIFromDB = new System.Windows.Forms.DateTimePicker();
            this.txtEnforceLoginDomains = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.gbEnforceLogin = new System.Windows.Forms.GroupBox();
            this.rbEnforceLoginYes = new System.Windows.Forms.RadioButton();
            this.rbEnforceLoginNo = new System.Windows.Forms.RadioButton();
            this.label34 = new System.Windows.Forms.Label();
            this.gbCreateNewSchedule = new System.Windows.Forms.GroupBox();
            this.rbCreateNewScheduleYes = new System.Windows.Forms.RadioButton();
            this.rbCreateNewScheduleNo = new System.Windows.Forms.RadioButton();
            this.label35 = new System.Windows.Forms.Label();
            this.txtScheduleSeq = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbHostVideo.SuspendLayout();
            this.gbParticipantVideo.SuspendLayout();
            this.gbJoinBeforeHost.SuspendLayout();
            this.gbMuteUponEntry.SuspendLayout();
            this.gbWaterMark.SuspendLayout();
            this.gbUsePMI.SuspendLayout();
            this.gbCloseRegistration.SuspendLayout();
            this.gbWaitingRoom.SuspendLayout();
            this.gbMeetingAuthentication.SuspendLayout();
            this.gbRegistrationEmailNotification.SuspendLayout();
            this.gbEnforceLogin.SuspendLayout();
            this.gbCreateNewSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(336, 239);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(417, 239);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Visible = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(255, 239);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnGetMeetings
            // 
            this.btnGetMeetings.Location = new System.Drawing.Point(13, 385);
            this.btnGetMeetings.Name = "btnGetMeetings";
            this.btnGetMeetings.Size = new System.Drawing.Size(219, 23);
            this.btnGetMeetings.TabIndex = 3;
            this.btnGetMeetings.Text = "Validate Meetings";
            this.btnGetMeetings.UseVisualStyleBackColor = true;
            this.btnGetMeetings.Click += new System.EventHandler(this.btnGetMeetings_Click);
            // 
            // btnCreateMeeting
            // 
            this.btnCreateMeeting.Location = new System.Drawing.Point(3, 26);
            this.btnCreateMeeting.Name = "btnCreateMeeting";
            this.btnCreateMeeting.Size = new System.Drawing.Size(219, 23);
            this.btnCreateMeeting.TabIndex = 4;
            this.btnCreateMeeting.Text = "Create Meetings";
            this.btnCreateMeeting.UseVisualStyleBackColor = true;
            this.btnCreateMeeting.Click += new System.EventHandler(this.btnCreateMeeting_Click);
            // 
            // btnUpdateMeetings
            // 
            this.btnUpdateMeetings.Location = new System.Drawing.Point(14, 322);
            this.btnUpdateMeetings.Name = "btnUpdateMeetings";
            this.btnUpdateMeetings.Size = new System.Drawing.Size(219, 23);
            this.btnUpdateMeetings.TabIndex = 5;
            this.btnUpdateMeetings.Text = "Update Meetings";
            this.btnUpdateMeetings.UseVisualStyleBackColor = true;
            this.btnUpdateMeetings.Click += new System.EventHandler(this.btnUpdateMeetings_Click);
            // 
            // btnDeleteMeetings
            // 
            this.btnDeleteMeetings.Location = new System.Drawing.Point(13, 353);
            this.btnDeleteMeetings.Name = "btnDeleteMeetings";
            this.btnDeleteMeetings.Size = new System.Drawing.Size(219, 23);
            this.btnDeleteMeetings.TabIndex = 6;
            this.btnDeleteMeetings.Text = "Delete Meetings";
            this.btnDeleteMeetings.UseVisualStyleBackColor = true;
            this.btnDeleteMeetings.Click += new System.EventHandler(this.btnDeleteMeetings_Click);
            // 
            // btnImportUsersToSynergetic
            // 
            this.btnImportUsersToSynergetic.Location = new System.Drawing.Point(498, 239);
            this.btnImportUsersToSynergetic.Name = "btnImportUsersToSynergetic";
            this.btnImportUsersToSynergetic.Size = new System.Drawing.Size(143, 23);
            this.btnImportUsersToSynergetic.TabIndex = 7;
            this.btnImportUsersToSynergetic.Text = "Import User to Synergetic";
            this.btnImportUsersToSynergetic.UseVisualStyleBackColor = true;
            this.btnImportUsersToSynergetic.Visible = false;
            this.btnImportUsersToSynergetic.Click += new System.EventHandler(this.btnImportUsersToSynergetic_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(10, 194);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(227, 23);
            this.progressBar.TabIndex = 9;
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(262, 4);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(368, 407);
            this.lstResults.TabIndex = 10;
            // 
            // lblUpdated
            // 
            this.lblUpdated.AutoSize = true;
            this.lblUpdated.Location = new System.Drawing.Point(152, 149);
            this.lblUpdated.Name = "lblUpdated";
            this.lblUpdated.Size = new System.Drawing.Size(47, 13);
            this.lblUpdated.TabIndex = 12;
            this.lblUpdated.Text = "Created:";
            // 
            // lblProcessed
            // 
            this.lblProcessed.AutoSize = true;
            this.lblProcessed.Location = new System.Drawing.Point(70, 149);
            this.lblProcessed.Name = "lblProcessed";
            this.lblProcessed.Size = new System.Drawing.Size(63, 13);
            this.lblProcessed.TabIndex = 13;
            this.lblProcessed.Text = "Processed: ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(11, 149);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Total:";
            // 
            // dtpPTI
            // 
            this.dtpPTI.AllowDrop = true;
            this.dtpPTI.Location = new System.Drawing.Point(799, 150);
            this.dtpPTI.Name = "dtpPTI";
            this.dtpPTI.Size = new System.Drawing.Size(227, 20);
            this.dtpPTI.TabIndex = 15;
            // 
            // chkDeleteExistingMeeting
            // 
            this.chkDeleteExistingMeeting.AutoSize = true;
            this.chkDeleteExistingMeeting.Location = new System.Drawing.Point(2, 3);
            this.chkDeleteExistingMeeting.Name = "chkDeleteExistingMeeting";
            this.chkDeleteExistingMeeting.Size = new System.Drawing.Size(159, 17);
            this.chkDeleteExistingMeeting.TabIndex = 16;
            this.chkDeleteExistingMeeting.Text = "Delete existing meetings first";
            this.chkDeleteExistingMeeting.UseVisualStyleBackColor = true;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(10, 224);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(225, 13);
            this.lblMsg.TabIndex = 17;
            this.lblMsg.Text = "Do not interupt the program until it is complete.";
            this.lblMsg.Visible = false;
            // 
            // txtMeetingTopic
            // 
            this.txtMeetingTopic.Location = new System.Drawing.Point(799, 61);
            this.txtMeetingTopic.Name = "txtMeetingTopic";
            this.txtMeetingTopic.Size = new System.Drawing.Size(590, 20);
            this.txtMeetingTopic.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Meeting Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Meeting Topic";
            // 
            // progressBarSimple
            // 
            this.progressBarSimple.Location = new System.Drawing.Point(10, 166);
            this.progressBarSimple.Name = "progressBarSimple";
            this.progressBarSimple.Size = new System.Drawing.Size(227, 23);
            this.progressBarSimple.TabIndex = 21;
            // 
            // lblJwtToken
            // 
            this.lblJwtToken.AutoSize = true;
            this.lblJwtToken.Location = new System.Drawing.Point(681, 39);
            this.lblJwtToken.Name = "lblJwtToken";
            this.lblJwtToken.Size = new System.Drawing.Size(68, 13);
            this.lblJwtToken.TabIndex = 22;
            this.lblJwtToken.Text = "JWT Token*";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(681, 130);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(59, 13);
            this.lblStartTime.TabIndex = 23;
            this.lblStartTime.Text = "Start Time*";
            // 
            // lblMeetingDuration
            // 
            this.lblMeetingDuration.AutoSize = true;
            this.lblMeetingDuration.Location = new System.Drawing.Point(681, 193);
            this.lblMeetingDuration.Name = "lblMeetingDuration";
            this.lblMeetingDuration.Size = new System.Drawing.Size(92, 13);
            this.lblMeetingDuration.TabIndex = 25;
            this.lblMeetingDuration.Text = "Meeting Duration*";
            // 
            // lblMeetingTimeZone
            // 
            this.lblMeetingTimeZone.AutoSize = true;
            this.lblMeetingTimeZone.Location = new System.Drawing.Point(681, 246);
            this.lblMeetingTimeZone.Name = "lblMeetingTimeZone";
            this.lblMeetingTimeZone.Size = new System.Drawing.Size(103, 13);
            this.lblMeetingTimeZone.TabIndex = 26;
            this.lblMeetingTimeZone.Text = "Meeting Time Zone*";
            // 
            // lblMeetingAgenda
            // 
            this.lblMeetingAgenda.AutoSize = true;
            this.lblMeetingAgenda.Location = new System.Drawing.Point(681, 298);
            this.lblMeetingAgenda.Name = "lblMeetingAgenda";
            this.lblMeetingAgenda.Size = new System.Drawing.Size(85, 13);
            this.lblMeetingAgenda.TabIndex = 27;
            this.lblMeetingAgenda.Text = "Meeting Agenda";
            // 
            // lblHostVideo
            // 
            this.lblHostVideo.AutoSize = true;
            this.lblHostVideo.Location = new System.Drawing.Point(681, 347);
            this.lblHostVideo.Name = "lblHostVideo";
            this.lblHostVideo.Size = new System.Drawing.Size(59, 13);
            this.lblHostVideo.TabIndex = 28;
            this.lblHostVideo.Text = "Host Video";
            // 
            // lblParticipantVideo
            // 
            this.lblParticipantVideo.AutoSize = true;
            this.lblParticipantVideo.Location = new System.Drawing.Point(1003, 345);
            this.lblParticipantVideo.Name = "lblParticipantVideo";
            this.lblParticipantVideo.Size = new System.Drawing.Size(84, 13);
            this.lblParticipantVideo.TabIndex = 29;
            this.lblParticipantVideo.Text = "Paticipant Video";
            // 
            // lblApprovalType
            // 
            this.lblApprovalType.AutoSize = true;
            this.lblApprovalType.Location = new System.Drawing.Point(681, 422);
            this.lblApprovalType.Name = "lblApprovalType";
            this.lblApprovalType.Size = new System.Drawing.Size(80, 13);
            this.lblApprovalType.TabIndex = 30;
            this.lblApprovalType.Text = "Approval Type*";
            // 
            // btnRefreshConfig
            // 
            this.btnRefreshConfig.Location = new System.Drawing.Point(798, 780);
            this.btnRefreshConfig.Name = "btnRefreshConfig";
            this.btnRefreshConfig.Size = new System.Drawing.Size(129, 23);
            this.btnRefreshConfig.TabIndex = 39;
            this.btnRefreshConfig.Text = "Refresh";
            this.btnRefreshConfig.UseVisualStyleBackColor = true;
            this.btnRefreshConfig.Click += new System.EventHandler(this.btnRefreshConfig_Click);
            // 
            // txtJWTToken
            // 
            this.txtJWTToken.Location = new System.Drawing.Point(799, 39);
            this.txtJWTToken.Name = "txtJWTToken";
            this.txtJWTToken.Size = new System.Drawing.Size(397, 20);
            this.txtJWTToken.TabIndex = 40;
            // 
            // txtMeetingDuration
            // 
            this.txtMeetingDuration.Location = new System.Drawing.Point(799, 189);
            this.txtMeetingDuration.Name = "txtMeetingDuration";
            this.txtMeetingDuration.Size = new System.Drawing.Size(199, 20);
            this.txtMeetingDuration.TabIndex = 43;
            // 
            // txtTimeZone
            // 
            this.txtTimeZone.Location = new System.Drawing.Point(799, 243);
            this.txtTimeZone.Name = "txtTimeZone";
            this.txtTimeZone.ReadOnly = true;
            this.txtTimeZone.Size = new System.Drawing.Size(199, 20);
            this.txtTimeZone.TabIndex = 44;
            // 
            // txtMeetingAgenda
            // 
            this.txtMeetingAgenda.Location = new System.Drawing.Point(799, 295);
            this.txtMeetingAgenda.Name = "txtMeetingAgenda";
            this.txtMeetingAgenda.Size = new System.Drawing.Size(199, 20);
            this.txtMeetingAgenda.TabIndex = 45;
            // 
            // rbHostVideoYes
            // 
            this.rbHostVideoYes.AutoSize = true;
            this.rbHostVideoYes.Location = new System.Drawing.Point(6, 7);
            this.rbHostVideoYes.Name = "rbHostVideoYes";
            this.rbHostVideoYes.Size = new System.Drawing.Size(43, 17);
            this.rbHostVideoYes.TabIndex = 49;
            this.rbHostVideoYes.TabStop = true;
            this.rbHostVideoYes.Text = "Yes";
            this.rbHostVideoYes.UseVisualStyleBackColor = true;
            // 
            // rbHostVideoNo
            // 
            this.rbHostVideoNo.AutoSize = true;
            this.rbHostVideoNo.Location = new System.Drawing.Point(55, 7);
            this.rbHostVideoNo.Name = "rbHostVideoNo";
            this.rbHostVideoNo.Size = new System.Drawing.Size(39, 17);
            this.rbHostVideoNo.TabIndex = 50;
            this.rbHostVideoNo.TabStop = true;
            this.rbHostVideoNo.Text = "No";
            this.rbHostVideoNo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCreateMeeting);
            this.panel1.Controls.Add(this.chkDeleteExistingMeeting);
            this.panel1.Location = new System.Drawing.Point(10, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 57);
            this.panel1.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 22);
            this.label3.TabIndex = 52;
            this.label3.Text = "Set Synergetic Tag List First";
            // 
            // btnConfigurationExpand
            // 
            this.btnConfigurationExpand.Location = new System.Drawing.Point(636, 13);
            this.btnConfigurationExpand.Name = "btnConfigurationExpand";
            this.btnConfigurationExpand.Size = new System.Drawing.Size(36, 30);
            this.btnConfigurationExpand.TabIndex = 53;
            this.btnConfigurationExpand.Text = ">>";
            this.btnConfigurationExpand.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfigurationExpand.UseVisualStyleBackColor = true;
            this.btnConfigurationExpand.Click += new System.EventHandler(this.btnConfigurationExpand_Click);
            // 
            // txtMeetingTopicFromDB
            // 
            this.txtMeetingTopicFromDB.Location = new System.Drawing.Point(14, 96);
            this.txtMeetingTopicFromDB.Name = "txtMeetingTopicFromDB";
            this.txtMeetingTopicFromDB.ReadOnly = true;
            this.txtMeetingTopicFromDB.Size = new System.Drawing.Size(242, 20);
            this.txtMeetingTopicFromDB.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(681, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Meeting Topic*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(799, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(291, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "This topic is one stored in DB. eg. {Staff Name} PTI Meeting";
            // 
            // txtMeetingStartTime
            // 
            this.txtMeetingStartTime.Location = new System.Drawing.Point(799, 127);
            this.txtMeetingStartTime.Name = "txtMeetingStartTime";
            this.txtMeetingStartTime.Size = new System.Drawing.Size(199, 20);
            this.txtMeetingStartTime.TabIndex = 58;
            // 
            // lblMeetingType
            // 
            this.lblMeetingType.AutoSize = true;
            this.lblMeetingType.Location = new System.Drawing.Point(681, 105);
            this.lblMeetingType.Name = "lblMeetingType";
            this.lblMeetingType.Size = new System.Drawing.Size(76, 13);
            this.lblMeetingType.TabIndex = 57;
            this.lblMeetingType.Text = "Meeting Type*";
            // 
            // ddlMeetingType
            // 
            this.ddlMeetingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMeetingType.FormattingEnabled = true;
            this.ddlMeetingType.Location = new System.Drawing.Point(799, 102);
            this.ddlMeetingType.Name = "ddlMeetingType";
            this.ddlMeetingType.Size = new System.Drawing.Size(397, 21);
            this.ddlMeetingType.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(681, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Start Date*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(799, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Meeting Date stored in DB.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1006, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "HH:mm:ss eg. 23:59:59";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1006, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "in minutes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1006, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(183, 13);
            this.label10.TabIndex = 66;
            this.label10.Text = "Meeting oragnised for someone else?";
            // 
            // txtScheduleFor
            // 
            this.txtScheduleFor.Location = new System.Drawing.Point(799, 215);
            this.txtScheduleFor.Name = "txtScheduleFor";
            this.txtScheduleFor.Size = new System.Drawing.Size(199, 20);
            this.txtScheduleFor.TabIndex = 65;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(681, 219);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 64;
            this.label11.Text = "Schedule For";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1006, 246);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "Australia Eastern Time Zone";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(799, 269);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(199, 20);
            this.txtPassword.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(681, 276);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 68;
            this.label13.Text = "Password";
            // 
            // gbHostVideo
            // 
            this.gbHostVideo.Controls.Add(this.rbHostVideoYes);
            this.gbHostVideo.Controls.Add(this.rbHostVideoNo);
            this.gbHostVideo.Location = new System.Drawing.Point(793, 336);
            this.gbHostVideo.Name = "gbHostVideo";
            this.gbHostVideo.Size = new System.Drawing.Size(200, 27);
            this.gbHostVideo.TabIndex = 70;
            this.gbHostVideo.TabStop = false;
            // 
            // gbParticipantVideo
            // 
            this.gbParticipantVideo.Controls.Add(this.rbPartticipantVideoYes);
            this.gbParticipantVideo.Controls.Add(this.rbPartticipantVideoNo);
            this.gbParticipantVideo.Location = new System.Drawing.Point(1101, 336);
            this.gbParticipantVideo.Name = "gbParticipantVideo";
            this.gbParticipantVideo.Size = new System.Drawing.Size(200, 27);
            this.gbParticipantVideo.TabIndex = 71;
            this.gbParticipantVideo.TabStop = false;
            // 
            // rbPartticipantVideoYes
            // 
            this.rbPartticipantVideoYes.AutoSize = true;
            this.rbPartticipantVideoYes.Location = new System.Drawing.Point(6, 7);
            this.rbPartticipantVideoYes.Name = "rbPartticipantVideoYes";
            this.rbPartticipantVideoYes.Size = new System.Drawing.Size(43, 17);
            this.rbPartticipantVideoYes.TabIndex = 49;
            this.rbPartticipantVideoYes.TabStop = true;
            this.rbPartticipantVideoYes.Text = "Yes";
            this.rbPartticipantVideoYes.UseVisualStyleBackColor = true;
            // 
            // rbPartticipantVideoNo
            // 
            this.rbPartticipantVideoNo.AutoSize = true;
            this.rbPartticipantVideoNo.Location = new System.Drawing.Point(55, 7);
            this.rbPartticipantVideoNo.Name = "rbPartticipantVideoNo";
            this.rbPartticipantVideoNo.Size = new System.Drawing.Size(39, 17);
            this.rbPartticipantVideoNo.TabIndex = 50;
            this.rbPartticipantVideoNo.TabStop = true;
            this.rbPartticipantVideoNo.Text = "No";
            this.rbPartticipantVideoNo.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(681, 367);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 13);
            this.label14.TabIndex = 72;
            this.label14.Text = "Join Before Host";
            // 
            // rbJoinBeforeHostYes
            // 
            this.rbJoinBeforeHostYes.AutoSize = true;
            this.rbJoinBeforeHostYes.Location = new System.Drawing.Point(6, 7);
            this.rbJoinBeforeHostYes.Name = "rbJoinBeforeHostYes";
            this.rbJoinBeforeHostYes.Size = new System.Drawing.Size(43, 17);
            this.rbJoinBeforeHostYes.TabIndex = 49;
            this.rbJoinBeforeHostYes.TabStop = true;
            this.rbJoinBeforeHostYes.Text = "Yes";
            this.rbJoinBeforeHostYes.UseVisualStyleBackColor = true;
            // 
            // gbJoinBeforeHost
            // 
            this.gbJoinBeforeHost.Controls.Add(this.rbJoinBeforeHostYes);
            this.gbJoinBeforeHost.Controls.Add(this.rbJoinBeforeHostNo);
            this.gbJoinBeforeHost.Location = new System.Drawing.Point(793, 360);
            this.gbJoinBeforeHost.Name = "gbJoinBeforeHost";
            this.gbJoinBeforeHost.Size = new System.Drawing.Size(200, 27);
            this.gbJoinBeforeHost.TabIndex = 73;
            this.gbJoinBeforeHost.TabStop = false;
            // 
            // rbJoinBeforeHostNo
            // 
            this.rbJoinBeforeHostNo.AutoSize = true;
            this.rbJoinBeforeHostNo.Location = new System.Drawing.Point(55, 7);
            this.rbJoinBeforeHostNo.Name = "rbJoinBeforeHostNo";
            this.rbJoinBeforeHostNo.Size = new System.Drawing.Size(39, 17);
            this.rbJoinBeforeHostNo.TabIndex = 50;
            this.rbJoinBeforeHostNo.TabStop = true;
            this.rbJoinBeforeHostNo.Text = "No";
            this.rbJoinBeforeHostNo.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1003, 367);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 13);
            this.label15.TabIndex = 74;
            this.label15.Text = "Mute Upon Entry";
            // 
            // rbMuteUponEntryYes
            // 
            this.rbMuteUponEntryYes.AutoSize = true;
            this.rbMuteUponEntryYes.Location = new System.Drawing.Point(6, 7);
            this.rbMuteUponEntryYes.Name = "rbMuteUponEntryYes";
            this.rbMuteUponEntryYes.Size = new System.Drawing.Size(43, 17);
            this.rbMuteUponEntryYes.TabIndex = 49;
            this.rbMuteUponEntryYes.TabStop = true;
            this.rbMuteUponEntryYes.Text = "Yes";
            this.rbMuteUponEntryYes.UseVisualStyleBackColor = true;
            // 
            // rbMuteUponEntryNo
            // 
            this.rbMuteUponEntryNo.AutoSize = true;
            this.rbMuteUponEntryNo.Location = new System.Drawing.Point(54, 7);
            this.rbMuteUponEntryNo.Name = "rbMuteUponEntryNo";
            this.rbMuteUponEntryNo.Size = new System.Drawing.Size(39, 17);
            this.rbMuteUponEntryNo.TabIndex = 50;
            this.rbMuteUponEntryNo.TabStop = true;
            this.rbMuteUponEntryNo.Text = "No";
            this.rbMuteUponEntryNo.UseVisualStyleBackColor = true;
            // 
            // gbMuteUponEntry
            // 
            this.gbMuteUponEntry.Controls.Add(this.rbMuteUponEntryYes);
            this.gbMuteUponEntry.Controls.Add(this.rbMuteUponEntryNo);
            this.gbMuteUponEntry.Location = new System.Drawing.Point(1101, 360);
            this.gbMuteUponEntry.Name = "gbMuteUponEntry";
            this.gbMuteUponEntry.Size = new System.Drawing.Size(200, 27);
            this.gbMuteUponEntry.TabIndex = 75;
            this.gbMuteUponEntry.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(681, 393);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 76;
            this.label16.Text = "Watermark";
            // 
            // rbWaterMarkYes
            // 
            this.rbWaterMarkYes.AutoSize = true;
            this.rbWaterMarkYes.Location = new System.Drawing.Point(6, 7);
            this.rbWaterMarkYes.Name = "rbWaterMarkYes";
            this.rbWaterMarkYes.Size = new System.Drawing.Size(43, 17);
            this.rbWaterMarkYes.TabIndex = 49;
            this.rbWaterMarkYes.TabStop = true;
            this.rbWaterMarkYes.Text = "Yes";
            this.rbWaterMarkYes.UseVisualStyleBackColor = true;
            // 
            // gbWaterMark
            // 
            this.gbWaterMark.Controls.Add(this.rbWaterMarkYes);
            this.gbWaterMark.Controls.Add(this.rbWaterMarkNo);
            this.gbWaterMark.Location = new System.Drawing.Point(793, 386);
            this.gbWaterMark.Name = "gbWaterMark";
            this.gbWaterMark.Size = new System.Drawing.Size(200, 27);
            this.gbWaterMark.TabIndex = 77;
            this.gbWaterMark.TabStop = false;
            // 
            // rbWaterMarkNo
            // 
            this.rbWaterMarkNo.AutoSize = true;
            this.rbWaterMarkNo.Location = new System.Drawing.Point(55, 7);
            this.rbWaterMarkNo.Name = "rbWaterMarkNo";
            this.rbWaterMarkNo.Size = new System.Drawing.Size(39, 17);
            this.rbWaterMarkNo.TabIndex = 50;
            this.rbWaterMarkNo.TabStop = true;
            this.rbWaterMarkNo.Text = "No";
            this.rbWaterMarkNo.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1003, 393);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 78;
            this.label17.Text = "Use PMI";
            // 
            // rbUsePMIYes
            // 
            this.rbUsePMIYes.AutoSize = true;
            this.rbUsePMIYes.Location = new System.Drawing.Point(6, 7);
            this.rbUsePMIYes.Name = "rbUsePMIYes";
            this.rbUsePMIYes.Size = new System.Drawing.Size(43, 17);
            this.rbUsePMIYes.TabIndex = 49;
            this.rbUsePMIYes.TabStop = true;
            this.rbUsePMIYes.Text = "Yes";
            this.rbUsePMIYes.UseVisualStyleBackColor = true;
            // 
            // gbUsePMI
            // 
            this.gbUsePMI.Controls.Add(this.rbUsePMIYes);
            this.gbUsePMI.Controls.Add(this.rbUsePMINo);
            this.gbUsePMI.Location = new System.Drawing.Point(1100, 386);
            this.gbUsePMI.Name = "gbUsePMI";
            this.gbUsePMI.Size = new System.Drawing.Size(200, 27);
            this.gbUsePMI.TabIndex = 79;
            this.gbUsePMI.TabStop = false;
            // 
            // rbUsePMINo
            // 
            this.rbUsePMINo.AutoSize = true;
            this.rbUsePMINo.Location = new System.Drawing.Point(55, 7);
            this.rbUsePMINo.Name = "rbUsePMINo";
            this.rbUsePMINo.Size = new System.Drawing.Size(39, 17);
            this.rbUsePMINo.TabIndex = 50;
            this.rbUsePMINo.TabStop = true;
            this.rbUsePMINo.Text = "No";
            this.rbUsePMINo.UseVisualStyleBackColor = true;
            // 
            // ddlApprovalType
            // 
            this.ddlApprovalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlApprovalType.FormattingEnabled = true;
            this.ddlApprovalType.Location = new System.Drawing.Point(799, 419);
            this.ddlApprovalType.Name = "ddlApprovalType";
            this.ddlApprovalType.Size = new System.Drawing.Size(397, 21);
            this.ddlApprovalType.TabIndex = 80;
            // 
            // ddlRegistrationType
            // 
            this.ddlRegistrationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRegistrationType.FormattingEnabled = true;
            this.ddlRegistrationType.Location = new System.Drawing.Point(799, 443);
            this.ddlRegistrationType.Name = "ddlRegistrationType";
            this.ddlRegistrationType.Size = new System.Drawing.Size(397, 21);
            this.ddlRegistrationType.TabIndex = 82;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(681, 446);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 13);
            this.label18.TabIndex = 81;
            this.label18.Text = "Registration Type";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1198, 446);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(235, 13);
            this.label19.TabIndex = 83;
            this.label19.Text = "Used ONLY for recurring meeting with fixed time.";
            // 
            // ddlAudio
            // 
            this.ddlAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAudio.FormattingEnabled = true;
            this.ddlAudio.Location = new System.Drawing.Point(799, 471);
            this.ddlAudio.Name = "ddlAudio";
            this.ddlAudio.Size = new System.Drawing.Size(397, 21);
            this.ddlAudio.TabIndex = 85;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(681, 474);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 13);
            this.label20.TabIndex = 84;
            this.label20.Text = "Audio*";
            // 
            // ddlAutoRecording
            // 
            this.ddlAutoRecording.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAutoRecording.FormattingEnabled = true;
            this.ddlAutoRecording.Location = new System.Drawing.Point(799, 499);
            this.ddlAutoRecording.Name = "ddlAutoRecording";
            this.ddlAutoRecording.Size = new System.Drawing.Size(397, 21);
            this.ddlAutoRecording.TabIndex = 87;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(681, 502);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 13);
            this.label21.TabIndex = 86;
            this.label21.Text = "Auto Recording*";
            // 
            // txtAlternativeHosts
            // 
            this.txtAlternativeHosts.Location = new System.Drawing.Point(799, 525);
            this.txtAlternativeHosts.Name = "txtAlternativeHosts";
            this.txtAlternativeHosts.Size = new System.Drawing.Size(398, 20);
            this.txtAlternativeHosts.TabIndex = 89;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(681, 530);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(87, 13);
            this.label22.TabIndex = 88;
            this.label22.Text = "Alternative Hosts";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(1197, 530);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(226, 13);
            this.label23.TabIndex = 90;
            this.label23.Text = "User ID or email address separated by comma.";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(681, 607);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(92, 13);
            this.label24.TabIndex = 91;
            this.label24.Text = "Close Registration";
            // 
            // gbCloseRegistration
            // 
            this.gbCloseRegistration.Controls.Add(this.rbCloseRegistrationYes);
            this.gbCloseRegistration.Controls.Add(this.rbCloseRegistrationNo);
            this.gbCloseRegistration.Location = new System.Drawing.Point(793, 600);
            this.gbCloseRegistration.Name = "gbCloseRegistration";
            this.gbCloseRegistration.Size = new System.Drawing.Size(200, 27);
            this.gbCloseRegistration.TabIndex = 92;
            this.gbCloseRegistration.TabStop = false;
            // 
            // rbCloseRegistrationYes
            // 
            this.rbCloseRegistrationYes.AutoSize = true;
            this.rbCloseRegistrationYes.Location = new System.Drawing.Point(6, 7);
            this.rbCloseRegistrationYes.Name = "rbCloseRegistrationYes";
            this.rbCloseRegistrationYes.Size = new System.Drawing.Size(43, 17);
            this.rbCloseRegistrationYes.TabIndex = 49;
            this.rbCloseRegistrationYes.TabStop = true;
            this.rbCloseRegistrationYes.Text = "Yes";
            this.rbCloseRegistrationYes.UseVisualStyleBackColor = true;
            // 
            // rbCloseRegistrationNo
            // 
            this.rbCloseRegistrationNo.AutoSize = true;
            this.rbCloseRegistrationNo.Location = new System.Drawing.Point(55, 9);
            this.rbCloseRegistrationNo.Name = "rbCloseRegistrationNo";
            this.rbCloseRegistrationNo.Size = new System.Drawing.Size(39, 17);
            this.rbCloseRegistrationNo.TabIndex = 50;
            this.rbCloseRegistrationNo.TabStop = true;
            this.rbCloseRegistrationNo.Text = "No";
            this.rbCloseRegistrationNo.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(1003, 607);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 13);
            this.label25.TabIndex = 93;
            this.label25.Text = "Waiting Room";
            // 
            // gbWaitingRoom
            // 
            this.gbWaitingRoom.Controls.Add(this.rbWaitingRoomYes);
            this.gbWaitingRoom.Controls.Add(this.rbWaitingRoomNo);
            this.gbWaitingRoom.Location = new System.Drawing.Point(1092, 600);
            this.gbWaitingRoom.Name = "gbWaitingRoom";
            this.gbWaitingRoom.Size = new System.Drawing.Size(200, 27);
            this.gbWaitingRoom.TabIndex = 94;
            this.gbWaitingRoom.TabStop = false;
            // 
            // rbWaitingRoomYes
            // 
            this.rbWaitingRoomYes.AutoSize = true;
            this.rbWaitingRoomYes.Location = new System.Drawing.Point(6, 7);
            this.rbWaitingRoomYes.Name = "rbWaitingRoomYes";
            this.rbWaitingRoomYes.Size = new System.Drawing.Size(43, 17);
            this.rbWaitingRoomYes.TabIndex = 49;
            this.rbWaitingRoomYes.TabStop = true;
            this.rbWaitingRoomYes.Text = "Yes";
            this.rbWaitingRoomYes.UseVisualStyleBackColor = true;
            // 
            // rbWaitingRoomNo
            // 
            this.rbWaitingRoomNo.AutoSize = true;
            this.rbWaitingRoomNo.Location = new System.Drawing.Point(56, 6);
            this.rbWaitingRoomNo.Name = "rbWaitingRoomNo";
            this.rbWaitingRoomNo.Size = new System.Drawing.Size(39, 17);
            this.rbWaitingRoomNo.TabIndex = 50;
            this.rbWaitingRoomNo.TabStop = true;
            this.rbWaitingRoomNo.Text = "No";
            this.rbWaitingRoomNo.UseVisualStyleBackColor = true;
            // 
            // txtGlobalDialCountries
            // 
            this.txtGlobalDialCountries.Location = new System.Drawing.Point(799, 631);
            this.txtGlobalDialCountries.Name = "txtGlobalDialCountries";
            this.txtGlobalDialCountries.Size = new System.Drawing.Size(398, 20);
            this.txtGlobalDialCountries.TabIndex = 96;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(681, 636);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(105, 13);
            this.label26.TabIndex = 95;
            this.label26.Text = "Global Dial Countries";
            // 
            // txtcontactName
            // 
            this.txtcontactName.Location = new System.Drawing.Point(799, 654);
            this.txtcontactName.Name = "txtcontactName";
            this.txtcontactName.Size = new System.Drawing.Size(398, 20);
            this.txtcontactName.TabIndex = 98;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(681, 659);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(75, 13);
            this.label27.TabIndex = 97;
            this.label27.Text = "Contact Name";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(948, 780);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(121, 23);
            this.btnSaveConfig.TabIndex = 99;
            this.btnSaveConfig.Text = "Save";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnConfigurationShrink
            // 
            this.btnConfigurationShrink.Location = new System.Drawing.Point(636, 49);
            this.btnConfigurationShrink.Name = "btnConfigurationShrink";
            this.btnConfigurationShrink.Size = new System.Drawing.Size(36, 30);
            this.btnConfigurationShrink.TabIndex = 100;
            this.btnConfigurationShrink.Text = "<<";
            this.btnConfigurationShrink.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfigurationShrink.UseVisualStyleBackColor = true;
            this.btnConfigurationShrink.Click += new System.EventHandler(this.btnConfigurationShrink_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(1039, 707);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(116, 13);
            this.label28.TabIndex = 103;
            this.label28.Text = "Meeting Authentication";
            // 
            // gbMeetingAuthentication
            // 
            this.gbMeetingAuthentication.Controls.Add(this.rbMeetingAuthenticationYes);
            this.gbMeetingAuthentication.Controls.Add(this.rbMeetingAuthenticationNo);
            this.gbMeetingAuthentication.Location = new System.Drawing.Point(1151, 700);
            this.gbMeetingAuthentication.Name = "gbMeetingAuthentication";
            this.gbMeetingAuthentication.Size = new System.Drawing.Size(200, 27);
            this.gbMeetingAuthentication.TabIndex = 104;
            this.gbMeetingAuthentication.TabStop = false;
            // 
            // rbMeetingAuthenticationYes
            // 
            this.rbMeetingAuthenticationYes.AutoSize = true;
            this.rbMeetingAuthenticationYes.Location = new System.Drawing.Point(6, 7);
            this.rbMeetingAuthenticationYes.Name = "rbMeetingAuthenticationYes";
            this.rbMeetingAuthenticationYes.Size = new System.Drawing.Size(43, 17);
            this.rbMeetingAuthenticationYes.TabIndex = 49;
            this.rbMeetingAuthenticationYes.TabStop = true;
            this.rbMeetingAuthenticationYes.Text = "Yes";
            this.rbMeetingAuthenticationYes.UseVisualStyleBackColor = true;
            // 
            // rbMeetingAuthenticationNo
            // 
            this.rbMeetingAuthenticationNo.AutoSize = true;
            this.rbMeetingAuthenticationNo.Location = new System.Drawing.Point(55, 7);
            this.rbMeetingAuthenticationNo.Name = "rbMeetingAuthenticationNo";
            this.rbMeetingAuthenticationNo.Size = new System.Drawing.Size(39, 17);
            this.rbMeetingAuthenticationNo.TabIndex = 50;
            this.rbMeetingAuthenticationNo.TabStop = true;
            this.rbMeetingAuthenticationNo.Text = "No";
            this.rbMeetingAuthenticationNo.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(681, 707);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(144, 13);
            this.label29.TabIndex = 101;
            this.label29.Text = "Registrants Email Notification";
            // 
            // gbRegistrationEmailNotification
            // 
            this.gbRegistrationEmailNotification.Controls.Add(this.rbRegistrantsEmailNotificationYes);
            this.gbRegistrationEmailNotification.Controls.Add(this.rbRegistrantsEmailNotificationNo);
            this.gbRegistrationEmailNotification.Location = new System.Drawing.Point(828, 700);
            this.gbRegistrationEmailNotification.Name = "gbRegistrationEmailNotification";
            this.gbRegistrationEmailNotification.Size = new System.Drawing.Size(200, 27);
            this.gbRegistrationEmailNotification.TabIndex = 102;
            this.gbRegistrationEmailNotification.TabStop = false;
            // 
            // rbRegistrantsEmailNotificationYes
            // 
            this.rbRegistrantsEmailNotificationYes.AutoSize = true;
            this.rbRegistrantsEmailNotificationYes.Location = new System.Drawing.Point(6, 7);
            this.rbRegistrantsEmailNotificationYes.Name = "rbRegistrantsEmailNotificationYes";
            this.rbRegistrantsEmailNotificationYes.Size = new System.Drawing.Size(43, 17);
            this.rbRegistrantsEmailNotificationYes.TabIndex = 49;
            this.rbRegistrantsEmailNotificationYes.TabStop = true;
            this.rbRegistrantsEmailNotificationYes.Text = "Yes";
            this.rbRegistrantsEmailNotificationYes.UseVisualStyleBackColor = true;
            // 
            // rbRegistrantsEmailNotificationNo
            // 
            this.rbRegistrantsEmailNotificationNo.AutoSize = true;
            this.rbRegistrantsEmailNotificationNo.Location = new System.Drawing.Point(55, 9);
            this.rbRegistrantsEmailNotificationNo.Name = "rbRegistrantsEmailNotificationNo";
            this.rbRegistrantsEmailNotificationNo.Size = new System.Drawing.Size(39, 17);
            this.rbRegistrantsEmailNotificationNo.TabIndex = 50;
            this.rbRegistrantsEmailNotificationNo.TabStop = true;
            this.rbRegistrantsEmailNotificationNo.Text = "No";
            this.rbRegistrantsEmailNotificationNo.UseVisualStyleBackColor = true;
            // 
            // txtAuthenticationDomains
            // 
            this.txtAuthenticationDomains.Location = new System.Drawing.Point(799, 754);
            this.txtAuthenticationDomains.Name = "txtAuthenticationDomains";
            this.txtAuthenticationDomains.Size = new System.Drawing.Size(398, 20);
            this.txtAuthenticationDomains.TabIndex = 108;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(681, 759);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(117, 13);
            this.label30.TabIndex = 107;
            this.label30.Text = "Authentication domains";
            // 
            // txtAuthenticationOption
            // 
            this.txtAuthenticationOption.Location = new System.Drawing.Point(799, 731);
            this.txtAuthenticationOption.Name = "txtAuthenticationOption";
            this.txtAuthenticationOption.Size = new System.Drawing.Size(398, 20);
            this.txtAuthenticationOption.TabIndex = 106;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(681, 736);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(109, 13);
            this.label31.TabIndex = 105;
            this.label31.Text = "Authentication Option";
            // 
            // txtContactEmail
            // 
            this.txtContactEmail.Location = new System.Drawing.Point(799, 682);
            this.txtContactEmail.Name = "txtContactEmail";
            this.txtContactEmail.Size = new System.Drawing.Size(398, 20);
            this.txtContactEmail.TabIndex = 110;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(681, 687);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(72, 13);
            this.label32.TabIndex = 109;
            this.label32.Text = "Contact Email";
            // 
            // dtpPTIFromDB
            // 
            this.dtpPTIFromDB.AllowDrop = true;
            this.dtpPTIFromDB.Enabled = false;
            this.dtpPTIFromDB.Location = new System.Drawing.Point(14, 52);
            this.dtpPTIFromDB.Name = "dtpPTIFromDB";
            this.dtpPTIFromDB.Size = new System.Drawing.Size(227, 20);
            this.dtpPTIFromDB.TabIndex = 111;
            // 
            // txtEnforceLoginDomains
            // 
            this.txtEnforceLoginDomains.Location = new System.Drawing.Point(799, 579);
            this.txtEnforceLoginDomains.Name = "txtEnforceLoginDomains";
            this.txtEnforceLoginDomains.Size = new System.Drawing.Size(398, 20);
            this.txtEnforceLoginDomains.TabIndex = 113;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(679, 584);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(117, 13);
            this.label33.TabIndex = 112;
            this.label33.Text = "Enforce Login Domains";
            // 
            // gbEnforceLogin
            // 
            this.gbEnforceLogin.Controls.Add(this.rbEnforceLoginYes);
            this.gbEnforceLogin.Controls.Add(this.rbEnforceLoginNo);
            this.gbEnforceLogin.Location = new System.Drawing.Point(793, 548);
            this.gbEnforceLogin.Name = "gbEnforceLogin";
            this.gbEnforceLogin.Size = new System.Drawing.Size(200, 27);
            this.gbEnforceLogin.TabIndex = 115;
            this.gbEnforceLogin.TabStop = false;
            // 
            // rbEnforceLoginYes
            // 
            this.rbEnforceLoginYes.AutoSize = true;
            this.rbEnforceLoginYes.Location = new System.Drawing.Point(6, 7);
            this.rbEnforceLoginYes.Name = "rbEnforceLoginYes";
            this.rbEnforceLoginYes.Size = new System.Drawing.Size(43, 17);
            this.rbEnforceLoginYes.TabIndex = 49;
            this.rbEnforceLoginYes.TabStop = true;
            this.rbEnforceLoginYes.Text = "Yes";
            this.rbEnforceLoginYes.UseVisualStyleBackColor = true;
            // 
            // rbEnforceLoginNo
            // 
            this.rbEnforceLoginNo.AutoSize = true;
            this.rbEnforceLoginNo.Location = new System.Drawing.Point(55, 9);
            this.rbEnforceLoginNo.Name = "rbEnforceLoginNo";
            this.rbEnforceLoginNo.Size = new System.Drawing.Size(39, 17);
            this.rbEnforceLoginNo.TabIndex = 50;
            this.rbEnforceLoginNo.TabStop = true;
            this.rbEnforceLoginNo.Text = "No";
            this.rbEnforceLoginNo.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(681, 554);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(73, 13);
            this.label34.TabIndex = 114;
            this.label34.Text = "Enforce Login";
            // 
            // gbCreateNewSchedule
            // 
            this.gbCreateNewSchedule.Controls.Add(this.rbCreateNewScheduleYes);
            this.gbCreateNewSchedule.Controls.Add(this.rbCreateNewScheduleNo);
            this.gbCreateNewSchedule.Location = new System.Drawing.Point(965, 6);
            this.gbCreateNewSchedule.Name = "gbCreateNewSchedule";
            this.gbCreateNewSchedule.Size = new System.Drawing.Size(200, 27);
            this.gbCreateNewSchedule.TabIndex = 117;
            this.gbCreateNewSchedule.TabStop = false;
            // 
            // rbCreateNewScheduleYes
            // 
            this.rbCreateNewScheduleYes.AutoSize = true;
            this.rbCreateNewScheduleYes.Location = new System.Drawing.Point(6, 7);
            this.rbCreateNewScheduleYes.Name = "rbCreateNewScheduleYes";
            this.rbCreateNewScheduleYes.Size = new System.Drawing.Size(43, 17);
            this.rbCreateNewScheduleYes.TabIndex = 49;
            this.rbCreateNewScheduleYes.TabStop = true;
            this.rbCreateNewScheduleYes.Text = "Yes";
            this.rbCreateNewScheduleYes.UseVisualStyleBackColor = true;
            // 
            // rbCreateNewScheduleNo
            // 
            this.rbCreateNewScheduleNo.AutoSize = true;
            this.rbCreateNewScheduleNo.Location = new System.Drawing.Point(55, 7);
            this.rbCreateNewScheduleNo.Name = "rbCreateNewScheduleNo";
            this.rbCreateNewScheduleNo.Size = new System.Drawing.Size(39, 17);
            this.rbCreateNewScheduleNo.TabIndex = 50;
            this.rbCreateNewScheduleNo.TabStop = true;
            this.rbCreateNewScheduleNo.Text = "No";
            this.rbCreateNewScheduleNo.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(681, 11);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(279, 16);
            this.label35.TabIndex = 116;
            this.label35.Text = "Do you like to create a new schedule?";
            // 
            // txtScheduleSeq
            // 
            this.txtScheduleSeq.Location = new System.Drawing.Point(1307, 11);
            this.txtScheduleSeq.Name = "txtScheduleSeq";
            this.txtScheduleSeq.ReadOnly = true;
            this.txtScheduleSeq.Size = new System.Drawing.Size(79, 20);
            this.txtScheduleSeq.TabIndex = 119;
            this.txtScheduleSeq.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(1219, 13);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(90, 13);
            this.label36.TabIndex = 118;
            this.label36.Text = "Schedule Seq:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1430, 808);
            this.Controls.Add(this.txtScheduleSeq);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.gbCreateNewSchedule);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.gbEnforceLogin);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.txtEnforceLoginDomains);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.dtpPTIFromDB);
            this.Controls.Add(this.txtContactEmail);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.txtAuthenticationDomains);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.txtAuthenticationOption);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.gbMeetingAuthentication);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.gbRegistrationEmailNotification);
            this.Controls.Add(this.btnConfigurationShrink);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.txtcontactName);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtGlobalDialCountries);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.gbWaitingRoom);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.gbCloseRegistration);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtAlternativeHosts);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.ddlAutoRecording);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.ddlAudio);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.ddlRegistrationType);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.ddlApprovalType);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.gbUsePMI);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.gbWaterMark);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.gbMuteUponEntry);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.gbJoinBeforeHost);
            this.Controls.Add(this.gbParticipantVideo);
            this.Controls.Add(this.gbHostVideo);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtScheduleFor);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ddlMeetingType);
            this.Controls.Add(this.txtMeetingStartTime);
            this.Controls.Add(this.lblMeetingType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMeetingTopicFromDB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnConfigurationExpand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtMeetingAgenda);
            this.Controls.Add(this.txtTimeZone);
            this.Controls.Add(this.txtMeetingDuration);
            this.Controls.Add(this.txtJWTToken);
            this.Controls.Add(this.btnRefreshConfig);
            this.Controls.Add(this.lblApprovalType);
            this.Controls.Add(this.lblParticipantVideo);
            this.Controls.Add(this.lblHostVideo);
            this.Controls.Add(this.lblMeetingAgenda);
            this.Controls.Add(this.lblMeetingTimeZone);
            this.Controls.Add(this.lblMeetingDuration);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblJwtToken);
            this.Controls.Add(this.progressBarSimple);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMeetingTopic);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.dtpPTI);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblProcessed);
            this.Controls.Add(this.lblUpdated);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnImportUsersToSynergetic);
            this.Controls.Add(this.btnDeleteMeetings);
            this.Controls.Add(this.btnUpdateMeetings);
            this.Controls.Add(this.btnGetMeetings);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnSubmit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zoom Meeting for PTI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbHostVideo.ResumeLayout(false);
            this.gbHostVideo.PerformLayout();
            this.gbParticipantVideo.ResumeLayout(false);
            this.gbParticipantVideo.PerformLayout();
            this.gbJoinBeforeHost.ResumeLayout(false);
            this.gbJoinBeforeHost.PerformLayout();
            this.gbMuteUponEntry.ResumeLayout(false);
            this.gbMuteUponEntry.PerformLayout();
            this.gbWaterMark.ResumeLayout(false);
            this.gbWaterMark.PerformLayout();
            this.gbUsePMI.ResumeLayout(false);
            this.gbUsePMI.PerformLayout();
            this.gbCloseRegistration.ResumeLayout(false);
            this.gbCloseRegistration.PerformLayout();
            this.gbWaitingRoom.ResumeLayout(false);
            this.gbWaitingRoom.PerformLayout();
            this.gbMeetingAuthentication.ResumeLayout(false);
            this.gbMeetingAuthentication.PerformLayout();
            this.gbRegistrationEmailNotification.ResumeLayout(false);
            this.gbRegistrationEmailNotification.PerformLayout();
            this.gbEnforceLogin.ResumeLayout(false);
            this.gbEnforceLogin.PerformLayout();
            this.gbCreateNewSchedule.ResumeLayout(false);
            this.gbCreateNewSchedule.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnGetMeetings;
        private System.Windows.Forms.Button btnCreateMeeting;
        private System.Windows.Forms.Button btnUpdateMeetings;
        private System.Windows.Forms.Button btnDeleteMeetings;
        private System.Windows.Forms.Button btnImportUsersToSynergetic;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label lblUpdated;
        private System.Windows.Forms.Label lblProcessed;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DateTimePicker dtpPTI;
        private System.Windows.Forms.CheckBox chkDeleteExistingMeeting;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtMeetingTopic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBarSimple;
        private System.Windows.Forms.Label lblJwtToken;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblMeetingDuration;
        private System.Windows.Forms.Label lblMeetingTimeZone;
        private System.Windows.Forms.Label lblMeetingAgenda;
        private System.Windows.Forms.Label lblHostVideo;
        private System.Windows.Forms.Label lblParticipantVideo;
        private System.Windows.Forms.Label lblApprovalType;
        private System.Windows.Forms.Button btnRefreshConfig;
        private System.Windows.Forms.TextBox txtJWTToken;
        private System.Windows.Forms.TextBox txtMeetingDuration;
        private System.Windows.Forms.TextBox txtTimeZone;
        private System.Windows.Forms.TextBox txtMeetingAgenda;
        private System.Windows.Forms.RadioButton rbHostVideoYes;
        private System.Windows.Forms.RadioButton rbHostVideoNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfigurationExpand;
        private System.Windows.Forms.TextBox txtMeetingTopicFromDB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMeetingStartTime;
        private System.Windows.Forms.Label lblMeetingType;
        private System.Windows.Forms.ComboBox ddlMeetingType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtScheduleFor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox gbHostVideo;
        private System.Windows.Forms.GroupBox gbParticipantVideo;
        private System.Windows.Forms.RadioButton rbPartticipantVideoYes;
        private System.Windows.Forms.RadioButton rbPartticipantVideoNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton rbJoinBeforeHostYes;
        private System.Windows.Forms.GroupBox gbJoinBeforeHost;
        private System.Windows.Forms.RadioButton rbJoinBeforeHostNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton rbMuteUponEntryYes;
        private System.Windows.Forms.RadioButton rbMuteUponEntryNo;
        private System.Windows.Forms.GroupBox gbMuteUponEntry;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton rbWaterMarkYes;
        private System.Windows.Forms.GroupBox gbWaterMark;
        private System.Windows.Forms.RadioButton rbWaterMarkNo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton rbUsePMIYes;
        private System.Windows.Forms.GroupBox gbUsePMI;
        private System.Windows.Forms.RadioButton rbUsePMINo;
        private System.Windows.Forms.ComboBox ddlApprovalType;
        private System.Windows.Forms.ComboBox ddlRegistrationType;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox ddlAudio;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox ddlAutoRecording;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtAlternativeHosts;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox gbCloseRegistration;
        private System.Windows.Forms.RadioButton rbCloseRegistrationYes;
        private System.Windows.Forms.RadioButton rbCloseRegistrationNo;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox gbWaitingRoom;
        private System.Windows.Forms.RadioButton rbWaitingRoomYes;
        private System.Windows.Forms.RadioButton rbWaitingRoomNo;
        private System.Windows.Forms.TextBox txtGlobalDialCountries;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtcontactName;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnConfigurationShrink;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox gbMeetingAuthentication;
        private System.Windows.Forms.RadioButton rbMeetingAuthenticationYes;
        private System.Windows.Forms.RadioButton rbMeetingAuthenticationNo;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox gbRegistrationEmailNotification;
        private System.Windows.Forms.RadioButton rbRegistrantsEmailNotificationYes;
        private System.Windows.Forms.RadioButton rbRegistrantsEmailNotificationNo;
        private System.Windows.Forms.TextBox txtAuthenticationDomains;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtAuthenticationOption;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtContactEmail;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DateTimePicker dtpPTIFromDB;
        private System.Windows.Forms.TextBox txtEnforceLoginDomains;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.GroupBox gbEnforceLogin;
        private System.Windows.Forms.RadioButton rbEnforceLoginYes;
        private System.Windows.Forms.RadioButton rbEnforceLoginNo;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.GroupBox gbCreateNewSchedule;
        private System.Windows.Forms.RadioButton rbCreateNewScheduleYes;
        private System.Windows.Forms.RadioButton rbCreateNewScheduleNo;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtScheduleSeq;
        private System.Windows.Forms.Label label36;
    }
}

