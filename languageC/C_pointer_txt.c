// ������
 
// * = �����͸� ��Ÿ���� ���� ( �ƽ��׸���ũ, asterisk)
// ** = 2���� ������
// *** = 3���� ������

/* �����Ϳ� ������ ����*/

/* �������� Ÿ�԰� ����
	- ������ ����� ���Ǵ� ������ : *
	- A�� ������(A*) : A�� ������ �ּҰ��� ����
		int main(void) {
			int*a;			// a��� �̸��� int�� ������
		}
*/

/* �ּ� ���� ������
- &������ : ������ �ּҰ� ��ȯ
- *������ : �����Ͱ� ����Ű�� �޸� ����
	int a = 2005;		// a = 2005
	int *pA = &a; 		// pA = a������ �ּҰ� 
	printf("%d", a);	// 2005(��������)
	printf("%d", *pA);	// 2005(��������)
*/

/* �����Ϳ� �پ��� Ÿ���� �����ϴ� ����
	- ������ Ÿ���� ������ �޸��� ũ�������� �����Ѵ�. */ 
	
/* int main(void) {
   		// 100�� ������� �� �� ����. 
		//���� system area�� ��� �ý��ۿ� ġ������ ������ �߻��� �� �ִ�.
		int* pA = 100;
		*pA = 10;
		return 0;		 
   }
*/

// DMA(Direct Memory Access) : ���κ����� ���Կ��� �����͸� �ְ� �޴� ��� (Linux - divice driver ���� ����) 
	
	
	
	