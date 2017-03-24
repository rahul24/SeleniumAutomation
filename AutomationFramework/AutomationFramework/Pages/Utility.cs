using System;
using System.Diagnostics;


namespace AutomationFramework.Pages
{
    internal static class Utility
    {
        public static string GetParentMethod()
        {
            StackTrace trace = new StackTrace();
            StackFrame[] frames = trace.GetFrames();
            //StackFrame frame= null;
            int j = 0;
            for (int i = 0; i < frames.Length; i++)
            {
                //frame = frames[i].GetMethod().Name;
                if (frames[i].GetMethod().Name == "InvokeMethod")
                {
                    j = i - 1;
                    break;
                }
            }
            StackFrame frame = frames[j];
            string methodName = (frame != null)? frame.GetMethod().Name:string.Empty;
            return methodName;
        }

        public static string GetPageName()
        {
            StackTrace trace = new StackTrace();
            StackFrame[] frames = trace.GetFrames();
            int j = 0;
            for (int i = frames.Length-1;i >= 0; i--)
            {
                if (frames[i].GetMethod().DeclaringType.Name == "PageConfigurationReader")
                {
                    j = i + 1;
                    break;
                }
            } 
            StackFrame frame = frames[j];
            string pageName = frame.GetMethod().DeclaringType.Name;                              
            return pageName;
        }
    }
}
