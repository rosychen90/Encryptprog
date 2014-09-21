using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace permutation
{
    public class permutationcipher
    {
        public static string encrypt(string spt, string sorder, int blen)							//加密函数
        {
            int n = spt.Length;
            char[] temppt = spt.Trim().ToCharArray();
            char[] pt = new char[100];
            temppt.CopyTo(pt, 0);
            int[] order = new int[sorder.Length];
            for (int i = 0; i < sorder.Length; i++)//将全部的数字存到数组里。
            {
                order[i] = Convert.ToInt32(sorder[i].ToString());
            }
            char[] ct = new char[500];
            if (n % blen != 0)					//补空格
            {
                for (int i = n; i < n + (blen - n % blen); i++)
                    pt[i] = ' ';
                n = n + blen - n % blen;
            }
            for (int i = 0; i < n / blen; i++)						//加密
            {
                for (int j = 0; j < blen; j++)
                {
                    ct[i * blen + order[j] - 1] = pt[i * blen + j];
                }
            }
            string ct1 = new string(ct);
            return ct1;
        }
        public static string decrypt(string sct, string sorder, int blen)
        {
            int n = sct.Trim().Length;
            char[] tempct = sct.Trim().ToCharArray();
            char[] order = sorder.ToCharArray();
            char[] pt = new char[200];
            char[] ct = new char[100];
            tempct.CopyTo(ct, 0);
            /*for (int i = 0; i < 20; i++)							//计算去掉空格后密文长度
            {
                if (ct[i] == ' ')
                {
                    for (int j = 0; j < n - i; j++)					//如果有空格，将后面的字符前移一位
                        ct[i + j] = ct[i + j + 1];
                    ct[n - 1] = '\0';
                    n--;
                }
            }*/
            if (n % blen != 0)					//补空格
            {
                for (int i = n; i < n + (blen - n % blen); i++)
                    ct[i] = ' ';
                n = n + blen - n % blen;
            }
            for (int i = 0; i < n / blen; i++)
                for (int j = 0; j < blen; j++)
                {
                    pt[i * blen + j] = ct[i * blen + order[j] - 1];
                }
            string pt1 = new string(pt);
            return pt1;
        }
    }
}

