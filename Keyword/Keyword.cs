using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keyword
{
                
    public class Keywordcipher
    {
        public static string encrypt(string spt,string skey)
        {
	        char k='a';
	        int n,i,j,t,l;
            int m=1;
	        l=spt.Trim().Length;
            n=skey.Trim().Length;
            char[] pt = spt.ToCharArray();
            char[] key = skey.ToCharArray();
            char[] zm={'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            char[] ct = new char[100];
	        //去除重复字母算法
	        /*for(i=0;i<n;i++)						//发现重复字母，后面字母全部往前覆盖一个
	        {
		        for(j=0;j<n;j++)
		        {
			        while(key[j]==key[j+i+1]&&key[j]!='\0')
			        {
				        for(t=1;t<n-j-1;t++)
					        key[j+i+t]=key[j+i+t+1];	
				        key[n-m]='\0';
				        m++;
			        }	
		        }
	        }
	        for(i=0;i<n;i++)				//将除去重复字母的密钥放入对应数组key2中
	        {
		        if(key[i]!='\0')
			        key2[i]=key[i];
	        }*/
            m = 1;
	        for(i=0;i<n;i++)				//将26个字母中除去密钥外的字母放入对应数组key2中
	        {
		        for(j=0;j<26;j++)
		        {
			        if(key[i]!='\0'&&zm[j]==key[i])
			        {
				        for(t=0;t<26-j-1;t++)
					        zm[j+t]=zm[j+t+1];
				        zm[26-m]='\0';
				        m++;
			        }
		        }
	        }
            string zm1 = new string(zm);
            string result = skey + zm1;
            char[] key2 = result.ToCharArray();
	        for(i=0;i<pt.Length;i++)						//加密
	        {
		        ct[i]=key2[pt[i]-k];				//ct存储的为密文
	        }
	        string sct = new string(ct);
	        return sct;
        }
        //解密算法
        public static string decrypt(string sct,string skey)
        {
	        char k='a';
	        int i,j,l,n,t;
            int m = 1;
            char[] pt = new char[100];
            char[] ct = sct.ToCharArray();
            char[] key = skey.ToCharArray();
            char[] zm = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            /*for(i=0;i<50;i++)						//将存储密文的数组初始化为0
	        {
		        ct[i]='0';
	        }*/
	        l=sct.Trim().Length;
	        n=skey.Trim().Length;
	        //去除重复字母
	        /*for(i=0;i<n;i++)						//发现重复字母，后面字母全部往前覆盖一个
	        {
		        for(j=0;j<n;j++)
		        {
			        while(key[j]==key[j+i+1]&&key[j]!='\0')
			        {
				        for(t=1;t<n-j-1;t++)
					        key[j+i+t]=key[j+i+t+1];	
				        key[n-m]='\0';
				        m++;
			        }
        				
		        }
	        }
	        for(i=0;i<n;i++)				//将除去重复字母的密钥放入对应数组key2中
	        {
		        if(key[i]!='\0')
			        key2[i]=key[i];
	        }*/
            m = 1;
            for(i=0;i<n;i++)				//将26个字母中除去密钥外的字母放入对应数组key2中
	        {
		        for(j=0;j<26;j++)
		        {
			        if(key[i]!='\0'&&zm[j]==key[i])
			        {
				        for(t=0;t<26-j-1;t++)
					        zm[j+t]=zm[j+t+1];
				        zm[26-m]='\0';
				        m++;
			        }
		        }
	        }
            string zm1 = new string(zm);
            string result = skey + zm1;
            char[] key2 = result.ToCharArray();
	        for(i=0;i<sct.Length;i++)				//解密算法
	        {
		        for(j=0;j<ct.Length;j++)
		        {
			        if(ct[i]==key2[j]&&ct[i]!='0')
				        pt[i]=(char)(k+j);					//pt为存储明文数组
		        }
	        }
	        string spt = new string(pt);
            return spt ;
        }
    }
}
