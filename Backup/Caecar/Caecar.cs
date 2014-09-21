using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caecar
{
    public class Caecarcipher
    {
        public static int AscII(string str)
        {
            byte[] array = new byte[1];
            array = System.Text.Encoding.ASCII.GetBytes(str);
            int asciicode = (short)(array[0]);
            return asciicode;
     }            
    public static string Caesar(string str,int spaceNum)
    {
        char[] c = str.ToCharArray();
        string strCaesar = "";
        for (int i = 0; i < str.Length; i++)
        {
            string ins = c[i].ToString();
            string outs = "";
            bool isChar = "abcdefghijklmnopqrstuvwxyz".Contains(ins.ToLower());
            bool isToUpperChar = isChar && (ins.ToUpper() == ins);
            ins = ins.ToLower();
            if (isChar)
                { 
                    int offset=(AscII(ins) + spaceNum - AscII("a"))%(AscII("z")-AscII("a")+1);
                    outs = Convert.ToChar(offset + AscII("a")).ToString();
                    if(isToUpperChar)
                    {
                        outs = outs.ToUpper();
                    }
                 }                
                 else
                 {
                    outs = ins;
                 }
                    strCaesar+= outs;
        }
        return strCaesar;
    }
    public static string DeCaesar(string str, int spaceNum)
    {
        char[] p = str.ToCharArray();
        string strCaesar = "";
        for (int i = 0; i < str.Length; i++)
        {
            string ins = p[i].ToString();
            string outs = "";
            bool isChar = "abcdefghijklmnopqrstuvwxyz".Contains(ins.ToLower());
            bool isToUpperChar = isChar && (ins.ToUpper() == ins);
            ins = ins.ToLower();
            if (isChar)
            {
                int offset = (AscII(ins) - spaceNum - AscII("a")) % (AscII("z") - AscII("a") + 1);
                outs = Convert.ToChar(offset + AscII("a")).ToString();
                if (isToUpperChar)
                {
                    outs = outs.ToUpper();
                }
            }
            else
            {
                outs = ins;
            }
            strCaesar += outs;
        }
        return strCaesar;
    }
    
    }
}
