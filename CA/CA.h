// CA.h

#pragma once

using namespace System;

namespace CA {

	public ref class CAcipher
	{
#define N 3						//定义密钥数组key1中哪位作为输出位

char * encrypt(char pt[],int key1[],int k)											//加密算法，将明文数组中每个分别与密钥流数组进行异或
{
	//int key1[7];					//初始数组，并根据规则变化
int key3[7];					//根据规则变换后的数组
int key2[8];					//存储对应规则的数组
int keystr[140];				//存储密钥流
//char pt[20];					//存储明文
int ct[20];					//存储密文
int pts[140];					//存储明文转化为二进制后的
int cts[140];					//存储pts数组加密后的
int i,j,l,m,e;
//char k='a';
char *p;
	//密钥流的生成
	key2[0]=k/128;									//将用户输入的规则转化为8位二进制数，即对应规则
	key2[1]=k%128/64;
	key2[2]=k%128%64/32;
	key2[3]=k%128%64%32/16;
	key2[4]=k%128%64%32%16/8;
	key2[5]=k%128%64%32%16%8/4;
	key2[6]=k%128%46%32%16%8%4/2;
	key2[7]=k%128%46%32%16%8%4%2/1;
	//printf("The keystream is:");
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
	//printf("The keystream is:");
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
		//printf("%c",e);
	}
	p=ct;
	return p;
}

char * decrypt(char ct[],int key1[],int k)
{
	int key1[7];					//初始数组，并根据规则变化
int key3[7];					//根据规则变换后的数组
int key2[8];					//存储对应规则的数组
int keystr[140];				//存储密钥流
char pt[20];					//存储明文
int ct[20];					//存储密文
int pts[140];					//存储明文转化为二进制后的
int cts[140];					//存储pts数组加密后的
int i,j,l,m,e;
char k='a';
char *p;
	//密钥流的生成
	key2[0]=k/128;									//将用户输入的规则转化为8位二进制数，即对应规则
	key2[1]=k%128/64;
	key2[2]=k%128%64/32;
	key2[3]=k%128%64%32/16;
	key2[4]=k%128%64%32%16/8;
	key2[5]=k%128%64%32%16%8/4;
	key2[6]=k%128%46%32%16%8%4/2;
	key2[7]=k%128%46%32%16%8%4%2/1;
	//printf("The keystream is:");
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
	//printf("The keystream is:");
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
			pt[i]=pts[i*7]*64+pts[i*7+1]*32+pts[i*7+2]*16+pts[i*7+3]*8+pts[i*7+4]*4+pts[i*7+5]*2+pts[i*7+6]*1;
			pt[i]-=97;
		}
		for(i=0;i<l;i++)
		{
			e=k+pt[i];
			pt[i]=e;
			//printf("%c",e);
		}
		p=pt;
		return p;

}
/*void main()
{
	printf("Please enter the plaintext:");
	gets(pt);
	l=strlen(pt);
	change(pt);
	keystream();
	encrypt();
}*/
	};
}
