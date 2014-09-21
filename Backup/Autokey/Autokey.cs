using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autokey
{
    public class Autokeycipher
    {
        public static char[] increase(char[] mw,char[] k,int n1)
        {
            int i=0;
            char[] key = new char[100];
            k.CopyTo(key, 0);
            while(k.Length+i<=n1)
		        {
			        key[k.Length+i]=mw[i];
			        i++;
                }
            return key;
        }
        public static string encryption(string splaintext,string skey)														//加密算法
        {
            char[] e= new char[2];
	        int s1,s2;
	        int n1= splaintext.Length;
	        int n2= skey.Length;
	        char[] plaintext = splaintext.ToCharArray();
            char[] temkey = skey.ToCharArray();
            char[] ciphertext=new char[100];
            int i;
            char[,] v = new char[26,26];
            for(i=0;i<26;i++)
	        {
		        for(int j=0;j<26;j++)
		        {
			        v[i,j]=(char)((i+j)%26+97);										//计算Vigenere中每一个位置并用26*26矩阵记录
		        }
	        }
	        if(n1<=n2)
	        {
		        for(int q=0;q<n1;q++)
		        {
			        s1=(int)plaintext[q]-97;
			        s2=(int)temkey[q%n2]-97;	
			        ciphertext[q]=v[s1,s2];									//在Vigenere表中找到对应位置并输出加密结果							
		        }
	        }else
	        {
                char[] key = increase(plaintext,temkey, n1);
		        for(int q=0;q<n1;q++)
		        {
			        s1=(int)plaintext[q]-97;
			        s2=(int)key[q]-97;	
			        ciphertext[q]=v[s1,s2];									//在Vigenere表中找到对应位置并输出加密结果								
		        }
	        }
            string sc = new string(ciphertext);
            return sc;
        }
        public static string decryption(string sciphertext,string skey)
        {
            char[,] v = new char[26,26];
            char[] m = new char[100];
            char[] r=new char[3];
            char[] ciphertext = sciphertext.ToCharArray();
            char[] temkey = skey.ToCharArray();
            int i=0;
	        int n3= sciphertext.Length;
	        int n4= skey.Length;
            char[] key = new char[n3 - 1];
            temkey.CopyTo(key, 0);
            for (i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    v[i, j] = (char)((i + j) % 26 + 97);										//计算Vigenere中每一个位置并用26*26矩阵记录
                }
            }
            if(n3<=n4)
	        {
		        for(int q=0;q<n3;q++)
		        {
			        m[i]=(char)(((int)ciphertext[q]-(int)key[q%n4]+26)%26+97);	//密文与密钥运算得到明文并输出
			        i++;
		        }
	        }else
	        {
		        while(n4+i<=n3)
		        {
			        for(int q=0;q<n3;q++)
			        {
				        m[i]=Convert.ToChar((((int)ciphertext[q]-(int)key[q]+26)%26+97));	//密文与密钥运算得到明文并输出
				        key[n4+i]=m[i];									//m存储的是解密后的明文
				        i++;
			        }
		        }
	        }
            string sm = new string(m);
            return sm;
        }
    }
}
