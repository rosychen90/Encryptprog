using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vigenere
{
    public class Vigenere
    {
        public static string encrypt(string smingwen,string smy)
        {
        	char[] k1={'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            char[] mingwen = smingwen.ToCharArray();
            char[] my = smy.ToCharArray();
            char[] miwen = new char[100];
            char[,] k = new char[26, 26];
            int i=0,j=0;
            int m, n;
            int klength = smy.Length;
	        //初始化维吉利亚方阵
	        for(i=0;i<26;i++)
		        for(j=0;j<26;j++)
		        {
			        if(i==0)
			        k[i,j]=k1[j];
			        else
			        k[i,j]=k[i-1,(j+1)%26];
		        }
        	
	        i=0;
            j = 0;
	        while(i<smingwen.Length)
	        {
		       /* if(mingwen[i]==' ')
		        { 
			        miwen[i]=' ';
			        i++;
		        }*/
                
		        for(m=0;m<26;m++)
		        if(mingwen[i]==k1[m])
		        break;
		        for(n=0;n<26;n++)
		        if(my[j]==k1[n])
		        break;
		        miwen[i]=k[n,m];
		        i++;
                j++;
                j = j % klength;
	        }
            string smiwen = new string(miwen);
            return smiwen;
        }
        //解密
        public static string decrypt(string smiwen,string smy)
        {
            char[,] k = new char[26, 26];
            char[] miwen = smiwen.ToCharArray();
            char[] my = smy.ToCharArray();
	        int i=0,j=0;
	        int miwenlen,t,mylen;
	        char[] mingwen = new char[100];
            char[] k1 = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            t=0;
	        mylen=smy.Length;
	        //初始化维吉利亚方阵
	        for(i=0;i<26;i++)
		        for(j=0;j<26;j++)
		        {
			        if(i==0)
			        k[i,j]=k1[j];
			        else
			        k[i,j]=k[i-1,(j+1)%26];
		        }
		        while(i<smiwen.Length)				//如果密文某位为空格，则其对应明文那位也为空格
		        {
			        if(miwen[i]==' ')
			        { 
				        mingwen[i]=' ';
				        i++;
			        }
		        }
		        miwenlen=smiwen.Length;
		        for(t=0;t<miwenlen;t++)
		        {
			        for(i=0;i<26;i++)
				        for(j=0;j<26;j++)
				        {
					        if(miwen[t]==k[i,j]&&k[0,j]==my[t%mylen])
						        mingwen[t]=k[i,0];
					        if(miwen[t]=='\0')
						        miwen[t]='\0';
				        }
		        }
                string smingwen = new string(mingwen);
                return smingwen;

        }
    }
}
