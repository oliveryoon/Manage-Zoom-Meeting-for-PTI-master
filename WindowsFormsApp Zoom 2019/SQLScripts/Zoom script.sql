/*
1. Update the database name with yours.
2. Update the schema name with yours. I use zoom as schema.
*/

USE [Your datbase name]
GO

CREATE SCHEMA [zoom] AUTHORIZATION [dbo]
go

/****** Object:  Table [zoom].[uZoom_Configs]    Script Date: 18/06/2020 12:23:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [zoom].[uZoom_Configs](
	[seq] [int] IDENTITY(1,1) NOT NULL,
	[jwt_token] [varchar](500) NOT NULL,
	[meeting_topic] [varchar](200) NOT NULL,
	[meeting_type] [int] NOT NULL,
	[start_time] [varchar](50) NOT NULL,
	[meeting_datetime] [datetime] NOT NULL,
	[meeting_duration] [int] NOT NULL,
	[schedule_for] [varchar](60) NULL,
	[meeting_time_zone] [varchar](50) NOT NULL,
	[password] [varchar](50) NULL,
	[meeting_agenda] [varchar](50) NOT NULL,
	[host_video] [bit] NOT NULL,
	[participant_video] [bit] NOT NULL,
	[join_before_host] [bit] NOT NULL,
	[mute_upon_entry] [bit] NOT NULL,
	[watermark] [bit] NOT NULL,
	[use_pmi] [bit] NOT NULL,
	[approval_type] [int] NOT NULL,
	[registration_type] [int] NULL,
	[audio] [varchar](10) NOT NULL,
	[auto_recording] [varchar](10) NOT NULL,
	[alternative_hosts] [varchar](300) NULL,
	[enforce_login] [bit] NOT NULL,
	[enforce_login_domains] [varchar](100) NULL,
	[close_registration] [bit] NOT NULL,
	[waiting_room] [bit] NOT NULL,
	[global_dial_countries] [varchar](300) NULL,
	[contact_name] [varchar](100) NULL,
	[contact_email] [varchar](100) NULL,
	[registraints_email_notification] [bit] NOT NULL,
	[meeting_authentication] [bit] NOT NULL,
	[authentication_option] [varchar](100) NULL,
	[authentication_domains] [varchar](100) NULL,
	[active_flag] [bit] NOT NULL,
 CONSTRAINT [PK__uZoom_Co__CA1E3C886AC1CADC] PRIMARY KEY CLUSTERED 
(
	[seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MAIN]
) ON [MAIN]
GO
/****** Object:  View [zoom].[uvZoom_Users]    Script Date: 18/06/2020 12:23:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/****** Object:  Table [zoom].[uZoom_Users]    Script Date: 18/06/2020 12:23:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [zoom].[uZoom_Users](
	[seq] [int] IDENTITY(1,1) NOT NULL,
	[config_seq] [int] NOT NULL,
	[user_id] [varchar](100) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[staff_id] [int] NULL,
	[staff_code] [varchar](50) NULL,
	[meeting_id] [bigint] NULL,
	[join_url] [varchar](2000) NULL,
	[start_url] [varchar](2000) NULL,
	[start_time] [date] NULL,
	[password] [varchar](500) NULL,
	[datetime_last_modified] [datetime] NOT NULL,
	[active_flag] [bit] NOT NULL,
 CONSTRAINT [PK__uZoom_Us__3213E83F4BF16E88] PRIMARY KEY CLUSTERED 
(
	[seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MAIN]
) ON [MAIN]
GO

ALTER TABLE [zoom].[uZoom_Users] ADD  CONSTRAINT [DF_uZoom_Users_DateTimeLastModified]  DEFAULT (sysdatetime()) FOR [datetime_last_modified]
GO

ALTER TABLE [zoom].[uZoom_Users]  WITH CHECK ADD  CONSTRAINT [FK_uZoom_Users_uZoom_Configs] FOREIGN KEY([config_seq])
REFERENCES [zoom].[uZoom_Configs] ([seq])
GO

ALTER TABLE [zoom].[uZoom_Users] CHECK CONSTRAINT [FK_uZoom_Users_uZoom_Configs]
GO







CREATE view [zoom].[uvZoom_Users]
as
		select s.StaffID staff_id, s.StaffOccupEmail email, s.StaffSurname last_name, s.StaffPreferred first_name, s.SchoolStaffCode staff_code,  [start_time], Max(z.meeting_id) meeting_id
		from vstaff s
			inner join vTagsOwn t  on s.StaffID = t.ID
			outer apply (select u.start_time, u.meeting_id
				from zoom.uZoom_Users u
					inner join zoom.uZoom_Configs c on u.config_seq = c.seq
				where u.active_flag = 1 and c.active_flag =1
					and s.StaffID = u.staff_id -- and s.StaffOccupEmail = u.email
				) z 
		
		group by s.StaffID, s.StaffOccupEmail, s.StaffSurname, s.StaffPreferred, SchoolStaffCode, start_time
GO
/****** Object:  Table [zoom].[uZoom_ApprovalTypes]    Script Date: 18/06/2020 12:23:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [zoom].[uZoom_ApprovalTypes](
	[Code] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MAIN]
) ON [MAIN]
GO
/****** Object:  Table [zoom].[uZoom_Audios]    Script Date: 18/06/2020 12:23:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [zoom].[uZoom_Audios](
	[Code] [varchar](20) NOT NULL,
	[Description] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MAIN]
) ON [MAIN]
GO
/****** Object:  Table [zoom].[uZoom_AutoRecordings]    Script Date: 18/06/2020 12:23:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [zoom].[uZoom_AutoRecordings](
	[Code] [varchar](20) NOT NULL,
	[Description] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MAIN]
) ON [MAIN]
GO
/****** Object:  Table [zoom].[uZoom_MeetingTypes]    Script Date: 18/06/2020 12:23:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [zoom].[uZoom_MeetingTypes](
	[Code] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MAIN]
) ON [MAIN]
GO
/****** Object:  Table [zoom].[uZoom_RegistrationTypes]    Script Date: 18/06/2020 12:23:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [zoom].[uZoom_RegistrationTypes](
	[Code] [int] NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [PK__uZoom_Re__DDDFBCBEE7C4FEDD] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MAIN]
) ON [MAIN]
GO
INSERT [zoom].[uZoom_ApprovalTypes] ([Code], [Description]) VALUES (0, N'Automatically approve')
INSERT [zoom].[uZoom_ApprovalTypes] ([Code], [Description]) VALUES (1, N'Manually approve')
INSERT [zoom].[uZoom_ApprovalTypes] ([Code], [Description]) VALUES (2, N'No registration required')
INSERT [zoom].[uZoom_Audios] ([Code], [Description]) VALUES (N'both', N'Both Telephony and VoIP')
INSERT [zoom].[uZoom_Audios] ([Code], [Description]) VALUES (N'telephony', N'Telephoney only')
INSERT [zoom].[uZoom_Audios] ([Code], [Description]) VALUES (N'voip', N'VoIP only')
INSERT [zoom].[uZoom_AutoRecordings] ([Code], [Description]) VALUES (N'cloud', N'Record on cloud')
INSERT [zoom].[uZoom_AutoRecordings] ([Code], [Description]) VALUES (N'local', N'Record on local')
INSERT [zoom].[uZoom_AutoRecordings] ([Code], [Description]) VALUES (N'none', N'Disabled')
SET IDENTITY_INSERT [zoom].[uZoom_Configs] ON 

INSERT [zoom].[uZoom_Configs] ([seq], [jwt_token], [meeting_topic], [meeting_type], [start_time], [meeting_datetime], [meeting_duration], [schedule_for], [meeting_time_zone], [password], [meeting_agenda], [host_video], [participant_video], [join_before_host], [mute_upon_entry], [watermark], [use_pmi], [approval_type], [registration_type], [audio], [auto_recording], [alternative_hosts], [enforce_login], [enforce_login_domains], [close_registration], [waiting_room], [global_dial_countries], [contact_name], [contact_email], [registraints_email_notification], [meeting_authentication], [authentication_option], [authentication_domains], [active_flag]) VALUES (1, N'your token', N'{Staff Name} PST Interview 14 June 2020', 2, N'08:30:59', CAST(N'2020-06-14T00:00:00.000' AS DateTime), 450, N'', N'Australia/Sydney', N'', N'Class Teacher Parent Interview', 1, 1, 0, 0, 0, 0, 2, NULL, N'both', N'none', N'', 0, N'', 1, 1, N'', N'', N'', 0, 0, N'', N'', 0)
INSERT [zoom].[uZoom_Configs] ([seq], [jwt_token], [meeting_topic], [meeting_type], [start_time], [meeting_datetime], [meeting_duration], [schedule_for], [meeting_time_zone], [password], [meeting_agenda], [host_video], [participant_video], [join_before_host], [mute_upon_entry], [watermark], [use_pmi], [approval_type], [registration_type], [audio], [auto_recording], [alternative_hosts], [enforce_login], [enforce_login_domains], [close_registration], [waiting_room], [global_dial_countries], [contact_name], [contact_email], [registraints_email_notification], [meeting_authentication], [authentication_option], [authentication_domains], [active_flag]) VALUES (2, N'you token', N'{Staff Name} PST Interview 26 July 2020', 2, N'08:30:59', CAST(N'2020-07-26T00:00:00.000' AS DateTime), 450, N'', N'Australia/Sydney', N'', N'Class Teacher Parent Interview', 1, 1, 0, 0, 0, 0, 2, NULL, N'both', N'none', N'', 0, N'', 1, 1, N'', N'', N'', 0, 0, N'', N'', 1)
SET IDENTITY_INSERT [zoom].[uZoom_Configs] OFF
INSERT [zoom].[uZoom_MeetingTypes] ([Code], [Description]) VALUES (1, N'Instant meeting.')
INSERT [zoom].[uZoom_MeetingTypes] ([Code], [Description]) VALUES (2, N'Scheduled meeting')
INSERT [zoom].[uZoom_MeetingTypes] ([Code], [Description]) VALUES (3, N'Recurring meeting with no fixed time.')
INSERT [zoom].[uZoom_MeetingTypes] ([Code], [Description]) VALUES (8, N'Recurring meeting with fixed time.')
INSERT [zoom].[uZoom_RegistrationTypes] ([Code], [Description]) VALUES (0, N'Not Required')
INSERT [zoom].[uZoom_RegistrationTypes] ([Code], [Description]) VALUES (1, N'Attendees register once and can attend any of the occurrences')
INSERT [zoom].[uZoom_RegistrationTypes] ([Code], [Description]) VALUES (2, N'Attendees need to register for each occurrence to attend')
INSERT [zoom].[uZoom_RegistrationTypes] ([Code], [Description]) VALUES (3, N'Attendees register once and can choose one or more occurrences to attend')
ALTER TABLE [zoom].[uZoom_Configs] ADD  CONSTRAINT [DF_uZoom_Configs_enforce_login]  DEFAULT ((0)) FOR [enforce_login]
GO
ALTER TABLE [zoom].[uZoom_Configs] ADD  CONSTRAINT [DF_uZoom_Configs_registraints_email_notification]  DEFAULT ((0)) FOR [registraints_email_notification]
GO
ALTER TABLE [zoom].[uZoom_Configs] ADD  CONSTRAINT [DF_uZoom_Configs_meeting_authentication]  DEFAULT ((0)) FOR [meeting_authentication]
GO
ALTER TABLE [zoom].[uZoom_Configs] ADD  CONSTRAINT [DF_uZoom_Configs_ActiveFlag]  DEFAULT ((0)) FOR [active_flag]
GO
