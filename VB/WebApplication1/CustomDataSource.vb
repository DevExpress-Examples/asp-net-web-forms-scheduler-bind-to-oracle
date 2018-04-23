Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data.OracleClient
Imports System.Linq
Imports System.Web

Namespace WebApplication1
	Public Class CustomAppointmentDataSource
		Public Sub New()
			Appointments = New BindingList(Of CustomAppointment)()
		End Sub
		Public Appointments As BindingList(Of CustomAppointment)

		#Region "ObjectDataSource methods"
		Public Function InsertMethodHandler(ByVal customAppt As CustomAppointment) As Object
			Dim newAppointmentId As Integer = Appointments.Count
			Dim conn As New OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
			conn.Open()
			Dim cmd As OracleCommand = conn.CreateCommand()
			cmd.CommandText = "INSERT INTO SCHEDULEAPPTS (UNIQUEID, TYPE, STARTDATE, ENDDATE, ALLDAY, SUBJECT, LOCATION, DESCRIPTION, STATUS, LABEL, RESOURCEID, REMINDERINFO, RECURRENCEINFO) VALUES (:UNIQUEID, :TYPE, :STARTDATE, :ENDDATE, :ALLDAY, :SUBJECT, :LOCATION, :DESCRIPTION, :STATUS, :LABEL, :RESOURCEID, :REMINDERINFO, :RECURRENCEINFO)"
			cmd.Parameters.Add("UNIQUEID", newAppointmentId)
			cmd.Parameters.Add("TYPE", customAppt.TYPE)
			cmd.Parameters.Add("STARTDATE", customAppt.STARTDATE)
			cmd.Parameters.Add("ENDDATE", customAppt.ENDDATE)
			cmd.Parameters.Add("ALLDAY", customAppt.ALLDAY)
			cmd.Parameters.Add("SUBJECT", customAppt.SUBJECT)
			cmd.Parameters.Add("LOCATION", customAppt.LOCATION)
			cmd.Parameters.Add("DESCRIPTION", customAppt.DESCRIPTION)
			cmd.Parameters.Add("STATUS", customAppt.STATUS)
			cmd.Parameters.Add("LABEL", customAppt.LABEL)
			cmd.Parameters.Add("RESOURCEID",If(customAppt.RESOURCEID Is Nothing, 0, customAppt.RESOURCEID))
			cmd.Parameters.Add("REMINDERINFO",If(customAppt.REMINDERINFO Is Nothing, "", customAppt.REMINDERINFO))
			cmd.Parameters.Add("RECURRENCEINFO",If(customAppt.RECURRENCEINFO Is Nothing, "", customAppt.RECURRENCEINFO))
			cmd.ExecuteNonQuery()
			Return newAppointmentId
		End Function
		Public Sub DeleteMethodHandler(ByVal customAppt As CustomAppointment)
			Dim conn As New OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
			conn.Open()
			Dim cmd As OracleCommand = conn.CreateCommand()
			cmd.CommandText = "DELETE FROM SCHEDULEAPPTS WHERE UNIQUEID = :UNIQUEID"
			cmd.Parameters.Add("UNIQUEID", customAppt.UNIQUEID)
			cmd.ExecuteNonQuery()

		End Sub
		Public Sub UpdateMethodHandler(ByVal customAppt As CustomAppointment)
			Dim conn As New OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
			conn.Open()
			Dim cmd As OracleCommand = conn.CreateCommand()
			cmd.CommandText = "UPDATE SCHEDULEAPPTS SET TYPE = :TYPE, STARTDATE = :STARTDATE, ENDDATE = :ENDDATE, ALLDAY = :ALLDAY, SUBJECT = :SUBJECT, LOCATION = :LOCATION, DESCRIPTION = :DESCRIPTION, STATUS = :STATUS, LABEL = :LABEL, RESOURCEID = :RESOURCEID, REMINDERINFO = :REMINDERINFO, RECURRENCEINFO = :RECURRENCEINFO WHERE UNIQUEID = :UNIQUEID"
			cmd.Parameters.Add("UNIQUEID", customAppt.UNIQUEID)
			cmd.Parameters.Add("TYPE", customAppt.TYPE)
			cmd.Parameters.Add("STARTDATE", customAppt.STARTDATE)
			cmd.Parameters.Add("ENDDATE", customAppt.ENDDATE)
			cmd.Parameters.Add("ALLDAY", customAppt.ALLDAY)
			cmd.Parameters.Add("SUBJECT", customAppt.SUBJECT)
			cmd.Parameters.Add("LOCATION", customAppt.LOCATION)
			cmd.Parameters.Add("DESCRIPTION", customAppt.DESCRIPTION)
			cmd.Parameters.Add("STATUS", customAppt.STATUS)
			cmd.Parameters.Add("LABEL", customAppt.LABEL)
			cmd.Parameters.Add("RESOURCEID",If(customAppt.RESOURCEID Is Nothing, 0, customAppt.RESOURCEID))
			cmd.Parameters.Add("REMINDERINFO",If(customAppt.REMINDERINFO Is Nothing, "", customAppt.REMINDERINFO))
			cmd.Parameters.Add("RECURRENCEINFO",If(customAppt.RECURRENCEINFO Is Nothing, "", customAppt.RECURRENCEINFO))
			cmd.ExecuteNonQuery()
		End Sub
		Public Function SelectMethodHandler() As IEnumerable
			Appointments.Clear()
			Dim conn As New OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
			conn.Open()
			Dim cmd As OracleCommand = conn.CreateCommand()
			cmd.CommandText = "SELECT * FROM SCHEDULEAPPTS"

			Dim dr As OracleDataReader = cmd.ExecuteReader()
			Do While dr.Read()
				Dim newAppt As New CustomAppointment()
				newAppt.ALLDAY = If(TypeOf dr("ALLDAY") Is System.DBNull, False, Convert.ToBoolean(dr("ALLDAY")))
				newAppt.DESCRIPTION = If(TypeOf dr("DESCRIPTION") Is System.DBNull, "", dr("DESCRIPTION").ToString())
				newAppt.ENDDATE = If(TypeOf dr("ENDDATE") Is System.DBNull, DateTime.MinValue, Convert.ToDateTime(dr("ENDDATE")))
				newAppt.LABEL = If(TypeOf dr("LABEL") Is System.DBNull, 0, Convert.ToInt32(dr("LABEL")))
				newAppt.LOCATION = If(TypeOf dr("LOCATION") Is System.DBNull, "", dr("LOCATION").ToString())
				newAppt.RECURRENCEINFO = If(TypeOf dr("RECURRENCEINFO") Is System.DBNull, "", dr("RECURRENCEINFO").ToString())
				newAppt.REMINDERINFO = If(TypeOf dr("REMINDERINFO") Is System.DBNull, "", dr("REMINDERINFO").ToString())
				newAppt.RESOURCEID = If(TypeOf dr("RESOURCEID") Is System.DBNull, 0, Convert.ToInt32(dr("RESOURCEID")))
				newAppt.STARTDATE = If(TypeOf dr("STARTDATE") Is System.DBNull, DateTime.MinValue, Convert.ToDateTime(dr("STARTDATE")))
				newAppt.STATUS = If(TypeOf dr("STATUS") Is System.DBNull, 0, Convert.ToInt32(dr("STATUS")))
				newAppt.SUBJECT = If(TypeOf dr("SUBJECT") Is System.DBNull, "", dr("SUBJECT").ToString())
				newAppt.TYPE = If(TypeOf dr("TYPE") Is System.DBNull, 0, Convert.ToInt32(dr("TYPE")))
				newAppt.UNIQUEID = If(TypeOf dr("UNIQUEID") Is System.DBNull, 0, Convert.ToInt32(dr("UNIQUEID")))

				Appointments.Add(newAppt)
			Loop
			Return Appointments
		End Function
		#End Region
	End Class
End Namespace