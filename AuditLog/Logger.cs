namespace AuditLog
{
    public class Logger
    {
        public string Path { get; set; }
        public bool Disable { get; set; }
        private string mCurrentClass;
        private int mActivateTimeDelay;
        //private DateTime mStartupTime;
        public Logger(string path)
        {
            Path = path;
            var fi = new FileInfo(path);
            if (!Directory.Exists(fi.Directory.FullName))
            {
                Directory.CreateDirectory(fi.Directory.FullName);
            }
            //mStartupTime = DateTime.Now;
        }

        public void SetCurrentClass(Type currentType)
        {
            mCurrentClass = currentType.Name;
        }

        public void ActivateAfterStartup(int s = 0)//second
        {
            mActivateTimeDelay = s;
        }

        public void WrtiteLog(string context = "", [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            if (Disable) return;

            //if (mActivateTimeDelay != 0)
            //{
            //    var diff = (DateTime.Now - GlobalSetting.StartupTime).TotalSeconds;
            //    if (diff < mActivateTimeDelay) return;
            //}

            StreamWriter userLog = null;
            try
            {
                userLog = new StreamWriter(Path, true);
                userLog.AutoFlush = true;
                userLog.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:{mCurrentClass} - {memberName}: {context}");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                userLog?.Close();
                //fs.Dispose();                
            }
        }
    }
}
