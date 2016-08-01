using System.Drawing;
using System.IO;
using System.Text;

namespace MSBuildDebugger
{
    public class StackFrame
    {
        internal string ExecutablePath { get; set; }
        internal Point StartLocation { get; set; }
        internal Point EndLocation { get; set; }
        internal string TargetName { get; set; }
        internal string TaskName { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Path.GetFileName(ExecutablePath));
            sb.AppendFormat(" [Line {0}, Column {1}]", StartLocation.Y, StartLocation.X);
            if (null != TargetName)
            {
                sb.AppendFormat(" - Target: {0}", TargetName);
                if (null != TaskName)
                {
                    sb.AppendFormat(" - Task: {0}", TaskName);
                }
            }

            return sb.ToString();
        }
    }
}
