// CA.h

#pragma once

using namespace System;

namespace CA {

	public ref class CAcipher
	{
#define N 3						//������Կ����key1����λ��Ϊ���λ

char * encrypt(char pt[],int key1[],int k)											//�����㷨��������������ÿ���ֱ�����Կ������������
{
	//int key1[7];					//��ʼ���飬�����ݹ���仯
int key3[7];					//���ݹ���任�������
int key2[8];					//�洢��Ӧ���������
int keystr[140];				//�洢��Կ��
//char pt[20];					//�洢����
int ct[20];					//�洢����
int pts[140];					//�洢����ת��Ϊ�����ƺ��
int cts[140];					//�洢pts������ܺ��
int i,j,l,m,e;
//char k='a';
char *p;
	//��Կ��������
	key2[0]=k/128;									//���û�����Ĺ���ת��Ϊ8λ��������������Ӧ����
	key2[1]=k%128/64;
	key2[2]=k%128%64/32;
	key2[3]=k%128%64%32/16;
	key2[4]=k%128%64%32%16/8;
	key2[5]=k%128%64%32%16%8/4;
	key2[6]=k%128%46%32%16%8%4/2;
	key2[7]=k%128%46%32%16%8%4%2/1;
	//printf("The keystream is:");
	for(i=0;i<7*l;i++)								//ѭ���任��ʼ����
	{
		key3[0]=key2[key1[6]*4+key1[0]*2+key1[1]*1];
		key3[1]=key2[key1[0]*4+key1[1]*2+key1[2]*1];
		key3[2]=key2[key1[1]*4+key1[2]*2+key1[3]*1];
		key3[3]=key2[key1[2]*4+key1[3]*2+key1[4]*1];
		key3[4]=key2[key1[3]*4+key1[4]*2+key1[5]*1];
		key3[5]=key2[key1[4]*4+key1[5]*2+key1[6]*1];
		key3[6]=key2[key1[5]*4+key1[6]*2+key1[0]*1];
		for(j=0;j<7;j++)								//��key2��ֵ����key1�������´α任
			key1[j]=key3[j];
		keystr[i]=key3[N];
	}
	//���û����������ת��Ϊ��������
	for(i=0;i<l;i++)
	{
		m=pt[i]-k;							//�������ľ�a��ƫ����
		m+=97;								//ƫ��������97��Ϊ��ASCII��
		pts[i*7+0]=m/64;
		pts[i*7+1]=m%64/32;
		pts[i*7+2]=m%64%32/16;
		pts[i*7+3]=m%64%32%16/8;
		pts[i*7+4]=m%64%32%16%8/4;
		pts[i*7+5]=m%64%32%16%8%4/2;
		pts[i*7+6]=m%64%32%16%8%4%2/1;				//ptsΪ���ĵĶ����Ʊ�ʾ
	}
	//��Կ���Ĳ���
	key2[0]=k/128;									//���û�����Ĺ���ת��Ϊ8λ��������������Ӧ����
	key2[1]=k%128/64;
	key2[2]=k%128%64/32;
	key2[3]=k%128%64%32/16;
	key2[4]=k%128%64%32%16/8;
	key2[5]=k%128%64%32%16%8/4;
	key2[6]=k%128%46%32%16%8%4/2;
	key2[7]=k%128%46%32%16%8%4%2/1;
	//printf("The keystream is:");
	for(i=0;i<7*l;i++)								//ѭ���任��ʼ����
	{
		key3[0]=key2[key1[6]*4+key1[0]*2+key1[1]*1];
		key3[1]=key2[key1[0]*4+key1[1]*2+key1[2]*1];
		key3[2]=key2[key1[1]*4+key1[2]*2+key1[3]*1];
		key3[3]=key2[key1[2]*4+key1[3]*2+key1[4]*1];
		key3[4]=key2[key1[3]*4+key1[4]*2+key1[5]*1];
		key3[5]=key2[key1[4]*4+key1[5]*2+key1[6]*1];
		key3[6]=key2[key1[5]*4+key1[6]*2+key1[0]*1];
		for(j=0;j<7;j++)								//��key2��ֵ����key1�������´α任
			key1[j]=key3[j];
		keystr[i]=key3[N];								//keystr�洢������Կ��								

	}


	for(i=0;i<7*l;i++)									//���
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
	int key1[7];					//��ʼ���飬�����ݹ���仯
int key3[7];					//���ݹ���任�������
int key2[8];					//�洢��Ӧ���������
int keystr[140];				//�洢��Կ��
char pt[20];					//�洢����
int ct[20];					//�洢����
int pts[140];					//�洢����ת��Ϊ�����ƺ��
int cts[140];					//�洢pts������ܺ��
int i,j,l,m,e;
char k='a';
char *p;
	//��Կ��������
	key2[0]=k/128;									//���û�����Ĺ���ת��Ϊ8λ��������������Ӧ����
	key2[1]=k%128/64;
	key2[2]=k%128%64/32;
	key2[3]=k%128%64%32/16;
	key2[4]=k%128%64%32%16/8;
	key2[5]=k%128%64%32%16%8/4;
	key2[6]=k%128%46%32%16%8%4/2;
	key2[7]=k%128%46%32%16%8%4%2/1;
	//printf("The keystream is:");
	for(i=0;i<7*l;i++)								//ѭ���任��ʼ����
	{
		key3[0]=key2[key1[6]*4+key1[0]*2+key1[1]*1];
		key3[1]=key2[key1[0]*4+key1[1]*2+key1[2]*1];
		key3[2]=key2[key1[1]*4+key1[2]*2+key1[3]*1];
		key3[3]=key2[key1[2]*4+key1[3]*2+key1[4]*1];
		key3[4]=key2[key1[3]*4+key1[4]*2+key1[5]*1];
		key3[5]=key2[key1[4]*4+key1[5]*2+key1[6]*1];
		key3[6]=key2[key1[5]*4+key1[6]*2+key1[0]*1];
		for(j=0;j<7;j++)								//��key2��ֵ����key1�������´α任
			key1[j]=key3[j];
		keystr[i]=key3[N];
	}
	//���û����������ת��Ϊ��������
	for(i=0;i<l;i++)
	{
		m=ct[i]-k;							//�������ľ�a��ƫ����
		m+=97;								//ƫ��������97��Ϊ��ASCII��
		cts[i*7+0]=m/64;
		cts[i*7+1]=m%64/32;
		cts[i*7+2]=m%64%32/16;
		cts[i*7+3]=m%64%32%16/8;
		cts[i*7+4]=m%64%32%16%8/4;
		cts[i*7+5]=m%64%32%16%8%4/2;
		cts[i*7+6]=m%64%32%16%8%4%2/1;				//ctsΪ���ĵĶ����Ʊ�ʾ
	}
	//��Կ���Ĳ���
	key2[0]=k/128;									//���û�����Ĺ���ת��Ϊ8λ��������������Ӧ����
	key2[1]=k%128/64;
	key2[2]=k%128%64/32;
	key2[3]=k%128%64%32/16;
	key2[4]=k%128%64%32%16/8;
	key2[5]=k%128%64%32%16%8/4;
	key2[6]=k%128%46%32%16%8%4/2;
	key2[7]=k%128%46%32%16%8%4%2/1;
	//printf("The keystream is:");
	for(i=0;i<7*l;i++)								//ѭ���任��ʼ����
	{
		key3[0]=key2[key1[6]*4+key1[0]*2+key1[1]*1];
		key3[1]=key2[key1[0]*4+key1[1]*2+key1[2]*1];
		key3[2]=key2[key1[1]*4+key1[2]*2+key1[3]*1];
		key3[3]=key2[key1[2]*4+key1[3]*2+key1[4]*1];
		key3[4]=key2[key1[3]*4+key1[4]*2+key1[5]*1];
		key3[5]=key2[key1[4]*4+key1[5]*2+key1[6]*1];
		key3[6]=key2[key1[5]*4+key1[6]*2+key1[0]*1];
		for(j=0;j<7;j++)								//��key2��ֵ����key1�������´α任
			key1[j]=key3[j];
		keystr[i]=key3[N];								//keystr�洢������Կ��								
	}
		for(i=0;i<7*l;i++)									//���
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
