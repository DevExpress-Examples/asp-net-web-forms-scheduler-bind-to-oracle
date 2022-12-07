<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="DefaultForm.aspx.vb" Inherits="WebApplication1.DefaultForm" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.XtraScheduler.v15.1.Core, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server"
				AppointmentDataSourceID="ObjectDataSourceAppointment"
				ClientIDMode="AutoID"
				Start="2015-03-12">
				<Storage>
					<Appointments AutoRetrieveId="True">
						<Mappings
							AllDay="ALLDAY"
							AppointmentId="UNIQUEID"
							Description="DESCRIPTION"
							End="ENDDATE"
							Label="LABEL"
							Location="LOCATION"
							RecurrenceInfo="RECURRENCEINFO"
							ReminderInfo="REMINDERINFO"
							Start="STARTDATE"
							Status="STATUS"
							Subject="SUBJECT"
							Type="TYPE" />
					</Appointments>
				</Storage>
			</dxwschs:ASPxScheduler>
			<asp:ObjectDataSource ID="ObjectDataSourceAppointment" runat="server" DataObjectTypeName="WebApplication1.CustomAppointment" DeleteMethod="DeleteMethodHandler" InsertMethod="InsertMethodHandler" SelectMethod="SelectMethodHandler" TypeName="WebApplication1.CustomAppointmentDataSource" UpdateMethod="UpdateMethodHandler"  OnObjectCreated="ObjectDataSource1_ObjectCreated"></asp:ObjectDataSource>
		</div>
	</form>
</body>
</html>