using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.Design;
using System.IO;
using System.Drawing;


namespace CustomServerControlsLibrary
{
	[ControlBuilder(typeof(RestrictedCalendarBuilder))
	,PersistChildren(false),ParseChildren(false)
	,Designer(typeof(RestrictedCalendarDesigner))
	]
	public class RestrictedCalendar : Calendar
	{
		public RestrictedCalendar()
		{
			AllowWeekendSelection = true;
			NonSelectableDates = new DateTimeCollection();

			// Configure the appearance of the calendar table.
			this.CellPadding = 8;
			this.CellSpacing = 8;
			this.BackColor = Color.LightYellow;
			this.BorderStyle = BorderStyle.Groove;
			this.BorderWidth = Unit.Pixel(2);
			this.ShowGridLines = true;

			// Configure the font.
			this.Font.Name = "Verdana";
			this.Font.Size = FontUnit.XXSmall;

			// Set calendar settings.
			this.FirstDayOfWeek = FirstDayOfWeek.Monday;
			this.PrevMonthText = "<--";
			this.NextMonthText = "-->";

			// Select the current date by default.
			this.SelectedDate = DateTime.Today;
		}

		public bool AllowWeekendSelection
		{
			get {return (bool)ViewState["AllowWeekendSelection"];}
			set {ViewState["AllowWeekendSelection"] = value;}
		}

		[PersistenceMode(PersistenceMode.InnerDefaultProperty)
		,DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public DateTimeCollection NonSelectableDates
		{
			get {return (DateTimeCollection)ViewState["NonSelectableDates"];}
			set {ViewState["NonSelectableDates"] = value;}
		}

		protected override void OnDayRender(TableCell cell,
			CalendarDay day)
		{
			if (day.IsWeekend && !AllowWeekendSelection)
			{
				day.IsSelectable = false;
			}
			else if (NonSelectableDates.Contains(day.Date))
			{
				day.IsSelectable = false;
			}

			// Let the base class raise this event.
			base.OnDayRender(cell, day);
		}

		protected override void AddParsedSubObject(object obj)
		{
			if (obj is DateTimeHelper)
			{
				DateTimeHelper date = (DateTimeHelper)obj;
				NonSelectableDates.Add(DateTime.Parse(date.Value));
			}
		}
	}

	
	public class DateTimeCollection : CollectionBase  
	{
		public DateTime this[int index]  
		{
			get {return((DateTime)List[index]);}
			set {List[index] = value;}
		}
		public int Add(DateTime value)  
		{
			return(List.Add(value));
		}
		public int IndexOf(DateTime value)
		{
			return(List.IndexOf(value));
		}
		public void Insert(int index, DateTime value)
		{
			List.Insert(index, value);
		}
		public void Remove(DateTime value)  
		{
			List.Remove(value);
		}
		public bool Contains(DateTime value)  
		{
			return(List.Contains(value));
		}
	}


	public class RestrictedCalendarDesigner : ControlDesigner
	{
		public override string GetPersistenceContent()
		{
			StringWriter sw = new StringWriter();
			HtmlTextWriter html = new HtmlTextWriter(sw);

			RestrictedCalendar calendar 
				= this.Component as RestrictedCalendar;
			if (calendar != null)
			{
				// for each color in the collection, output its
				// html known name (if it is a known color)
				// or its html hex string representation
				// in the format:
				//   <Color value='xxx' />
				foreach(DateTime date in calendar.NonSelectableDates)
				{
					html.WriteBeginTag("DateTime");
					html.WriteAttribute("Value", date.ToString());
					html.WriteLine(HtmlTextWriter.SelfClosingTagEnd);
				}

			}
        
			return sw.ToString();

		}
	}

	public class RestrictedCalendarBuilder : ControlBuilder
	{
		public override Type GetChildControlType(string tagName, 
			IDictionary attribs)
		{
			if (string.Compare(tagName,"DateTime", true) == 0)
			{
				return typeof(DateTimeHelper);
			}

			return base.GetChildControlType (tagName, attribs);
		}
	}

	public class DateTimeHelper
	{
		private string val;
		public string Value
		{
			get {return val;}
			set {val = value;}
		}
	}
}
