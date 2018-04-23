using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class CustomAppointment
    {
        private DateTime m_Start;
        private DateTime m_End;
        private string m_Subject;
        private int m_Status;
        private string m_Description;
        private int m_Label;
        private string m_Location;
        private bool m_Allday;
        private int m_EventType;
        private string m_RecurrenceInfo;
        private string m_ReminderInfo;
        private object m_OwnerId;
        private object m_Id;


        public DateTime STARTDATE { get { return m_Start; } set { m_Start = value; } }
        public DateTime ENDDATE { get { return m_End; } set { m_End = value; } }
        public string SUBJECT { get { return m_Subject; } set { m_Subject = value; } }
        public int STATUS { get { return m_Status; } set { m_Status = value; } }
        public string DESCRIPTION { get { return m_Description; } set { m_Description = value; } }
        public int LABEL { get { return m_Label; } set { m_Label = value; } }
        public string LOCATION { get { return m_Location; } set { m_Location = value; } }
        public bool ALLDAY { get { return m_Allday; } set { m_Allday = value; } }
        public int TYPE { get { return m_EventType; } set { m_EventType = value; } }
        public string RECURRENCEINFO { get { return m_RecurrenceInfo; } set { m_RecurrenceInfo = value; } }
        public string REMINDERINFO { get { return m_ReminderInfo; } set { m_ReminderInfo = value; } }
        public object RESOURCEID { get { return m_OwnerId; } set { m_OwnerId = value; } }
        public object UNIQUEID { get { return m_Id; } set { m_Id = value; } }

        public CustomAppointment()
        {
        }
    }
}