#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main(void)
{
	int event;
	int hp=100;
	int power=10;
	int speed=10;
	int defence=10;
	int smart=10;
	int luk;
	int damage;
	int loop=0;
	int cho;
	float time;
	
	int love1=0;
	int love2=0;
	int love3=0;
	
	//�^�C�g��
	printf("\n\n\n\n\n\n\n\n\n\n\n\n\n                                                    �͂�����-��\n\n\n\n\n\n\n\n                                                   �N���b�N�X�^-�g\n\n\n");
	getchar();
	
	
	//�͂��߂�
	printf("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
	
	printf("����ɂ��́I�l�͂�����I���̃Q-���̍�҂���I��");
	getchar();
	
	printf("���O�ɓ`���Ă����Ȃ��Ⴂ���Ȃ��������������� ���̏���؂�Č��킹�Ă��炤��I��");
	getchar();
	
	printf("���̃Q-���⃓-�X�R-�h�͊��S�ȃt��-����I���쌠��������Ă����I��");
	getchar();
	
	printf("�����玩�씭���⃓-�X���ς����R����I���R�Ɏg���ĂˁI��");
	getchar();
	
	
	//���ӏ���
	printf("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
	printf("\n\n");
	printf("���J�����̎d�l�ׁ̈A�g�p�ł��Ȃ���������������܂��B���ׁ̈A���傭���傭���������Ƃ��낪����܂��B\n");
	printf("�@���Ɍ��Â炢�Ǝv���܂����A��L��_�̔c�������肢�v���܂��B�]���⊮������A�]���⊮���B");
	getchar();
	
	
	//�v�����[�O
	printf("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
	
	printf("�͂�����\n");
	printf("�l�A�͂�����I�ޏ��~�����I��");
	getchar();
	
	printf("�������獂�Z��N���₵�A�撣���Ă߂񂱂����ƕt�������˂�I��");
	getchar();
	
	printf("\n�����̃Q-���̃W�������͈琬�����ł��B�Ƃ�����4�Ƌ߂��W�������ł��B");
	getchar();
	
	printf("�@�͂�����̃X�e-�^�X��������ƁA����ɑΉ��������̎q�̍D���x���オ���Ă����܂��B");
	getchar();
	
	printf("�@�Ȃ̂ŁA�C�ɓ��������̎q���ǂ̃X�e-�^�X���D�������ɂ߂ăX�e-�^�X�グ������Ƃ����Ǝv���܂��B");
	getchar();
	
	
	//��������琬�ɂȂ�B���[�v�����܂���B
	for(loop=0;loop<100;loop++){
		printf("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
		printf("%d����\n\n",loop +1);
		
		srand((unsigned int) time(NULL));
		luk = rand() %100 + 1;1
		
		printf("�X�e-�^�X\n�̗�%d\n�́@%d\n��@%d\n���@%d\n���@%d\n",hp,power,defence,speed,smart);
		
		if(luk>80){
			printf("�^�@��g")
		}
		else if(luk>50){
			printf("�^�@���g")
		}
		else if(luk>30){
			printf("�^�@���g")
		}
		else if (luk>10){
			printf("�^�@��")
		}
		else{
			printf("�^�@�勥");
		}
		
		printf("\n\n");
		printf("�͂�����\n�����͉������悤���ȁH��\n\n1.�؃g��\n2.�����j���O\n3.�׋�\n4.�x�e\n\n->");
		scanf("%d",&cho);
		
	}
	
	//�G���f�B���O
	return 0;
}