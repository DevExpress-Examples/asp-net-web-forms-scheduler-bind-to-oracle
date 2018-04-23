Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace WebApplication1
	Public Class CustomAppointment
		Private m_Start As DateTime
		Private m_End As DateTime
		Private m_Subject As String
		Private m_Status As Integer
		Private m_Description As String
		Private m_Label As Integer
		Private m_Location As String
		Private m_Allday As Boolean
		Private m_EventType As Integer
		Private m_RecurrenceInfo As String
		Private m_ReminderInfo As String
		Private m_OwnerId As Object
		Private m_Id As Object


		Public Property STARTDATE() As DateTime
			Get
				Return m_Start
			End Get
			Set(ByVal value As DateTime)
				m_Start = value
			End Set
		End Property
		Public Property ENDDATE() As DateTime
			Get
				Return m_End
			End Get
			Set(ByVal value As DateTime)
				m_End = value
			End Set
		End Property
		Public Property SUBJECT() As String
			Get
				Return m_Subject
			End Get
			Set(ByVal value As String)
				m_Subject = value
			End Set
		End Property
		Public Property STATUS() As Integer
			Get
				Return m_Status
			End Get
			Set(ByVal value As Integer)
				m_Status = value
			End Set
		End Property
		Public Property DESCRIPTION() As String
			Get
				Return m_Description
			End Get
			Set(ByVal value As String)
				m_Description = value
			End Set
		End Property
		Public Property LABEL() As Integer
			Get
				Return m_Label
			End Get
			Set(ByVal value As Integer)
				m_Label = value
			End Set
		End Property
		Public Property LOCATION() As String
			Get
				Return m_Location
			End Get
			Set(ByVal value As String)
				m_Location = value
			End Set
		End Property
		Public Property ALLDAY() As Boolean
			Get
				Return m_Allday
			End Get
			Set(ByVal value As Boolean)
				m_Allday = value
			End Set
		End Property
		Public Property TYPE() As Integer
			Get
				Return m_EventType
			End Get
			Set(ByVal value As Integer)
				m_EventType = value
			End Set
		End Property
		Public Property RECURRENCEINFO() As String
			Get
				Return m_RecurrenceInfo
			End Get
			Set(ByVal value As String)
				m_RecurrenceInfo = value
			End Set
		End Property
		Public Property REMINDERINFO() As String
			Get
				Return m_ReminderInfo
			End Get
			Set(ByVal value As String)
				m_ReminderInfo = value
			End Set
		End Property
		Public Property RESOURCEID() As Object
			Get
				Return m_OwnerId
			End Get
			Set(ByVal value As Object)
				m_OwnerId = value
			End Set
		End Property
		Public Property UNIQUEID() As Object
			Get
				Return m_Id
			End Get
			Set(ByVal value As Object)
				m_Id = value
			End Set
		End Property

		Public Sub New()
		End Sub
	End Class
End Namespace