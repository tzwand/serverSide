using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Data;
using ExcelDataReader;
using DTO;
using DAL;

namespace BLL
{
    public static class FileLogic
    {
        public static string handleNewGroup(Base64 base64File, string fileName, int reqId, string groupName, string folderPath = "")
        {
            //create a new group
            addGroup(reqId, groupName);
            //handle the info in the file
            string filename = SaveFileByBase64(base64File.base64, fileName, reqId,groupName);
            return filename;
        }
        //adds a new closed group to the db
        public static  void addGroup(int reqId,string groupName){
            using (BTProjectEntities db = new BTProjectEntities())
            {
                ClosedGroup cg = new ClosedGroup();
                cg.reqId = reqId;
                cg.groupName = groupName;
                List<ClosedGroup> c = new List<ClosedGroup>();
                c.Add(cg);
                db.closedGroup_tbl.Add(ClosedGroup.DTOToc(c)[0]);
                db.SaveChanges();
            }
        }
            /// <summary>
            /// שמירת הקובץ בתקיה פנימת
            /// </summary>
            /// <param name="base64File"></param>
            /// <param name="fileName"></param>
            /// <param name="folderPath"></param>
            /// <returns></returns>
        public static string SaveFileByBase64(string base64File, string fileName, int reqId,string groupName ,string folderPath = "")
            {
                try
                {
                    if (base64File.IndexOf(";base64,") != -1)
                    {
                        // Create a new folder, if necessary.
                        if (!Directory.Exists(@AppDomain.CurrentDomain.BaseDirectory))
                            Directory.CreateDirectory(@AppDomain.CurrentDomain.BaseDirectory + ReadSetting("FileFolderPath") + folderPath);

                        if (fileName == null || fileName == "")
                            fileName = Guid.NewGuid() + "." + base64File.Substring(base64File.IndexOf('/') + 1, base64File.IndexOf(';') - (base64File.IndexOf('/') + 1));
                        else
                        {
                            int index = 1;
                            string newFilename = fileName;
                            while (File.Exists(@AppDomain.CurrentDomain.BaseDirectory + "Files\\" + newFilename))
                            {
                                newFilename = fileName.Split('.')[0] + "(" + index + ")" + (fileName.Split('.').Length > 1 ? "." + fileName.Split('.')[1] : "");
                                index++;
                            }
                            fileName = newFilename;
                        }

                        string sPath = AppDomain.CurrentDomain.BaseDirectory + "Files\\" + fileName;
                        byte[] array = Convert.FromBase64String(base64File.Substring(base64File.IndexOf(",") + 1));
                        File.WriteAllBytes(sPath, array);

                    //call a function to read to file and export to sql server
                    ExportExcelToSql(fileName, sPath,reqId,groupName);
                        return fileName;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {

                    return null;
                }
            }

            private static string ReadSetting(string v)
            {
                throw new NotImplementedException();
            }
        public static void ExportExcelToSql(string fileName,string path,int reqId,string groupName)
        {
            ReadExcelFile(fileName, path, reqId,groupName);
            
            //ExportExcelToSql();
        }
        private static void ExportToSql(DataTable dt)
        {

        }
        //public static string ReadExcelFile()
        //{
        //    return null;
        //}

        //a function to convert an excel spreadsheet to a data table
        private static void ReadExcelFile(string sheetName, string path, int reqId, string groupName)
        {
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:
                    //// 1. Use the reader methods
                    //do
                    //{/
                    //    while (reader.Read())
                    //    {
                    //        // reader.GetDouble(0);
                    //    }
                    //} while (reader.NextResult());


                    // 2. Use the AsDataSet extension method
                    var result = reader.AsDataSet();

                    // The result of each spreadsheet is in result.Tables
                    //
                    //var cellStr = "AB2"; // var cellStr = "A1";
                    //var match = Regex.Match(cellStr, @"(?<col>[A-Z]+)(?<row>\d+)");
                    //var colStr = match.Groups["col"].ToString();
                    //var col = colStr.Select((t, i) => (colStr[i] - 64) * Math.Pow(26, colStr.Length - i - 1)).Sum();
                    //var row = int.Parse(match.Groups["row"].ToString());
                    Learner l = new Learner();
                    var dataTable = result.Tables[0];
                    //for (var i = 1; i < dataTable.Rows.Count; i++)
                    //{
                    //    for (var j = 1; j < dataTable.Columns.Count; j++)
                    //    {

                    //        var data = dataTable.Rows[i][j];
                    //    }
                    //}

                    //start i from 1 because id is auto generated
                    for (int i = 2; i < dataTable.Rows.Count; i++)
                    {
                        //in the meantime - just learner email and name and we will email the learners in the list
                        l.learnerName = dataTable.Rows[i][1].ToString();
                        l.learnerEmail = dataTable.Rows[i][2].ToString();
                        //email the learners
                        using (BTProjectEntities db = new BTProjectEntities())
                        {
                            //find the donor
                            var req = db.request_tbl.FirstOrDefault(myreq => myreq.reqId == reqId);
                            var userName = req.donorName;
                            Email e = new Email(l.learnerName, l.learnerEmail);
                            string bodyPath = "C:\\Users\\tzipp\\BTProject\\cheshvanProject\\BLL\\BLL\\NewLearner.rtf";

                            e.sendEmailViaWebApi(l.learnerName, l.learnerEmail, "הצטרפות לאוצר הלימוד", bodyPath, userName);

                            //add the learner to the closed group section in learner tbl

                            var group = db.closedGroup_tbl.FirstOrDefault(g => g.groupName == groupName);
                            l.groupId = group.GroupId;
                            //we need to generate a password as well
                            int pass = logic.getRandomPassword();
                            l.password = pass.ToString();

                            e.sendEmailViaWebApi(pass.ToString());

                            //need to email him his password
                            //a workaround for the meantime


                            //data.addLearner(l);

                        }

                    }

                }
            }
        }
        //private static DataTable ReadExcelFile(string sheetName, string path)
        //{

        //    using (OleDbConnection conn = new OleDbConnection())
        //    {
        //        DataTable dt = new DataTable();
        //        string Import_FileName = path;
        //        string fileExtension = Path.GetExtension(Import_FileName);
        //        if (fileExtension == ".xls")
        //            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
        //        if (fileExtension == ".xlsx")
        //            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";


        //        using (OleDbCommand comm = new OleDbCommand())
        //        {
        //            sheetName = "גליון1";

        //            comm.CommandText = "Select * from [ + sheetName + $]";
        //            comm.Connection = conn;
        //            using (OleDbDataAdapter da = new OleDbDataAdapter())
        //            {
        //                da.SelectCommand = comm;
        //                da.Fill(dt);
        //                return dt;
        //            }
        //        }

        //    }

        //}
      
    }
    }


