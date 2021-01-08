using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace NOPI_Import
{
    public class ImportHelper
    {
        private string _tableName = string.Empty;
        private string _constr = string.Empty;
        private string _serverPath = string.Empty;
        private Dictionary<string, string> source_destination_Dic = new Dictionary<string, string>();//(数据源中源列的名称,目标表中目标列的名称)

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serverPath">文件路径</param>
        /// <param name="tableName">要操作的数据库表名称</param>
        /// <param name="constr">设置的数据库连接字符串</param>
        public ImportHelper(string serverPath, string tableName, string constr)
        {
            this._serverPath = serverPath;
            this._tableName = tableName;
            this._constr = constr;
        }

        /// <summary>
        /// 导入数据库
        /// </summary>
        /// <returns>返回导入信息 status=200表示成功</returns>
        public ImportResponse Import()
        {
            ImportResponse response = new ImportResponse();
            try
            {
                DataTable dt = ReadExcel(_serverPath);
                BulkInsertDB(dt);
                response.status = 200;
                response.Message = "导入成功";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }


        /// <summary>
        /// 获取excel内容
        /// </summary>
        /// <param name="filePath">excel文件路径</param>
        /// <returns></returns>
        private DataTable ReadExcel(string filePath)
        {
            DataTable dt = new DataTable();
            using (FileStream fsRead = System.IO.File.OpenRead(filePath))
            {
                IWorkbook wk = null;
                //获取后缀名
                string extension = filePath.Substring(filePath.LastIndexOf(".")).ToString().ToLower();
                //判断是否是excel文件
                if (extension == ".xlsx" || extension == ".xls")
                {
                    //判断excel的版本
                    if (extension == ".xlsx")
                    {
                        wk = new XSSFWorkbook(fsRead);
                    }
                    else
                    {
                        wk = new HSSFWorkbook(fsRead);
                    }
                    //wk = new XSSFWorkbook(fsRead);
                    //获取第一个sheet
                    ISheet sheet = wk.GetSheetAt(0);
                    //获取第一行
                    IRow headrow = sheet.GetRow(0);
                    //创建列
                    for (int i = headrow.FirstCellNum; i < headrow.Cells.Count; i++)
                    {
                        string value = headrow.GetCell(i).StringCellValue;
                        DataColumn datacolum = new DataColumn(value);
                        //DataColumn datacolum = new DataColumn("F" + i);
                        dt.Columns.Add(datacolum);
                        source_destination_Dic.Add(value, value);
                    }
                    //读取每行,从第2行起
                    for (int r = 1; r <= sheet.LastRowNum; r++)
                    {
                        bool result = false;
                        DataRow dr = dt.NewRow();
                        //获取当前行
                        IRow row = sheet.GetRow(r);
                        if (row != null)
                        {
                            //读取每列
                            for (int j = 0; j < headrow.Cells.Count; j++)
                            {
                                ICell cell = row.GetCell(j); //一个单元格
                                if (r == 1748)
                                {

                                }
                                try
                                {
                                    dr[j] = GetCellValue(cell); //获取单元格的值
                                                                //全为空则不取
                                    if (!string.IsNullOrEmpty(dr[j].ToString()))
                                    {
                                        result = true;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }

                        if (result == true)
                        {
                            dt.Rows.Add(dr); //把每行追加到DataTable
                        }
                    }
                }

            }
            return dt;
        }
        //对单元格进行判断取值
        private string GetCellValue(ICell cell)
        {
            if (cell == null)
                return string.Empty;
            switch (cell.CellType)
            {
                case CellType.Blank: //空数据类型 这里类型注意一下，不同版本NPOI大小写可能不一样,有的版本是Blank（首字母大写)
                    return string.Empty;
                case CellType.Boolean: //bool类型
                    return cell.BooleanCellValue.ToString();
                case CellType.Error:
                    return cell.ErrorCellValue.ToString();
                case CellType.Numeric: //数字类型
                    if (HSSFDateUtil.IsCellDateFormatted(cell))//日期类型
                    {
                        return cell.DateCellValue.ToString();
                    }
                    else //其它数字
                    {
                        return cell.NumericCellValue.ToString();
                    }
                case CellType.Unknown: //无法识别类型
                case CellType.String: //string 类型
                    return cell.StringCellValue;
                case CellType.Formula: //带公式类型
                    try
                    {
                        HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
                        e.EvaluateInCell(cell);
                        return cell.ToString();
                    }
                    catch
                    {
                        //return cell.NumericCellValue.ToString();
                        return cell.ToString();
                    }
                default: //默认类型
                    return cell.ToString();//
            }

        }

        /// <summary>
        /// 批量导入数据库
        /// </summary>
        /// <param name="dt"></param>
        private void BulkInsertDB(DataTable dt)
        {
            using (SqlBulkCopy bulk = new SqlBulkCopy(_constr))
            {
                bulk.DestinationTableName = _tableName;
                foreach (var item in source_destination_Dic)
                {
                    bulk.ColumnMappings.Add(item.Key, item.Value);
                }
                bulk.WriteToServer(dt);
            }

        }
    }

    public class ImportResponse
    {
        public int status { get; set; }

        public string Message { get; set; }

        public ImportResponse()
        {
            this.status = 0;
            this.Message = string.Empty;
        }

    }
}
