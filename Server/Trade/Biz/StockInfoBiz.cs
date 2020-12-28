using Common;
using Model.DB;
using MySQLSrv;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace Trade.Biz
{
    public class StockInfoBiz
    {
        private static List<BlockInfo> block;
        private static Dictionary<string, StockInfo> stock;

        public static void Init()
        {
            block = BlockInfoDA.List();
            stock = StockInfoDA.List();
        }

        public static BlockInfo GetBlock(string code)
        {
            return block.FirstOrDefault(b => b.specode.Contains(code.Substring(0, 3)));
        }

        public static IEnumerable<StockInfo> SearchStock(string key)
        {
            return stock.Where(kvp => kvp.Value.code.Contains(key) || kvp.Value.name.Contains(key) || kvp.Value.pyjc.Contains(key)).Take(10).Select(kvp => kvp.Value);
        }

        public static StockInfo GetStock(string code)
        {
            if (stock.ContainsKey(code))
                return stock[code];
            return null;
        }

        public static async void RefreshBlockList()
        {
            await Task.Run(() =>
            {
                try
                {
                    List<StockInfo> list = new List<StockInfo>();
                    FillSZList(ref list, ConfigurationManager.AppSettings["SZListUrl"], HostingEnvironment.MapPath("~") + "\\file\\SZList.xlsx");
                    FillSHList(ref list, ConfigurationManager.AppSettings["SHMbmListUrl"], HostingEnvironment.MapPath("~") + "\\file\\SHMbmList.txt");
                    FillSHList(ref list, ConfigurationManager.AppSettings["SHStartListUrl"], HostingEnvironment.MapPath("~") + "\\file\\SHStartList.txt");
                    if (list.Count > 4000)
                    {
                        StockInfoDA.Add(list);
                    }
                }
                catch (Exception ex)
                {
                    NLog.Error("刷新股票列表失败", ex);
                }
            });
        }

        private static void FillSZList(ref List<StockInfo> list, string url, string filename)
        {
            if (File.Exists(filename))
                File.Delete(filename);
            WebHelper.DownloadFile(url, filename);
            DataTable dt = ExcelHelper.ExcelToDataTable(filename, true);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new StockInfo()
                    {
                        code = dr["A股代码"].ToString(),
                        name = dr["A股简称"].ToString().Trim(),
                        date = dr["A股上市日期"].ToString()
                    });
                }
            }
        }

        private static void FillSHList(ref List<StockInfo> list, string url, string filename)
        {
            if (File.Exists(filename))
                File.Delete(filename);
            WebHelper.DownloadFile(url, filename);
            string[] lines = File.ReadAllLines(filename, Encoding.Default);
            if (lines != null && lines.Length > 0)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split('\t');
                    list.Add(new StockInfo()
                    {
                        code = fields[0],
                        name = fields[1].Trim(),
                        date = fields[4].Trim()
                    });
                }
            }
        }
    }
}