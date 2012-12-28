using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TMM.Core.Utils
{
    public class MyRandom
    {
        /// <summary>
        /// ���ش��ڻ��������С�� System.Int32.MaxValue �� 32 λ������������
        /// </summary>
        /// <returns></returns>
        public static int Next()
        {
            Random rand = new Random();
            return rand.Next();
        }
        /// <summary>
        /// ���ش��ڻ��������С�� maxValue �� 32 λ����������
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int Next(int maxValue)
        {
            Random rand = new Random();
            return rand.Next(maxValue);
        }
        /// <summary>
        /// ����һ�����ڻ���� minValue ��С�� maxValue �� 32 λ������������
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int Next(int minValue, int maxValue)
        {
            Random rand = new Random();
            return rand.Next(minValue, maxValue);
        }

        /// <summary>
        /// C#���������ָ�����ȵ�����
        /// </summary>
        private static string MakePassword(int pwdLength)
        {
            //����Ҫ���ص��ַ���
            string tmpstr = "";
            //�����а������ַ�����
            string pwdchars = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //�������������
            int iRandNum;
            //�����������
            Random rnd = new Random();
            for (int i = 0; i < pwdLength; i++)
            {
                //Random���Next��������һ��ָ����Χ�������
                iRandNum = rnd.Next(pwdchars.Length);
                //tmpstr������һ���ַ�
                tmpstr += pwdchars[iRandNum];
            }
            return tmpstr;
        }

        /// <summary>
        /// ������[minValue,maxValue]ȡ��num��������ͬ����������������顣 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public int[] DifferSamenessRandomNum(int num, int minValue, int maxValue)
        {

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));//��֤���������ֵ������ 

            int[] intArr = new int[num];

            ArrayList myList = new ArrayList();

            while (myList.Count < num)
            {
                int value = rnd.Next(minValue, maxValue);
                if (!myList.Contains(value))    // ����ǹؼ�
                    myList.Add(value);
            }

            //  ת��Ϊ��������
            for (int i = 0; i < num; i++)
                intArr[i] = (int)myList[i];

            ////  ����
            //for (int i = 0; i < intArr.Length-1; i++)
            //{
            //    for (int j = 0; j < intArr.Length-1; j++)
            //    {
            //        if(intArr[j] > intArr[j+1])
            //        {
            //            temp = intArr[j + 1];
            //            intArr[j + 1] = intArr[j];
            //            intArr[j] = temp;
            //        }
            //    }
            //}


            return intArr;

        }

    }

}
