using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class CustomAppointmentDataSource
    {
        public CustomAppointmentDataSource()
        {
            Appointments = new BindingList<CustomAppointment>();
        }
        public BindingList<CustomAppointment> Appointments;

        #region ObjectDataSource methods
        public object InsertMethodHandler(CustomAppointment customAppt)
        {            
            int newAppointmentId = Appointments.Count;
            OracleConnection conn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO SCHEDULEAPPTS (UNIQUEID, TYPE, STARTDATE, ENDDATE, ALLDAY, SUBJECT, LOCATION, DESCRIPTION, STATUS, LABEL, RESOURCEID, REMINDERINFO, RECURRENCEINFO) VALUES (:UNIQUEID, :TYPE, :STARTDATE, :ENDDATE, :ALLDAY, :SUBJECT, :LOCATION, :DESCRIPTION, :STATUS, :LABEL, :RESOURCEID, :REMINDERINFO, :RECURRENCEINFO)";
            cmd.Parameters.Add("UNIQUEID", newAppointmentId);
            cmd.Parameters.Add("TYPE", customAppt.TYPE);
            cmd.Parameters.Add("STARTDATE", customAppt.STARTDATE);
            cmd.Parameters.Add("ENDDATE", customAppt.ENDDATE);
            cmd.Parameters.Add("ALLDAY", customAppt.ALLDAY);
            cmd.Parameters.Add("SUBJECT", customAppt.SUBJECT);
            cmd.Parameters.Add("LOCATION", customAppt.LOCATION);
            cmd.Parameters.Add("DESCRIPTION", customAppt.DESCRIPTION);
            cmd.Parameters.Add("STATUS", customAppt.STATUS);
            cmd.Parameters.Add("LABEL", customAppt.LABEL);
            cmd.Parameters.Add("RESOURCEID", customAppt.RESOURCEID == null ? 0 : customAppt.RESOURCEID);
            cmd.Parameters.Add("REMINDERINFO", customAppt.REMINDERINFO == null ? "" : customAppt.REMINDERINFO);
            cmd.Parameters.Add("RECURRENCEINFO", customAppt.RECURRENCEINFO == null ? "" : customAppt.RECURRENCEINFO);
            cmd.ExecuteNonQuery();
            return newAppointmentId;
        }
        public void DeleteMethodHandler(CustomAppointment customAppt)
        {
            OracleConnection conn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM SCHEDULEAPPTS WHERE UNIQUEID = :UNIQUEID";
            cmd.Parameters.Add("UNIQUEID", customAppt.UNIQUEID);
            cmd.ExecuteNonQuery();

        }
        public void UpdateMethodHandler(CustomAppointment customAppt)
        {            
            OracleConnection conn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE SCHEDULEAPPTS SET TYPE = :TYPE, STARTDATE = :STARTDATE, ENDDATE = :ENDDATE, ALLDAY = :ALLDAY, SUBJECT = :SUBJECT, LOCATION = :LOCATION, DESCRIPTION = :DESCRIPTION, STATUS = :STATUS, LABEL = :LABEL, RESOURCEID = :RESOURCEID, REMINDERINFO = :REMINDERINFO, RECURRENCEINFO = :RECURRENCEINFO WHERE UNIQUEID = :UNIQUEID";
            cmd.Parameters.Add("UNIQUEID", customAppt.UNIQUEID);
            cmd.Parameters.Add("TYPE", customAppt.TYPE);
            cmd.Parameters.Add("STARTDATE", customAppt.STARTDATE);
            cmd.Parameters.Add("ENDDATE", customAppt.ENDDATE);
            cmd.Parameters.Add("ALLDAY", customAppt.ALLDAY);
            cmd.Parameters.Add("SUBJECT", customAppt.SUBJECT);
            cmd.Parameters.Add("LOCATION", customAppt.LOCATION);
            cmd.Parameters.Add("DESCRIPTION", customAppt.DESCRIPTION);
            cmd.Parameters.Add("STATUS", customAppt.STATUS);
            cmd.Parameters.Add("LABEL", customAppt.LABEL);
            cmd.Parameters.Add("RESOURCEID", customAppt.RESOURCEID == null ? 0 : customAppt.RESOURCEID);
            cmd.Parameters.Add("REMINDERINFO", customAppt.REMINDERINFO == null ? "" : customAppt.REMINDERINFO);
            cmd.Parameters.Add("RECURRENCEINFO", customAppt.RECURRENCEINFO == null ? "" : customAppt.RECURRENCEINFO);
            cmd.ExecuteNonQuery();
        }
        public IEnumerable SelectMethodHandler()
        {
            Appointments.Clear();
            OracleConnection conn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM SCHEDULEAPPTS";

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CustomAppointment newAppt = new CustomAppointment();
                newAppt.ALLDAY = dr["ALLDAY"] is System.DBNull ? false : Convert.ToBoolean(dr["ALLDAY"]);
                newAppt.DESCRIPTION = dr["DESCRIPTION"] is System.DBNull ? "" : dr["DESCRIPTION"].ToString();
                newAppt.ENDDATE = dr["ENDDATE"] is System.DBNull ? DateTime.MinValue : Convert.ToDateTime(dr["ENDDATE"]);
                newAppt.LABEL = dr["LABEL"] is System.DBNull ? 0 : Convert.ToInt32(dr["LABEL"]);
                newAppt.LOCATION = dr["LOCATION"] is System.DBNull ? "" : dr["LOCATION"].ToString();
                newAppt.RECURRENCEINFO = dr["RECURRENCEINFO"] is System.DBNull ? "" : dr["RECURRENCEINFO"].ToString();
                newAppt.REMINDERINFO = dr["REMINDERINFO"] is System.DBNull ? "" : dr["REMINDERINFO"].ToString();
                newAppt.RESOURCEID = dr["RESOURCEID"] is System.DBNull ? 0 : Convert.ToInt32(dr["RESOURCEID"]);
                newAppt.STARTDATE = dr["STARTDATE"] is System.DBNull ? DateTime.MinValue : Convert.ToDateTime(dr["STARTDATE"]);
                newAppt.STATUS = dr["STATUS"] is System.DBNull ? 0 : Convert.ToInt32(dr["STATUS"]);
                newAppt.SUBJECT = dr["SUBJECT"] is System.DBNull ? "" : dr["SUBJECT"].ToString();
                newAppt.TYPE = dr["TYPE"] is System.DBNull ? 0 : Convert.ToInt32(dr["TYPE"]);
                newAppt.UNIQUEID = dr["UNIQUEID"] is System.DBNull ? 0 : Convert.ToInt32(dr["UNIQUEID"]);

                Appointments.Add(newAppt);
            }
            return Appointments;
        }
        #endregion
    }
}