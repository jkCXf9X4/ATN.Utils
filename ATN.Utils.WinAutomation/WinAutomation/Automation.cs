
using System;
using System.Windows.Forms;
//using System.Drawing;
using System.Diagnostics;
using System.Windows.Automation;


namespace ATN.Utils.WinAutomation
{
	/// <summary>
	/// Description of automation.
	/// </summary>
	public static class Automation
	{
					
		public static void AutomationElementToDebug()
		{
			throw new NotImplementedException();



			// AutomationElement temp = AutomationElement.FromPoint(new System.Windows.Point(ATN.WinApi.Mouse.GetCursorPosition().x, Mouse.GetCursorPosition().y));
			// if (temp != null) {
			// 	Debug.WriteLine("Name: {0}", temp.GetCurrentPropertyValue(AutomationElement.NameProperty));
			// 	Debug.WriteLine("Value: {0}", temp.GetCurrentPropertyValue(ValuePattern.ValueProperty));
			// }
		}
		
		
		public static void DebugInfoExt(this AutomationElement root)
		{
			Debug.WriteLine("Name: {0}", root.GetCurrentPropertyValue(AutomationElement.NameProperty));
			Debug.WriteLine("Value: {0}", root.GetCurrentPropertyValue(ValuePattern.ValueProperty));
		   
		}
		
		public static void CheckNull(this object i)
        {
			if (i == null)
			{
				throw new Exception("Control not found");
			}
		}
		
		public static AutomationElement FindByNameExt(this AutomationElement root, string name)
		{
			var result = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, name));
			result.CheckNull();
			return result;
		}

		public static AutomationElement FindByTextExt(this AutomationElement root, string text)
		{
			var result = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.HelpTextProperty, text));
			result.CheckNull();
			return result;
		}

		public static AutomationElement FindByClassExt(this AutomationElement root, string Class)
		{
			var result = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, Class));
			result.CheckNull();
			return result;
		}
		public static AutomationElement FindByIdExt(this AutomationElement root, string Id)
		{
			var result = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, Id));
			result.CheckNull();
			return result;
		}

		public static AutomationElementCollection FindByTypeExt(this AutomationElement root, ControlType type)
		{
			var result = root.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, type));
			result.CheckNull();
			return result;
		}

		public static AutomationElement FindWindowFromName(string captation, int timeout = 2000, PropertyConditionFlags pcf = PropertyConditionFlags.IgnoreCase)
		{
			const int timer = 100;
			int ticks = timeout / timer;
			
			var root = AutomationElement.RootElement;
			for (int i = 0; i < ticks; i++) {
				var dialog = root.FindFirst(TreeScope.Subtree, new PropertyCondition(
					             AutomationElement.NameProperty, 
					             captation, 
					             pcf));
				
				if (dialog != null) {
					return dialog;
				}
				
				System.Threading.Thread.Sleep(timer);
			}
			return null;
		}
		

		
		public static bool SelectComboboxItemExt(this AutomationElement comboBox, string item)
		{
			if (comboBox == null)
				return false;
			// Get the list box within the combobox
			AutomationElement listBox = comboBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List));
			if (listBox == null)
				return false;
			// Search for item within the listbox
			AutomationElement listItem = listBox.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, item));
			if (listItem == null)
				return false;
            // Check if listbox item has SelectionItemPattern
            if (true == listItem.TryGetCurrentPattern(SelectionItemPatternIdentifiers.Pattern, out object objPattern))
            {
                var selectionItemPattern = objPattern as SelectionItemPattern;
                selectionItemPattern.Select(); // Invoke Selection

                System.Threading.Thread.Sleep(100);
                return true;
            }
            return false;
		}
		
		public static bool SelectFieldExt(this AutomationElement button)
		{
			try {
				var invokePattern = (SelectionItemPattern) button.GetCurrentPattern(SelectionItemPatternIdentifiers.Pattern);
				invokePattern.Select();
				return true;
			} catch (Exception e) {
				Debug.WriteLine(e.Message);
				return false;
			}
		}
	
		// dont work
		public static bool PressLMouseButtonExt(this AutomationElement field)
		{
			throw new NotImplementedException();
			
			//var sim = new WindowsInput.InputSimulator();
			//System.Windows.Point point = field.GetClickablePoint();
			//sim.Mouse.MoveMouseToPositionOnVirtualDesktop((int)point.X, (int)point.Y);
			//System.Threading.Thread.Sleep(100);
			//sim.Mouse.LeftButtonClick();
			//return true;

		}
		
			
		public static bool PressButtonExt(this AutomationElement button)
		{
			try {
				var invokePattern = button.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
				invokePattern.Invoke();
				return true;
			} catch (Exception e) {
				Debug.WriteLine(e.Message);
				return false;
			}
		}
		
		public static bool ToggleCheckboxExt(this AutomationElement checkBox)
		{
			try {
				var togglePattern = checkBox.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
				togglePattern.Toggle();
				return true;
			} catch (Exception e) {
				Debug.WriteLine(e.Message);
				return false;
			}
		}
	
		public static bool WriteTextExt(this AutomationElement element, string text)
		{
			if(element == null)
				throw new NullReferenceException("Element is null");
			try {
				var valuePattern = element.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
				valuePattern.SetValue(text);
				return true;
				
			} catch {

				element.SetFocus(); 
				System.Threading.Thread.Sleep(100);

				SendKeys.SendWait(text);
				
				return true;
			}
		}
		
	
	}
}
