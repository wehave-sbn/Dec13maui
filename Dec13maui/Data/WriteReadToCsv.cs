using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dec13maui.Data
{
	internal class WriteReadToCsv
	{
		public static void WritejsonDataToText(StudentModel data, string path)
		{
            //var jdata = string.Format("{0},{1},{2},{3}", data.Name, data.Address, data.Phone, data.Email);

            List<StudentModel> students = new List<StudentModel>();
            students.Add(
                new StudentModel
                {
                    Name = data.Name,
                    Address = data.Address,
                    Phone = data.Phone,
                    Email = data.Email
                }
            );

            string json = JsonSerializer.Serialize(students) + Environment.NewLine;

			File.AppendAllText(path, json);
		}


        public static List<StudentModel> GetAll(string path)
        {
            string _filePath = "D:\\studentRecord.json";
            //// string appUsersFilePath = Utils.GetAppUsersFilePath();
            if (!File.Exists(_filePath))
            {
                return new List<StudentModel>();
            }
            var json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<List<StudentModel>>(json);
        }
    }
}
