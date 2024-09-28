﻿using System;
using System.Web.UI.WebControls;
namespace Practical_3a
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void btnResult_Click(object sender, EventArgs e)
        {
            Calendar1.Caption = "SAMBARE";
            Calendar1.FirstDayOfWeek = FirstDayOfWeek.Sunday;
            Calendar1.NextPrevFormat = NextPrevFormat.ShortMonth;
            Calendar1.TitleFormat = TitleFormat.Month;
            Label2.Text = "Today's Date: " + Calendar1.TodaysDate.ToShortDateString();
            Label3.Text = "Ganpati Vacation Start: 9-13-2018";
            TimeSpan d = new DateTime(2018, 9, 13) - DateTime.Now;
            Label4.Text = "Days Remaining For Ganpati Vacation: " + d.Days.ToString();
            TimeSpan d1 = new DateTime(2018, 12, 31) - DateTime.Now;
            Label5.Text = "Days Remaining for New Year: " + d1.Days.ToString();
            if (Calendar1.SelectedDate.ToShortDateString() == "9-13-2018")
                Label3.Text = "<b>Ganpati Festival Start</b>";
            if (Calendar1.SelectedDate.ToShortDateString() == "9-23-2018")
                Label3.Text = "<b>Ganpati Festival End</b>";
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date.Day == 5 && e.Day.Date.Month == 9)
            {
                e.Cell.BackColor = System.Drawing.Color.Yellow;
                Label lbl = new Label();
                lbl.Text = "<br>Teachers Day!";
                e.Cell.Controls.Add(lbl);
                Image g1 = new Image();
                g1.ImageUrl = "td.jpg";
                g1.Height = 20;
                g1.Width = 20;
                e.Cell.Controls.Add(g1);
            }
            if (e.Day.Date.Day == 13 && e.Day.Date.Month == 9)
            {
                Calendar1.SelectedDate = new DateTime(2018, 9, 12);
                Calendar1.SelectedDates.SelectRange(Calendar1.SelectedDate,
                Calendar1.SelectedDate.AddDays(10));
                Label lbl1 = new Label();
                lbl1.Text = "<br>Ganpati!";
                e.Cell.Controls.Add(lbl1);
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            Label5.Text = "";
            Calendar1.SelectedDates.Clear();
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Label1.Text = "Your Selected Date: " + Calendar1.SelectedDate.Date.ToString();
        }
    }
}