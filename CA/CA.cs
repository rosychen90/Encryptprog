using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA
{
    public class CA
    {
        					//初始数组，并根据规则变化

        public static string itos(int[] intArray)
        {
            string str = "";

            for (int index = 0; index < intArray.Length; ++index)
            {

                str+= intArray[index].ToString();

            }
            return str;
        }
        private static int[] aaaaa(string a)
        {
        int[] ccc=new int[a.Length];
        for(int i=0;i<a.Length;i++)//将全部的数字存到数组里。
        {
            ccc[i]=Convert.ToInt32(a[i].ToString());
        }
        return ccc;
        } 

        
        public static string encrypt(string spt,string skey1,int k)											//加密算法，将明文数组中每个分别与密钥流数组进行异或

        {
    
            int[] key1 = aaaaa(skey1);
            int[] key3 = new int[7];					//根据规则变换后的数组
            int[] key2 = new int[8];					//存储对应规则的数组
            int[] keystr = new int[140];				//存储密钥流
            char[] pt = new char[20];					//存储明文
            int[] ct=new int[20];					//存储密文
            int[] pts=new int[140];					//存储明文转化为二进制后的
            int[] cts=new int[140];					//存储pts数组加密后的
            int i,j,l,m,e;
            int N = 3;
            //密钥流的生成
	        key2[0]=k/128;									//将用户输入的规则转化为8位二进制数，即对应规则
	        key2[1]=k%128/64;
	        key2[2]=k%128%64/32;
	        key2[3]=k%128%64%32/16;
	        key2[4]=k%128%64%32%16/8;
	        key2[5]=k%128%64%32%16%8/4;
	        key2[6]=k%128%46%32%16%8%4/2;
	        key2[7]=k%128%46%32%16%8%4%2/1;
            l = pt.Length;
            for(i=0;i<7*l;i++)								//循环变换初始数组
	        {
		        key3[0]=key2[key1[6]*4+key1[0]*2+key1[1]*1];
		        key3[1]=key2[key1[0]*4+key1[1]*2+key1[2]*1];
		        key3[2]=key2[key1[1]*4+key1[2]*2+key1[3]*1];
		        key3[3]=key2[key1[2]*4+key1[3]*2+key1[4]*1];
		        key3[4]=key2[key1[3]*4+key1[4]*2+key1[5]*1];
		        key3[5]=key2[key1[4]*4+key1[5]*2+key1[6]*1];
		        key3[6]=key2[key1[5]*4+key1[6]*2+key1[0]*1];
		        for(j=0;j<7;j++)								//将key2的值赋给key1，用作下次变换
			        key1[j]=key3[j];
		        keystr[i]=key3[N];
	        }
	        //将用户输入的明文转换为二进制数
	        for(i=0;i<l;i++)
	        {
		        m=pt[i]-k;							//计算明文距a的偏移量
		        m+=97;								//偏移量加上97即为其ASCII码
		        pts[i*7+0]=m/64;
		        pts[i*7+1]=m%64/32;
		        pts[i*7+2]=m%64%32/16;
		        pts[i*7+3]=m%64%32%16/8;
		        pts[i*7+4]=m%64%32%16%8/4;
		        pts[i*7+5]=m%64%32%16%8%4/2;
		        pts[i*7+6]=m%64%32%16%8%4%2/1;				//pts为明文的二进制表示
	        }
	        //密钥流的产生
	        key2[0]=k/128;									//将用户输入的规则转化为8位二进制数，即对应规则
	        key2[1]=k%128/64;
	        key2[2]=k%128%64/32;
	        key2[3]=k%128%64%32/16;
	        key2[4]=k%128%64%32%16/8;
	        key2[5]=k%128%64%32%16%8/4;
	        key2[6]=k%128%46%32%16%8%4/2;
	        key2[7]=k%128%46%32%16%8%4%2/1;
	        for(i=0;i<7*l;i++)								//循环变换初始数组
	        {
		        key3[0]=key2[key1[6]*4+key1[0]*2+key1[1]*1];
		        key3[1]=key2[key1[0]*4+key1[1]*2+key1[2]*1];
		        key3[2]=key2[key1[1]*4+key1[2]*2+key1[3]*1];
		        key3[3]=key2[key1[2]*4+key1[3]*2+key1[4]*1];
		        key3[4]=key2[key1[3]*4+key1[4]*2+key1[5]*1];
		        key3[5]=key2[key1[4]*4+key1[5]*2+key1[6]*1];
		        key3[6]=key2[key1[5]*4+key1[6]*2+key1[0]*1];
		        for(j=0;j<7;j++)								//将key2的值赋给key1，用作下次变换
			        key1[j]=key3[j];
		        keystr[i]=key3[N];								//keystr存储的是密钥流								

	        }


	        for(i=0;i<7*l;i++)									//异或
	        {
		        if(pts[i]==keystr[i])
			        cts[i]=0;
		        else
			        cts[i]=1;
	        }	
	        for(i=0;i<l;i++)
	        {
		        ct[i]=cts[i*7]*64+cts[i*7+1]*32+cts[i*7+2]*16+cts[i*7+3]*8+cts[i*7+4]*4+cts[i*7+5]*2+cts[i*7+6]*1;
		        ct[i]-=97;
	        }
	        for(i=0;i<l;i++)
	        {
		        e=k+ct[i];
		        ct[i]=e;
	        }
            return itos(ct);
        }

        public static string decrypt(string ct,string skey1,int k)
        {
	        //密钥流的生成
            int[] key1 = aaaaa(skey1);
            int[] key3 = new int[3];					//根据规则变换后的数组
            int[] key2 = new int[8];					//存储对应规则的数组
            int[] keystr = new int[140];				//存储密钥流
            char[] pt = new char[20];					//存储明文
            int[] pts=new int[140];					//存储明文转化为二进制后的
            int[] cts=new int[140];					//存储pts数组加密后的
            int i,j,l,m,e;
            int N = 3;
            key2[0]=k/128;									//将用户输入的规则转化为8位二进制数，即对应规则
	        key2[1]=k%128/64;
	        key2[2]=k%128%64/32;
	        key2[3]=k%128%64%32/16;
	        key2[4]=k%128%64%32%16/8;
	        key2[5]=k%128%64%32%16%8/4;
	        key2[6]=k%128%46%32%16%8%4/2;
	        key2[7]=k%128%46%32%16%8%4%2/1;
            l = ct.Length;
            for(i=0;i<7*l;i++)								//循环变换初始数组
	        {
		        key3[0]=key2[key1[6]*4+key1[0]*2+key1[1]*1];
		        key3[1]=key2[key1[0]*4+key1[1]*2+key1[2]*1];
		        key3[2]=key2[key1[1]*4+key1[2]*2+key1[3]*1];
		        key3[3]=key2[key1[2]*4+key1[3]*2+key1[4]*1];
		        key3[4]=key2[key1[3]*4+key1[4]*2+key1[5]*1];
		        key3[5]=key2[key1[4]*4+key1[5]*2+key1[6]*1];
		        key3[6]=key2[key1[5]*4+key1[6]*2+key1[0]*1];
		        for(j=0;j<7;j++)								//将key2的值赋给key1，用作下次变换
			        key1[j]=key3[j];
		        keystr[i]=key3[N];
	        }
	        //将用户输入的明文转换为二进制数
	        for(i=0;i<l;i++)
	        {
		        m=ct[i]-k;							//计算明文距a的偏移量
		        m+=97;								//偏移量加上97即为其ASCII码
		        cts[i*7+0]=m/64;
		        cts[i*7+1]=m%64/32;
		        cts[i*7+2]=m%64%32/16;
		        cts[i*7+3]=m%64%32%16/8;
		        cts[i*7+4]=m%64%32%16%8/4;
		        cts[i*7+5]=m%64%32%16%8%4/2;
		        cts[i*7+6]=m%64%32%16%8%4%2/1;				//cts为密文的二进制表示
	        }
	        //密钥流的产生
	        key2[0]=k/128;									//将用户输入的规则转化为8位二进制数，即对应规则
	        key2[1]=k%128/64;
	        key2[2]=k%128%64/32;
	        key2[3]=k%128%64%32/16;
	        key2[4]=k%128%64%32%16/8;
	        key2[5]=k%128%64%32%16%8/4;
	        key2[6]=k%128%46%32%16%8%4/2;
	        key2[7]=k%128%46%32%16%8%4%2/1;
	        for(i=0;i<7*l;i++)								//循环变换初始数组
	        {
		        key3[0]=key2[key1[6]*4+key1[0]*2+key1[1]*1];
		        key3[1]=key2[key1[0]*4+key1[1]*2+key1[2]*1];
		        key3[2]=key2[key1[1]*4+key1[2]*2+key1[3]*1];
		        key3[3]=key2[key1[2]*4+key1[3]*2+key1[4]*1];
		        key3[4]=key2[key1[3]*4+key1[4]*2+key1[5]*1];
		        key3[5]=key2[key1[4]*4+key1[5]*2+key1[6]*1];
		        key3[6]=key2[key1[5]*4+key1[6]*2+key1[0]*1];
		        for(j=0;j<7;j++)								//将key2的值赋给key1，用作下次变换
			        key1[j]=key3[j];
		        keystr[i]=key3[N];								//keystr存储的是密钥流								
	        }
		        for(i=0;i<7*l;i++)									//异或
		        {
			        if(cts[i]==keystr[i])
				        pts[i]=0;
			        else
				        pts[i]=1;
		        }
		        for(i=0;i<l;i++)
		        {
			        pt[i]=(char)(pts[i*7]*64+pts[i*7+1]*32+pts[i*7+2]*16+pts[i*7+3]*8+pts[i*7+4]*4+pts[i*7+5]*2+pts[i*7+6]*1);
			        pt[i]-=(char)97;
		        }
		        for(i=0;i<l;i++)
		        {
			        e=k+pt[i];
			        pt[i]=(char)e;
		        }
                return pt.ToString();

        }
    }
}
