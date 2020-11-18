using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;


namespace Print.Http
{
    public class WriteLogs
    {

        /// <summary>
        /// 日志部分
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="type"></param>
        /// <param name="content"></param>
        public static void WriteLog(string fileName, string type, string content)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (!string.IsNullOrEmpty(path))
            {
                path = AppDomain.CurrentDomain.BaseDirectory + fileName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\" + DateTime.Now.ToString("yyyyMMdd");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                if (!File.Exists(path))
                {
                    FileStream fs = File.Create(path);
                    fs.Close();
                }
                String str = File.ReadAllText(path, Encoding.UTF8);
                FileStream _file = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                using (StreamWriter writer1 = new StreamWriter(_file))
                {
                    // writer1.WriteLine(writer1.NewLine);

                    writer1.WriteLine(str + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + type + "-->" + content);
                    writer1.Flush();
                    writer1.Close();
                    writer1.Dispose();
                    _file.Close();
                }

            }
        }


    }
}