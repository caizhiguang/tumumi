using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Collections;

namespace TMM.Core.Helper
{
    public class FormatHelper
    {
        

        

        /// <summary>
        /// ��ȡ��Ӣ�ĳ��ȣ����ġ�ȫ����2
        /// </summary>
        /// <returns></returns> 
        public static string CutString(string stringToSub, int length)
        {
            if (string.IsNullOrEmpty(stringToSub))
                return stringToSub;

            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            char[] stringChar = stringToSub.Trim().ToCharArray();
            StringBuilder sb = new StringBuilder();
            int nLength = 0;
            bool isCut = false;
            for (int i = 0; i < stringChar.Length; i++)
            {
                if (nLength >= length)
                {
                    isCut = true;
                    break;
                }
                if (regex.IsMatch((stringChar[i]).ToString()) || (stringChar[i] > 255))
                {
                    sb.Append(stringChar[i]);
                    nLength += 2;
                }
                else
                {
                    sb.Append(stringChar[i]);
                    nLength = nLength + 1;
                }

            }
            if (isCut)
                return sb.ToString() + "...";
            else
                return sb.ToString();

        }
        /// <summary>
        /// ��ȡ��Ӣ�ĳ��ȣ����ġ�ȫ����2
        /// </summary>
        /// <param name="stringToSub"></param>
        /// <param name="length"></param>
        /// <param name="end">������أ���β�ַ�</param>
        /// <returns></returns>
        public static string CutString(string stringToSub, int length, string end)
        {
            if (string.IsNullOrEmpty(stringToSub))
                return stringToSub;

            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            char[] stringChar = stringToSub.Trim().ToCharArray();
            StringBuilder sb = new StringBuilder();
            int nLength = 0;
            bool isCut = false;
            for (int i = 0; i < stringChar.Length; i++)
            {
                if (nLength >= length)
                {
                    isCut = true;
                    break;
                }
                if (regex.IsMatch((stringChar[i]).ToString()) || (stringChar[i] > 255))
                {
                    sb.Append(stringChar[i]);
                    nLength += 2;
                }
                else
                {
                    sb.Append(stringChar[i]);
                    nLength = nLength + 1;
                }

            }
            if (isCut)
                return sb.ToString() + end;
            else
                return sb.ToString();

        }
        /// <summary>
        /// �����ַ������ȣ����İ���2���ֽ���
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int Len(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            char[] stringChar = str.Trim().ToCharArray();
            StringBuilder sb = new StringBuilder();
            int nLength = 0;
            for (int i = 0; i < stringChar.Length; i++)
            {

                if (regex.IsMatch((stringChar[i]).ToString()) || (stringChar[i] > 255))
                {
                    nLength += 2;
                }
                else
                {

                    nLength = nLength + 1;
                }

            }
            return nLength;
        }

        public static string GetDateTime(DateTime dt)
        {
            return dt.Year + "-" + dt.Month + "-" + dt.Day + " " + dt.Hour + ":" + dt.Minute;
        }

        
        public static string FormatDate(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        public static string FormatDateToTimeJs(DateTime dt)
        {
            return dt.Year+","+(dt.Month-1)+","+dt.Day+","+dt.Hour+","+dt.Minute+","+dt.Second;
        }

        public static string GetYear(DateTime dt)
        {
            return dt.Year.ToString();
        }
        public static string GetMonth(DateTime dt)
        {
            return dt.Month.ToString();
        }

        public static string GetDay(DateTime dt)
        {
            return dt.Day.ToString();
        }

        

        public static string FormatNormNames(string normNames,string itemNormName)
        {
            normNames += itemNormName + " ";

            return normNames;

        }

        

        public static int Round(decimal number)
        {
            return Convert.ToInt32(Decimal.Round(number, 0));
        }
        public static int ConvertToInt(string str)
        {
            return Convert.ToInt32(str);
        }

        public static string GetDocIcon(string type) {
            return Helper.ConfigHelper.DocIconPath + type + ".gif";
        }
        /// <summary>
        /// ��ȡ�ĵ����ȶȵȼ�
        /// </summary>
        /// <param name="viewCount"></param>
        /// <returns></returns>
        public static int GetHotRule(int viewCount) {
            try
            {
                string[] hotRule = ConfigHelper.HotRule;
                int level = 0;
                for (int i = 0; i < hotRule.Length; i++)
                {
                    string[] range = hotRule[i].Split('-');
                    int min = int.Parse(range[0]);
                    //int max = 0;
                    //int.TryParse(range[1], out max);
                    int max = int.Parse(range[1]);
                    if (viewCount >= min && viewCount < max)
                    {
                        level = i + 1;
                        break;
                    }
                }
                return level;
            }
            catch {
                return 0;
            }
        }
        /// <summary>
        /// ��ȡ���ʱ��
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string GetRelateTime(DateTime d) {
            TimeSpan ts = DateTime.Now - d;
            double secondTotal = ts.TotalSeconds;
            string tp = "<p>{0}<span>{1}ǰ</span></p>";
            if (secondTotal < 60) {
                return string.Format(tp, (int)Math.Round(secondTotal), "��");
            }
            else if (secondTotal >= 60 && secondTotal < 60 * 60) {
                return string.Format(tp, (int)Math.Round(secondTotal/60), "����");
            }
            else if (secondTotal >= 60 * 60 && secondTotal < 60 * 60 * 24)
            {
                return string.Format(tp, (int)Math.Round(secondTotal / 3600), "Сʱ");
            }
            else {
                return string.Format(tp,(int)Math.Round( secondTotal / (3600 * 24)), "��");
            }
            
        }
        /// <summary>
        /// ��������ڶһ��Ĳ���
        /// </summary>
        /// <param name="amount">�˻����</param>
        /// <returns></returns>
        public static decimal ExchangeValue(decimal amount) {
            int a = Convert.ToInt32(amount);
            int ys = a % ConfigHelper.MinExchange;
            return a - ys;
        }
        /// <summary>
        /// ��ת���ĵ������ʵ��·��ת��Ϊ����·��
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetConvertUrl(string path)
        {
            string noImgUrl = "/contents/images/90x80_no.gif";
            if (string.IsNullOrEmpty(path))
                return noImgUrl;
            string r = path.Replace(ConfigHelper.ConvertPathReplaceStr,"").Replace('\\','/');
            return r;
        }
        /// <summary>
        /// ��ȡ֧����ʽ��intֵ
        /// </summary>
        /// <param name="payWay"></param>
        /// <returns></returns>
        public static int GetPayWay(string payWay)
        {
            int r = 0;
            if(!string.IsNullOrEmpty(payWay))
            {  
                switch (payWay.ToLower())
                { 
                    case "tenpay" :
                        r = 2;
                        break;
                    case "alipay" :
                        r = 1;
                        break;
                    case "chinabank":
                        r = 3;
                        break;
                    default :
                        r = -1;
                        break;
                }
            }
            return r;
        }
        /// <summary>
        /// �����ݰ������ķָ����ָ����ַ�������
        /// </summary>
        /// <param name="spilitChars">�����������ַ�����ֻ��ѡ��һ</param>
        /// <param name="content"></param>
        /// <returns></returns>
        /*public static string[] SpilitByChar(string[] spilitChars,string content)
        { 
        }
         * */
    }
}
