using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Column
{
    public class Column
    {
        public static string encrypt(string sp,string sk)
        {
	        int kl,pl,i,j;
	        int[] kn = new int[10];
	        kl=sk.Length;
	        pl=sp.Length;
            char[] temp = sp.ToCharArray();
            char[] p = new char[pl + kl-1];
            temp.CopyTo(p, 0);
            char[] k = sk.ToCharArray();
            char[] c = new char[pl+kl-1];
	        for(i=0;i<kl;i++)
	        {
		        kn[i]=1;		
		        for(j=0;j<kl;j++)
		        {	
			        if(k[j]<k[i])
			        kn[i]++;	
		        }	
		        for(j=0;j<i;j++)
		        {	
			        if(k[j] == k[i])
			        kn[i]=kn[i]+1;
		        }	
	        }
	        while(pl%kl!=0)
	        {
		        pl=pl+1;
		        p[pl-1]='q';
	        }
		        for(j=0;j<kl;j++)
		        {
			        for(i=0;i<(pl/kl);i++)
			        {
				        c[i+j*(pl/kl)]=p[kn[j]+kl*i-1];
			        }
		        }
            string sc = new string(c);
	        return sc;
        }

        public static string decrypt(string sc,string sk)
        {
	        int i,j;
	        int q=1;
            int[] knt = new int[10];
            int[] kn = new int[10];
            char[] k = sk.ToCharArray();
            char[] c = sc.ToCharArray();
	        int cl=sc.Length;
            int kl = sk.Length;
            char[] p = new char[cl+kl-1];
	        for(i=0;i<kl;i++)
	        {
		        knt[i]=1;		
		        for(j=0;j<kl;j++)
		        {	
			        if(k[j]<k[i])
			        knt[i]++;	
		        }	
		        for(j=0;j<i;j++)
		        {	
			        if(k[j] == k[i])
			        knt[i]=knt[i]+1;
		        }	
	        }
	        for(j=0;j<(cl/kl);j++)
		        {
			        for(i=0;i<kl;i++)
			        {
				        p[knt[i]-1+kl*j]=c[i*(cl/kl)+j];
			        }
		        }
            string sp = new string(p);
            return sp;
        }
    }
}
