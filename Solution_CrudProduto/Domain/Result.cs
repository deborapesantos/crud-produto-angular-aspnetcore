using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Solution_CrudProduto.Domain
{
    public class Result
    {
        public string Message { get; private  set; }
        private TaskStatus Status { get; set; }
        private string FileName { get; set; }

        public bool Success { get; private set; }

        public Result()
        {
            this.Success = true;
        }

        public Result GravarLog(Exception ex,string pFileName=null)
        {
            this.Message = ex.Message;
            this.FileName = pFileName;
            this.Success = false;
            
            if (string.IsNullOrEmpty(this.FileName))
                this.FileName = DateTime.Now.ToString("yyyy-mm-dd");

            GravaLogTxt(this);

            return this;
        }


        private void GravaLogTxt(Result resultado)
        {
            string folderPath = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["LogPath"];
            string filePath = string.Empty;
            try
            {

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                filePath = Path.Combine(folderPath, string.Format("{0}_{1}", resultado.FileName, DateTime.Now.ToString("yyyyMM")) + ".log");

                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(DateTime.Now.ToString() + resultado.Message);
                }
            }
            catch
            {
                //Erro ao escrever no log do arquivo filePath.
            }

            finally { }

        }

    }
}
