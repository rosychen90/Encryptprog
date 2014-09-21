using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.ComponentModel;
namespace playfair
{
    public class Program
    {
        public static string encryption(string splaintext,string skey)
        {

            char[] tempplaintext = splaintext.ToCharArray();
            char[] plaintext = new char[splaintext.Length + 1];
            tempplaintext.CopyTo(plaintext, 0);
            char a='i';
	        int n2,n3;
	        int i,j,q;
            int[] m1= new int[100];
            int[] m2 = new int[100];//,m3,m4;
	        char[] s= new char[2];
	        char[] alpha={'a','b','c','d','e','f','g','h','i','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','\0'};
	        int n1,n4;
            string saph = new string(alpha);
            string result = skey + saph;
            char[] key = result.ToCharArray();
            n4 = skey.Length;
            n1 = n4;
            char[,] label = new char[5, 5];
            char[] ciphertext = new char[100];
	        /*for(i=0;i<n1;i++)						//去掉关键字中所含的字符j,重复字符
	        {
		        if(key[i]=='j')
		        {
			        for(q=0;q<n1-i-1;q++)
			        {
				        key[i+q]=key[i+q+1];
        			
			        }
        			
			        key[n1-1]='\0';
			        n1=n1-1;
        			
		        }
	        }*/
	        for(i=0;i<n1;i++)
	        {
        		
			        for(j=1;j<n1-i;j++)
			        {
				        if(key[i]==key[i+j])
				        {
					        for(q=0;q<n1-i-j-1;q++)
					        {
						        key[i+j+q]=key[i+j+q+1];
        				
					        }
					        key[n1-1]='\0';
					        n1=n1-1;
				        }
			        }
        		
	        }
	        for(i=0;i<5;i++)
	        {
		        for(j=0;j<5;j++)
		        {
        			
			        label[i,j]=key[i*5+j];
        			
		        }
        	
	        }

	        n2=splaintext.Length;

	        for(i=0;i<n2;i++)						//将明文中所含的字符j变为i,重复字符中插入q或x，判断明文字符数
	        {
		        if(plaintext[i]=='j')
		        {
			        plaintext[i]=a;

		        }
	        }
	        for(i=0;i<n2-1;i++)												//在相同字符之间插入等效字符
	        {
		        if((plaintext[i]==plaintext[i+1])&&(plaintext[i+1]!='\0'))
			        {
				        for(q=0;q<n2-i-1;q++)
				        {
					        plaintext[n2-q]=plaintext[n2-q-1];
        					
				        }
				        plaintext[i+1]='q';
				        n2=n2+1;
			        }
	        }
	        if(n2%2!=0)
	        {
		        plaintext[n2]='q';
	        }

            n3 = n2;
	        for(q=0;q<n3;q++)						//明文查表加密过程
	        {
		        for(i=0;i<5;i++)
		        {
			        for(j=0;j<5;j++)
			        {
        			
				        if(plaintext[q]==label[i,j])
				        {
					        m1[q]=i;
					        m2[q]=j;
        				
				        }
        			
			        }
        		
		        }
	        }

	        for(i=0;i<n3-1;i++)
	        {
		        if(m1[i]==m1[i+1])
		        {
			        if(m2[i]+1<5)
			        {
				        ciphertext[i]=label[m1[i],m2[i]+1];
			        }else
			        {
				        ciphertext[i]=label[m1[i],0];
			        }
			        if(m2[i+1]+1<5)
			        {
				        ciphertext[i+1]=label[m1[i+1],m2[i+1]+1];
			        }else
			        {
				        ciphertext[i+1]=label[m1[i+1],m2[0]];
			        }

		        }else if(m2[i]==m2[i+1])
		        {
			        if(m1[i]+1<5)
			        {
				        ciphertext[i]=label[m1[i]+1,m2[i]];
			        }else
			        {
				        ciphertext[i]=label[0,m2[i]];
			        }
			        if(m1[i+1]+1<5)
			        {
				        ciphertext[i+1]=label[m1[i+1]+1,m2[i+1]];
			        }else
			        {
				        ciphertext[i+1]=label[0,m2[i+1]];
			        }
        	
		        }else
		        {
			        ciphertext[i]=label[m1[i],m2[i+1]];
			        ciphertext[i+1]=label[m1[i+1],m2[i]];
        	
        		
		        }
		        i++;
	        }
	        string pp=new string(ciphertext);
	        return pp;
        }

        public static string Decrypt(string sciphertext,string skey)
        {
	        char[] plaintext=new char[100];
            char[,] label = new char[5,5];
	        char[] ciphertext = sciphertext.ToCharArray();
	        char[] s=new char[2];
	        int n2;
	        int i,j,q;
            int[] m1= new int[100];
            int[] m2= new int[100];
		    char[] alpha={'a','b','c','d','e','f','g','h','i','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','\0'};
	        int n1,n4;
        	
	        n4 = skey.Length;
            string sah = new string(alpha);
            string result = skey+ sah;
            char[] key = result.ToCharArray();
            n1 = n4;
	        for(i=0;i<n1;i++)						//去掉关键字中所含的字符j,重复字符
	        {
		        if(key[i]=='j')
		        {
			        for(q=0;q<n1-i-1;q++)
			        {
				        key[i+q]=key[i+q+1];
        			
			        }
        			
			        key[n1-1]='\0';
			        n1=n1-1;
        			
		        }
	        }
	        for(i=0;i<n1;i++)
	        {
        		
			        for(j=1;j<n1-i;j++)
			        {
				        if(key[i]==key[i+j])
				        {
					        for(q=0;q<n1-i-j-1;q++)
					        {
						        key[i+j+q]=key[i+j+q+1];
        				
					        }
					        key[n1-1]='\0';
					        n1=n1-1;
				        }
			        }
        		
	        }
        	
	        for(i=0;i<5;i++)
	        {
		        for(j=0;j<5;j++)
		        {
        			
			        label[i,j]=key[i*5+j];
		        }
	        }

            n2 = sciphertext.Length;
;
	        for(q=0;q<n2;q++)						//密文查表加密过程
	        {
		        for(i=0;i<5;i++)
		        {
			        for(j=0;j<5;j++)
			        {
        			
				        if(ciphertext[q]==label[i,j])
				        {
					        m1[q]=i;
					        m2[q]=j;
				        }
        			
			        }
		        }
	        }
	        for(i=0;i<n2-1;i++)
	        {
		        if(m1[i]==m1[i+1])
		        {
			        if(m2[i]-1>=0)
			        {
				        plaintext[i]=label[m1[i],m2[i]-1];
			        }else
			        {
				        plaintext[i]=label[m1[i],4];
			        }
			        if(m2[i+1]-1>=0)
			        {
				        plaintext[i+1]=label[m1[i+1],m2[i+1]-1];
			        }else
			        {
				        plaintext[i+1]=label[m1[i+1],4];
			        }
		        }else if(m2[i]==m2[i+1])
		        {
			        if(m1[i]-1>=0)
			        {
				        plaintext[i]=label[m1[i]-1,m2[i]];
			        }else
			        {
				        plaintext[i]=label[4,m2[i]];
			        }
			        if(m1[i+1]-1>=0)
			        {
				        plaintext[i+1]=label[m1[i+1]-1,m2[i+1]];
			        }else
			        {
				        plaintext[i+1]=label[4,m2[i+1]];
			        }
		        }else
		        {
			        plaintext[i]=label[m1[i],m2[i+1]];
			        plaintext[i+1]=label[m1[i+1],m2[i]];
        		
		        }
		        i++;
	        }
            string sp = new string(plaintext);
	        return sp;

        }
    }
}
