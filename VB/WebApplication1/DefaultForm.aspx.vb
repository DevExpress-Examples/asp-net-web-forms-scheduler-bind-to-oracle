Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace WebApplication1
	Partial Public Class DefaultForm
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub ObjectDataSource1_ObjectCreated(ByVal sender As Object, ByVal e As ObjectDataSourceEventArgs)
			If Session("CustomAppointmentDataSource") Is Nothing Then
				Session("CustomAppointmentDataSource") = New CustomAppointmentDataSource()
			End If
			e.ObjectInstance = Session("CustomAppointmentDataSource")
		End Sub
	End Class
End Namespace